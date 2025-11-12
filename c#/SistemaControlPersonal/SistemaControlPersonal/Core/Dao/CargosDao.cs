using Microsoft.Data.SqlClient;
using SistemaControlPersonal.Core.Clases;
using SistemaControlPersonal.Core.Lib;
using System.Data;

namespace SistemaControlPersonal.Core.Dao
{
    internal class CargosDao : Cnn
    {
        protected SqlConnection Con;

        public List<Cargos> GetAll(string filtro = "")
        {
            var list = new List<Cargos>();
            SqlDataReader rd = null;
            SqlCommand cmd = null;
            try
            {
                Con = OpenDb();

                var where = string.Empty;
                if (!string.IsNullOrWhiteSpace(filtro))
                {
                    where = "WHERE nombre_cargo LIKE @f";
                }

                string sql = $@"
                    SELECT id_cargo, nombre_cargo, descripcion, salario_base, tipo_pago
                    FROM Cargo
                    {where}
                    ORDER BY nombre_cargo;";

                cmd = new SqlCommand(sql, Con);

                if (!string.IsNullOrWhiteSpace(filtro))
                {
                    cmd.Parameters.Add("@f", SqlDbType.NVarChar, 200).Value = $"%{filtro.Trim()}%";
                }

                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    list.Add(Map(rd));
                }
            }
            finally
            {
                rd?.Close();
                cmd?.Dispose();
                CloseDB();
            }

            return list;
        }

        private static Cargos Map(SqlDataReader rd)
        {
            var c = new Cargos();
            c.IdCargo = rd.IsDBNull(0) ? 0 : Convert.ToInt32(rd.GetValue(0));
            c.NombreCargo = rd.IsDBNull(1) ? string.Empty : rd.GetValue(1).ToString();
            c.Descripcion = rd.IsDBNull(2) ? string.Empty : rd.GetValue(2).ToString();

            if (rd.IsDBNull(3))
                c.SalarioBase = 0;
            else
            {
                var val = rd.GetValue(3);
                if (val is decimal dec) c.SalarioBase = Convert.ToDouble(dec);
                else if (double.TryParse(val.ToString(), out var d)) c.SalarioBase = d;
                else c.SalarioBase = 0;
            }

            c.TipoPago = rd.IsDBNull(4) ? string.Empty : rd.GetValue(4).ToString();
            return c;
        }

        // Insertar un cargo y devolver el id generado
        public int Insert(Cargos cargo)
        {
            SqlCommand cmd = null;
            try
            {
                Con = OpenDb();
                cmd = new SqlCommand(@"
                    INSERT INTO Cargo (nombre_cargo, descripcion, salario_base, tipo_pago)
                    OUTPUT INSERTED.id_cargo
                    VALUES (@nombre, @descripcion, @salario, @tipo);", Con);

                cmd.Parameters.Add("@nombre", SqlDbType.NVarChar, 150).Value = (object?)cargo.NombreCargo ?? DBNull.Value;
                cmd.Parameters.Add("@descripcion", SqlDbType.NVarChar, 500).Value = (object?)cargo.Descripcion ?? DBNull.Value;
                cmd.Parameters.Add("@salario", SqlDbType.Decimal).Value = Convert.ToDecimal(cargo.SalarioBase);
                cmd.Parameters.Add("@tipo", SqlDbType.NVarChar, 50).Value = (object?)cargo.TipoPago ?? DBNull.Value;

                var idObj = cmd.ExecuteScalar();
                return idObj != null ? Convert.ToInt32(idObj) : 0;
            }
            finally
            {
                cmd?.Dispose();
                CloseDB();
            }
        }

        // Actualizar un cargo
        public bool Update(Cargos cargo)
        {
            SqlCommand cmd = null;
            try
            {
                Con = OpenDb();
                cmd = new SqlCommand(@"
                    UPDATE Cargo
                    SET nombre_cargo = @nombre,
                        descripcion = @descripcion,
                        salario_base = @salario,
                        tipo_pago = @tipo
                    WHERE id_cargo = @id;", Con);

                cmd.Parameters.Add("@nombre", SqlDbType.NVarChar, 150).Value = (object?)cargo.NombreCargo ?? DBNull.Value;
                cmd.Parameters.Add("@descripcion", SqlDbType.NVarChar, 500).Value = (object?)cargo.Descripcion ?? DBNull.Value;
                cmd.Parameters.Add("@salario", SqlDbType.Decimal).Value = Convert.ToDecimal(cargo.SalarioBase);
                cmd.Parameters.Add("@tipo", SqlDbType.NVarChar, 50).Value = (object?)cargo.TipoPago ?? DBNull.Value;
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = cargo.IdCargo;

                var rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
            finally
            {
                cmd?.Dispose();
                CloseDB();
            }
        }

        // Eliminar cargo por id
        public bool Delete(int idCargo)
        {
            SqlCommand cmd = null;
            try
            {
                Con = OpenDb();
                cmd = new SqlCommand("DELETE FROM Cargo WHERE id_cargo = @id", Con);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = idCargo;
                var rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
            catch (SqlException ex)
            {
                // Código 547 = Violación de restricción de clave foránea en SQL Server
                if (ex.Number == 547)
                {
                    throw new InvalidOperationException("No se puede eliminar este cargo porque está siendo usado en otra tabla (por ejemplo: empleados).", ex);
                }
                throw;
            }
            finally
            {
                cmd?.Dispose();
                CloseDB();
            }
        }
    }
}
