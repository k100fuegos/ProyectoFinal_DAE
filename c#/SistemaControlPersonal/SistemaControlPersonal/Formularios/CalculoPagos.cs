using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
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

            // conectar el evento del botón Calcular Pago (si no está enlazado en el diseñador)
            if (this.Controls.Find("btnCalcularPago", true).FirstOrDefault() is Button btnCalc)
                btnCalc.Click += btnCalcularPago_Click;
            else
                btnCalcularPago.Click += btnCalcularPago_Click; // por seguridad, usar el campo si existe

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

            // Nuevo: columna calculada para Tipo de Pago (según cargo)
            dgvCalculoPagos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "tipoPagoCol",
                HeaderText = "Tipo Pago",
                // No enlazado a DataPropertyName porque se calcula dinámicamente
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

            // Formateo dinámico para mostrar Tipo de Pago según Cargo
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
                        // Buscar por código (contiene), nombre y cargo (ignorando mayúsculas/minúsculas)
                        e.CodigoEmpleado.ToString().IndexOf(f, StringComparison.OrdinalIgnoreCase) >= 0
                        || (!string.IsNullOrWhiteSpace(e.NombreEmpleado) && e.NombreEmpleado.IndexOf(f, StringComparison.OrdinalIgnoreCase) >= 0)
                        || (!string.IsNullOrWhiteSpace(e.Cargo) && e.Cargo.IndexOf(f, StringComparison.OrdinalIgnoreCase) >= 0)
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

        // --- nuevo: generación de reporte y cálculo (horas extra calculadas a partir de horas trabajadas) ---
        private void btnCalcularPago_Click(object sender, EventArgs e)
        {
            lbxReporte.Items.Clear();

            // Obtener empleado seleccionado
            if (dgvCalculoPagos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un empleado en la tabla para generar el reporte.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var row = dgvCalculoPagos.SelectedRows[0];
            var empleadoObj = row.DataBoundItem;
            if (empleadoObj == null)
            {
                MessageBox.Show("No se pudo obtener el empleado seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Helpers para leer propiedades con reflexión (evita compilar contra campos inexistentes)
            object GetProp(params string[] names)
            {
                var t = empleadoObj.GetType();
                foreach (var n in names)
                {
                    var p = t.GetProperty(n);
                    if (p != null) return p.GetValue(empleadoObj);
                }
                return null;
            }

            string nombre = (GetProp("NombreEmpleado", "Nombre") ?? "").ToString();
            string codigo = (GetProp("CodigoEmpleado", "Id", "Codigo") ?? "").ToString();
            string cargo = (GetProp("Cargo") ?? "").ToString();

            // Salario base y tipo de pago: se intentan leer; si no existen, se avisará
            object salarioObj = GetProp("SalarioBase", "Salario", "Sueldo", "SueldoBase");
            object tipoPagoObj = GetProp("TipoPago", "PagoTipo", "PagoPor", "PagoPorHora", "Pago");

            if (salarioObj == null || tipoPagoObj == null)
            {
                MessageBox.Show(
                    "Faltan datos en el registro del empleado. Asegúrese de que exista al menos una propiedad 'SalarioBase' (o 'Salario','Sueldo') y una 'TipoPago' (por ejemplo 'mes' o 'hora').",
                    "Datos insuficientes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal salarioBase = 0m;
            if (!decimal.TryParse(salarioObj.ToString(), out salarioBase)) salarioBase = 0m;

            // normalizar tipo de pago
            string tipoPagoRaw = tipoPagoObj.ToString().ToLowerInvariant();
            bool pagoPorHora = tipoPagoRaw.Contains("hora") || tipoPagoRaw.Contains("porhora") || tipoPagoRaw.Contains("por hora");
            // si se encuentra un booleano
            if (tipoPagoObj is bool b) pagoPorHora = b;

            // Lectura de campos de la UI para horas, deducciones y dias
            decimal deducciones = 0m;
            decimal.TryParse(txtDeducciones.Text?.Trim(), out deducciones);

            int diasTrabajados = 30;
            int.TryParse(txtDiasTrajados.Text?.Trim(), out diasTrabajados);
            if (diasTrabajados <= 0) diasTrabajados = 30;

            decimal horasInput = 0m;
            decimal.TryParse(txtHorasTrabajadas.Text?.Trim(), out horasInput);

            // Cálculo de horas:
            const decimal limiteMensual = 176m;
            decimal horasTrabajadasBase;
            decimal horasExtrasCalculadas = 0m;

            if (horasInput > 0m)
            {
                // Si el usuario ingresó horas trabajadas, calcular base y extras a partir de ese valor
                if (horasInput > limiteMensual)
                {
                    horasExtrasCalculadas = horasInput - limiteMensual;
                    horasTrabajadasBase = limiteMensual;
                }
                else
                {
                    horasExtrasCalculadas = 0m;
                    horasTrabajadasBase = horasInput;
                }
            }
            else
            {
                // Si no hay horas ingresadas, para pago mensual usamos horas proporcionales por días (o 176 si no se desea proporcionalidad)
                if (!pagoPorHora)
                {
                    horasTrabajadasBase = limiteMensual * (diasTrabajados / 30m);
                    if (horasTrabajadasBase > limiteMensual) horasTrabajadasBase = limiteMensual;
                    horasExtrasCalculadas = 0m;
                }
                else
                {
                    // pago por hora y no ingresó horas -> todo cero
                    horasTrabajadasBase = 0m;
                    horasExtrasCalculadas = 0m;
                }
            }

            // Calcular pago:
            decimal pagoTotal = 0m;
            if (!pagoPorHora)
            {
                // salarioBase entendido como salario mensual
                decimal salarioMensual = salarioBase;
                decimal valorHora = limiteMensual == 0 ? 0m : salarioMensual / limiteMensual;
                decimal pagoHorasExtra = horasExtrasCalculadas * valorHora * 1.5m; // recargo 50%
                pagoTotal = salarioMensual + pagoHorasExtra - deducciones;
            }
            else
            {
                // salarioBase entendido como tarifa por hora
                decimal tarifaHora = salarioBase;
                decimal pagoHoras = horasTrabajadasBase * tarifaHora;
                decimal pagoHorasExtra = horasExtrasCalculadas * tarifaHora * 1.5m;
                pagoTotal = pagoHoras + pagoHorasExtra - deducciones;
            }

            // Rellenar lbxReporte
            lbxReporte.Items.Add($"Nombre: {nombre}");
            lbxReporte.Items.Add($"Código: {codigo}");
            lbxReporte.Items.Add($"Cargo: {cargo}");
            lbxReporte.Items.Add($"Salario base: {salarioBase:C}");
            lbxReporte.Items.Add($"Tipo de pago: {(pagoPorHora ? "Por hora" : "Mensual")}");
            lbxReporte.Items.Add($"Horas trabajadas (base): {horasTrabajadasBase}");
            lbxReporte.Items.Add($"Horas extras: {horasExtrasCalculadas}");
            lbxReporte.Items.Add($"Deducciones: {deducciones:C}");
            lbxReporte.Items.Add($"Pago total: {pagoTotal:C}");
        }

        // Evento para formatear la columna calculada "Tipo Pago" según el cargo
        private void dgvCalculoPagos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvCalculoPagos.Columns[e.ColumnIndex].Name != "tipoPagoCol")
                return;

            var row = dgvCalculoPagos.Rows[e.RowIndex];
            var item = row.DataBoundItem as CalculoPagoEmpleado;
            if (item == null)
            {
                e.Value = string.Empty;
                e.FormattingApplied = true;
                return;
            }

            bool porHora = IsCargoPagoPorHora(item.Cargo);
            e.Value = porHora ? "Por hora" : "Mensual";
            e.FormattingApplied = true;
        }

        // Mapeo simple: ajustar palabras clave según su negocio
        private bool IsCargoPagoPorHora(string cargo)
        {
            if (string.IsNullOrWhiteSpace(cargo)) return false;
            cargo = cargo.ToLowerInvariant();

            // Palabras clave típicas para cargos por hora (modifique según su lista real)
            string[] hourlyKeywords = new[]
            {
                "oper", "obrero", "aux", "téc", "tec", "chofer", "conductor", "vendedor", "temporal", "contrat", "practic"
            };

            foreach (var key in hourlyKeywords)
            {
                if (cargo.Contains(key)) return true;
            }

            return false; // por defecto mensual
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
