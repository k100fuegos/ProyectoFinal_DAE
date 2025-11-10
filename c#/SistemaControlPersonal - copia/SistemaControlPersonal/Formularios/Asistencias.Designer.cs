namespace SistemaControlPersonal.Formularios
{
    partial class frmAsistencias
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
            btnIniciar = new Button();
            mtxtFecha = new MaskedTextBox();
            panel3 = new Panel();
            btnMinimizar = new PictureBox();
            label1 = new Label();
            txtBusqueda = new TextBox();
            groupBox1 = new GroupBox();
            rbtJustificado = new RadioButton();
            rbtAusente = new RadioButton();
            rbtTarde = new RadioButton();
            rbtPresente = new RadioButton();
            btnAceptar = new Button();
            panel2 = new Panel();
            txtComentario = new TextBox();
            lblblb4 = new Label();
            dgvAsistencias = new DataGridView();
            pictureBox3 = new PictureBox();
            panel1 = new Panel();
            btnCerrar = new PictureBox();
            pictureBox2 = new PictureBox();
            btnVolver = new PictureBox();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)btnMinimizar).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAsistencias).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnCerrar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnVolver).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnIniciar
            // 
            btnIniciar.BackColor = Color.FromArgb(27, 25, 25);
            btnIniciar.FlatAppearance.BorderColor = Color.FromArgb(255, 206, 0);
            btnIniciar.FlatAppearance.BorderSize = 2;
            btnIniciar.FlatStyle = FlatStyle.Flat;
            btnIniciar.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnIniciar.ForeColor = Color.FromArgb(254, 254, 254);
            btnIniciar.Location = new Point(604, 24);
            btnIniciar.Margin = new Padding(3, 2, 3, 2);
            btnIniciar.Name = "btnIniciar";
            btnIniciar.Size = new Size(194, 61);
            btnIniciar.TabIndex = 43;
            btnIniciar.Text = "Iniciar asistencia del dia";
            btnIniciar.UseVisualStyleBackColor = false;
            btnIniciar.Click += btnIniciar_Click;
            // 
            // mtxtFecha
            // 
            mtxtFecha.BackColor = Color.FromArgb(27, 25, 25);
            mtxtFecha.BorderStyle = BorderStyle.None;
            mtxtFecha.Font = new Font("Segoe UI", 12F);
            mtxtFecha.ForeColor = Color.FromArgb(255, 206, 0);
            mtxtFecha.Location = new Point(444, 48);
            mtxtFecha.Mask = "00/00/0000";
            mtxtFecha.Name = "mtxtFecha";
            mtxtFecha.PromptChar = '-';
            mtxtFecha.Size = new Size(139, 22);
            mtxtFecha.TabIndex = 46;
            mtxtFecha.ValidatingType = typeof(DateTime);
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(255, 206, 0);
            panel3.Location = new Point(444, 75);
            panel3.Margin = new Padding(3, 2, 3, 2);
            panel3.Name = "panel3";
            panel3.Size = new Size(139, 5);
            panel3.TabIndex = 34;
            // 
            // btnMinimizar
            // 
            btnMinimizar.Cursor = Cursors.Hand;
            btnMinimizar.Image = Properties.Resources.minimizar;
            btnMinimizar.Location = new Point(1144, 25);
            btnMinimizar.Margin = new Padding(3, 2, 3, 2);
            btnMinimizar.Name = "btnMinimizar";
            btnMinimizar.Size = new Size(26, 22);
            btnMinimizar.SizeMode = PictureBoxSizeMode.Zoom;
            btnMinimizar.TabIndex = 45;
            btnMinimizar.TabStop = false;
            btnMinimizar.Click += btnMinimizar_Click_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(239, 239, 239);
            label1.Location = new Point(441, 24);
            label1.Name = "label1";
            label1.Size = new Size(109, 21);
            label1.TabIndex = 33;
            label1.Text = "Fecha del dia:";
            // 
            // txtBusqueda
            // 
            txtBusqueda.BackColor = Color.FromArgb(27, 25, 25);
            txtBusqueda.BorderStyle = BorderStyle.None;
            txtBusqueda.Cursor = Cursors.IBeam;
            txtBusqueda.Font = new Font("Segoe UI", 12F);
            txtBusqueda.ForeColor = Color.FromArgb(254, 254, 254);
            txtBusqueda.Location = new Point(59, 132);
            txtBusqueda.Margin = new Padding(3, 2, 3, 2);
            txtBusqueda.Name = "txtBusqueda";
            txtBusqueda.Size = new Size(739, 22);
            txtBusqueda.TabIndex = 44;
            txtBusqueda.TextChanged += txtBusqueda_TextChanged;
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
            groupBox1.Location = new Point(857, 156);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(344, 445);
            groupBox1.TabIndex = 42;
            groupBox1.TabStop = false;
            groupBox1.Text = "Asistencia";
            // 
            // rbtJustificado
            // 
            rbtJustificado.AutoSize = true;
            rbtJustificado.Location = new Point(62, 203);
            rbtJustificado.Margin = new Padding(3, 2, 3, 2);
            rbtJustificado.Name = "rbtJustificado";
            rbtJustificado.Size = new Size(137, 34);
            rbtJustificado.TabIndex = 29;
            rbtJustificado.TabStop = true;
            rbtJustificado.Text = "Justificado";
            rbtJustificado.UseVisualStyleBackColor = true;
            // 
            // rbtAusente
            // 
            rbtAusente.AutoSize = true;
            rbtAusente.Location = new Point(62, 155);
            rbtAusente.Margin = new Padding(3, 2, 3, 2);
            rbtAusente.Name = "rbtAusente";
            rbtAusente.Size = new Size(113, 34);
            rbtAusente.TabIndex = 28;
            rbtAusente.TabStop = true;
            rbtAusente.Text = "Ausente";
            rbtAusente.UseVisualStyleBackColor = true;
            // 
            // rbtTarde
            // 
            rbtTarde.AutoSize = true;
            rbtTarde.Location = new Point(62, 105);
            rbtTarde.Margin = new Padding(3, 2, 3, 2);
            rbtTarde.Name = "rbtTarde";
            rbtTarde.Size = new Size(85, 34);
            rbtTarde.TabIndex = 27;
            rbtTarde.TabStop = true;
            rbtTarde.Text = "Tarde";
            rbtTarde.UseVisualStyleBackColor = true;
            // 
            // rbtPresente
            // 
            rbtPresente.AutoSize = true;
            rbtPresente.Location = new Point(62, 51);
            rbtPresente.Margin = new Padding(3, 2, 3, 2);
            rbtPresente.Name = "rbtPresente";
            rbtPresente.Size = new Size(118, 34);
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
            btnAceptar.Location = new Point(219, 387);
            btnAceptar.Margin = new Padding(3, 2, 3, 2);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(106, 32);
            btnAceptar.TabIndex = 25;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = false;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(255, 206, 0);
            panel2.Location = new Point(19, 327);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(306, 4);
            panel2.TabIndex = 8;
            // 
            // txtComentario
            // 
            txtComentario.BackColor = Color.FromArgb(27, 25, 25);
            txtComentario.BorderStyle = BorderStyle.None;
            txtComentario.Cursor = Cursors.IBeam;
            txtComentario.Font = new Font("Segoe UI", 12F);
            txtComentario.ForeColor = Color.FromArgb(254, 254, 254);
            txtComentario.Location = new Point(19, 302);
            txtComentario.Margin = new Padding(3, 2, 3, 2);
            txtComentario.Name = "txtComentario";
            txtComentario.Size = new Size(306, 22);
            txtComentario.TabIndex = 7;
            // 
            // lblblb4
            // 
            lblblb4.AutoSize = true;
            lblblb4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblblb4.ForeColor = Color.FromArgb(239, 239, 239);
            lblblb4.Location = new Point(19, 278);
            lblblb4.Name = "lblblb4";
            lblblb4.Size = new Size(100, 21);
            lblblb4.TabIndex = 6;
            lblblb4.Text = "Comentario:";
            // 
            // dgvAsistencias
            // 
            dgvAsistencias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAsistencias.Location = new Point(59, 174);
            dgvAsistencias.Margin = new Padding(3, 2, 3, 2);
            dgvAsistencias.Name = "dgvAsistencias";
            dgvAsistencias.RowHeadersWidth = 51;
            dgvAsistencias.Size = new Size(771, 427);
            dgvAsistencias.TabIndex = 41;
            dgvAsistencias.SelectionChanged += dgvAsistencias_SelectionChanged;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.busqueda;
            pictureBox3.Location = new Point(803, 129);
            pictureBox3.Margin = new Padding(3, 2, 3, 2);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(26, 22);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 40;
            pictureBox3.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(255, 206, 0);
            panel1.Location = new Point(59, 156);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(774, 4);
            panel1.TabIndex = 39;
            // 
            // btnCerrar
            // 
            btnCerrar.Cursor = Cursors.Hand;
            btnCerrar.Image = Properties.Resources.cerrar;
            btnCerrar.Location = new Point(1176, 25);
            btnCerrar.Margin = new Padding(3, 2, 3, 2);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(26, 22);
            btnCerrar.SizeMode = PictureBoxSizeMode.Zoom;
            btnCerrar.TabIndex = 38;
            btnCerrar.TabStop = false;
            btnCerrar.Click += btnCerrar_Click_1;
            // 
            // pictureBox2
            // 
            pictureBox2.Cursor = Cursors.Hand;
            pictureBox2.Image = Properties.Resources.Home;
            pictureBox2.Location = new Point(1112, 25);
            pictureBox2.Margin = new Padding(3, 2, 3, 2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(26, 22);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 37;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click_1;
            // 
            // btnVolver
            // 
            btnVolver.Cursor = Cursors.Hand;
            btnVolver.Image = Properties.Resources.Volver;
            btnVolver.Location = new Point(11, 25);
            btnVolver.Margin = new Padding(3, 2, 3, 2);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(26, 22);
            btnVolver.SizeMode = PictureBoxSizeMode.Zoom;
            btnVolver.TabIndex = 36;
            btnVolver.TabStop = false;
            btnVolver.Click += btnVolver_Click_1;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.LogoPNG1;
            pictureBox1.InitialImage = Properties.Resources.LogoPNG;
            pictureBox1.Location = new Point(59, 25);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(91, 72);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 35;
            pictureBox1.TabStop = false;
            // 
            // frmAsistencias
            // 
            AccessibleRole = AccessibleRole.Client;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(27, 25, 25);
            ClientSize = new Size(1212, 625);
            Controls.Add(btnIniciar);
            Controls.Add(mtxtFecha);
            Controls.Add(panel3);
            Controls.Add(btnMinimizar);
            Controls.Add(label1);
            Controls.Add(txtBusqueda);
            Controls.Add(groupBox1);
            Controls.Add(dgvAsistencias);
            Controls.Add(pictureBox3);
            Controls.Add(panel1);
            Controls.Add(btnCerrar);
            Controls.Add(pictureBox2);
            Controls.Add(btnVolver);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            MinimizeBox = false;
            Name = "frmAsistencias";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Asistencias";
            Load += frmAsistencias_Load;
            ((System.ComponentModel.ISupportInitialize)btnMinimizar).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAsistencias).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnCerrar).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnVolver).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnIniciar;
        private MaskedTextBox mtxtFecha;
        private Panel panel3;
        private PictureBox btnMinimizar;
        private Label label1;
        private TextBox txtBusqueda;
        private GroupBox groupBox1;
        private RadioButton rbtJustificado;
        private RadioButton rbtAusente;
        private RadioButton rbtTarde;
        private RadioButton rbtPresente;
        private Button btnAceptar;
        private Panel panel2;
        private TextBox txtComentario;
        private Label lblblb4;
        private DataGridView dgvAsistencias;
        private PictureBox pictureBox3;
        private Panel panel1;
        private PictureBox btnCerrar;
        private PictureBox pictureBox2;
        private PictureBox btnVolver;
        private PictureBox pictureBox1;
    }
}