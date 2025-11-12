using Microsoft.Data.SqlClient;
using SistemaControlPersonal.Core.Clases;
using SistemaControlPersonal.Core.Lib;
using System.Data;

namespace SistemaControlPersonal.Core.Dao
{
    internal class EmpleadosDao : Cnn
    {
        SqlConnection Con = null;
        SqlCommand command = null;

        public List<Empleados> GetAll(string filtro = "")
        {
            var list = new List<Empleados>();
            SqlDataReader rd = null;

            try
            {
                Con = OpenDb();

                var where = string.Empty;
                if (!string.IsNullOrWhiteSpace(filtro))
                {
                    where = @"WHERE
                        CAST(E.codigo_empleado AS NVARCHAR(50)) LIKE @f
                        OR E.nombre_empleado LIKE @f
                        OR E.dui LIKE @f
                        OR C.nombre_cargo LIKE @f";
                }

                string sql = $@"
                    SELECT
                        E.id_empleado,
                        E.codigo_empleado,
                        E.nombre_empleado,
                        E.dui,
                        E.sexo,
                        E.fecha_nacimiento,
                        E.direccion,
                        E.telefono,
                        E.salario_base,
                        E.fecha_ingreso,
                        E.estado_laboral,
                        C.nombre_cargo
                    FROM Empleado E
                    LEFT JOIN Cargo C ON E.id_cargo = C.id_cargo
                    {where}
                    ORDER BY E.nombre_empleado;";

                command = new SqlCommand(sql, Con);

                if (!string.IsNullOrWhiteSpace(filtro))
                {
                    command.Parameters.Add("@f", SqlDbType.NVarChar, 200).Value = $"%{filtro.Trim()}%";
                }

                rd = command.ExecuteReader();

                while (rd.Read())
                {
                    list.Add(Map(rd));
                }
            }
            finally
            {
                rd?.Close();
                command?.Dispose();
                CloseDB();
            }

            return list;
        }

