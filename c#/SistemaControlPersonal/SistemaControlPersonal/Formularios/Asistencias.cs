using PracticaVehiculo.Core.Enums;
using SistemaControlPersonal.Core.Clases;
using SistemaControlPersonal.Core.Dao;
using System.Data;
using System.Globalization;

namespace SistemaControlPersonal.Formularios
{
    // Módulo: Gestión de asistencias
    // Responsabilidad: mostrar listado de empleados con su asistencias, permitir registrar nueva asistencia y mostrar detalles seleccionados.
    public partial class frmAsistencias : Form
    {
        public frmAsistencias()
        {
            InitializeComponent();
        }

        // DAO responsable de acceso a datos de asistencias
        private AsistenciasDao AsistenciasDao = new AsistenciasDao();

        // Módulo: Configuración del DataGridView
        // Propósito: definir columnas (Name para acceso en Cells, DataPropertyName para enlace a la entidad Asistencias).
        private void ConfiguracionGrid()
        {
            dgvAsistencias.AutoGenerateColumns = false;
            dgvAsistencias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAsistencias.MultiSelect = false;
            dgvAsistencias.Columns.Clear();

            dgvAsistencias.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "codigo_empleadoCol",
                HeaderText = "Código",
                DataPropertyName = "CodigoExterno", // mostrar el código visible en la UI
                MinimumWidth = 60
            });

