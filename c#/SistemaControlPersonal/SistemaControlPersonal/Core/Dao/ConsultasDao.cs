using Microsoft.Data.SqlClient;
using SistemaControlPersonal.Core.Lib;
using SistemaControlPersonal.Core.Clases;
using System;
using System.Collections.Generic;
using System.Data;

namespace SistemaControlPersonal.Core.Dao
{
    internal class ConsultasDao : Cnn
    {
        public List<Consultas> GetAll(string filtro = "", DateTime? fechaInicio = null, DateTime? fechaFin = null)
        {
            var list = new List<Consultas>();
            SqlConnection Con = null;
            SqlCommand cmd = null;
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
                        OR C.nombre_cargo LIKE @f
                        OR C.tipo_pago LIKE @f";
                }

                // Fecha rango en JOIN de asistencias (si se provee)
                var fechaCond = string.Empty;
                if (fechaInicio.HasValue && fechaFin.HasValue)
                {
                    fechaCond = "AND A.fecha BETWEEN @fi AND @ff";
                }
                else if (fechaInicio.HasValue)
                {
                    fechaCond = "AND A.fecha >= @fi";
                }
                else if (fechaFin.HasValue)
                {
                    fechaCond = "AND A.fecha <= @ff";
                }

                string sql = $@"
                    SELECT
                        E.id_empleado,
                        E.codigo_empleado,
                        E.nombre_empleado,
                        E.sexo,
                        E.dui,
                        E.direccion,
                        E.telefono,
                        E.fecha_ingreso,
                        E.estado_laboral,
                        C.nombre_cargo,
                        C.descripcion,
                        C.tipo_pago,
                        C.salario_base,
                        A.estado_asistencia,
                        A.nota,
                        A.fecha
                    FROM Empleado E
                    LEFT JOIN Cargo C ON E.id_cargo = C.id_cargo
                    LEFT JOIN Asistencias A ON E.id_empleado = A.id_empleado
                        {fechaCond}
                    {where}
                    ORDER BY E.fecha_ingreso;";

                cmd = new SqlCommand(sql, Con);

                if (!string.IsNullOrWhiteSpace(filtro))
                    cmd.Parameters.Add("@f", SqlDbType.NVarChar, 200).Value = $"%{filtro.Trim()}%";

                if (fechaInicio.HasValue)
                    cmd.Parameters.Add("@fi", SqlDbType.Date).Value = fechaInicio.Value.Date;
                if (fechaFin.HasValue)
                    cmd.Parameters.Add("@ff", SqlDbType.Date).Value = fechaFin.Value.Date;

                rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    var c = new Consultas();

                    c.IdEmpleado = rd.IsDBNull(0) ? 0 : Convert.ToInt32(rd.GetValue(0));
                    c.CodigoEmpleado = rd.IsDBNull(1) ? 0 : Convert.ToInt32(rd.GetValue(1));
                    c.CodigoExterno = rd.IsDBNull(1) ? string.Empty : rd.GetValue(1).ToString();
                    c.NombreEmpleado = rd.IsDBNull(2) ? string.Empty : rd.GetValue(2).ToString();
                    c.Sexo = rd.IsDBNull(3) ? string.Empty : rd.GetValue(3).ToString();
                    c.DUI = rd.IsDBNull(4) ? string.Empty : rd.GetValue(4).ToString();
                    c.Direccion = rd.IsDBNull(5) ? string.Empty : rd.GetValue(5).ToString();
                    c.Telefono = rd.IsDBNull(6) ? string.Empty : rd.GetValue(6).ToString();
                    c.FechaIngreso = rd.IsDBNull(7) ? string.Empty : rd.GetValue(7).ToString();
                    c.EstadoLaboral = rd.IsDBNull(8) ? string.Empty : rd.GetValue(8).ToString();

                    c.NombreCargo = rd.IsDBNull(9) ? string.Empty : rd.GetValue(9).ToString();
                    c.DescripcionCargo = rd.IsDBNull(10) ? string.Empty : rd.GetValue(10).ToString();
                    c.TipoPago = rd.IsDBNull(11) ? string.Empty : rd.GetValue(11).ToString();

                    if (rd.IsDBNull(12))
                        c.SalarioBase = 0m;
                    else
                    {
                        var val = rd.GetValue(12);
                        if (val is decimal dec) c.SalarioBase = dec;
                        else if (decimal.TryParse(val.ToString(), out var d)) c.SalarioBase = d;
                        else c.SalarioBase = 0m;
                    }

                    c.EstadoAsistencia = rd.IsDBNull(13) ? string.Empty : rd.GetValue(13).ToString();
                    c.Nota = rd.IsDBNull(14) ? string.Empty : rd.GetValue(14).ToString();

                    if (rd.IsDBNull(15))
                    {
                        c.Fecha = string.Empty;
                    }
                    else
                    {
                        var val = rd.GetValue(15);
                        if (val is DateTime dt)
                            c.Fecha = dt.ToString("dd/MM/yyyy");
                        else
                            c.Fecha = val.ToString();
                    }

                    list.Add(c);
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
    }
}