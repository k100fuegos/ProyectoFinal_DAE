namespace SistemaControlPersonal.Formularios
{
    partial class Empleados
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
            dgvEmpleados = new DataGridView();
            txtBusqueda = new TextBox();
            btnMinimizar = new PictureBox();
            btnAniadirEmpleados = new PictureBox();
            btnModificarEmpleado = new PictureBox();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnVolver).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnCerrar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvEmpleados).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnMinimizar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnAniadirEmpleados).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnModificarEmpleado).BeginInit();
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
            panel1.Location = new Point(58, 142);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(843, 5);
            panel1.TabIndex = 21;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.busqueda;
            pictureBox3.Location = new Point(875, 113);
            pictureBox3.Margin = new Padding(3, 2, 3, 2);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(26, 22);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 22;
            pictureBox3.TabStop = false;
            // 
            // dgvEmpleados
            // 
            dgvEmpleados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEmpleados.Location = new Point(58, 158);
            dgvEmpleados.Margin = new Padding(3, 2, 3, 2);
            dgvEmpleados.Name = "dgvEmpleados";
            dgvEmpleados.RowHeadersWidth = 51;
            dgvEmpleados.Size = new Size(847, 427);
            dgvEmpleados.TabIndex = 23;
            // 
            // txtBusqueda
            // 
            txtBusqueda.BackColor = Color.FromArgb(27, 25, 25);
            txtBusqueda.BorderStyle = BorderStyle.None;
            txtBusqueda.Cursor = Cursors.IBeam;
            txtBusqueda.Font = new Font("Segoe UI", 12F);
            txtBusqueda.ForeColor = Color.FromArgb(254, 254, 254);
            txtBusqueda.Location = new Point(58, 116);
            txtBusqueda.Margin = new Padding(3, 2, 3, 2);
            txtBusqueda.Name = "txtBusqueda";
            txtBusqueda.Size = new Size(812, 22);
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
            // btnAniadirEmpleados
            // 
            btnAniadirEmpleados.Cursor = Cursors.Hand;
            btnAniadirEmpleados.Image = Properties.Resources.btnAniadirEmpleado;
            btnAniadirEmpleados.Location = new Point(937, 219);
            btnAniadirEmpleados.Margin = new Padding(3, 2, 3, 2);
            btnAniadirEmpleados.Name = "btnAniadirEmpleados";
            btnAniadirEmpleados.Size = new Size(264, 70);
            btnAniadirEmpleados.SizeMode = PictureBoxSizeMode.Zoom;
            btnAniadirEmpleados.TabIndex = 18;
            btnAniadirEmpleados.TabStop = false;
            btnAniadirEmpleados.Click += btnAniadirEmpleados_Click;
            // 
            // btnModificarEmpleado
            // 
            btnModificarEmpleado.Cursor = Cursors.Hand;
            btnModificarEmpleado.Image = Properties.Resources.btnModificarEmpleado;
            btnModificarEmpleado.Location = new Point(937, 341);
            btnModificarEmpleado.Margin = new Padding(3, 2, 3, 2);
            btnModificarEmpleado.Name = "btnModificarEmpleado";
            btnModificarEmpleado.Size = new Size(264, 70);
            btnModificarEmpleado.SizeMode = PictureBoxSizeMode.Zoom;
            btnModificarEmpleado.TabIndex = 32;
            btnModificarEmpleado.TabStop = false;
            btnModificarEmpleado.Click += btnModificarEmpleado_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(239, 239, 239);
            label2.Location = new Point(496, 9);
            label2.Name = "label2";
            label2.Size = new Size(150, 37);
            label2.TabIndex = 33;
            label2.Text = "Empleados";
            // 
            // Empleados
            // 
            AccessibleRole = AccessibleRole.Client;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(27, 25, 25);
            ClientSize = new Size(1212, 625);
            Controls.Add(label2);
            Controls.Add(btnModificarEmpleado);
            Controls.Add(btnMinimizar);
            Controls.Add(txtBusqueda);
            Controls.Add(dgvEmpleados);
            Controls.Add(pictureBox3);
            Controls.Add(panel1);
            Controls.Add(btnCerrar);
            Controls.Add(pictureBox2);
            Controls.Add(btnAniadirEmpleados);
            Controls.Add(btnVolver);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            MinimizeBox = false;
            Name = "Empleados";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Empleados";
            Load += Empleados_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnVolver).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnCerrar).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvEmpleados).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnMinimizar).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnAniadirEmpleados).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnModificarEmpleado).EndInit();
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
        private DataGridView dgvEmpleados;
        private TextBox txtBusqueda;
        private PictureBox btnMinimizar;
        private PictureBox btnAniadirEmpleados;
        private PictureBox btnModificarEmpleado;
        private Label label2;
    }
}