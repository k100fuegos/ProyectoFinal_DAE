using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Globalization;
using SistemaControlPersonal.Core.Dao;
using SistemaControlPersonal.Core.Clases;

namespace SistemaControlPersonal.Formularios
{
    public partial class CalculoPagos : Form
    {
        private readonly CalculoPagosDao calculoDao = new CalculoPagosDao();

        public CalculoPagos()
        {
            InitializeComponent();
            ConfiguracionGrid();

            // conectar evento de búsqueda aceptando ambos nombres comunes del control
            TextBox tb = this.Controls.Find("txtBusqueda", true).FirstOrDefault() as TextBox
                         ?? this.Controls.Find("textBuscador", true).FirstOrDefault() as TextBox;
            if (tb != null)
                tb.TextChanged += txtBusqueda_TextChanged;

            // conectar el botón "Calcular Pago" (nombre definido en el Designer)
            if (btnCalcularPago != null)
                btnCalcularPago.Click += btnCalcularPago_Click;

            Cargar(); // carga inicial
        }

        private void ConfiguracionGrid()
        {
            dgvCalculoPagos.AutoGenerateColumns = false;
            dgvCalculoPagos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCalculoPagos.MultiSelect = false;
            dgvCalculoPagos.Columns.Clear();

            dgvCalculoPagos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "codigoCol",
                HeaderText = "Código",
                DataPropertyName = "CodigoEmpleado",
                MinimumWidth = 40,
                ValueType = typeof(int)
            });

