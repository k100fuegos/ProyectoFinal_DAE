using SistemaControlPersonal.Core.Dao;
using SistemaControlPersonal.Core.Enums;
using System.Globalization;
using CoreCargos = SistemaControlPersonal.Core.Clases.Cargos;

namespace SistemaControlPersonal.Formularios.CCargos
{
    public partial class CargosAniadir : Form
    {
        private readonly CargosDao _dao = new CargosDao();
        private ComboBox? _cmbTipoPago;

        public CargosAniadir()
        {
            InitializeComponent();
            Load += CargosAniadir_Load;
            btnAceptar.Click += BtnAceptar_Click;
        }

        private void CargosAniadir_Load(object? sender, EventArgs e)
        {
            // Buscar ComboBox existente en el diseñador (por nombre o por tipo)
            _cmbTipoPago = Controls.Find("cmbTipoPago", true).OfType<ComboBox>().FirstOrDefault()
                          ?? groupBox1.Controls.OfType<ComboBox>().FirstOrDefault()
                          ?? Controls.Find("comboBox1", true).OfType<ComboBox>().FirstOrDefault();

            // Si no existe ComboBox pero existe textBox3 (diseñador antiguo), lo reemplazamos por uno nuevo
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

            // Poblamos el combo con los nombres del enum
            if (_cmbTipoPago != null)
            {
                _cmbTipoPago.Items.Clear();
                foreach (var name in Enum.GetNames(typeof(TiposPagos)))
                    _cmbTipoPago.Items.Add(name);

                if (_cmbTipoPago.Items.Count > 0)
                    _cmbTipoPago.SelectedIndex = 0;
            }
        }

        private void BtnAceptar_Click(object? sender, EventArgs e)
        {
            try
            {
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

                var tipoPago = _cmbTipoPago?.SelectedItem?.ToString() ?? string.Empty;

                // Nuevo: tomar la descripción desde el control correspondiente (textBox1 según diseñador)
                var descripcion = textBox1.Text?.Trim() ?? string.Empty;

                // Usar el tipo de datos del modelo (CoreCargos) para evitar ambigüedad con el Form 'Cargos'
                var cargo = new CoreCargos
                {
                    NombreCargo = nombre,
                    Descripcion = descripcion,
                    SalarioBase = salario,
                    TipoPago = tipoPago
                };

                var id = _dao.Insert(cargo);
                if (id > 0)
                {
                    MessageBox.Show("Cargo guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    new Formularios.CCargos.Cargos().Show();
                }
                else
                {
                    MessageBox.Show("No se pudo guardar el cargo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el cargo:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
