using PracticaVehiculo.Core.Enums;
using SistemaControlPersonal.Core.Dao;

namespace SistemaControlPersonal.Formularios
{
    public partial class EmpleadosAniadir : Form
    {
        private readonly EmpleadosDao empleadosDao = new EmpleadosDao();
        // Lista de cargos con salario incluido
        private List<(int Id, string Nombre, double Salario)> cargos = new();

        public EmpleadosAniadir()
        {
            InitializeComponent();
            this.Load += EmpleadosAniadir_Load;
            cbxCargo.SelectedIndexChanged += CbxCargo_SelectedIndexChanged;
        }

        private void EmpleadosAniadir_Load(object? sender, EventArgs e)
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
                    // no se muestra campo salario: se autodefine según cargo
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar cargos:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CbxCargo_SelectedIndexChanged(object? sender, EventArgs e)
        {
            // El salario se toma internamente desde la tabla Cargo; no actualizamos ningún txtSalario
            // (si quieres mostrar el salario, añade un Label en el diseñador y actualízalo aquí)
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

            var nuevo = new Core.Clases.Empleados
            {
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
                var idInsertado = empleadosDao.Insert(nuevo, idCargo);
                if (idInsertado > 0)
                {
                    MessageBox.Show("Empleado agregado correctamente.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    var frm = new Empleados();
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("No se pudo agregar el empleado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar el empleado:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