        // Devuelve id, nombre y salario_base del cargo para usar en el formulario
        public List<(int Id, string Nombre, double Salario)> GetAllCargos()
        {
            var list = new List<(int, string, double)>();
            SqlDataReader rd = null;
            SqlCommand cmd = null;
            try
            {
                Con = OpenDb();
                cmd = new SqlCommand("SELECT id_cargo, nombre_cargo, salario_base FROM Cargo ORDER BY nombre_cargo", Con);
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    int id = rd.IsDBNull(0) ? 0 : Convert.ToInt32(rd.GetValue(0));
                    string nombre = rd.IsDBNull(1) ? string.Empty : rd.GetValue(1).ToString();
                    double salario = 0;
                    if (!rd.IsDBNull(2))
                    {
                        var val = rd.GetValue(2);
                        if (val is decimal dec) salario = Convert.ToDouble(dec);
                        else if (double.TryParse(val.ToString(), out var d)) salario = d;
                    }

                    list.Add((id, nombre, salario));
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

        public int Insert(Empleados empleado, int idCargo)
        {
            try
            {
                Con = OpenDb();
                command = new SqlCommand(@"
                    INSERT INTO Empleado (codigo_empleado, nombre_empleado, dui, sexo, fecha_nacimiento, direccion, telefono, salario_base, fecha_ingreso, estado_laboral, id_cargo)
                    OUTPUT INSERTED.id_empleado
                    VALUES (@codigo, @nombre, @dui, @sexo, @fecha_nac, @direccion, @telefono, @salario, @fecha_ing, @estado, @id_cargo);", Con);

                command.Parameters.Add("@codigo", SqlDbType.Int).Value = empleado.CodigoEmpleado;
                command.Parameters.Add("@nombre", SqlDbType.NVarChar, 150).Value = (object?)empleado.NombreEmpleado ?? DBNull.Value;
                command.Parameters.Add("@dui", SqlDbType.NVarChar, 10).Value = (object?)empleado.DUI ?? DBNull.Value;
                command.Parameters.Add("@sexo", SqlDbType.Char, 1).Value = (object?)empleado.Sexo ?? DBNull.Value;
                command.Parameters.Add("@fecha_nac", SqlDbType.NVarChar, 11).Value = (object?)empleado.FechaNacimiento ?? DBNull.Value;
                command.Parameters.Add("@direccion", SqlDbType.NVarChar, 150).Value = (object?)empleado.Direccion ?? DBNull.Value;
                command.Parameters.Add("@telefono", SqlDbType.NVarChar, 15).Value = (object?)empleado.Telefono ?? DBNull.Value;
                command.Parameters.Add("@salario", SqlDbType.Decimal).Value = empleado.SalarioBase;
                command.Parameters.Add("@fecha_ing", SqlDbType.NVarChar, 11).Value = (object?)empleado.FechaIngreso ?? DBNull.Value;
                command.Parameters.Add("@estado", SqlDbType.NVarChar, 20).Value = (object?)empleado.EstadoLaboral ?? DBNull.Value;
                command.Parameters.Add("@id_cargo", SqlDbType.Int).Value = idCargo;

                var id = (int)command.ExecuteScalar();
                return id;
            }
            finally
            {
                command?.Dispose();
                CloseDB();
            }
        }

        // Nuevo: actualizar empleado existente
        public bool Update(Empleados empleado, int idCargo)
        {
            try
            {
                Con = OpenDb();
                command = new SqlCommand(@"
                    UPDATE Empleado
                    SET codigo_empleado = @codigo,
                        nombre_empleado = @nombre,
                        dui = @dui,
                        sexo = @sexo,
                        fecha_nacimiento = @fecha_nac,
                        direccion = @direccion,
                        telefono = @telefono,
                        salario_base = @salario,
                        fecha_ingreso = @fecha_ing,
                        estado_laboral = @estado,
                        id_cargo = @id_cargo
                    WHERE id_empleado = @id;", Con);

                command.Parameters.Add("@codigo", SqlDbType.Int).Value = empleado.CodigoEmpleado;
                command.Parameters.Add("@nombre", SqlDbType.NVarChar, 150).Value = (object?)empleado.NombreEmpleado ?? DBNull.Value;
                command.Parameters.Add("@dui", SqlDbType.NVarChar, 10).Value = (object?)empleado.DUI ?? DBNull.Value;
                command.Parameters.Add("@sexo", SqlDbType.Char, 1).Value = (object?)empleado.Sexo ?? DBNull.Value;
                command.Parameters.Add("@fecha_nac", SqlDbType.NVarChar, 11).Value = (object?)empleado.FechaNacimiento ?? DBNull.Value;
                command.Parameters.Add("@direccion", SqlDbType.NVarChar, 150).Value = (object?)empleado.Direccion ?? DBNull.Value;
                command.Parameters.Add("@telefono", SqlDbType.NVarChar, 15).Value = (object?)empleado.Telefono ?? DBNull.Value;
                command.Parameters.Add("@salario", SqlDbType.Decimal).Value = empleado.SalarioBase;
                command.Parameters.Add("@fecha_ing", SqlDbType.NVarChar, 11).Value = (object?)empleado.FechaIngreso ?? DBNull.Value;
                command.Parameters.Add("@estado", SqlDbType.NVarChar, 20).Value = (object?)empleado.EstadoLaboral ?? DBNull.Value;
                command.Parameters.Add("@id_cargo", SqlDbType.Int).Value = idCargo;
                command.Parameters.Add("@id", SqlDbType.Int).Value = empleado.IdEmpleado;

                int rows = command.ExecuteNonQuery();
                return rows > 0;
            }
            finally
            {
                command?.Dispose();
                CloseDB();
            }
        }

        private static Empleados Map(SqlDataReader rd)
        {
            var e = new Empleados();

            e.IdEmpleado = rd.IsDBNull(0) ? 0 : Convert.ToInt32(rd.GetValue(0));
            e.CodigoEmpleado = rd.IsDBNull(1) ? 0 : Convert.ToInt32(rd.GetValue(1));
            e.NombreEmpleado = rd.IsDBNull(2) ? string.Empty : rd.GetValue(2).ToString();
            e.DUI = rd.IsDBNull(3) ? string.Empty : rd.GetValue(3).ToString();
            e.Sexo = rd.IsDBNull(4) ? string.Empty : rd.GetValue(4).ToString();
            e.FechaNacimiento = rd.IsDBNull(5) ? string.Empty : rd.GetValue(5).ToString();
            e.Direccion = rd.IsDBNull(6) ? string.Empty : rd.GetValue(6).ToString();
            e.Telefono = rd.IsDBNull(7) ? string.Empty : rd.GetValue(7).ToString();

            if (rd.IsDBNull(8))
                e.SalarioBase = 0;
            else
            {
                var val = rd.GetValue(8);
                if (val is decimal dec) e.SalarioBase = Convert.ToDouble(dec);
                else if (double.TryParse(val.ToString(), out var d)) e.SalarioBase = d;
                else e.SalarioBase = 0;
            }

            e.FechaIngreso = rd.IsDBNull(9) ? string.Empty : rd.GetValue(9).ToString();
            e.EstadoLaboral = rd.IsDBNull(10) ? string.Empty : rd.GetValue(10).ToString();
            e.Cargo = rd.IsDBNull(11) ? string.Empty : rd.GetValue(11).ToString();

            return e;
        }
    }
}
