namespace SistemaControlPersonal.Formularios.CCargos
{
    partial class CargosEditar
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
            pictureBox2 = new PictureBox();
            btnCerrar = new PictureBox();
            btnMinimizar = new PictureBox();
            groupBox1 = new GroupBox();
            label3 = new Label();
            panel3 = new Panel();
            textBox2 = new TextBox();
            label2 = new Label();
            panel1 = new Panel();
            textBox1 = new TextBox();
            label1 = new Label();
            btnAceptar = new Button();
            panel2 = new Panel();
            txtComentario = new TextBox();
            lblblb4 = new Label();
            cbxTipoPago = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnVolver).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnCerrar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnMinimizar).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.LogoPNG1;
            pictureBox1.InitialImage = Properties.Resources.LogoPNG;
            pictureBox1.Location = new Point(58, 9);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(91, 72);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 12;
            pictureBox1.TabStop = false;
            // 
            // btnVolver
            // 
            btnVolver.Cursor = Cursors.Hand;
            btnVolver.Image = Properties.Resources.Volver;
            btnVolver.Location = new Point(10, 9);
            btnVolver.Margin = new Padding(3, 2, 3, 2);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(26, 22);
            btnVolver.SizeMode = PictureBoxSizeMode.Zoom;
            btnVolver.TabIndex = 14;
            btnVolver.TabStop = false;
            btnVolver.Click += btnVolver_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Cursor = Cursors.Hand;
            pictureBox2.Image = Properties.Resources.Home;
            pictureBox2.Location = new Point(679, 9);
            pictureBox2.Margin = new Padding(3, 2, 3, 2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(26, 22);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 19;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.Cursor = Cursors.Hand;
            btnCerrar.Image = Properties.Resources.cerrar;
            btnCerrar.Location = new Point(743, 9);
            btnCerrar.Margin = new Padding(3, 2, 3, 2);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(26, 22);
            btnCerrar.SizeMode = PictureBoxSizeMode.Zoom;
            btnCerrar.TabIndex = 20;
            btnCerrar.TabStop = false;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // btnMinimizar
            // 
            btnMinimizar.Cursor = Cursors.Hand;
            btnMinimizar.Image = Properties.Resources.minimizar;
            btnMinimizar.Location = new Point(710, 9);
            btnMinimizar.Margin = new Padding(3, 2, 3, 2);
            btnMinimizar.Name = "btnMinimizar";
            btnMinimizar.Size = new Size(26, 22);
            btnMinimizar.SizeMode = PictureBoxSizeMode.Zoom;
            btnMinimizar.TabIndex = 31;
            btnMinimizar.TabStop = false;
            btnMinimizar.Click += btnMinimizar_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cbxTipoPago);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(panel3);
            groupBox1.Controls.Add(textBox2);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(panel1);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(btnAceptar);
            groupBox1.Controls.Add(panel2);
            groupBox1.Controls.Add(txtComentario);
            groupBox1.Controls.Add(lblblb4);
            groupBox1.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = Color.FromArgb(254, 254, 254);
            groupBox1.Location = new Point(181, 61);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(398, 519);
            groupBox1.TabIndex = 32;
            groupBox1.TabStop = false;
            groupBox1.Text = "Editar cargo";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(239, 239, 239);
            label3.Location = new Point(19, 284);
            label3.Name = "label3";
            label3.Size = new Size(116, 21);
            label3.TabIndex = 32;
            label3.Text = "Tipo de pago: ";
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(255, 206, 0);
            panel3.Location = new Point(19, 254);
            panel3.Margin = new Padding(3, 2, 3, 2);
            panel3.Name = "panel3";
            panel3.Size = new Size(306, 4);
            panel3.TabIndex = 31;
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.FromArgb(27, 25, 25);
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.Cursor = Cursors.IBeam;
            textBox2.Font = new Font("Segoe UI", 12F);
            textBox2.ForeColor = Color.FromArgb(254, 254, 254);
            textBox2.Location = new Point(19, 229);
            textBox2.Margin = new Padding(3, 2, 3, 2);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(306, 22);
            textBox2.TabIndex = 30;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(239, 239, 239);
            label2.Location = new Point(19, 205);
            label2.Name = "label2";
            label2.Size = new Size(105, 21);
            label2.TabIndex = 29;
            label2.Text = "Salario base: ";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(255, 206, 0);
            panel1.Location = new Point(19, 184);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(306, 4);
            panel1.TabIndex = 28;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.FromArgb(27, 25, 25);
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Cursor = Cursors.IBeam;
            textBox1.Font = new Font("Segoe UI", 12F);
            textBox1.ForeColor = Color.FromArgb(254, 254, 254);
            textBox1.Location = new Point(19, 159);
            textBox1.Margin = new Padding(3, 2, 3, 2);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(306, 22);
            textBox1.TabIndex = 27;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(239, 239, 239);
            label1.Location = new Point(19, 135);
            label1.Name = "label1";
            label1.Size = new Size(100, 21);
            label1.TabIndex = 26;
            label1.Text = "Descripcion:";
            // 
            // btnAceptar
            // 
            btnAceptar.BackColor = Color.FromArgb(27, 25, 25);
            btnAceptar.FlatAppearance.BorderColor = Color.FromArgb(255, 206, 0);
            btnAceptar.FlatAppearance.BorderSize = 2;
            btnAceptar.FlatStyle = FlatStyle.Flat;
            btnAceptar.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAceptar.ForeColor = Color.FromArgb(254, 254, 254);
            btnAceptar.Location = new Point(148, 433);
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
            panel2.Location = new Point(19, 107);
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
            txtComentario.Location = new Point(19, 82);
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
            lblblb4.Location = new Point(19, 58);
            lblblb4.Name = "lblblb4";
            lblblb4.Size = new Size(75, 21);
            lblblb4.TabIndex = 6;
            lblblb4.Text = "Nombre:";
            // 
            // cbxTipoPago
            // 
            cbxTipoPago.BackColor = Color.FromArgb(27, 25, 25);
            cbxTipoPago.ForeColor = Color.FromArgb(254, 254, 254);
            cbxTipoPago.FormattingEnabled = true;
            cbxTipoPago.Items.AddRange(new object[] { "Activo", "Inactivo" });
            cbxTipoPago.Location = new Point(19, 321);
            cbxTipoPago.Name = "cbxTipoPago";
            cbxTipoPago.Size = new Size(200, 38);
            cbxTipoPago.TabIndex = 82;
            // 
            // CargosEditar
            // 
            AccessibleRole = AccessibleRole.Client;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(27, 25, 25);
            ClientSize = new Size(780, 618);
            Controls.Add(groupBox1);
            Controls.Add(btnMinimizar);
            Controls.Add(btnCerrar);
            Controls.Add(pictureBox2);
            Controls.Add(btnVolver);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            MinimizeBox = false;
            Name = "CargosEditar";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Empleados";
            Load += CargosEditar_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnVolver).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnCerrar).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnMinimizar).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private PictureBox btnVolver;
        private PictureBox pictureBox2;
        private PictureBox btnCerrar;
        private PictureBox btnMinimizar;
        private GroupBox groupBox1;
        private Button btnAceptar;
        private Panel panel2;
        private TextBox txtComentario;
        private Label lblblb4;
        private Label label3;
        private Panel panel3;
        private TextBox textBox2;
        private Label label2;
        private Panel panel1;
        private TextBox textBox1;
        private Label label1;
        private ComboBox cbxTipoPago;
    }
}