namespace SistemaControlPersonal.Formularios
{
    public partial class PaginaPrincipal : Form
    {
        public PaginaPrincipal()
        {
            InitializeComponent();
        }

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

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Formularios.InicioDeSecion().Show();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Formularios.frmAsistencias().Show();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Formularios.Administracion().Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Formularios.Consultas().Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Formularios.CalculoPagos().Show();
        }
    }
}
