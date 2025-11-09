using Microsoft.Data.SqlClient;
using SistemaControlPersonal.Core.Clases;
using SistemaControlPersonal.Core.Lib;
using System;
using System.Collections.Generic;
using System.Data;

namespace SistemaControlPersonal.Core.Dao
{
    internal class CalculoPagosDao : Cnn
    {
        public List<CalculoPagoEmpleado> GetAll(string filtro = "")
        {
            var list = new List<CalculoPagoEmpleado>();
            SqlConnection Con = null;
            SqlCommand command = null;
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
                        OR C.nombre_cargo LIKE @f";
                }

                string sql = $@"
                    SELECT
                        E.codigo_empleado,
                        E.nombre_empleado,
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
                    var modelo = new CalculoPagoEmpleado
                    {
                        CodigoEmpleado = rd.IsDBNull(0) ? 0 : Convert.ToInt32(rd.GetValue(0)),
                        NombreEmpleado = rd.IsDBNull(1) ? string.Empty : rd.GetValue(1).ToString(),
                        Cargo = rd.IsDBNull(2) ? string.Empty : rd.GetValue(2).ToString()
                    };
                    list.Add(modelo);
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
    }
}