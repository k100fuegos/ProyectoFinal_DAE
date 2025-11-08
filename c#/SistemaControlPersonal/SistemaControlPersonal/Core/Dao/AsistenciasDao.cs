using Microsoft.Data.SqlClient;
using SistemaControlPersonal.Core.Clases;
using SistemaControlPersonal.Core.Lib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaControlPersonal.Core.Dao
{
    internal class AsistenciasDao : Cnn, IAsistencias
    {

        SqlConnection Con = null;
        SqlCommand command = null;

        public List<Asistencias> GetAll(string filtro = "")
        {
            var list = new List<Asistencias>();
            SqlDataReader rd = null;

            try
            {
                Con = OpenDb();
                string sql = @"
                            SELECT Asistencias.fecha, Asistencias.estado_asistencia, Asistencias.nota, Empleado.codigo_empleado, Empleado.nombre_empleado 
                            FROM Asistencias
                            INNER JOIN Empleado ON Asistencias.id_empleado = Empleado.id_empleado
                            /**WHERE**/
                            ORDER BY Empleado.nombre_empleado DESC;";

                if (!string.IsNullOrWhiteSpace(filtro))
                {
                    sql = sql.Replace("/**WHERE**/", " WHERE Empleado.nombre_empleado LIKE @f OR Empleado.codigo_empleado LIKE @f OR DUI LIKE @f");
                }
                else
                {
                    sql = sql.Replace("/**WHERE**/", string.Empty);
                }

                command = new SqlCommand(sql, Con);

                if (!string.IsNullOrWhiteSpace(filtro))
                {
                    command.Parameters.Add("@f", System.Data.SqlDbType.NVarChar, 120).Value = $"%{filtro}%";

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

        private static Asistencias Map(SqlDataReader rd) => new Asistencias
        {
            Fecha = rd.GetString(0),
            Estado_asistencia = rd.GetString(1),
            Nota = rd.IsDBNull(2) ? null :  rd.GetString(2),
            CodigoEmpleado = rd.GetInt32(3),
            NombreEmpleado = rd.GetString(4)

        };


        public Asistencias GetById(int idAsistencia)
        {
            SqlDataReader rd = null;

            try
            {
                Con = OpenDb();

                command = new SqlCommand(@"SELECT IdPropietario, Nombre, Apellido, DUI, Telefono, Direccion 
                                       FROM Propietarios
                                       WHERE IdPropietario = @id", Con);
                command.Parameters.Add("@id", SqlDbType.Int).Value = idAsistencia;

                rd = command.ExecuteReader(CommandBehavior.SingleRow);

                if (!rd.Read())
                {
                    return null;
                }

                return Map(rd);
            }
            finally
            {
                rd?.Close();
                command?.Dispose();
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
                command.Parameters.Add("@fecha", SqlDbType.Date).Value = paAsistencias.Fecha;
                command.Parameters.Add("@estado_asistencia", SqlDbType.VarChar, 10).Value = paAsistencias.Estado_asistencia;
                command.Parameters.Add("@nota", SqlDbType.VarChar, 15).Value = (object?)paAsistencias.Nota ?? DBNull.Value;
                command.Parameters.Add("@id_empleado", SqlDbType.Int, 11).Value = paAsistencias.CodigoEmpleado;

                var id = (int)command.ExecuteScalar();
                return id;
            }
            catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601)
            {
                throw new ApplicationException("El DUI ya esta ingrezado en el sistema, Verifique la informacion");
            }
            finally
            {
                command?.Dispose();
                CloseDB();
            }
        }
    }
}
