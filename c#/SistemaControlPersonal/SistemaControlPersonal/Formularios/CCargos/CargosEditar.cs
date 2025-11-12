using SistemaControlPersonal.Core.Dao;
using SistemaControlPersonal.Core.Enums;
using System.Globalization;
using CoreCargos = SistemaControlPersonal.Core.Clases.Cargos;

namespace SistemaControlPersonal.Formularios.CCargos
{
    public partial class CargosEditar : Form
    {
        private readonly CargosDao _dao = new CargosDao();
        private CoreCargos? _cargo;
        private ComboBox? _cmbTipoPago;

        // Constructor para el diseñador
        public CargosEditar()
        {
            InitializeComponent();
            // No volver a suscribir eventos que ya establece el diseñador en InitializeComponent()
        }

        // Constructor que recibe el cargo a editar
        public CargosEditar(CoreCargos cargo) : this()
        {
            _cargo = cargo;
        }

        private void CargosEditar_Load(object? sender, EventArgs e)
        {
            // localizar ComboBox existente en diseñador (si ya lo colocó)
            _cmbTipoPago = Controls.Find("cmbTipoPago", true).OfType<ComboBox>().FirstOrDefault()
                          ?? groupBox1.Controls.OfType<ComboBox>().FirstOrDefault();

            // si no existe combo, pero existe textBox3 del diseñador, crear un combo en su lugar y ocultar textBox3
            if (_cmbTipoPago == null)
            {
                var tb = Controls.Find("textBox3", true).OfType<TextBox>().FirstOrDefault()
                         ?? groupBox1.Controls.Find("textBox3", true).OfType<TextBox>().FirstOrDefault();
                if (tb != null)
                {
                    var cb = new ComboBox
                    {
                        Name = "cmbTipoPago",
                        DropDownStyle = ComboBoxStyle.DropDownList,
                        BackColor = tb.BackColor,
                        ForeColor = tb.ForeColor,
                        Font = tb.Font,
                        Location = tb.Location,
                        Size = tb.Size
                    };
                    groupBox1.Controls.Add(cb);
                    tb.Visible = false;
                    _cmbTipoPago = cb;
                }
            }

            // Poblar con valores del enum TiposPagos
            if (_cmbTipoPago != null)
            {
                _cmbTipoPago.Items.Clear();
                foreach (var name in Enum.GetNames(typeof(TiposPagos)))
                    _cmbTipoPago.Items.Add(name);
            }

            // Si hay un cargo pasado, rellenar controles
            if (_cargo != null)
            {
                txtComentario.Text = _cargo.NombreCargo ?? string.Empty;
                textBox2.Text = _cargo.SalarioBase.ToString(CultureInfo.InvariantCulture);
                // nuevo: rellenar descripción en el control correspondiente (textBox1 según diseñador)
                textBox1.Text = _cargo.Descripcion ?? string.Empty;

                // establecer selección en el combo si existe
                if (_cmbTipoPago != null)
                {
                    if (!string.IsNullOrEmpty(_cargo.TipoPago))
                    {
                        var idx = _cmbTipoPago.FindStringExact(_cargo.TipoPago);
                        if (idx >= 0) _cmbTipoPago.SelectedIndex = idx;
                        else
                        {
                            _cmbTipoPago.Items.Add(_cargo.TipoPago);
                            _cmbTipoPago.SelectedItem = _cargo.TipoPago;
                        }
                    }
                    else if (_cmbTipoPago.Items.Count > 0)
                    {
                        _cmbTipoPago.SelectedIndex = 0;
                    }
                }
                else
                {
                    // fallback si no existe combo: mostrar en textBox3
                    var tb = Controls.Find("textBox3", true).OfType<TextBox>().FirstOrDefault()
                             ?? groupBox1.Controls.Find("textBox3", true).OfType<TextBox>().FirstOrDefault();
                    if (tb != null) tb.Text = _cargo.TipoPago ?? string.Empty;
                }
            }
            else
            {
                // si no se pasó cargo, seleccionar primer valor del combo
                if (_cmbTipoPago != null && _cmbTipoPago.Items.Count > 0)
                    _cmbTipoPago.SelectedIndex = 0;
            }
        }

        private void btnAceptar_Click(object? sender, EventArgs e)
        {
            try
            {
                if (_cargo == null)
                {
                    MessageBox.Show("No se ha cargado el cargo para editar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var nombre = txtComentario.Text?.Trim() ?? string.Empty;
                if (string.IsNullOrWhiteSpace(nombre))
                {
                    MessageBox.Show("Ingrese el nombre del cargo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var salarioText = textBox2.Text?.Trim() ?? string.Empty;
                if (!double.TryParse(salarioText, NumberStyles.Any, CultureInfo.InvariantCulture, out double salario))
                {
                    MessageBox.Show("Salario base inválido. Use un número válido (ej. 350.50).", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var tipoPago = _cmbTipoPago?.SelectedItem?.ToString()
                               ?? Controls.Find("textBox3", true).OfType<TextBox>().FirstOrDefault()?.Text
                               ?? string.Empty;

                // Nuevo: tomar la descripción desde el control (textBox1 según diseñador)
                var descripcion = textBox1.Text?.Trim() ?? string.Empty;

                // actualizar objeto y persistir
                _cargo.NombreCargo = nombre;
                _cargo.Descripcion = descripcion;
                _cargo.SalarioBase = salario;
                _cargo.TipoPago = tipoPago;

                var ok = _dao.Update(_cargo);
                if (ok)
                {
                    MessageBox.Show("Cargo actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    new Formularios.CCargos.Cargos().Show();
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar el cargo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el cargo:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Formularios.CCargos.Cargos().Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Formularios.PaginaPrincipal().Show();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show(
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
