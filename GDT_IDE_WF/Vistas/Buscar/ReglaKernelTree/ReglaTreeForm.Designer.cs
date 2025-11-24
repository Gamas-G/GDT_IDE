
namespace GDT_IDE_WF.Vista.Buscar.ReglaKernelTree
{
    partial class ReglaTreeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReglaTreeForm));
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_destec = new System.Windows.Forms.Label();
            this.lbl_titulo = new System.Windows.Forms.Label();
            this.pnl_contenedor = new System.Windows.Forms.Panel();
            this.picture_wait = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.pnl_contenedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture_wait)).BeginInit();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(776, 413);
            this.treeView1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(98)))), ((int)(((byte)(66)))));
            this.panel1.Controls.Add(this.lbl_destec);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 468);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 36);
            this.panel1.TabIndex = 10;
            // 
            // lbl_destec
            // 
            this.lbl_destec.AutoSize = true;
            this.lbl_destec.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.lbl_destec.ForeColor = System.Drawing.Color.White;
            this.lbl_destec.Location = new System.Drawing.Point(8, 6);
            this.lbl_destec.Name = "lbl_destec";
            this.lbl_destec.Size = new System.Drawing.Size(66, 21);
            this.lbl_destec.TabIndex = 1;
            this.lbl_destec.Text = "DesTec";
            // 
            // lbl_titulo
            // 
            this.lbl_titulo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_titulo.AutoSize = true;
            this.lbl_titulo.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_titulo.Location = new System.Drawing.Point(172, 13);
            this.lbl_titulo.Name = "lbl_titulo";
            this.lbl_titulo.Size = new System.Drawing.Size(450, 22);
            this.lbl_titulo.TabIndex = 11;
            this.lbl_titulo.Text = "ÁRBOL DE SEGUIMIENTO DE LAS REGLAS DE KERNEL";
            // 
            // pnl_contenedor
            // 
            this.pnl_contenedor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_contenedor.Controls.Add(this.picture_wait);
            this.pnl_contenedor.Controls.Add(this.treeView1);
            this.pnl_contenedor.Location = new System.Drawing.Point(12, 49);
            this.pnl_contenedor.Name = "pnl_contenedor";
            this.pnl_contenedor.Size = new System.Drawing.Size(776, 413);
            this.pnl_contenedor.TabIndex = 12;
            // 
            // picture_wait
            // 
            this.picture_wait.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picture_wait.BackColor = System.Drawing.Color.Transparent;
            this.picture_wait.Image = ((System.Drawing.Image)(resources.GetObject("picture_wait.Image")));
            this.picture_wait.Location = new System.Drawing.Point(297, 87);
            this.picture_wait.Name = "picture_wait";
            this.picture_wait.Size = new System.Drawing.Size(186, 216);
            this.picture_wait.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picture_wait.TabIndex = 0;
            this.picture_wait.TabStop = false;
            // 
            // ReglaTreeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 504);
            this.Controls.Add(this.pnl_contenedor);
            this.Controls.Add(this.lbl_titulo);
            this.Controls.Add(this.panel1);
            this.Name = "ReglaTreeForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = " Árbol de seguimiento";
            this.Load += new System.EventHandler(this.ReglaTreeForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnl_contenedor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picture_wait)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_destec;
        private System.Windows.Forms.Label lbl_titulo;
        private System.Windows.Forms.Panel pnl_contenedor;
        private System.Windows.Forms.PictureBox picture_wait;
    }
}