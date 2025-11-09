using SistemaControlPersonal.Core.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using EmpleadoModel = SistemaControlPersonal.Core.Clases.Empleados;

namespace SistemaControlPersonal.Formularios
{
    public partial class Empleados : Form
    {
        private readonly EmpleadosDao empleadosDao = new EmpleadosDao();

        public Empleados()
        {
            InitializeComponent();
            ConfiguracionGrid();
            Cargar(); // carga inicial
        }

        private void ConfiguracionGrid()
        {
            dgvEmpleados.AutoGenerateColumns = false;
            dgvEmpleados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEmpleados.MultiSelect = false;
            dgvEmpleados.Columns.Clear();

            dgvEmpleados.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "codigoCol",
                HeaderText = "Código",
                DataPropertyName = "CodigoEmpleado",
                MinimumWidth = 80
            });

            dgvEmpleados.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "nombreCol",
                HeaderText = "Nombre",
                DataPropertyName = "NombreEmpleado",
                MinimumWidth = 150
            });

            dgvEmpleados.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "duiCol",
                HeaderText = "DUI",
                DataPropertyName = "DUI",
                MinimumWidth = 100
            });

            dgvEmpleados.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "sexoCol",
                HeaderText = "Sexo",
                DataPropertyName = "Sexo",
                MinimumWidth = 60
            });

            dgvEmpleados.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "fechaNacCol",
                HeaderText = "Fecha Nac.",
                DataPropertyName = "FechaNacimiento",
                MinimumWidth = 95
            });

            dgvEmpleados.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "direccionCol",
                HeaderText = "Dirección",
                DataPropertyName = "Direccion",
                MinimumWidth = 180
            });

            dgvEmpleados.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "telefonoCol",
                HeaderText = "Teléfono",
                DataPropertyName = "Telefono",
                MinimumWidth = 100
            });

            dgvEmpleados.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "salarioCol",
                HeaderText = "Salario base",
                DataPropertyName = "SalarioBase",
                MinimumWidth = 100,
                DefaultCellStyle = { Format = "N2" }
            });

            dgvEmpleados.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "fechaIngresoCol",
                HeaderText = "Fecha Ingreso",
                DataPropertyName = "FechaIngreso",
                MinimumWidth = 95
            });

            dgvEmpleados.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "estadoCol",
                HeaderText = "Estado laboral",
                DataPropertyName = "EstadoLaboral",
                MinimumWidth = 100
            });

            dgvEmpleados.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "cargoCol",
                HeaderText = "Cargo",
                DataPropertyName = "Cargo",
                MinimumWidth = 120
            });

            var columnas = dgvEmpleados.Columns.Count;
            if (columnas > 0)
            {
                float peso = 100f / columnas;
                foreach (DataGridViewColumn col in dgvEmpleados.Columns)
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    col.FillWeight = peso;
                }
            }
        }

        private void Cargar(string filtro = "")
        {
            try
            {
                List<EmpleadoModel> lista = empleadosDao.GetAll(filtro ?? string.Empty);

                if (!string.IsNullOrWhiteSpace(filtro))
                {
                    string f = filtro.Trim();
                    lista = lista.Where(e =>
                        (e.CodigoEmpleado.ToString().IndexOf(f, StringComparison.OrdinalIgnoreCase) >= 0)
                        || (!string.IsNullOrWhiteSpace(e.NombreEmpleado) && e.NombreEmpleado.IndexOf(f, StringComparison.OrdinalIgnoreCase) >= 0)
                        || (!string.IsNullOrWhiteSpace(e.DUI) && e.DUI.IndexOf(f, StringComparison.OrdinalIgnoreCase) >= 0)
                        || (!string.IsNullOrWhiteSpace(e.Cargo) && e.Cargo.IndexOf(f, StringComparison.OrdinalIgnoreCase) >= 0)
                    ).ToList();
                }

                dgvEmpleados.DataSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar empleados:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgvEmpleados.DataSource = null;
            }
            finally
            {
                dgvEmpleados.ClearSelection();
                dgvEmpleados.CurrentCell = null;
            }
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
            new Formularios.EmpleadosAniadir().Show();
        }

        private void btnModificarEmpleado_Click(object sender, EventArgs e)
        {
            // Ahora verificamos selección y mandamos el objeto empleado al formulario de edición
            if (dgvEmpleados.SelectedRows == null || dgvEmpleados.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un empleado en la lista.", "Selección requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var fila = dgvEmpleados.SelectedRows[0];

            EmpleadoModel empleadoSeleccionado;
            if (fila.DataBoundItem is EmpleadoModel em)
            {
                empleadoSeleccionado = em;
            }
            else
            {
                // Fallback: intentar obtener el id desde la celda visible (no esperado, pero seguro)
                object val = fila.Cells["codigoCol"].Value;
                MessageBox.Show("No se pudo obtener el empleado seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.Hide();
            var frm = new Formularios.EmpleadosEditar(empleadoSeleccionado);
            frm.Show();
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            string filtro = string.Empty;
            if (sender is TextBox tb)
                filtro = tb.Text ?? string.Empty;
            else
            {
                var ctrl = this.Controls.Find("txtBusqueda", true).FirstOrDefault() as TextBox;
                filtro = ctrl?.Text ?? string.Empty;
            }

            Cargar(filtro);
        }

        private void Empleados_Load(object sender, EventArgs e)
        {
        }
    }
}
