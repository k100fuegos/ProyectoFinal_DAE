using SistemaControlPersonal.Core.Dao;
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
    public partial class frmAsistencias : Form
    {
        public frmAsistencias()
        {
            InitializeComponent();
        }

        private AsistenciasDao AsistenciasDao = new AsistenciasDao();

        private void ConfiguracionGrid()
        {
            dgvAsistencias.AutoGenerateColumns = false;
            dgvAsistencias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAsistencias.MultiSelect = false;
            dgvAsistencias.Columns.Clear();

            dgvAsistencias.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FechaCol",
                HeaderText = "Fecha",
                DataPropertyName = "Fecha",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvAsistencias.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "estado_asistenciaCol",
                HeaderText = "estado_asistencia",
                DataPropertyName = "estado_asistencia",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvAsistencias.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "notaCol",
                HeaderText = "nota",
                DataPropertyName = "nota",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvAsistencias.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "codigo_empleadoCol",
                HeaderText = "Código empleado",
                DataPropertyName = "CodigoEmpleado",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvAsistencias.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "nombre_empleadoCol",
                HeaderText = "Nombre empleado",
                DataPropertyName = "NombreEmpleado",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

        }

        private void Cargar(string filtro = "")
        {
            dgvAsistencias.DataSource = AsistenciasDao.GetAll();
            dgvAsistencias.ClearSelection();
            dgvAsistencias.CurrentCell = null;

        }

        private void frmAsistencias_Load_1(object sender, EventArgs e)
        {
            ConfiguracionGrid();
            Cargar();
        }


        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Formularios.PaginaPrincipal().Show();
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


    }
}