            dgvCalculoPagos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "nombreCol",
                HeaderText = "Nombre",
                DataPropertyName = "NombreEmpleado",
                MinimumWidth = 130
            });

            dgvCalculoPagos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "cargoCol",
                HeaderText = "Cargo",
                DataPropertyName = "Cargo",
                MinimumWidth = 130
            });

            // Columna para Tipo de Pago (viene de la tabla Cargo.tipo_pago)
            dgvCalculoPagos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "tipoPagoCol",
                HeaderText = "Tipo Pago",
                DataPropertyName = "TipoPago",
                MinimumWidth = 100,
                ValueType = typeof(string)
            });

            // Ajustar anchuras iguales en porcentaje
            var columnas = dgvCalculoPagos.Columns.Count;
            if (columnas > 0)
            {
                float peso = 100f / columnas;
                foreach (DataGridViewColumn col in dgvCalculoPagos.Columns)
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    col.FillWeight = peso;
                }
            }

            // Formateo dinámico para mostrar Tipo de Pago según el cargo (si lo necesitas puedes ajustar aquí)
            dgvCalculoPagos.CellFormatting -= dgvCalculoPagos_CellFormatting;
            dgvCalculoPagos.CellFormatting += dgvCalculoPagos_CellFormatting;
        }

        private void Cargar(string filtro = "")
        {
            try
            {
                // Traer todos y filtrar en cliente para asegurar que búsqueda combine campos
                List<CalculoPagoEmpleado> lista = calculoDao.GetAll(string.Empty);

                if (!string.IsNullOrWhiteSpace(filtro))
                {
                    string f = filtro.Trim();
                    lista = lista.Where(e =>
                        // Buscar por código (contiene), nombre, cargo y tipo de pago (ignorando mayúsculas/minúsculas)
                        e.CodigoEmpleado.ToString().IndexOf(f, StringComparison.OrdinalIgnoreCase) >= 0
                        || (!string.IsNullOrWhiteSpace(e.NombreEmpleado) && e.NombreEmpleado.IndexOf(f, StringComparison.OrdinalIgnoreCase) >= 0)
                        || (!string.IsNullOrWhiteSpace(e.Cargo) && e.Cargo.IndexOf(f, StringComparison.OrdinalIgnoreCase) >= 0)
                        || (!string.IsNullOrWhiteSpace(e.TipoPago) && e.TipoPago.IndexOf(f, StringComparison.OrdinalIgnoreCase) >= 0)
                    ).ToList();
                }

                dgvCalculoPagos.DataSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos de cálculo de pagos:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgvCalculoPagos.DataSource = null;
            }
            finally
            {
                dgvCalculoPagos.ClearSelection();
                dgvCalculoPagos.CurrentCell = null;
            }
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            string filtro = string.Empty;
            if (sender is TextBox tb)
                filtro = tb.Text ?? string.Empty;
            else
            {
                var ctrl = this.Controls.Find("txtBusqueda", true).FirstOrDefault() as TextBox
                           ?? this.Controls.Find("textBuscador", true).FirstOrDefault() as TextBox;
                filtro = ctrl?.Text ?? string.Empty;
            }

            Cargar(filtro);
        }

        // Evento del botón "Calcular Pago": muestra en lbxReporte los datos de la fila seleccionada
        private void btnCalcularPago_Click(object sender, EventArgs e)
        {
            var fila = dgvCalculoPagos.CurrentRow;
            if (fila == null)
            {
                MessageBox.Show("Seleccione una fila del empleado antes de calcular.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var empleado = fila.DataBoundItem as CalculoPagoEmpleado;
            if (empleado == null)
            {
                MessageBox.Show("No se pudo obtener la información del empleado seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Solo aplicar cálculo por horas cuando el tipo de pago indique "por hora" (insensible a mayúsculas)
            if (string.IsNullOrWhiteSpace(empleado.TipoPago) || !empleado.TipoPago.Trim().ToLowerInvariant().Contains("hora"))
            {
                MessageBox.Show("Este cálculo sólo aplica a empleados con tipo de pago por hora.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // VALIDACIÓN OBLIGATORIA: horas y días son requeridos para tipo por hora
            if (string.IsNullOrWhiteSpace(txtHorasTrabajadas.Text) || string.IsNullOrWhiteSpace(txtDiasTrajados.Text))
            {
                MessageBox.Show("Para empleados por hora, los campos 'Horas Trabajadas' y 'Días Trabajados' son obligatorios.", "Datos faltantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Leer inputs: horas, dias, deducciones
            var culture = CultureInfo.CurrentCulture;
            decimal horasTrabajadas = 0m;
            decimal diasTrabajados = 0m;
            decimal deducciones = 0m;

            if (!decimal.TryParse(txtHorasTrabajadas.Text.Trim(), NumberStyles.Number, culture, out horasTrabajadas))
            {
                MessageBox.Show("Ingrese un número válido en Horas Trabajadas.", "Dato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtDiasTrajados.Text.Trim(), NumberStyles.Number, culture, out diasTrabajados))
            {
                MessageBox.Show("Ingrese un número válido en Días Trabajados.", "Dato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!string.IsNullOrWhiteSpace(txtDeducciones.Text) &&
                !decimal.TryParse(txtDeducciones.Text.Trim(), NumberStyles.Currency | NumberStyles.Number, culture, out deducciones))
            {
                MessageBox.Show("Ingrese un número válido en Deducciones.", "Dato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lógica de cálculo
            const decimal LIMITE_MENSUAL = 176m;
            decimal salarioBase = empleado.SalarioBase; // se asume salario por hora
            if (salarioBase <= 0m)
            {
                MessageBox.Show("Salario base invalido para este cargo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            decimal horasExtra = Math.Max(0m, horasTrabajadas - LIMITE_MENSUAL);
            decimal horasNormales = Math.Max(0m, horasTrabajadas - horasExtra);

            decimal pagoNormal = horasNormales * salarioBase;
            // CORRECCIÓN: cada hora extra vale 2 dólares fijos (no multiplicado por salarioBase)
            decimal pagoHorasExtra = horasExtra * 2m;
            decimal pagoTotal = pagoNormal + pagoHorasExtra - deducciones;

            // Redondeo a 2 decimales
            pagoNormal = Math.Round(pagoNormal, 2);
            pagoHorasExtra = Math.Round(pagoHorasExtra, 2);
            pagoTotal = Math.Round(pagoTotal, 2);

            // Poblar lbxReporte (viene del Designer)
            if (lbxReporte == null)
            {
                MessageBox.Show("Control lbxReporte no encontrado en el formulario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lbxReporte.BeginUpdate();
            try
            {
                lbxReporte.Items.Clear();
                lbxReporte.Items.Add($"Nombre: {empleado.NombreEmpleado}");
                lbxReporte.Items.Add($"Código: {empleado.CodigoEmpleado}");
                lbxReporte.Items.Add($"Cargo: {empleado.Cargo}");
                lbxReporte.Items.Add($"Tipo Pago: {empleado.TipoPago}");
                lbxReporte.Items.Add($"Salario Base (por hora): {salarioBase.ToString("C", culture)}");
                lbxReporte.Items.Add($"Horas trabajadas: {horasTrabajadas}");
                lbxReporte.Items.Add($"Días trabajados: {diasTrabajados}");
                lbxReporte.Items.Add($"Horas extra: {horasExtra}");
                lbxReporte.Items.Add($"Pago normal: {pagoNormal.ToString("C", culture)}");
                lbxReporte.Items.Add($"Pago horas extra (2$ por hora): {pagoHorasExtra.ToString("C", culture)}");
                lbxReporte.Items.Add($"Deducciones: {deducciones.ToString("C", culture)}");
                lbxReporte.Items.Add($"Pago Total: {pagoTotal.ToString("C", culture)}");
            }
            finally
            {
                lbxReporte.EndUpdate();
            }
        }

        // Evento para formatear la columna calculada "Tipo Pago" según el cargo
        private void dgvCalculoPagos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Actualmente no necesita lógica adicional porque la columna está enlazada a TipoPago.
            // Si quieres formateos especiales (por ejemplo traducciones o iconos) puedes hacerlo aquí.
        }


        // --- métodos existentes de navegación y UI (no modificados) ---
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

        private void CalculoPagos_Load(object sender, EventArgs e)
        {

        }
    }
}
