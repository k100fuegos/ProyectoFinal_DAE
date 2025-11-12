using SistemaControlPersonal.Core.Dao;
using System.Globalization;

namespace SistemaControlPersonal.Formularios
{
    public partial class Consultas : Form
    {
        private readonly ConsultasDao _dao = new ConsultasDao();

        public Consultas()
        {
            InitializeComponent();
        }

        private void Consultas_Load(object sender, EventArgs e)
        {
            ConfiguracionGrid();
            Cargar();
            // Asignar control de eventos
            txtBusqueda.TextChanged += TxtBusqueda_TextChanged;
            btnFiltrar.Click += btnFiltrar_Click; // enlazamos el botón filtrar
        }

        private void ConfiguracionGrid()
        {
            dgvAsistencias.AutoGenerateColumns = false;
            dgvAsistencias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAsistencias.MultiSelect = false;
            dgvAsistencias.Columns.Clear();

            void Add(string name, string header, string prop, int minw = 80)
            {
                dgvAsistencias.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = name,
                    HeaderText = header,
                    DataPropertyName = prop,
                    MinimumWidth = minw
                });
            }

            // Orden: empleado (nombre, codigo, sexo, dui, direccion, telefono, fecha ingreso, estado laboral)
            Add("nombre_empleadoCol", "Nombre", "NombreEmpleado", 140);
            Add("codigo_empleadoCol", "Código", "CodigoExterno", 80);
            Add("sexoCol", "Sexo", "Sexo", 60);
            Add("duiCol", "DUI", "DUI", 100);
            Add("direccionCol", "Dirección", "Direccion", 160);
            Add("telefonoCol", "Teléfono", "Telefono", 100);
            Add("fecha_ingresoCol", "Fecha Ingreso", "FechaIngreso", 100);
            Add("estado_laboralCol", "Estado", "EstadoLaboral", 100);

            // cargo (nombre, descripcion, tipo pago, salario base)
            Add("nombre_cargoCol", "Cargo", "NombreCargo", 120);
            Add("tipo_pagoCol", "Tipo Pago", "TipoPago", 90);
            Add("salario_baseCol", "Salario Base", "SalarioBase", 100);

            // asistencia (estado, nota, fecha)
            Add("estado_asistenciaCol", "Estado Asistencia", "EstadoAsistencia", 120);
            Add("notaCol", "Nota", "Nota", 160);
            Add("fechaCol", "Fecha Asistencia", "Fecha", 100);

            // Ajuste de anchuras
            var columnas = dgvAsistencias.Columns.Count;
            if (columnas > 0)
            {
                float peso = 100f / columnas;
                foreach (DataGridViewColumn col in dgvAsistencias.Columns)
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    col.FillWeight = peso;
                }
            }
        }

        private void Cargar(string filtro = "")
        {
            DateTime? fi = null;
            DateTime? ff = null;

            // Intentar parsear rango si los masked text boxes tienen valor
            var inicio = mtxtFechaInicio.Text?.Trim();
            var fin = mtxtFechaFin.Text?.Trim();

            if (!string.IsNullOrWhiteSpace(inicio) && !inicio.Contains("-") && DateTime.TryParseExact(inicio, "dd/MM/yyyy", CultureInfo.CurrentCulture, DateTimeStyles.None, out var d1))
                fi = d1.Date;
            if (!string.IsNullOrWhiteSpace(fin) && !fin.Contains("-") && DateTime.TryParseExact(fin, "dd/MM/yyyy", CultureInfo.CurrentCulture, DateTimeStyles.None, out var d2))
                ff = d2.Date;

            try
            {
                var list = _dao.GetAll(filtro, fi, ff);

                // Aplicar filtrado adicional por texto de búsqueda (si es necesario)
                if (!string.IsNullOrWhiteSpace(filtro))
                {
                    var f = filtro.Trim();
                    list = list.Where(x =>
                        (!string.IsNullOrWhiteSpace(x.NombreEmpleado) && x.NombreEmpleado.IndexOf(f, StringComparison.OrdinalIgnoreCase) >= 0)
                        || (!string.IsNullOrWhiteSpace(x.CodigoExterno) && x.CodigoExterno.IndexOf(f, StringComparison.OrdinalIgnoreCase) >= 0)
                        || (!string.IsNullOrWhiteSpace(x.NombreCargo) && x.NombreCargo.IndexOf(f, StringComparison.OrdinalIgnoreCase) >= 0)
                    ).ToList();
                }

                dgvAsistencias.DataSource = list;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar consultas:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgvAsistencias.DataSource = null;
            }
            finally
            {
                dgvAsistencias.ClearSelection();
                dgvAsistencias.CurrentCell = null;
            }
        }

        private void TxtBusqueda_TextChanged(object sender, EventArgs e)
        {
            var filtro = (sender as TextBox)?.Text ?? txtBusqueda.Text ?? string.Empty;
            Cargar(filtro);
        }

        private void FechaControl_Changed(object? sender, EventArgs e)
        {
            // Si cambian las fechas recargar
            Cargar(txtBusqueda.Text ?? string.Empty);
        }

        // Nuevo: manejador del botón Filtrar - valida rango y aplica filtro
        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            var inicio = mtxtFechaInicio.Text?.Trim();
            var fin = mtxtFechaFin.Text?.Trim();

            if (string.IsNullOrWhiteSpace(inicio) || inicio.Contains("-") || !DateTime.TryParseExact(inicio, "dd/MM/yyyy", CultureInfo.CurrentCulture, DateTimeStyles.None, out var d1))
            {
                MessageBox.Show("Ingrese una fecha de inicio válida (dd/MM/yyyy).", "Fecha inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(fin) || fin.Contains("-") || !DateTime.TryParseExact(fin, "dd/MM/yyyy", CultureInfo.CurrentCulture, DateTimeStyles.None, out var d2))
            {
                MessageBox.Show("Ingrese una fecha de fin válida (dd/MM/yyyy).", "Fecha inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (d2 < d1)
            {
                MessageBox.Show("La fecha de fin debe ser igual o posterior a la fecha de inicio.", "Rango inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Llamamos a Cargar que ya usa los masked boxes para construir el rango
            Cargar(txtBusqueda.Text ?? string.Empty);
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
