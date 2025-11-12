using Microsoft.Data.SqlClient;
using SistemaControlPersonal.Core.Clases;
using SistemaControlPersonal.Core.Lib;
using System.Data;

namespace SistemaControlPersonal.Core.Dao
{
    internal class ConsultasDao : Cnn
    {
        public List<Consultas> GetAll(string filtro = "", DateTime? fechaInicio = null, DateTime? fechaFin = null, bool soloActivos = true)
        {
            var list = new List<Consultas>();
            SqlConnection Con = null;
            SqlCommand cmd = null;
            SqlDataReader rd = null;

            try
            {
                Con = OpenDb();
                cmd = new SqlCommand("dbo.sp_GetConsultas", Con);
                cmd.CommandType = CommandType.StoredProcedure;

                // Parámetros del procedimiento almacenado
                if (string.IsNullOrWhiteSpace(filtro))
                    cmd.Parameters.Add("@Filtro", SqlDbType.NVarChar, 200).Value = DBNull.Value;
                else
                    cmd.Parameters.Add("@Filtro", SqlDbType.NVarChar, 200).Value = $"%{filtro.Trim()}%";

                if (fechaInicio.HasValue)
                    cmd.Parameters.Add("@FechaInicio", SqlDbType.Date).Value = fechaInicio.Value.Date;
                else
                    cmd.Parameters.Add("@FechaInicio", SqlDbType.Date).Value = DBNull.Value;

                if (fechaFin.HasValue)
                    cmd.Parameters.Add("@FechaFin", SqlDbType.Date).Value = fechaFin.Value.Date;
                else
                    cmd.Parameters.Add("@FechaFin", SqlDbType.Date).Value = DBNull.Value;

                cmd.Parameters.Add("@SoloActivos", SqlDbType.Bit).Value = soloActivos;

                rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    var c = new Consultas
                    {
                        IdEmpleado = rd["IdEmpleado"] != DBNull.Value ? Convert.ToInt32(rd["IdEmpleado"]) : 0,
                        CodigoEmpleado = rd["CodigoEmpleado"] != DBNull.Value ? Convert.ToInt32(rd["CodigoEmpleado"]) : 0,
                        CodigoExterno = rd["CodigoExterno"] != DBNull.Value ? rd["CodigoExterno"].ToString() : string.Empty,
                        NombreEmpleado = rd["NombreEmpleado"] != DBNull.Value ? rd["NombreEmpleado"].ToString() : string.Empty,
                        Sexo = rd["Sexo"] != DBNull.Value ? rd["Sexo"].ToString() : string.Empty,
                        DUI = rd["DUI"] != DBNull.Value ? rd["DUI"].ToString() : string.Empty,
                        Direccion = rd["Direccion"] != DBNull.Value ? rd["Direccion"].ToString() : string.Empty,
                        Telefono = rd["Telefono"] != DBNull.Value ? rd["Telefono"].ToString() : string.Empty,
                        FechaIngreso = rd["FechaIngreso"] != DBNull.Value ? rd["FechaIngreso"].ToString() : string.Empty,
                        EstadoLaboral = rd["EstadoLaboral"] != DBNull.Value ? rd["EstadoLaboral"].ToString() : string.Empty,
                        NombreCargo = rd["NombreCargo"] != DBNull.Value ? rd["NombreCargo"].ToString() : string.Empty,
                        DescripcionCargo = rd["TipoPago"] != DBNull.Value ? rd["TipoPago"].ToString() : string.Empty,
                        TipoPago = rd["TipoPago"] != DBNull.Value ? rd["TipoPago"].ToString() : string.Empty,
                        SalarioBase = rd["SalarioBase"] != DBNull.Value ? Convert.ToDecimal(rd["SalarioBase"]) : 0m,
                        EstadoAsistencia = rd["EstadoAsistencia"] != DBNull.Value ? rd["EstadoAsistencia"].ToString() : string.Empty,
                        Nota = rd["Nota"] != DBNull.Value ? rd["Nota"].ToString() : string.Empty,
                        Fecha = rd["Fecha"] != DBNull.Value
                            ? Convert.ToDateTime(rd["Fecha"]).ToString("dd/MM/yyyy")
                            : string.Empty
                    };

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
