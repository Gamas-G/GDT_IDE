namespace GDT_IDE_WF.Vistas.Crear
{
    partial class EditarCuadroReglasKernel
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
            this.pnl_top = new System.Windows.Forms.Panel();
            this.lbl_titulo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_destec = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_guardarBloqueReglas = new System.Windows.Forms.Button();
            this.btn_AgregarBloque = new System.Windows.Forms.Button();
            this.pnl_contenedorBloquesReglas = new System.Windows.Forms.FlowLayoutPanel();
            this.pnl_top.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_top
            // 
            this.pnl_top.Controls.Add(this.btn_AgregarBloque);
            this.pnl_top.Controls.Add(this.lbl_titulo);
            this.pnl_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_top.Location = new System.Drawing.Point(0, 0);
            this.pnl_top.Name = "pnl_top";
            this.pnl_top.Size = new System.Drawing.Size(833, 37);
            this.pnl_top.TabIndex = 0;
            // 
            // lbl_titulo
            // 
            this.lbl_titulo.AutoSize = true;
            this.lbl_titulo.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_titulo.Location = new System.Drawing.Point(265, 9);
            this.lbl_titulo.Name = "lbl_titulo";
            this.lbl_titulo.Size = new System.Drawing.Size(272, 18);
            this.lbl_titulo.TabIndex = 0;
            this.lbl_titulo.Text = "Editar Cuadro de Reglas de Kernel";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(98)))), ((int)(((byte)(66)))));
            this.panel1.Controls.Add(this.lbl_destec);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 543);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(833, 36);
            this.panel1.TabIndex = 2;
            // 
            // lbl_destec
            // 
            this.lbl_destec.AutoSize = true;
            this.lbl_destec.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.lbl_destec.ForeColor = System.Drawing.Color.White;
            this.lbl_destec.Location = new System.Drawing.Point(8, 6);
            this.lbl_destec.Name = "lbl_destec";
            this.lbl_destec.Size = new System.Drawing.Size(66, 21);
            this.lbl_destec.TabIndex = 2;
            this.lbl_destec.Text = "DesTec";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btn_guardarBloqueReglas);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 508);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(833, 35);
            this.panel2.TabIndex = 3;
            // 
            // btn_guardarBloqueReglas
            // 
            this.btn_guardarBloqueReglas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_guardarBloqueReglas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_guardarBloqueReglas.Location = new System.Drawing.Point(0, 0);
            this.btn_guardarBloqueReglas.Name = "btn_guardarBloqueReglas";
            this.btn_guardarBloqueReglas.Size = new System.Drawing.Size(833, 35);
            this.btn_guardarBloqueReglas.TabIndex = 0;
            this.btn_guardarBloqueReglas.Text = "GUARDAR";
            this.btn_guardarBloqueReglas.UseVisualStyleBackColor = true;
            this.btn_guardarBloqueReglas.Click += new System.EventHandler(this.btn_guardarBloqueReglas_Click);
            // 
            // btn_AgregarBloque
            // 
            this.btn_AgregarBloque.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_AgregarBloque.Location = new System.Drawing.Point(775, 7);
            this.btn_AgregarBloque.Name = "btn_AgregarBloque";
            this.btn_AgregarBloque.Size = new System.Drawing.Size(49, 23);
            this.btn_AgregarBloque.TabIndex = 2;
            this.btn_AgregarBloque.Text = "✚";
            this.btn_AgregarBloque.UseVisualStyleBackColor = true;
            this.btn_AgregarBloque.Click += new System.EventHandler(this.btn_AgregarBloque_Click);
            // 
            // pnl_contenedorBloquesReglas
            // 
            this.pnl_contenedorBloquesReglas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_contenedorBloquesReglas.Location = new System.Drawing.Point(0, 37);
            this.pnl_contenedorBloquesReglas.Name = "pnl_contenedorBloquesReglas";
            this.pnl_contenedorBloquesReglas.Size = new System.Drawing.Size(833, 471);
            this.pnl_contenedorBloquesReglas.TabIndex = 4;
            // 
            // EditarCuadroReglasKernel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 579);
            this.Controls.Add(this.pnl_contenedorBloquesReglas);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnl_top);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditarCuadroReglasKernel";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = " ";
            this.pnl_top.ResumeLayout(false);
            this.pnl_top.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_top;
        private System.Windows.Forms.Label lbl_titulo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbl_destec;
        private System.Windows.Forms.Button btn_guardarBloqueReglas;
        private System.Windows.Forms.Button btn_AgregarBloque;
        private System.Windows.Forms.FlowLayoutPanel pnl_contenedorBloquesReglas;
    }
}