
namespace GDT_IDE_WF.Vista.Actualizar
{
    partial class ActualizarReglaForm
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
            this.pnl_header = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnl_filtrarComponent = new System.Windows.Forms.Panel();
            this.containerGridReglas = new System.Windows.Forms.Panel();
            this.containerGridSelectedReglas = new System.Windows.Forms.Panel();
            this.pnl_header.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_header
            // 
            this.pnl_header.BackColor = System.Drawing.SystemColors.ControlText;
            this.pnl_header.Controls.Add(this.label1);
            this.pnl_header.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_header.ForeColor = System.Drawing.SystemColors.Control;
            this.pnl_header.Location = new System.Drawing.Point(0, 0);
            this.pnl_header.Name = "pnl_header";
            this.pnl_header.Size = new System.Drawing.Size(992, 38);
            this.pnl_header.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 14.25F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(389, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(248, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Actualizar regla del Kernel";
            // 
            // pnl_filtrarComponent
            // 
            this.pnl_filtrarComponent.BackColor = System.Drawing.Color.Transparent;
            this.pnl_filtrarComponent.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_filtrarComponent.Location = new System.Drawing.Point(0, 38);
            this.pnl_filtrarComponent.Name = "pnl_filtrarComponent";
            this.pnl_filtrarComponent.Size = new System.Drawing.Size(992, 39);
            this.pnl_filtrarComponent.TabIndex = 1;
            // 
            // containerGridReglas
            // 
            this.containerGridReglas.BackColor = System.Drawing.Color.Transparent;
            this.containerGridReglas.Dock = System.Windows.Forms.DockStyle.Top;
            this.containerGridReglas.Location = new System.Drawing.Point(0, 77);
            this.containerGridReglas.Name = "containerGridReglas";
            this.containerGridReglas.Size = new System.Drawing.Size(992, 58);
            this.containerGridReglas.TabIndex = 2;
            // 
            // containerGridSelectedReglas
            // 
            this.containerGridSelectedReglas.BackColor = System.Drawing.Color.Transparent;
            this.containerGridSelectedReglas.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.containerGridSelectedReglas.Location = new System.Drawing.Point(0, 897);
            this.containerGridSelectedReglas.Name = "containerGridSelectedReglas";
            this.containerGridSelectedReglas.Size = new System.Drawing.Size(992, 33);
            this.containerGridSelectedReglas.TabIndex = 3;
            // 
            // ActualizarReglaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(992, 930);
            this.Controls.Add(this.containerGridSelectedReglas);
            this.Controls.Add(this.containerGridReglas);
            this.Controls.Add(this.pnl_filtrarComponent);
            this.Controls.Add(this.pnl_header);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ActualizarReglaForm";
            this.Text = "ActualizarReglaForm";
            this.Load += new System.EventHandler(this.ActualizarReglaForm_Load);
            this.pnl_header.ResumeLayout(false);
            this.pnl_header.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_header;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnl_filtrarComponent;
        private System.Windows.Forms.Panel containerGridReglas;
        private System.Windows.Forms.Panel containerGridSelectedReglas;
    }
}