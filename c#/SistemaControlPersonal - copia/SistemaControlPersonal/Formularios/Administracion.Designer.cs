namespace SistemaControlPersonal.Formularios
{
    partial class Administracion
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
            btnCerrar = new PictureBox();
            pictureBox1 = new PictureBox();
            btnVolver = new PictureBox();
            btnEmpleados = new PictureBox();
            btnCargos = new PictureBox();
            btnMinimizar = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)btnCerrar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnVolver).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnEmpleados).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnCargos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnMinimizar).BeginInit();
            SuspendLayout();
            // 
            // btnCerrar
            // 
            btnCerrar.Cursor = Cursors.Hand;
            btnCerrar.Image = Properties.Resources.cerrar;
            btnCerrar.Location = new Point(826, 9);
            btnCerrar.Margin = new Padding(3, 2, 3, 2);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(26, 22);
            btnCerrar.SizeMode = PictureBoxSizeMode.Zoom;
            btnCerrar.TabIndex = 12;
            btnCerrar.TabStop = false;
            btnCerrar.Click += pictureBox2_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.LogoPNG1;
            pictureBox1.InitialImage = Properties.Resources.LogoPNG;
            pictureBox1.Location = new Point(60, 135);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(175, 150);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 11;
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
            btnVolver.TabIndex = 13;
            btnVolver.TabStop = false;
            btnVolver.Click += btnVolver_Click;
            // 
            // btnEmpleados
            // 
            btnEmpleados.Cursor = Cursors.Hand;
            btnEmpleados.Image = Properties.Resources.btnEmpleados;
            btnEmpleados.Location = new Point(371, 108);
            btnEmpleados.Margin = new Padding(3, 2, 3, 2);
            btnEmpleados.Name = "btnEmpleados";
            btnEmpleados.Size = new Size(315, 90);
            btnEmpleados.SizeMode = PictureBoxSizeMode.Zoom;
            btnEmpleados.TabIndex = 17;
            btnEmpleados.TabStop = false;
            btnEmpleados.Click += pictureBox7_Click;
            // 
            // btnCargos
            // 
            btnCargos.Cursor = Cursors.Hand;
            btnCargos.Image = Properties.Resources.btnCargos;
            btnCargos.Location = new Point(371, 241);
            btnCargos.Margin = new Padding(3, 2, 3, 2);
            btnCargos.Name = "btnCargos";
            btnCargos.Size = new Size(315, 90);
            btnCargos.SizeMode = PictureBoxSizeMode.Zoom;
            btnCargos.TabIndex = 18;
            btnCargos.TabStop = false;
            btnCargos.Click += pictureBox4_Click;
            // 
            // btnMinimizar
            // 
            btnMinimizar.Cursor = Cursors.Hand;
            btnMinimizar.Image = Properties.Resources.minimizar;
            btnMinimizar.Location = new Point(794, 9);
            btnMinimizar.Margin = new Padding(3, 2, 3, 2);
            btnMinimizar.Name = "btnMinimizar";
            btnMinimizar.Size = new Size(26, 22);
            btnMinimizar.SizeMode = PictureBoxSizeMode.Zoom;
            btnMinimizar.TabIndex = 21;
            btnMinimizar.TabStop = false;
            btnMinimizar.Click += btnMinimizar_Click;
            // 
            // Administracion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(27, 25, 25);
            ClientSize = new Size(863, 430);
            Controls.Add(btnMinimizar);
            Controls.Add(btnCargos);
            Controls.Add(btnEmpleados);
            Controls.Add(btnVolver);
            Controls.Add(btnCerrar);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            Name = "Administracion";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PaginaPrincipal";
            ((System.ComponentModel.ISupportInitialize)btnCerrar).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnVolver).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnEmpleados).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnCargos).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnMinimizar).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox btnCerrar;
        private PictureBox pictureBox1;
        private PictureBox btnVolver;
        private PictureBox btnEmpleados;
        private PictureBox btnCargos;
        private PictureBox btnMinimizar;
    }
}