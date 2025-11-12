using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace SistemaControlPersonal.Core.Lib
{
    internal class Cnn
    {

        private readonly SqlConnection _conexion;

        public Cnn()
        {
            string cadena = ConfigurationManager.ConnectionStrings["SqlConn"].ConnectionString;
            _conexion = new SqlConnection(cadena);
        }

        public SqlConnection OpenDb()
        {
            try
            {
                if (_conexion.State == ConnectionState.Closed)
                    _conexion.Open();
                return _conexion;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al abrir la conexion a la BD: " + ex.Message, "DataBase",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        public void CloseDB()
        {
            try
            {
                if (_conexion.State != ConnectionState.Closed)
                    _conexion.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al cerrar la conexion: " + ex.Message, "DateBase",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

    }
}
