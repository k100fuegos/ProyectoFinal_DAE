using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaControlPersonal.Formularios.CCargos
{
    public partial class Cargos : Form
    {
        public Cargos()
        {
            InitializeComponent();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Formularios.Administracion().Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Formularios.PaginaPrincipal().Show();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
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

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnAniadirEmpleados_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Formularios.CCargos.CargosAniadir().Show();
        }

        private void btnModificarEmpleado_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Formularios.CCargos.CargosEditar().Show();
        }
    }
}
