using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SistemaControlPersonal.Core.Dao;
using CoreCargos = SistemaControlPersonal.Core.Clases.Cargos;

namespace SistemaControlPersonal.Formularios.CCargos
{
    public partial class Cargos : Form
    {
        private readonly CargosDao _dao = new CargosDao();
        private List<CoreCargos> listaCargos = new List<CoreCargos>();

        public Cargos()
        {
            InitializeComponent();
            Load += Cargos_Load;
            txtBusqueda.TextChanged += txtBusqueda_TextChanged;
        }

        private void Cargos_Load(object sender, EventArgs e)
        {
            ConfigurarGrid();
            Cargar();
        }

        private void ConfigurarGrid()
        {
            dgvEmpleados.AutoGenerateColumns = false;
            dgvEmpleados.Columns.Clear();

            var colId = new DataGridViewTextBoxColumn
            {
                Name = "IdCargo",
                DataPropertyName = "IdCargo",
                HeaderText = "Id",
                Visible = false
            };
            var colNombre = new DataGridViewTextBoxColumn
            {
                Name = "NombreCargo",
                DataPropertyName = "NombreCargo",
                HeaderText = "Nombre",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };
            var colDescripcion = new DataGridViewTextBoxColumn
            {
                Name = "Descripcion",
                DataPropertyName = "Descripcion",
                HeaderText = "Descripción",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            };
            var colSalario = new DataGridViewTextBoxColumn
            {
                Name = "SalarioBase",
                DataPropertyName = "SalarioBase",
                HeaderText = "Salario",
                DefaultCellStyle = { Format = "N2" },
                Width = 120
            };
            var colTipo = new DataGridViewTextBoxColumn
            {
                Name = "TipoPago",
                DataPropertyName = "TipoPago",
                HeaderText = "Tipo de pago",
                Width = 120
            };

            dgvEmpleados.Columns.AddRange(new DataGridViewColumn[] { colId, colNombre, colDescripcion, colSalario, colTipo });
            dgvEmpleados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEmpleados.MultiSelect = false;
            dgvEmpleados.ReadOnly = true;
        }

        private void Cargar(string filtro = "")
        {
            try
            {
                listaCargos = _dao.GetAll(filtro);
                dgvEmpleados.DataSource = new BindingSource { DataSource = listaCargos };
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar cargos:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            Cargar(txtBusqueda.Text?.Trim() ?? string.Empty);
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
            // Si desea abrir edición, puede pasar el objeto seleccionado a CargosEditar
            if (dgvEmpleados.CurrentRow?.DataBoundItem is CoreCargos seleccionado)
            {
                var editar = new CargosEditar(seleccionado);
                this.Hide();
                editar.Show();
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            // eliminar cargo: obtener el id de la fila seleccionada y llamar a Delete en CargosDao
            if (dgvEmpleados.CurrentRow?.DataBoundItem is CoreCargos seleccionado)
            {
                var confirmar = MessageBox.Show($"¿Eliminar el cargo '{seleccionado.NombreCargo}'?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmar == DialogResult.Yes)
                {
                    try
                    {
                        var ok = _dao.Delete(seleccionado.IdCargo);
                        if (ok)
                        {
                            MessageBox.Show("Cargo eliminado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Cargar();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo eliminar el cargo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (InvalidOperationException ex)
                    {
                        // Mensaje amigable cuando existe referencia en otra tabla
                        MessageBox.Show(ex.Message, "Operación no permitida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione un cargo para eliminar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
