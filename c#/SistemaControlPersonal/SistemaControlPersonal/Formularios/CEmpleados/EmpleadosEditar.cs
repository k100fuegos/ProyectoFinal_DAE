using PracticaVehiculo.Core.Enums;
using SistemaControlPersonal.Core.Dao;
using EmpleadoModel = SistemaControlPersonal.Core.Clases.Empleados;

namespace SistemaControlPersonal.Formularios
{
    public partial class EmpleadosEditar : Form
    {
        private readonly EmpleadosDao empleadosDao = new EmpleadosDao();
        private List<(int Id, string Nombre, double Salario)> cargos = new();
        private EmpleadoModel _empleado;

        public EmpleadosEditar()
        {
            InitializeComponent();
            // soporte para diseñador
            this.Load += EmpleadosEditar_Load;
        }

        // Constructor usado al editar: recibe el empleado seleccionado
        public EmpleadosEditar(EmpleadoModel empleado) : this()
        {
            _empleado = empleado;
        }

        private void EmpleadosEditar_Load(object? sender, EventArgs e)
        {
            // Cargar estados laborales desde el enum (fallback si no existe)
            try
            {
                cbxEstadoLaboral.DataSource = Enum.GetValues(typeof(EstadosLaborales)).Cast<EstadosLaborales>().ToList();
            }
            catch
            {
                cbxEstadoLaboral.Items.Clear();
                cbxEstadoLaboral.Items.AddRange(new object[] { "Activo", "Inactivo" });
                if (cbxEstadoLaboral.Items.Count > 0) cbxEstadoLaboral.SelectedIndex = 0;
            }

            // Sexo
            cbxSexo.Items.Clear();
            cbxSexo.Items.AddRange(new object[] { "M", "F" });
            if (cbxSexo.Items.Count > 0) cbxSexo.SelectedIndex = 0;

            // Cargar cargos desde BD (id, nombre, salario)
            try
            {
                cargos = empleadosDao.GetAllCargos(); // debe devolver List<(int,string,double)>
                cbxCargo.DataSource = cargos.Select(c => c.Nombre).ToList();
                if (cbxCargo.Items.Count > 0)
                {
                    cbxCargo.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar cargos:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Si se proporcionó un empleado, rellenar controles para permitir edición
            if (_empleado != null)
            {
                // Código y validaciones similares a EmpleadosAniadir
                mtxtCodigoEmpleado.Text = _empleado.CodigoEmpleado.ToString();
                txtNombre.Text = _empleado.NombreEmpleado ?? string.Empty;
                txtDUI.Text = _empleado.DUI ?? string.Empty;
                cbxSexo.SelectedItem = string.IsNullOrWhiteSpace(_empleado.Sexo) ? (cbxSexo.Items.Count > 0 ? cbxSexo.Items[0] : null) : _empleado.Sexo;
                mtxtFechaNacimiento.Text = _empleado.FechaNacimiento ?? string.Empty;
                txtDireccion.Text = _empleado.Direccion ?? string.Empty;
                txtTelefono.Text = _empleado.Telefono ?? string.Empty;
                mtxtFechaIngreso.Text = _empleado.FechaIngreso ?? string.Empty;
                cbxEstadoLaboral.SelectedItem = string.IsNullOrWhiteSpace(_empleado.EstadoLaboral) ? (cbxEstadoLaboral.Items.Count > 0 ? cbxEstadoLaboral.Items[0] : null) : _empleado.EstadoLaboral;

                // Seleccionar cargo por nombre (si existe)
                if (!string.IsNullOrWhiteSpace(_empleado.Cargo))
                {
                    int idx = cargos.FindIndex(c => string.Equals(c.Nombre, _empleado.Cargo, StringComparison.OrdinalIgnoreCase));
                    if (idx >= 0 && idx < cbxCargo.Items.Count)
                        cbxCargo.SelectedIndex = idx;
                }
            }

            cbxCargo.SelectedIndexChanged += CbxCargo_SelectedIndexChanged;
        }

        private void CbxCargo_SelectedIndexChanged(object? sender, EventArgs e)
        {
            // El salario se toma internamente desde la tabla Cargo; si quieres mostrarlo, añade Label y actualízalo aquí.
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            // Validaciones
            if (string.IsNullOrWhiteSpace(mtxtCodigoEmpleado.Text) || !int.TryParse(mtxtCodigoEmpleado.Text.Trim(), out int codigo))
            {
                MessageBox.Show("Ingrese un código de empleado válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mtxtCodigoEmpleado.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Ingrese el nombre del empleado.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }

            if (cbxCargo.SelectedIndex < 0 || cargos.Count <= cbxCargo.SelectedIndex)
            {
                MessageBox.Show("Seleccione un cargo válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbxCargo.Focus();
                return;
            }

            var selectedCargo = cargos[cbxCargo.SelectedIndex];
            int idCargo = selectedCargo.Id;
            double salario = selectedCargo.Salario;

            // Construir objeto con datos editados
            var actualizado = new EmpleadoModel
            {
                // Mantener el Id interno si existe (_empleado puede ser null en casos inesperados)
                IdEmpleado = _empleado?.IdEmpleado ?? 0,
                CodigoEmpleado = codigo,
                NombreEmpleado = txtNombre.Text.Trim(),
                DUI = string.IsNullOrWhiteSpace(txtDUI.Text) ? string.Empty : txtDUI.Text.Trim(),
                Sexo = cbxSexo.SelectedItem?.ToString() ?? string.Empty,
                FechaNacimiento = mtxtFechaNacimiento.Text?.Trim() ?? string.Empty,
                Direccion = txtDireccion.Text?.Trim() ?? string.Empty,
                Telefono = txtTelefono.Text?.Trim() ?? string.Empty,
                SalarioBase = salario,
                FechaIngreso = mtxtFechaIngreso.Text?.Trim() ?? string.Empty,
                EstadoLaboral = cbxEstadoLaboral.SelectedItem?.ToString() ?? string.Empty,
                Cargo = selectedCargo.Nombre
            };

            try
            {
                bool ok = empleadosDao.Update(actualizado, idCargo);
                if (ok)
                {
                    MessageBox.Show("Empleado actualizado correctamente.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    var frm = new Empleados();
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar el empleado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el empleado:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Formularios.Empleados().Show();
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            var frm = new Empleados();
            frm.Show();
        }
    }
}
