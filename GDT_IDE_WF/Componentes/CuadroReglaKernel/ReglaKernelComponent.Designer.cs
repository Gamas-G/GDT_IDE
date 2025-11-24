namespace GDT_IDE_WF.Componentes.CuadroReglaKernel
{
    partial class ReglaKernelComponent
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
            this.btn_accionPnl = new System.Windows.Forms.Button();
            this.pnl_body = new System.Windows.Forms.Panel();
            this.list_reglasKernel = new System.Windows.Forms.ListView();
            this.pnl_top.SuspendLayout();
            this.pnl_body.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_top
            // 
            this.pnl_top.Controls.Add(this.lbl_titulo);
            this.pnl_top.Controls.Add(this.btn_accionPnl);
            this.pnl_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_top.Location = new System.Drawing.Point(0, 0);
            this.pnl_top.Name = "pnl_top";
            this.pnl_top.Size = new System.Drawing.Size(258, 35);
            this.pnl_top.TabIndex = 0;
            // 
            // lbl_titulo
            // 
            this.lbl_titulo.AutoSize = true;
            this.lbl_titulo.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_titulo.Location = new System.Drawing.Point(6, 11);
            this.lbl_titulo.Name = "lbl_titulo";
            this.lbl_titulo.Size = new System.Drawing.Size(56, 14);
            this.lbl_titulo.TabIndex = 0;
            this.lbl_titulo.Text = "DEFAULT";
            // 
            // btn_accionPnl
            // 
            this.btn_accionPnl.Location = new System.Drawing.Point(146, 7);
            this.btn_accionPnl.Name = "btn_accionPnl";
            this.btn_accionPnl.Size = new System.Drawing.Size(105, 23);
            this.btn_accionPnl.TabIndex = 0;
            this.btn_accionPnl.Text = "▼ Mostrar Default";
            this.btn_accionPnl.UseVisualStyleBackColor = true;
            this.btn_accionPnl.Click += new System.EventHandler(this.btn_accionPnl_Click);
            // 
            // pnl_body
            // 
            this.pnl_body.Controls.Add(this.list_reglasKernel);
            this.pnl_body.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_body.Location = new System.Drawing.Point(0, 35);
            this.pnl_body.Name = "pnl_body";
            this.pnl_body.Size = new System.Drawing.Size(258, 302);
            this.pnl_body.TabIndex = 1;
            // 
            // list_reglasKernel
            // 
            this.list_reglasKernel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.list_reglasKernel.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.list_reglasKernel.HideSelection = false;
            this.list_reglasKernel.Location = new System.Drawing.Point(0, 0);
            this.list_reglasKernel.Name = "list_reglasKernel";
            this.list_reglasKernel.Size = new System.Drawing.Size(258, 302);
            this.list_reglasKernel.TabIndex = 0;
            this.list_reglasKernel.UseCompatibleStateImageBehavior = false;
            this.list_reglasKernel.View = System.Windows.Forms.View.List;
            // 
            // ReglaKernelComponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(258, 337);
            this.Controls.Add(this.pnl_body);
            this.Controls.Add(this.pnl_top);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ReglaKernelComponent";
            this.Text = "ReglaKernelForm";
            this.pnl_top.ResumeLayout(false);
            this.pnl_top.PerformLayout();
            this.pnl_body.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_top;
        private System.Windows.Forms.Panel pnl_body;
        private System.Windows.Forms.Button btn_accionPnl;
        private System.Windows.Forms.Label lbl_titulo;
        private System.Windows.Forms.ListView list_reglasKernel;
    }
}