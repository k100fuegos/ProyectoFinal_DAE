using Microsoft.Data.SqlClient;
using SistemaControlPersonal.Core.Lib;
using System.Data;

namespace SistemaControlPersonal.Core.Dao
{
    internal class UsuariosDao : Cnn
    {
        public bool ValidateCredentials(string usuario, string contrasena)
        {
            SqlCommand? cmd = null;
            try
            {
                var conn = OpenDb();
                // Usar el nombre correcto de tabla y columnas según su esquema
                cmd = new SqlCommand("SELECT COUNT(1) FROM dbo.usuario WHERE nombre_usuario = @u AND contrasenia = @p", conn);
                cmd.Parameters.Add("@u", SqlDbType.NVarChar, 200).Value = (object?)usuario ?? DBNull.Value;
                cmd.Parameters.Add("@p", SqlDbType.NVarChar, 200).Value = (object?)contrasena ?? DBNull.Value;

                var result = cmd.ExecuteScalar();
                if (result == null) return false;
                return Convert.ToInt32(result) > 0;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al validar credenciales:\n" + ex.Message, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
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