            dgvAsistencias.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "nombre_empleadoCol",
                HeaderText = "Nombre",
                DataPropertyName = "NombreEmpleado",
                MinimumWidth = 120
            });

            dgvAsistencias.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "cargoCol",
                HeaderText = "Cargo",
                DataPropertyName = "Cargo",
                MinimumWidth = 100
            });

            dgvAsistencias.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "estado_asistenciaCol",
                HeaderText = "Estado",
                DataPropertyName = "Estado_asistencia",
                MinimumWidth = 80
            });

            dgvAsistencias.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "notaCol",
                HeaderText = "Nota",
                DataPropertyName = "Nota",
                MinimumWidth = 100
            });

            dgvAsistencias.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "fechaCol",
                HeaderText = "Fecha",
                DataPropertyName = "Fecha",
                MinimumWidth = 90
            });

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

        // Módulo: Cargar datos
        // Propósito: obtener lista de asistencias desde DAO y enlazarla al grid.
        private void Cargar(string filtro = "", DateTime? fechaFiltro = null)
        {
            try
            {
                List<Asistencias> list;
                if (fechaFiltro.HasValue)
                {
                    list = AsistenciasDao.GetAll(string.Empty, fechaFiltro);
                }
                else
                {
                    list = AsistenciasDao.GetAll(filtro);
                }

                if (!string.IsNullOrWhiteSpace(filtro))
                {
                    string f = filtro.Trim();
                    list = list.Where(a =>
                        (!string.IsNullOrWhiteSpace(a.NombreEmpleado) && a.NombreEmpleado.IndexOf(f, StringComparison.OrdinalIgnoreCase) >= 0)
                        || (!string.IsNullOrWhiteSpace(a.CodigoExterno) && a.CodigoExterno.IndexOf(f, StringComparison.OrdinalIgnoreCase) >= 0)
                    ).ToList();
                }

                dgvAsistencias.DataSource = list;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar asistencias:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgvAsistencias.DataSource = null;
            }
            finally
            {
                dgvAsistencias.ClearSelection();
                dgvAsistencias.CurrentCell = null;
            }
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

        private void btnCerrar_Click_1(object sender, EventArgs e)
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

        private void btnMinimizar_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            new Formularios.PaginaPrincipal().Show();
        }

        // Módulo: Validación de entrada de fecha y disparo de carga
        private void btnIniciar_Click(object sender, EventArgs e)
        {
            var textoFecha = mtxtFecha.Text?.Trim();
            if (string.IsNullOrWhiteSpace(textoFecha) || textoFecha.Contains("-") || textoFecha.Contains(" "))
            {
                MessageBox.Show("Ingrese una fecha válida en el campo Fecha.", "Fecha requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!DateTime.TryParseExact(textoFecha, "dd/MM/yyyy", CultureInfo.CurrentCulture, DateTimeStyles.None, out var fecha))
            {
                MessageBox.Show("Formato de fecha inválido. Use dd/MM/yyyy.", "Fecha inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Cargar(string.Empty, fecha.Date);
        }

        private void btnVolver_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            new Formularios.PaginaPrincipal().Show();
        }

        // Módulo: Guardar nueva asistencia
        // Propósito: validar selección y datos, construir objeto Asistencias y persistir mediante DAO.
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (dgvAsistencias.SelectedRows == null || dgvAsistencias.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un trabajador en la lista.", "Selección requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var fila = dgvAsistencias.SelectedRows[0];

            // Obtener ID real del empleado desde el objeto enlazado, no desde la celda visible
            int idEmpleado;
            if (fila.DataBoundItem is Asistencias bound)
            {
                idEmpleado = bound.CodigoEmpleado;
            }
            else
            {
                object valId = fila.Cells["codigo_empleadoCol"].Value;
                if (valId == null || !int.TryParse(valId.ToString(), out idEmpleado))
                {
                    MessageBox.Show("No se pudo obtener el ID del empleado seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            var textoFecha = mtxtFecha.Text?.Trim();
            if (string.IsNullOrWhiteSpace(textoFecha) || !DateTime.TryParseExact(textoFecha, "dd/MM/yyyy", CultureInfo.CurrentCulture, DateTimeStyles.None, out var fechaSeleccionada))
            {
                MessageBox.Show("Ingrese una fecha válida en el campo Fecha (dd/MM/yyyy).", "Fecha inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nota = string.IsNullOrWhiteSpace(txtComentario.Text) ? null : txtComentario.Text.Trim();

            EstadoAsistencia estadoEnum;
            if (rbtPresente.Checked)
                estadoEnum = EstadoAsistencia.Presente;
            else if (rbtAusente.Checked)
                estadoEnum = EstadoAsistencia.Ausente;
            else if (rbtTarde.Checked)
                estadoEnum = EstadoAsistencia.Tarde;
            else if (rbtJustificado.Checked)
                estadoEnum = EstadoAsistencia.Justificado;
            else
            {
                MessageBox.Show("Seleccione un estado de asistencia.", "Estado requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool existe;
            try
            {
                existe = AsistenciasDao.ExistsAttendance(idEmpleado, fechaSeleccionada.Date);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al verificar existencia de asistencia:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (existe)
            {
                MessageBox.Show("Ya existe una asistencia registrada para ese empleado en la fecha indicada.", "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var nueva = new Asistencias
            {
                CodigoEmpleado = idEmpleado,
                Fecha = fechaSeleccionada.ToString("yyyy-MM-dd"),
                Estado_asistencia = estadoEnum.ToString(),
                Nota = nota
            };

            try
            {
                var idInsertado = AsistenciasDao.Insert(nueva);
                if (idInsertado > 0)
                {
                    MessageBox.Show("Asistencia registrada correctamente.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Cargar(string.Empty, fechaSeleccionada.Date);
                }
                else
                {
                    MessageBox.Show("No se pudo registrar la asistencia.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar la asistencia:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Módulo: Inicialización del formulario
        private void frmAsistencias_Load(object sender, EventArgs e)
        {
            ConfiguracionGrid();
        }

        // Módulo: Sincronización UI al cambiar selección en grid
        // Propósito: leer las celdas visibles (por Name de columna) y actualizar controles (radiobuttons, comentario).
        private void dgvAsistencias_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvAsistencias.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvAsistencias.SelectedRows[0];

                string estadoActual = selectedRow.Cells["estado_asistenciaCol"].Value?.ToString() ?? "no registrada";
                string notaActual = selectedRow.Cells["notaCol"].Value?.ToString() ?? "Ninguna";

                rbtPresente.Checked = false;
                rbtTarde.Checked = false;
                rbtAusente.Checked = false;
                rbtJustificado.Checked = false;

                if (estadoActual.Equals("Presente", StringComparison.OrdinalIgnoreCase))
                {
                    rbtPresente.Checked = true;
                }
                else if (estadoActual.Equals("Tarde", StringComparison.OrdinalIgnoreCase))
                {
                    rbtTarde.Checked = true;
                }
                else if (estadoActual.Equals("Ausente", StringComparison.OrdinalIgnoreCase))
                {
                    rbtAusente.Checked = true;
                }
                else if (estadoActual.Equals("Justificado", StringComparison.OrdinalIgnoreCase))
                {
                    rbtJustificado.Checked = true;
                }

                if (notaActual.Equals("Ninguna", StringComparison.OrdinalIgnoreCase))
                {
                    txtComentario.Text = string.Empty;
                }
                else
                {
                    txtComentario.Text = notaActual;
                }
            }
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            string filtro = string.Empty;
            if (sender is TextBox tb)
            {
                filtro = tb.Text ?? string.Empty;
            }
            else
            {
                var ctrl = this.Controls.Find("txtBusqueda", true).FirstOrDefault() as TextBox;
                filtro = ctrl?.Text ?? string.Empty;
            }

            DateTime? fechaFiltro = null;
            var textoFecha = mtxtFecha.Text?.Trim();
            if (!string.IsNullOrWhiteSpace(textoFecha) && DateTime.TryParseExact(textoFecha, "dd/MM/yyyy", CultureInfo.CurrentCulture, DateTimeStyles.None, out var fecha))
            {
                fechaFiltro = fecha.Date;
            }

            Cargar(filtro, fechaFiltro);
        }
    }
}
