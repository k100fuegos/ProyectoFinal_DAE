using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using SistemaControlPersonal.Core.Clases;
using SistemaControlPersonal.Core.Lib;

namespace SistemaControlPersonal.Core.Dao
{
    internal class CalculoPagosDao : Cnn
    {
        public List<CalculoPagoEmpleado> GetAll(string filtro = "")
        {
            var list = new List<CalculoPagoEmpleado>();
            SqlConnection con = null;

            try
            {
                con = OpenDb();

                var where = string.Empty;
                if (!string.IsNullOrWhiteSpace(filtro))
                {
                    where = @"WHERE
                        CAST(E.codigo_empleado AS NVARCHAR(50)) LIKE @f
                        OR E.nombre_empleado LIKE @f
                        OR C.nombre_cargo LIKE @f
                        OR C.tipo_pago LIKE @f";
                }

                string sql = $@"
                    SELECT
                        E.codigo_empleado,
                        E.nombre_empleado,
                        C.nombre_cargo,
                        C.tipo_pago,
                        C.salario_base
                    FROM Empleado E
                    LEFT JOIN Cargo C ON E.id_cargo = C.id_cargo
                    {where}
                    ORDER BY E.nombre_empleado;";

                using (var command = new SqlCommand(sql, con))
                {
                    if (!string.IsNullOrWhiteSpace(filtro))
                    {
                        command.Parameters.Add("@f", SqlDbType.NVarChar, 200).Value = $"%{filtro.Trim()}%";
                    }

                    using (var rd = command.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            var modelo = new CalculoPagoEmpleado
                            {
                                CodigoEmpleado = rd.IsDBNull(0) ? 0 : Convert.ToInt32(rd.GetValue(0)),
                                NombreEmpleado = rd.IsDBNull(1) ? string.Empty : rd.GetValue(1).ToString(),
                                Cargo = rd.IsDBNull(2) ? string.Empty : rd.GetValue(2).ToString(),
                                TipoPago = rd.IsDBNull(3) ? string.Empty : rd.GetValue(3).ToString(),
                                SalarioBase = rd.IsDBNull(4) ? 0m : Convert.ToDecimal(rd.GetValue(4))
                            };
                            list.Add(modelo);
                        }
                    }
                }
            }
            finally
            {
                // Cnn administra la conexión; aseguramos cierre siempre llamando a CloseDB()
                CloseDB();
            }

            return list;
        }
    }
}