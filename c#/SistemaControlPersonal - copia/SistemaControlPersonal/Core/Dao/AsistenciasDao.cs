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

                // Si la fecha se proporciona, añadimos la condición sobre A.Fecha en el LEFT JOIN.
                var fechaJoin = fechaFiltro.HasValue ? "AND A.Fecha = @fecha" : string.Empty;

                string sql = $@"
                    SELECT
                        E.ID_Empleado,
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

            // Índices según SELECT: 0=ID_Empleado,1=nombre_empleado,2=nombre_cargo,3=estado_asistencia,4=nota,5=fecha
            a.CodigoEmpleado = rd.IsDBNull(0) ? 0 : Convert.ToInt32(rd.GetValue(0));
            a.NombreEmpleado = rd.IsDBNull(1) ? null : rd.GetString(1);
            a.Cargo = rd.IsDBNull(2) ? null : rd.GetString(2);
            a.Estado_asistencia = rd.IsDBNull(3) ? null : rd.GetString(3);
            a.Nota = rd.IsDBNull(4) ? null : rd.GetString(4);

            if (rd.IsDBNull(5))
            {
                a.Fecha = null;
            }
            else
            {
                var val = rd.GetValue(5);
                if (val is DateTime dt)
                    a.Fecha = dt.ToString("dd/MM/yyyy");
                else
                    a.Fecha = val.ToString();
            }

            return a;
        }

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

                if (DateTime.TryParse(paAsistencias.Fecha, out var dt))
                    command.Parameters.Add("@fecha", SqlDbType.Date).Value = dt.Date;
                else
                    command.Parameters.Add("@fecha", SqlDbType.Date).Value = DBNull.Value;

                command.Parameters.Add("@estado_asistencia", SqlDbType.VarChar, 10).Value = (object?)paAsistencias.Estado_asistencia ?? DBNull.Value;
                command.Parameters.Add("@nota", SqlDbType.VarChar, 250).Value = (object?)paAsistencias.Nota ?? DBNull.Value;
                command.Parameters.Add("@id_empleado", SqlDbType.Int).Value = paAsistencias.CodigoEmpleado;

                var id = (int)command.ExecuteScalar();
                return id;
            }
            finally
            {
                command?.Dispose();
                CloseDB();
            }
        }
    }
}
