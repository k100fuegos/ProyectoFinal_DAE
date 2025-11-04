namespace SistemaControlPersonal.Formularios
{
    partial class Asistencias
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox1 = new PictureBox();
            btnVolver = new PictureBox();
            pictureBox7 = new PictureBox();
            pictureBox2 = new PictureBox();
            btnCerrar = new PictureBox();
            panel1 = new Panel();
            pictureBox3 = new PictureBox();
            dgvAsistencias = new DataGridView();
            groupBox1 = new GroupBox();
            rbtJustificado = new RadioButton();
            rbtAusente = new RadioButton();
            rbtTarde = new RadioButton();
            rbtPresente = new RadioButton();
            btnAceptar = new Button();
            panel2 = new Panel();
            txtComentario = new TextBox();
            lblblb4 = new Label();
            txtBusqueda = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnVolver).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnCerrar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvAsistencias).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.LogoPNG1;
            pictureBox1.InitialImage = Properties.Resources.LogoPNG;
            pictureBox1.Location = new Point(66, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(104, 96);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 12;
            pictureBox1.TabStop = false;
            // 
            // btnVolver
            // 
            btnVolver.Cursor = Cursors.Hand;
            btnVolver.Image = Properties.Resources.Volver;
            btnVolver.Location = new Point(12, 12);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(30, 30);
            btnVolver.SizeMode = PictureBoxSizeMode.Zoom;
            btnVolver.TabIndex = 14;
            btnVolver.TabStop = false;
            btnVolver.Click += btnVolver_Click;
            // 
            // pictureBox7
            // 
            pictureBox7.Cursor = Cursors.Hand;
            pictureBox7.Image = Properties.Resources.btnTerminarAsistenciaDelDia;
            pictureBox7.Location = new Point(419, 12);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(531, 94);
            pictureBox7.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox7.TabIndex = 18;
            pictureBox7.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Cursor = Cursors.Hand;
            pictureBox2.Image = Properties.Resources.Home;
            pictureBox2.Location = new Point(1307, 12);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(30, 30);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 19;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.Cursor = Cursors.Hand;
            btnCerrar.Image = Properties.Resources.cerrar;
            btnCerrar.Location = new Point(1343, 12);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(30, 30);
            btnCerrar.SizeMode = PictureBoxSizeMode.Zoom;
            btnCerrar.TabIndex = 20;
            btnCerrar.TabStop = false;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(255, 206, 0);
            panel1.Location = new Point(66, 187);
            panel1.Name = "panel1";
            panel1.Size = new Size(884, 5);
            panel1.TabIndex = 21;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.busqueda;
            pictureBox3.Location = new Point(917, 151);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(30, 30);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 22;
            pictureBox3.TabStop = false;
            // 
            // dgvAsistencias
            // 
            dgvAsistencias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAsistencias.Location = new Point(66, 211);
            dgvAsistencias.Name = "dgvAsistencias";
            dgvAsistencias.RowHeadersWidth = 51;
            dgvAsistencias.Size = new Size(881, 414);
            dgvAsistencias.TabIndex = 23;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rbtJustificado);
            groupBox1.Controls.Add(rbtAusente);
            groupBox1.Controls.Add(rbtTarde);
            groupBox1.Controls.Add(rbtPresente);
            groupBox1.Controls.Add(btnAceptar);
            groupBox1.Controls.Add(panel2);
            groupBox1.Controls.Add(txtComentario);
            groupBox1.Controls.Add(lblblb4);
            groupBox1.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = Color.FromArgb(254, 254, 254);
            groupBox1.Location = new Point(980, 70);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(393, 555);
            groupBox1.TabIndex = 24;
            groupBox1.TabStop = false;
            groupBox1.Text = "Asistencia";
            // 
            // rbtJustificado
            // 
            rbtJustificado.AutoSize = true;
            rbtJustificado.Location = new Point(71, 272);
            rbtJustificado.Name = "rbtJustificado";
            rbtJustificado.Size = new Size(173, 42);
            rbtJustificado.TabIndex = 29;
            rbtJustificado.TabStop = true;
            rbtJustificado.Text = "Justificado";
            rbtJustificado.UseVisualStyleBackColor = true;
            // 
            // rbtAusente
            // 
            rbtAusente.AutoSize = true;
            rbtAusente.Location = new Point(71, 208);
            rbtAusente.Name = "rbtAusente";
            rbtAusente.Size = new Size(141, 42);
            rbtAusente.TabIndex = 28;
            rbtAusente.TabStop = true;
            rbtAusente.Text = "Ausente";
            rbtAusente.UseVisualStyleBackColor = true;
            // 
            // rbtTarde
            // 
            rbtTarde.AutoSize = true;
            rbtTarde.Location = new Point(71, 141);
            rbtTarde.Name = "rbtTarde";
            rbtTarde.Size = new Size(107, 42);
            rbtTarde.TabIndex = 27;
            rbtTarde.TabStop = true;
            rbtTarde.Text = "Tarde";
            rbtTarde.UseVisualStyleBackColor = true;
            // 
            // rbtPresente
            // 
            rbtPresente.AutoSize = true;
            rbtPresente.Location = new Point(71, 69);
            rbtPresente.Name = "rbtPresente";
            rbtPresente.Size = new Size(147, 42);
            rbtPresente.TabIndex = 26;
            rbtPresente.TabStop = true;
            rbtPresente.Text = "Presente";
            rbtPresente.UseVisualStyleBackColor = true;
            // 
            // btnAceptar
            // 
            btnAceptar.BackColor = Color.FromArgb(27, 25, 25);
            btnAceptar.FlatAppearance.BorderColor = Color.FromArgb(255, 206, 0);
            btnAceptar.FlatAppearance.BorderSize = 2;
            btnAceptar.FlatStyle = FlatStyle.Flat;
            btnAceptar.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAceptar.ForeColor = Color.FromArgb(254, 254, 254);
            btnAceptar.Location = new Point(251, 490);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(121, 42);
            btnAceptar.TabIndex = 25;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(255, 206, 0);
            panel2.Location = new Point(22, 436);
            panel2.Name = "panel2";
            panel2.Size = new Size(350, 5);
            panel2.TabIndex = 8;
            // 
            // txtComentario
            // 
            txtComentario.BackColor = Color.FromArgb(27, 25, 25);
            txtComentario.BorderStyle = BorderStyle.None;
            txtComentario.Cursor = Cursors.IBeam;
            txtComentario.Font = new Font("Segoe UI", 12F);
            txtComentario.ForeColor = Color.FromArgb(254, 254, 254);
            txtComentario.Location = new Point(22, 403);
            txtComentario.Name = "txtComentario";
            txtComentario.Size = new Size(350, 27);
            txtComentario.TabIndex = 7;
            // 
            // lblblb4
            // 
            lblblb4.AutoSize = true;
            lblblb4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblblb4.ForeColor = Color.FromArgb(239, 239, 239);
            lblblb4.Location = new Point(22, 372);
            lblblb4.Name = "lblblb4";
            lblblb4.Size = new Size(123, 28);
            lblblb4.TabIndex = 6;
            lblblb4.Text = "Comentario:";
            // 
            // txtBusqueda
            // 
            txtBusqueda.BackColor = Color.FromArgb(27, 25, 25);
            txtBusqueda.BorderStyle = BorderStyle.None;
            txtBusqueda.Cursor = Cursors.IBeam;
            txtBusqueda.Font = new Font("Segoe UI", 12F);
            txtBusqueda.ForeColor = Color.FromArgb(254, 254, 254);
            txtBusqueda.Location = new Point(66, 154);
            txtBusqueda.Name = "txtBusqueda";
            txtBusqueda.Size = new Size(845, 27);
            txtBusqueda.TabIndex = 30;
            // 
            // Asistencias
            // 
            AccessibleRole = AccessibleRole.Client;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(27, 25, 25);
            ClientSize = new Size(1385, 661);
            Controls.Add(txtBusqueda);
            Controls.Add(groupBox1);
            Controls.Add(dgvAsistencias);
            Controls.Add(pictureBox3);
            Controls.Add(panel1);
            Controls.Add(btnCerrar);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox7);
            Controls.Add(btnVolver);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Asistencias";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Asistencias";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnVolver).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnCerrar).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvAsistencias).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private PictureBox btnVolver;
        private PictureBox pictureBox7;
        private PictureBox pictureBox2;
        private PictureBox btnCerrar;
        private Panel panel1;
        private PictureBox pictureBox3;
        private DataGridView dgvAsistencias;
        private GroupBox groupBox1;
        private Panel panel2;
        private TextBox txtComentario;
        private Label lblblb4;
        private RadioButton rbtPresente;
        private Button btnAceptar;
        private RadioButton rbtJustificado;
        private RadioButton rbtAusente;
        private RadioButton rbtTarde;
        private TextBox txtBusqueda;
    }
}