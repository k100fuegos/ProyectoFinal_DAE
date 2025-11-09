using PracticaVehiculo.Core.Enums;
using SistemaControlPersonal.Core.Clases;
using SistemaControlPersonal.Core.Dao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaControlPersonal.Formularios
{
    public partial class frmAsistencias : Form
    {
        public frmAsistencias()
        {
            InitializeComponent();
        }

        private AsistenciasDao AsistenciasDao = new AsistenciasDao();


        private void ConfiguracionGrid()
        {
            dgvAsistencias.AutoGenerateColumns = false;
            dgvAsistencias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAsistencias.MultiSelect = false;
            dgvAsistencias.Columns.Clear();

            // Orden: primero datos del trabajador, luego datos de la asistencia
            dgvAsistencias.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "codigo_empleadoCol",
                HeaderText = "Código",
                DataPropertyName = "CodigoEmpleado",
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

            // Ahora los campos de asistencia
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

            // Ajuste proporcional automático: usar AutoSizeMode = Fill y repartir el ancho según el número de columnas.
            // Se asigna el mismo peso a todas las columnas; si necesitas proporciones distintas, modifica los pesos.
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



        private void Cargar(string filtro = "", DateTime? fechaFiltro = null)
        {
            try
            {
                dgvAsistencias.DataSource = AsistenciasDao.GetAll(filtro, fechaFiltro);
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

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            var textoFecha = mtxtFecha.Text?.Trim();
            if (string.IsNullOrWhiteSpace(textoFecha) || textoFecha.Contains("-") || textoFecha.Contains(" "))
            {
                MessageBox.Show("Ingrese una fecha válida en el campo Fecha.", "Fecha requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Parsear con formato de la máscara
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

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            // Verificar fila seleccionada
            if (dgvAsistencias.SelectedRows == null || dgvAsistencias.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un trabajador en la lista.", "Selección requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var fila = dgvAsistencias.SelectedRows[0];

            // Obtener id del empleado desde la celda de código
            object valId = fila.Cells["codigo_empleadoCol"].Value;
            if (valId == null || !int.TryParse(valId.ToString(), out int idEmpleado))
            {
                MessageBox.Show("No se pudo obtener el ID del empleado seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validar fecha
            var textoFecha = mtxtFecha.Text?.Trim();
            if (string.IsNullOrWhiteSpace(textoFecha) || !DateTime.TryParseExact(textoFecha, "dd/MM/yyyy", CultureInfo.CurrentCulture, DateTimeStyles.None, out var fechaSeleccionada))
            {
                MessageBox.Show("Ingrese una fecha válida en el campo Fecha (dd/MM/yyyy).", "Fecha inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtener nota desde txtComentario (control existente en el diseñador)
            string nota = string.IsNullOrWhiteSpace(txtComentario.Text) ? null : txtComentario.Text.Trim();

            // Determinar estado según radiobuttons (usa el enum de PracticaVehiculo.Core.Enums)
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

            // Verificar duplicado
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

            // Crear objeto y guardar
            var nueva = new Asistencias
            {
                CodigoEmpleado = idEmpleado,
                Fecha = fechaSeleccionada.ToString("yyyy-MM-dd"),
                Estado_asistencia = estadoEnum.ToString(), // almacenamos el nombre del enum
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
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar la asistencia:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmAsistencias_Load(object sender, EventArgs e)
        {
            ConfiguracionGrid();
        }
    }
}
