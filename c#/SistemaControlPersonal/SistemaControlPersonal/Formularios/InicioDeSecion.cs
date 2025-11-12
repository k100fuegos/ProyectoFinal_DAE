using SistemaControlPersonal.Core.Dao;
using SistemaControlPersonal.Core.Lib;

namespace SistemaControlPersonal.Formularios
{
    public partial class InicioDeSecion : Form
    {
        public InicioDeSecion()
        {
            InitializeComponent();
        }


        Cnn Cnn = new Cnn();

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
                "¿Está seguro que desea cerrar el sistema?",
                "Confirmar Salida",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            if (resultado == DialogResult.Yes)
            {
                this.Close();
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Leer campos
            var usuario = textBox1.Text.Trim();
            var contrasena = textBox2.Text;

            // Validaciones básicas
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contrasena))
            {
                MessageBox.Show("Ingrese usuario y contraseña.", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Usar UsuariosDao para validar que usuario y contraseña pertenezcan al mismo registro
                var usuariosDao = new UsuariosDao();
                bool esValido = usuariosDao.ValidateCredentials(usuario, contrasena);

                if (esValido)
                {
                    // Credenciales correctas: abrir siguiente interfaz
                    this.Hide();
                    new Formularios.PaginaPrincipal().Show();
                }
                else
                {
                    // Credenciales inválidas
                    MessageBox.Show("Usuario o contraseña incorrectos.", "Autenticación fallida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores imprevistos
                MessageBox.Show("Error al validar credenciales:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
