using Microsoft.Data.SqlClient;
using SistemaControlPersonal.Core.Clases;
using SistemaControlPersonal.Core.Lib;
using System;
using System.Collections.Generic;
using System.Data;

namespace SistemaControlPersonal.Core.Dao
{
    internal class AsistenciasDao : Cnn, IAsistencias
    {
        SqlConnection Con = null;
        SqlCommand command = null;

        public List<Asistencias> GetAll(string filtro = "", DateTime? fechaFiltro = null)
        {
            var list = new List<Asistencias>();
            SqlDataReader rd = null;

            try
            {
                Con = OpenDb();

                var fechaJoin = fechaFiltro.HasValue ? "AND A.Fecha = @fecha" : string.Empty;

                string sql = $@"
                    SELECT
                        E.ID_Empleado,
                        E.codigo_empleado,
                        E.nombre_empleado,
                        C.nombre_cargo,
                        A.estado_asistencia,
                        A.nota,
                        A.fecha
                    FROM Empleado E
                    LEFT JOIN Cargo C ON E.ID_Cargo = C.ID_Cargo
                    LEFT JOIN Asistencias A ON E.ID_Empleado = A.ID_Empleado
                        {fechaJoin}
                    ORDER BY
                        E.nombre_empleado DESC;";

                command = new SqlCommand(sql, Con);

                if (fechaFiltro.HasValue)
                {
                    command.Parameters.Add("@fecha", SqlDbType.Date).Value = fechaFiltro.Value.Date;
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

        private static Asistencias Map(SqlDataReader rd)
        {
            var a = new Asistencias();

            // Índices: 0=ID_Empleado,1=codigo_empleado,2=nombre_empleado,3=nombre_cargo,4=estado_asistencia,5=nota,6=fecha
            a.CodigoEmpleado = rd.IsDBNull(0) ? 0 : Convert.ToInt32(rd.GetValue(0)); // ID interno (PK)
            a.CodigoExterno = rd.IsDBNull(1) ? string.Empty : rd.GetValue(1).ToString(); // código visible (puede ser int en BD)
            a.NombreEmpleado = rd.IsDBNull(2) ? string.Empty : rd.GetValue(2).ToString();
            a.Cargo = rd.IsDBNull(3) ? string.Empty : rd.GetValue(3).ToString();
            a.Estado_asistencia = rd.IsDBNull(4) ? "no registrada" : rd.GetValue(4).ToString();
            a.Nota = rd.IsDBNull(5) ? "Ninguna" : rd.GetValue(5).ToString();

            if (rd.IsDBNull(6))
            {
                a.Fecha = string.Empty;
            }
            else
            {
                var val = rd.GetValue(6);
                if (val is DateTime dt)
                    a.Fecha = dt.ToString("dd/MM/yyyy");
                else
                    a.Fecha = val.ToString();
            }

            return a;
        }

        public bool ExistsAttendance(int idEmpleado, DateTime fecha)
        {
            try
            {
                Con = OpenDb();
                using (var cmd = new SqlCommand("SELECT COUNT(1) FROM Asistencias WHERE id_empleado = @id AND Fecha = @fecha", Con))
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = idEmpleado;
                    cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = fecha.Date;
                    var result = cmd.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out int count))
                    {
                        return count > 0;
                    }
                    return false;
                }
            }
            finally
            {
                CloseDB();
            }
        }

        public int Insert(Asistencias paAsistencias)
        {
            try
            {
                Con = OpenDb();
                command = new SqlCommand(@"INSERT INTO Asistencias (fecha, estado_asistencia, nota, id_empleado) 
                                           OUTPUT INSERTED.id_asistencia 
                                           VALUES (@fecha, @estado_asistencia, @nota, @id_empleado);", Con);

                if (DateTime.TryParse(paAsistencias.Fecha, out var dt))
                    command.Parameters.Add("@fecha", SqlDbType.Date).Value = dt.Date;
                else
                    command.Parameters.Add("@fecha", SqlDbType.Date).Value = DBNull.Value;

                command.Parameters.Add("@estado_asistencia", SqlDbType.VarChar, 50).Value = (object?)paAsistencias.Estado_asistencia ?? DBNull.Value;
                command.Parameters.Add("@nota", SqlDbType.VarChar, 250).Value = (object?)paAsistencias.Nota ?? DBNull.Value;
                command.Parameters.Add("@id_empleado", SqlDbType.Int).Value = paAsistencias.CodigoEmpleado;

                var id = (int)command.ExecuteScalar();
                return id;
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601)
                {
                    throw new InvalidOperationException("No se puede registrar la asistencia: ya existe una asistencia para ese empleado en la fecha indicada.", ex);
                }
                throw;
            }
            finally
            {
                command?.Dispose();
                CloseDB();
            }
        }
    }
}
