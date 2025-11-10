namespace SistemaControlPersonal.Formularios
{
    partial class CalculoPagos
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
            panel1 = new Panel();
            pictureBox3 = new PictureBox();
            dgvCalculoPagos = new DataGridView();
            txtBusqueda = new TextBox();
            btnMinimizar = new PictureBox();
            panel2 = new Panel();
            txtDiasTrajados = new TextBox();
            lblblb4 = new Label();
            panel3 = new Panel();
            txtHorasTrabajadas = new TextBox();
            label1 = new Label();
            panel5 = new Panel();
            txtDeducciones = new TextBox();
            label3 = new Label();
            label4 = new Label();
            lbxReporte = new ListBox();
            groupBox1 = new GroupBox();
            btnCalcularPago = new Button();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnVolver).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnCerrar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvCalculoPagos).BeginInit();
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
            pictureBox2.Location = new Point(1111, 9);
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
            btnCerrar.Location = new Point(1175, 9);
            btnCerrar.Margin = new Padding(3, 2, 3, 2);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(26, 22);
            btnCerrar.SizeMode = PictureBoxSizeMode.Zoom;
            btnCerrar.TabIndex = 20;
            btnCerrar.TabStop = false;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(255, 206, 0);
            panel1.Location = new Point(58, 176);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(496, 5);
            panel1.TabIndex = 21;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.busqueda;
            pictureBox3.Location = new Point(528, 150);
            pictureBox3.Margin = new Padding(3, 2, 3, 2);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(26, 22);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 22;
            pictureBox3.TabStop = false;
            // 
            // dgvCalculoPagos
            // 
            dgvCalculoPagos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCalculoPagos.Location = new Point(58, 185);
            dgvCalculoPagos.Margin = new Padding(3, 2, 3, 2);
            dgvCalculoPagos.Name = "dgvCalculoPagos";
            dgvCalculoPagos.RowHeadersWidth = 51;
            dgvCalculoPagos.Size = new Size(501, 400);
            dgvCalculoPagos.TabIndex = 23;
            // 
            // txtBusqueda
            // 
            txtBusqueda.BackColor = Color.FromArgb(27, 25, 25);
            txtBusqueda.BorderStyle = BorderStyle.None;
            txtBusqueda.Cursor = Cursors.IBeam;
            txtBusqueda.Font = new Font("Segoe UI", 12F);
            txtBusqueda.ForeColor = Color.FromArgb(254, 254, 254);
            txtBusqueda.Location = new Point(58, 152);
            txtBusqueda.Margin = new Padding(3, 2, 3, 2);
            txtBusqueda.Name = "txtBusqueda";
            txtBusqueda.Size = new Size(444, 22);
            txtBusqueda.TabIndex = 30;
            txtBusqueda.TextChanged += txtBusqueda_TextChanged;
            // 
            // btnMinimizar
            // 
            btnMinimizar.Cursor = Cursors.Hand;
            btnMinimizar.Image = Properties.Resources.minimizar;
            btnMinimizar.Location = new Point(1143, 9);
            btnMinimizar.Margin = new Padding(3, 2, 3, 2);
            btnMinimizar.Name = "btnMinimizar";
            btnMinimizar.Size = new Size(26, 22);
            btnMinimizar.SizeMode = PictureBoxSizeMode.Zoom;
            btnMinimizar.TabIndex = 31;
            btnMinimizar.TabStop = false;
            btnMinimizar.Click += btnMinimizar_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(255, 206, 0);
            panel2.Location = new Point(580, 271);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(169, 4);
            panel2.TabIndex = 34;
            // 
            // txtDiasTrajados
            // 
            txtDiasTrajados.BackColor = Color.FromArgb(27, 25, 25);
            txtDiasTrajados.BorderStyle = BorderStyle.None;
            txtDiasTrajados.Cursor = Cursors.IBeam;
            txtDiasTrajados.Font = new Font("Segoe UI", 12F);
            txtDiasTrajados.ForeColor = Color.FromArgb(254, 254, 254);
            txtDiasTrajados.Location = new Point(580, 250);
            txtDiasTrajados.Margin = new Padding(3, 2, 3, 2);
            txtDiasTrajados.Name = "txtDiasTrajados";
            txtDiasTrajados.Size = new Size(157, 22);
            txtDiasTrajados.TabIndex = 33;
            // 
            // lblblb4
            // 
            lblblb4.AutoSize = true;
            lblblb4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblblb4.ForeColor = Color.FromArgb(239, 239, 239);
            lblblb4.Location = new Point(580, 226);
            lblblb4.Name = "lblblb4";
            lblblb4.Size = new Size(127, 21);
            lblblb4.TabIndex = 32;
            lblblb4.Text = "Dias Trabajados:";
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(255, 206, 0);
            panel3.Location = new Point(580, 198);
            panel3.Margin = new Padding(3, 2, 3, 2);
            panel3.Name = "panel3";
            panel3.Size = new Size(167, 4);
            panel3.TabIndex = 37;
            // 
            // txtHorasTrabajadas
            // 
            txtHorasTrabajadas.BackColor = Color.FromArgb(27, 25, 25);
            txtHorasTrabajadas.BorderStyle = BorderStyle.None;
            txtHorasTrabajadas.Cursor = Cursors.IBeam;
            txtHorasTrabajadas.Font = new Font("Segoe UI", 12F);
            txtHorasTrabajadas.ForeColor = Color.FromArgb(254, 254, 254);
            txtHorasTrabajadas.Location = new Point(580, 174);
            txtHorasTrabajadas.Margin = new Padding(3, 2, 3, 2);
            txtHorasTrabajadas.Name = "txtHorasTrabajadas";
            txtHorasTrabajadas.Size = new Size(179, 22);
            txtHorasTrabajadas.TabIndex = 36;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(239, 239, 239);
            label1.Location = new Point(580, 150);
            label1.Name = "label1";
            label1.Size = new Size(138, 21);
            label1.TabIndex = 35;
            label1.Text = "Horas Trabajadas:";
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(255, 206, 0);
            panel5.Location = new Point(580, 342);
            panel5.Margin = new Padding(3, 2, 3, 2);
            panel5.Name = "panel5";
            panel5.Size = new Size(167, 4);
            panel5.TabIndex = 40;
            // 
            // txtDeducciones
            // 
            txtDeducciones.BackColor = Color.FromArgb(27, 25, 25);
            txtDeducciones.BorderStyle = BorderStyle.None;
            txtDeducciones.Cursor = Cursors.IBeam;
            txtDeducciones.Font = new Font("Segoe UI", 12F);
            txtDeducciones.ForeColor = Color.FromArgb(254, 254, 254);
            txtDeducciones.Location = new Point(580, 317);
            txtDeducciones.Margin = new Padding(3, 2, 3, 2);
            txtDeducciones.Name = "txtDeducciones";
            txtDeducciones.Size = new Size(179, 22);
            txtDeducciones.TabIndex = 39;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(239, 239, 239);
            label3.Location = new Point(580, 293);
            label3.Name = "label3";
            label3.Size = new Size(108, 21);
            label3.TabIndex = 38;
            label3.Text = "Deducciones:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label4.ForeColor = Color.FromArgb(239, 239, 239);
            label4.Location = new Point(58, 112);
            label4.Name = "label4";
            label4.Size = new Size(140, 21);
            label4.TabIndex = 41;
            label4.Text = "Buscar empleado:";
            // 
            // lbxReporte
            // 
            lbxReporte.BackColor = Color.FromArgb(27, 25, 25);
            lbxReporte.BorderStyle = BorderStyle.None;
            lbxReporte.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbxReporte.ForeColor = Color.FromArgb(254, 254, 254);
            lbxReporte.FormattingEnabled = true;
            lbxReporte.ItemHeight = 21;
            lbxReporte.Location = new Point(18, 22);
            lbxReporte.Name = "lbxReporte";
            lbxReporte.Size = new Size(354, 462);
            lbxReporte.TabIndex = 42;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lbxReporte);
            groupBox1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = Color.FromArgb(254, 254, 254);
            groupBox1.Location = new Point(774, 90);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(395, 495);
            groupBox1.TabIndex = 43;
            groupBox1.TabStop = false;
            groupBox1.Text = "Reporte de pago";
            // 
            // btnCalcularPago
            // 
            btnCalcularPago.BackColor = Color.FromArgb(27, 25, 25);
            btnCalcularPago.FlatAppearance.BorderColor = Color.FromArgb(255, 206, 0);
            btnCalcularPago.FlatAppearance.BorderSize = 2;
            btnCalcularPago.FlatStyle = FlatStyle.Flat;
            btnCalcularPago.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold);
            btnCalcularPago.ForeColor = Color.FromArgb(254, 254, 254);
            btnCalcularPago.Location = new Point(580, 409);
            btnCalcularPago.Margin = new Padding(3, 2, 3, 2);
            btnCalcularPago.Name = "btnCalcularPago";
            btnCalcularPago.Size = new Size(169, 125);
            btnCalcularPago.TabIndex = 56;
            btnCalcularPago.Text = "Calcular Pago";
            btnCalcularPago.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold);
            label5.ForeColor = Color.FromArgb(239, 239, 239);
            label5.Location = new Point(563, 9);
            label5.Name = "label5";
            label5.Size = new Size(196, 37);
            label5.TabIndex = 57;
            label5.Text = "Calcular pagos";
            // 
            // CalculoPagos
            // 
            AccessibleRole = AccessibleRole.Client;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(27, 25, 25);
            ClientSize = new Size(1212, 625);
            Controls.Add(label5);
            Controls.Add(btnCalcularPago);
            Controls.Add(groupBox1);
            Controls.Add(label4);
            Controls.Add(panel5);
            Controls.Add(txtDeducciones);
            Controls.Add(label3);
            Controls.Add(panel3);
            Controls.Add(txtHorasTrabajadas);
            Controls.Add(panel2);
            Controls.Add(label1);
            Controls.Add(txtDiasTrajados);
            Controls.Add(lblblb4);
            Controls.Add(btnMinimizar);
            Controls.Add(txtBusqueda);
            Controls.Add(dgvCalculoPagos);
            Controls.Add(pictureBox3);
            Controls.Add(panel1);
            Controls.Add(btnCerrar);
            Controls.Add(pictureBox2);
            Controls.Add(btnVolver);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            MinimizeBox = false;
            Name = "CalculoPagos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Asistencias";
            Load += CalculoPagos_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnVolver).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnCerrar).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvCalculoPagos).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnMinimizar).EndInit();
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private PictureBox btnVolver;
        private PictureBox pictureBox2;
        private PictureBox btnCerrar;
        private Panel panel1;
        private PictureBox pictureBox3;
        private DataGridView dgvCalculoPagos;
        private TextBox txtBusqueda;
        private PictureBox btnMinimizar;
        private Panel panel2;
        private TextBox txtDiasTrajados;
        private Label lblblb4;
        private Panel panel3;
        private TextBox txtHorasTrabajadas;
        private Label label1;
        private Panel panel5;
        private TextBox txtDeducciones;
        private Label label3;
        private Label label4;
        private ListBox lbxReporte;
        private GroupBox groupBox1;
        private Button btnCalcularPago;
        private Label label5;
    }
}