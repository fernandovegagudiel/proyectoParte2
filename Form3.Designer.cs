namespace ProyectoPae2
{
    partial class Form3
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.textBoxPregunta = new System.Windows.Forms.TextBox();
            this.textBoxRespuesta = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.buttonBuscar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonRegresar = new System.Windows.Forms.Button();
            this.texGrado = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.buttonGuardar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxPregunta
            // 
            this.textBoxPregunta.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPregunta.Location = new System.Drawing.Point(50, 139);
            this.textBoxPregunta.Multiline = true;
            this.textBoxPregunta.Name = "textBoxPregunta";
            this.textBoxPregunta.Size = new System.Drawing.Size(431, 37);
            this.textBoxPregunta.TabIndex = 0;
            // 
            // textBoxRespuesta
            // 
            this.textBoxRespuesta.Font = new System.Drawing.Font("Comic Sans MS", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRespuesta.Location = new System.Drawing.Point(77, 286);
            this.textBoxRespuesta.Multiline = true;
            this.textBoxRespuesta.Name = "textBoxRespuesta";
            this.textBoxRespuesta.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxRespuesta.Size = new System.Drawing.Size(877, 264);
            this.textBoxRespuesta.TabIndex = 1;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // buttonBuscar
            // 
            this.buttonBuscar.Location = new System.Drawing.Point(120, 183);
            this.buttonBuscar.Name = "buttonBuscar";
            this.buttonBuscar.Size = new System.Drawing.Size(104, 36);
            this.buttonBuscar.TabIndex = 3;
            this.buttonBuscar.Text = "Buscar";
            this.buttonBuscar.UseVisualStyleBackColor = true;
            this.buttonBuscar.Click += new System.EventHandler(this.buttonBuscar_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(902, 37);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(8, 8);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // buttonRegresar
            // 
            this.buttonRegresar.Location = new System.Drawing.Point(916, 8);
            this.buttonRegresar.Name = "buttonRegresar";
            this.buttonRegresar.Size = new System.Drawing.Size(104, 37);
            this.buttonRegresar.TabIndex = 5;
            this.buttonRegresar.Text = "Regresar ";
            this.buttonRegresar.UseVisualStyleBackColor = true;
            this.buttonRegresar.Click += new System.EventHandler(this.buttonRegresar_Click);
            // 
            // texGrado
            // 
            this.texGrado.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.texGrado.Location = new System.Drawing.Point(644, 41);
            this.texGrado.Name = "texGrado";
            this.texGrado.Size = new System.Drawing.Size(142, 22);
            this.texGrado.TabIndex = 7;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.SystemColors.Info;
            this.label10.Font = new System.Drawing.Font("Comic Sans MS", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(621, 12);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(239, 24);
            this.label10.TabIndex = 26;
            this.label10.Text = "ingreses su  nivel academico";
            // 
            // buttonGuardar
            // 
            this.buttonGuardar.Location = new System.Drawing.Point(230, 183);
            this.buttonGuardar.Name = "buttonGuardar";
            this.buttonGuardar.Size = new System.Drawing.Size(92, 37);
            this.buttonGuardar.TabIndex = 27;
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.UseVisualStyleBackColor = true;
            this.buttonGuardar.Click += new System.EventHandler(this.buttonGuardar_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1031, 721);
            this.Controls.Add(this.buttonGuardar);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.texGrado);
            this.Controls.Add(this.buttonRegresar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonBuscar);
            this.Controls.Add(this.textBoxRespuesta);
            this.Controls.Add(this.textBoxPregunta);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxPregunta;
        private System.Windows.Forms.TextBox textBoxRespuesta;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button buttonBuscar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonRegresar;
        private System.Windows.Forms.TextBox texGrado;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button buttonGuardar;
    }
}