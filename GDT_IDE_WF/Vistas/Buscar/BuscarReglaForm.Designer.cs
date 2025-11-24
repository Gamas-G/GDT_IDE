
namespace GDT_IDE_WF.Vista.Buscar
{
    partial class BuscarReglaForm
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
            this.pnl_moduloFiltrar = new System.Windows.Forms.Panel();
            this.pnl_1 = new System.Windows.Forms.Panel();
            this.lbl_titulo1 = new System.Windows.Forms.Label();
            this.containerGridReglas = new System.Windows.Forms.Panel();
            this.pnl_1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_moduloFiltrar
            // 
            this.pnl_moduloFiltrar.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnl_moduloFiltrar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_moduloFiltrar.Location = new System.Drawing.Point(0, 38);
            this.pnl_moduloFiltrar.Name = "pnl_moduloFiltrar";
            this.pnl_moduloFiltrar.Size = new System.Drawing.Size(1008, 10);
            this.pnl_moduloFiltrar.TabIndex = 11;
            // 
            // pnl_1
            // 
            this.pnl_1.BackColor = System.Drawing.Color.Black;
            this.pnl_1.Controls.Add(this.lbl_titulo1);
            this.pnl_1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_1.Location = new System.Drawing.Point(0, 0);
            this.pnl_1.Name = "pnl_1";
            this.pnl_1.Size = new System.Drawing.Size(1008, 38);
            this.pnl_1.TabIndex = 9;
            // 
            // lbl_titulo1
            // 
            this.lbl_titulo1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_titulo1.AutoSize = true;
            this.lbl_titulo1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_titulo1.ForeColor = System.Drawing.Color.White;
            this.lbl_titulo1.Location = new System.Drawing.Point(389, 8);
            this.lbl_titulo1.Name = "lbl_titulo1";
            this.lbl_titulo1.Size = new System.Drawing.Size(224, 22);
            this.lbl_titulo1.TabIndex = 2;
            this.lbl_titulo1.Text = "Buscar reglas del Kernel";
            // 
            // containerGridReglas
            // 
            this.containerGridReglas.BackColor = System.Drawing.Color.Black;
            this.containerGridReglas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.containerGridReglas.Location = new System.Drawing.Point(0, 48);
            this.containerGridReglas.Name = "containerGridReglas";
            this.containerGridReglas.Size = new System.Drawing.Size(1008, 633);
            this.containerGridReglas.TabIndex = 12;
            // 
            // BuscarReglaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 681);
            this.Controls.Add(this.containerGridReglas);
            this.Controls.Add(this.pnl_moduloFiltrar);
            this.Controls.Add(this.pnl_1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BuscarReglaForm";
            this.Text = "BuscarReglaForm";
            this.Load += new System.EventHandler(this.BuscarReglaForm_Load);
            this.pnl_1.ResumeLayout(false);
            this.pnl_1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnl_moduloFiltrar;
        private System.Windows.Forms.Panel pnl_1;
        private System.Windows.Forms.Label lbl_titulo1;
        private System.Windows.Forms.Panel containerGridReglas;
    }
}