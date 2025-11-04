namespace SistemaControlPersonal.Formularios
{
    partial class InicioDeSecion
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            textBox1 = new TextBox();
            panel1 = new Panel();
            panel2 = new Panel();
            textBox2 = new TextBox();
            label4 = new Label();
            btnIniciarSecion = new Button();
            btnCerrar = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnCerrar).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.LogoPNG1;
            pictureBox1.InitialImage = Properties.Resources.LogoPNG;
            pictureBox1.Location = new Point(38, 114);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(200, 200);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 35F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(239, 239, 239);
            label1.Location = new Point(338, 27);
            label1.Name = "label1";
            label1.Size = new Size(355, 78);
            label1.TabIndex = 1;
            label1.Text = "Bienvenidos";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(239, 239, 239);
            label2.Location = new Point(389, 105);
            label2.Name = "label2";
            label2.Size = new Size(258, 46);
            label2.TabIndex = 2;
            label2.Text = "Inicio de secion";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(239, 239, 239);
            label3.Location = new Point(292, 173);
            label3.Name = "label3";
            label3.Size = new Size(86, 28);
            label3.TabIndex = 3;
            label3.Text = "Usuario:";
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.FromArgb(27, 25, 25);
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Cursor = Cursors.IBeam;
            textBox1.Font = new Font("Segoe UI", 12F);
            textBox1.ForeColor = Color.FromArgb(254, 254, 254);
            textBox1.Location = new Point(384, 174);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(350, 27);
            textBox1.TabIndex = 4;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(255, 206, 0);
            panel1.Location = new Point(384, 207);
            panel1.Name = "panel1";
            panel1.Size = new Size(350, 5);
            panel1.TabIndex = 5;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(255, 206, 0);
            panel2.Location = new Point(384, 294);
            panel2.Name = "panel2";
            panel2.Size = new Size(350, 5);
            panel2.TabIndex = 8;
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.FromArgb(27, 25, 25);
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.Cursor = Cursors.IBeam;
            textBox2.Font = new Font("Segoe UI", 12F);
            textBox2.ForeColor = Color.FromArgb(254, 254, 254);
            textBox2.Location = new Point(389, 261);
            textBox2.Name = "textBox2";
            textBox2.PasswordChar = '*';
            textBox2.Size = new Size(350, 27);
            textBox2.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label4.ForeColor = Color.FromArgb(239, 239, 239);
            label4.Location = new Point(264, 260);
            label4.Name = "label4";
            label4.Size = new Size(119, 28);
            label4.TabIndex = 6;
            label4.Text = "Contraseña:";
            // 
            // btnIniciarSecion
            // 
            btnIniciarSecion.BackColor = Color.FromArgb(27, 25, 25);
            btnIniciarSecion.FlatAppearance.BorderColor = Color.FromArgb(255, 206, 0);
            btnIniciarSecion.FlatAppearance.BorderSize = 2;
            btnIniciarSecion.FlatStyle = FlatStyle.Flat;
            btnIniciarSecion.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnIniciarSecion.ForeColor = Color.FromArgb(254, 254, 254);
            btnIniciarSecion.Location = new Point(613, 342);
            btnIniciarSecion.Name = "btnIniciarSecion";
            btnIniciarSecion.Size = new Size(121, 42);
            btnIniciarSecion.TabIndex = 9;
            btnIniciarSecion.Text = "Iniciar secion";
            btnIniciarSecion.UseVisualStyleBackColor = false;
            btnIniciarSecion.Click += button1_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.Cursor = Cursors.Hand;
            btnCerrar.Image = Properties.Resources.cerrar;
            btnCerrar.Location = new Point(788, 12);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(30, 30);
            btnCerrar.SizeMode = PictureBoxSizeMode.Zoom;
            btnCerrar.TabIndex = 10;
            btnCerrar.TabStop = false;
            btnCerrar.Click += pictureBox2_Click;
            // 
            // InicioDeSecion
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(27, 25, 25);
            ClientSize = new Size(830, 459);
            Controls.Add(btnCerrar);
            Controls.Add(btnIniciarSecion);
            Controls.Add(panel2);
            Controls.Add(textBox2);
            Controls.Add(panel1);
            Controls.Add(label4);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "InicioDeSecion";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "InicioDeSecion";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnCerrar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBox1;
        private Panel panel1;
        private Panel panel2;
        private TextBox textBox2;
        private Label label4;
        private Button btnIniciarSecion;
        private PictureBox btnCerrar;
    }
}