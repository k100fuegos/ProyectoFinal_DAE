namespace SistemaControlPersonal.Formularios
{
    partial class PaginaPrincipal
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
            pictureBox7 = new PictureBox();
            pictureBox4 = new PictureBox();
            pictureBox5 = new PictureBox();
            pictureBox6 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)btnCerrar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnVolver).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            SuspendLayout();
            // 
            // btnCerrar
            // 
            btnCerrar.Cursor = Cursors.Hand;
            btnCerrar.Image = Properties.Resources.cerrar;
            btnCerrar.Location = new Point(944, 12);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(30, 30);
            btnCerrar.SizeMode = PictureBoxSizeMode.Zoom;
            btnCerrar.TabIndex = 12;
            btnCerrar.TabStop = false;
            btnCerrar.Click += pictureBox2_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.LogoPNG1;
            pictureBox1.InitialImage = Properties.Resources.LogoPNG;
            pictureBox1.Location = new Point(69, 180);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(200, 200);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 11;
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
            btnVolver.TabIndex = 13;
            btnVolver.TabStop = false;
            btnVolver.Click += btnVolver_Click;
            // 
            // pictureBox7
            // 
            pictureBox7.Cursor = Cursors.Hand;
            pictureBox7.Image = Properties.Resources.btnAsistencias1;
            pictureBox7.Location = new Point(406, 37);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(400, 120);
            pictureBox7.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox7.TabIndex = 17;
            pictureBox7.TabStop = false;
            pictureBox7.Click += pictureBox7_Click;
            // 
            // pictureBox4
            // 
            pictureBox4.Cursor = Cursors.Hand;
            pictureBox4.Image = Properties.Resources.btnConsultasReportes;
            pictureBox4.Location = new Point(406, 163);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(400, 120);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 18;
            pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            pictureBox5.Cursor = Cursors.Hand;
            pictureBox5.Image = Properties.Resources.btnCalculoPagos;
            pictureBox5.Location = new Point(406, 289);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(400, 120);
            pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox5.TabIndex = 19;
            pictureBox5.TabStop = false;
            // 
            // pictureBox6
            // 
            pictureBox6.Cursor = Cursors.Hand;
            pictureBox6.Image = Properties.Resources.btnAdministracion;
            pictureBox6.Location = new Point(406, 415);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(400, 120);
            pictureBox6.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox6.TabIndex = 20;
            pictureBox6.TabStop = false;
            // 
            // PaginaPrincipal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(27, 25, 25);
            ClientSize = new Size(986, 574);
            Controls.Add(pictureBox6);
            Controls.Add(pictureBox5);
            Controls.Add(pictureBox4);
            Controls.Add(pictureBox7);
            Controls.Add(btnVolver);
            Controls.Add(btnCerrar);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "PaginaPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PaginaPrincipal";
            ((System.ComponentModel.ISupportInitialize)btnCerrar).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnVolver).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox btnCerrar;
        private PictureBox pictureBox1;
        private PictureBox btnVolver;
        private PictureBox pictureBox7;
        private PictureBox pictureBox4;
        private PictureBox pictureBox5;
        private PictureBox pictureBox6;
    }
}