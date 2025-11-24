
namespace GDT_IDE_WF.Vista
{
    partial class InicioForm
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
            this.containerServidores = new System.Windows.Forms.FlowLayoutPanel();
            this.contenedor = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.contenedorCanales = new System.Windows.Forms.FlowLayoutPanel();
            this.lbl_pais = new System.Windows.Forms.Label();
            this.cbx_pais = new System.Windows.Forms.ComboBox();
            this.lbl_canal = new System.Windows.Forms.Label();
            this.cbx_canal = new System.Windows.Forms.ComboBox();
            this.contenedor.SuspendLayout();
            this.panel1.SuspendLayout();
            this.contenedorCanales.SuspendLayout();
            this.SuspendLayout();
            // 
            // containerServidores
            // 
            this.containerServidores.AutoScroll = true;
            this.containerServidores.AutoSize = true;
            this.containerServidores.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.containerServidores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.containerServidores.Location = new System.Drawing.Point(0, 0);
            this.containerServidores.Name = "containerServidores";
            this.containerServidores.Size = new System.Drawing.Size(1008, 647);
            this.containerServidores.TabIndex = 6;
            // 
            // contenedor
            // 
            this.contenedor.AutoScroll = true;
            this.contenedor.AutoSize = true;
            this.contenedor.BackColor = System.Drawing.Color.Transparent;
            this.contenedor.Controls.Add(this.panel1);
            this.contenedor.Controls.Add(this.contenedorCanales);
            this.contenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contenedor.Location = new System.Drawing.Point(0, 0);
            this.contenedor.Name = "contenedor";
            this.contenedor.Size = new System.Drawing.Size(1008, 681);
            this.contenedor.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.containerServidores);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1008, 647);
            this.panel1.TabIndex = 7;
            // 
            // contenedorCanales
            // 
            this.contenedorCanales.AutoSize = true;
            this.contenedorCanales.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(98)))), ((int)(((byte)(66)))));
            this.contenedorCanales.Controls.Add(this.lbl_pais);
            this.contenedorCanales.Controls.Add(this.cbx_pais);
            this.contenedorCanales.Controls.Add(this.lbl_canal);
            this.contenedorCanales.Controls.Add(this.cbx_canal);
            this.contenedorCanales.Dock = System.Windows.Forms.DockStyle.Top;
            this.contenedorCanales.Location = new System.Drawing.Point(0, 0);
            this.contenedorCanales.Name = "contenedorCanales";
            this.contenedorCanales.Size = new System.Drawing.Size(1008, 34);
            this.contenedorCanales.TabIndex = 0;
            this.contenedorCanales.WrapContents = false;
            // 
            // lbl_pais
            // 
            this.lbl_pais.AutoSize = true;
            this.lbl_pais.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_pais.ForeColor = System.Drawing.Color.White;
            this.lbl_pais.Location = new System.Drawing.Point(3, 0);
            this.lbl_pais.Name = "lbl_pais";
            this.lbl_pais.Size = new System.Drawing.Size(43, 20);
            this.lbl_pais.TabIndex = 5;
            this.lbl_pais.Text = "País";
            this.lbl_pais.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbx_pais
            // 
            this.cbx_pais.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbx_pais.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_pais.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbx_pais.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_pais.FormattingEnabled = true;
            this.cbx_pais.Location = new System.Drawing.Point(52, 3);
            this.cbx_pais.Name = "cbx_pais";
            this.cbx_pais.Size = new System.Drawing.Size(166, 28);
            this.cbx_pais.TabIndex = 3;
            this.cbx_pais.SelectedIndexChanged += new System.EventHandler(this.cbx_pais_SelectedIndexChanged);
            // 
            // lbl_canal
            // 
            this.lbl_canal.AutoSize = true;
            this.lbl_canal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_canal.ForeColor = System.Drawing.Color.White;
            this.lbl_canal.Location = new System.Drawing.Point(224, 0);
            this.lbl_canal.Name = "lbl_canal";
            this.lbl_canal.Size = new System.Drawing.Size(55, 20);
            this.lbl_canal.TabIndex = 6;
            this.lbl_canal.Text = "Canal";
            // 
            // cbx_canal
            // 
            this.cbx_canal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbx_canal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_canal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbx_canal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_canal.FormattingEnabled = true;
            this.cbx_canal.Location = new System.Drawing.Point(285, 3);
            this.cbx_canal.Name = "cbx_canal";
            this.cbx_canal.Size = new System.Drawing.Size(166, 28);
            this.cbx_canal.TabIndex = 4;
            this.cbx_canal.SelectedIndexChanged += new System.EventHandler(this.cbx_canal_SelectedIndexChanged);
            // 
            // InicioForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 681);
            this.Controls.Add(this.contenedor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "InicioForm";
            this.Text = "InicioForm";
            this.contenedor.ResumeLayout(false);
            this.contenedor.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.contenedorCanales.ResumeLayout(false);
            this.contenedorCanales.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel containerServidores;
        private System.Windows.Forms.Panel contenedor;
        private System.Windows.Forms.FlowLayoutPanel contenedorCanales;
        private System.Windows.Forms.ComboBox cbx_pais;
        private System.Windows.Forms.ComboBox cbx_canal;
        private System.Windows.Forms.Label lbl_pais;
        private System.Windows.Forms.Label lbl_canal;
        private System.Windows.Forms.Panel panel1;
    }
}