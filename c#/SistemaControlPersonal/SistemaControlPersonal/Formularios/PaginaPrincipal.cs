using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
    }
}
