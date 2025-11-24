
namespace GDT_IDE_WF.Vista.Eliminar
{
    partial class EliminarReglaForm
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
            this.lbl_titulo1 = new System.Windows.Forms.Label();
            this.pnl_header = new System.Windows.Forms.Panel();
            this.pnl_moduloFiltrar = new System.Windows.Forms.Panel();
            this.containerGridReglas = new System.Windows.Forms.Panel();
            this.containerGridSelectedReglas = new System.Windows.Forms.Panel();
            this.pnl_header.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_titulo1
            // 
            this.lbl_titulo1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_titulo1.AutoSize = true;
            this.lbl_titulo1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_titulo1.Location = new System.Drawing.Point(389, 9);
            this.lbl_titulo1.Name = "lbl_titulo1";
            this.lbl_titulo1.Size = new System.Drawing.Size(230, 22);
            this.lbl_titulo1.TabIndex = 0;
            this.lbl_titulo1.Text = "Eliminar reglas del Kernel";
            // 
            // pnl_header
            // 
            this.pnl_header.BackColor = System.Drawing.SystemColors.ControlText;
            this.pnl_header.Controls.Add(this.lbl_titulo1);
            this.pnl_header.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_header.ForeColor = System.Drawing.Color.White;
            this.pnl_header.Location = new System.Drawing.Point(0, 0);
            this.pnl_header.Name = "pnl_header";
            this.pnl_header.Size = new System.Drawing.Size(992, 38);
            this.pnl_header.TabIndex = 4;
            // 
            // pnl_moduloFiltrar
            // 
            this.pnl_moduloFiltrar.BackColor = System.Drawing.Color.LightGray;
            this.pnl_moduloFiltrar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_moduloFiltrar.Location = new System.Drawing.Point(0, 38);
            this.pnl_moduloFiltrar.Name = "pnl_moduloFiltrar";
            this.pnl_moduloFiltrar.Size = new System.Drawing.Size(992, 54);
            this.pnl_moduloFiltrar.TabIndex = 5;
            // 
            // containerGridReglas
            // 
            this.containerGridReglas.BackColor = System.Drawing.Color.Transparent;
            this.containerGridReglas.Dock = System.Windows.Forms.DockStyle.Top;
            this.containerGridReglas.Location = new System.Drawing.Point(0, 92);
            this.containerGridReglas.Name = "containerGridReglas";
            this.containerGridReglas.Size = new System.Drawing.Size(992, 58);
            this.containerGridReglas.TabIndex = 9;
            // 
            // containerGridSelectedReglas
            // 
            this.containerGridSelectedReglas.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.containerGridSelectedReglas.Location = new System.Drawing.Point(0, 897);
            this.containerGridSelectedReglas.Name = "containerGridSelectedReglas";
            this.containerGridSelectedReglas.Size = new System.Drawing.Size(992, 33);
            this.containerGridSelectedReglas.TabIndex = 10;
            // 
            // EliminarReglaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(992, 930);
            this.Controls.Add(this.containerGridSelectedReglas);
            this.Controls.Add(this.containerGridReglas);
            this.Controls.Add(this.pnl_moduloFiltrar);
            this.Controls.Add(this.pnl_header);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EliminarReglaForm";
            this.Text = "EliminarReglaForm";
            this.Load += new System.EventHandler(this.EliminarReglaForm_Load);
            this.pnl_header.ResumeLayout(false);
            this.pnl_header.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_titulo1;
        private System.Windows.Forms.Panel pnl_header;
        private System.Windows.Forms.Panel pnl_moduloFiltrar;
        private System.Windows.Forms.Panel containerGridReglas;
        private System.Windows.Forms.Panel containerGridSelectedReglas;
    }
}