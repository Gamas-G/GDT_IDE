
namespace GDT_IDE_WF.Vista.Crear
{
    partial class CrearReglaForm
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
            this.pnl_cuadroReglasKernel = new System.Windows.Forms.Panel();
            this.pnl_cuadroContenedor = new System.Windows.Forms.FlowLayoutPanel();
            this.pnl_cuadroReglaAccion = new System.Windows.Forms.Panel();
            this.link_editarReglasKernel = new System.Windows.Forms.LinkLabel();
            this.pnl_cuadroReglaTop = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnl_top = new System.Windows.Forms.Panel();
            this.btn_cuadroReglas = new System.Windows.Forms.Button();
            this.lbl_modo = new System.Windows.Forms.Label();
            this.rd_junior = new System.Windows.Forms.RadioButton();
            this.rd_senior = new System.Windows.Forms.RadioButton();
            this.pn_consola = new System.Windows.Forms.Panel();
            this.pnl_cuadroReglasKernel.SuspendLayout();
            this.pnl_cuadroReglaAccion.SuspendLayout();
            this.pnl_cuadroReglaTop.SuspendLayout();
            this.pnl_top.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_cuadroReglasKernel
            // 
            this.pnl_cuadroReglasKernel.BackColor = System.Drawing.SystemColors.WindowText;
            this.pnl_cuadroReglasKernel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_cuadroReglasKernel.Controls.Add(this.pnl_cuadroContenedor);
            this.pnl_cuadroReglasKernel.Controls.Add(this.pnl_cuadroReglaAccion);
            this.pnl_cuadroReglasKernel.Controls.Add(this.pnl_cuadroReglaTop);
            this.pnl_cuadroReglasKernel.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnl_cuadroReglasKernel.Location = new System.Drawing.Point(732, 39);
            this.pnl_cuadroReglasKernel.Name = "pnl_cuadroReglasKernel";
            this.pnl_cuadroReglasKernel.Size = new System.Drawing.Size(276, 642);
            this.pnl_cuadroReglasKernel.TabIndex = 6;
            // 
            // pnl_cuadroContenedor
            // 
            this.pnl_cuadroContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_cuadroContenedor.Location = new System.Drawing.Point(0, 54);
            this.pnl_cuadroContenedor.Name = "pnl_cuadroContenedor";
            this.pnl_cuadroContenedor.Size = new System.Drawing.Size(274, 586);
            this.pnl_cuadroContenedor.TabIndex = 2;
            // 
            // pnl_cuadroReglaAccion
            // 
            this.pnl_cuadroReglaAccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_cuadroReglaAccion.Controls.Add(this.link_editarReglasKernel);
            this.pnl_cuadroReglaAccion.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_cuadroReglaAccion.Location = new System.Drawing.Point(0, 29);
            this.pnl_cuadroReglaAccion.Name = "pnl_cuadroReglaAccion";
            this.pnl_cuadroReglaAccion.Size = new System.Drawing.Size(274, 25);
            this.pnl_cuadroReglaAccion.TabIndex = 1;
            // 
            // link_editarReglasKernel
            // 
            this.link_editarReglasKernel.AutoSize = true;
            this.link_editarReglasKernel.LinkColor = System.Drawing.Color.White;
            this.link_editarReglasKernel.Location = new System.Drawing.Point(155, 6);
            this.link_editarReglasKernel.Name = "link_editarReglasKernel";
            this.link_editarReglasKernel.Size = new System.Drawing.Size(98, 13);
            this.link_editarReglasKernel.TabIndex = 0;
            this.link_editarReglasKernel.TabStop = true;
            this.link_editarReglasKernel.Text = "Editar Regla Kernel";
            this.link_editarReglasKernel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_editarReglasKernel_LinkClicked);
            // 
            // pnl_cuadroReglaTop
            // 
            this.pnl_cuadroReglaTop.BackColor = System.Drawing.SystemColors.WindowText;
            this.pnl_cuadroReglaTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_cuadroReglaTop.Controls.Add(this.label1);
            this.pnl_cuadroReglaTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_cuadroReglaTop.Location = new System.Drawing.Point(0, 0);
            this.pnl_cuadroReglaTop.Name = "pnl_cuadroReglaTop";
            this.pnl_cuadroReglaTop.Size = new System.Drawing.Size(274, 29);
            this.pnl_cuadroReglaTop.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(73, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cuadro Reglas Kernel";
            // 
            // pnl_top
            // 
            this.pnl_top.BackColor = System.Drawing.SystemColors.ControlText;
            this.pnl_top.Controls.Add(this.btn_cuadroReglas);
            this.pnl_top.Controls.Add(this.lbl_modo);
            this.pnl_top.Controls.Add(this.rd_junior);
            this.pnl_top.Controls.Add(this.rd_senior);
            this.pnl_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_top.Location = new System.Drawing.Point(0, 0);
            this.pnl_top.Name = "pnl_top";
            this.pnl_top.Size = new System.Drawing.Size(1008, 39);
            this.pnl_top.TabIndex = 4;
            // 
            // btn_cuadroReglas
            // 
            this.btn_cuadroReglas.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btn_cuadroReglas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cuadroReglas.Location = new System.Drawing.Point(839, 8);
            this.btn_cuadroReglas.Name = "btn_cuadroReglas";
            this.btn_cuadroReglas.Size = new System.Drawing.Size(157, 23);
            this.btn_cuadroReglas.TabIndex = 4;
            this.btn_cuadroReglas.Text = "▶ Cuadro Reglas Kernel";
            this.btn_cuadroReglas.UseVisualStyleBackColor = true;
            this.btn_cuadroReglas.Click += new System.EventHandler(this.btn_cuadroReglas_Click);
            // 
            // lbl_modo
            // 
            this.lbl_modo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_modo.AutoSize = true;
            this.lbl_modo.Font = new System.Drawing.Font("Century Gothic", 14.25F);
            this.lbl_modo.ForeColor = System.Drawing.Color.White;
            this.lbl_modo.Location = new System.Drawing.Point(420, 9);
            this.lbl_modo.Name = "lbl_modo";
            this.lbl_modo.Size = new System.Drawing.Size(208, 22);
            this.lbl_modo.TabIndex = 3;
            this.lbl_modo.Text = "Crear regla del Kernel";
            // 
            // rd_junior
            // 
            this.rd_junior.AutoSize = true;
            this.rd_junior.Location = new System.Drawing.Point(103, 9);
            this.rd_junior.Name = "rd_junior";
            this.rd_junior.Size = new System.Drawing.Size(83, 17);
            this.rd_junior.TabIndex = 1;
            this.rd_junior.TabStop = true;
            this.rd_junior.Text = "Modo Junior";
            this.rd_junior.UseVisualStyleBackColor = true;
            this.rd_junior.CheckedChanged += new System.EventHandler(this.rd_junior_CheckedChanged);
            // 
            // rd_senior
            // 
            this.rd_senior.AutoSize = true;
            this.rd_senior.ForeColor = System.Drawing.Color.White;
            this.rd_senior.Location = new System.Drawing.Point(12, 9);
            this.rd_senior.Name = "rd_senior";
            this.rd_senior.Size = new System.Drawing.Size(85, 17);
            this.rd_senior.TabIndex = 2;
            this.rd_senior.TabStop = true;
            this.rd_senior.Text = "Modo Senior";
            this.rd_senior.UseVisualStyleBackColor = true;
            this.rd_senior.CheckedChanged += new System.EventHandler(this.rd_senior_CheckedChanged);
            // 
            // pn_consola
            // 
            this.pn_consola.AutoScroll = true;
            this.pn_consola.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pn_consola.Location = new System.Drawing.Point(0, 39);
            this.pn_consola.Name = "pn_consola";
            this.pn_consola.Size = new System.Drawing.Size(732, 642);
            this.pn_consola.TabIndex = 7;
            // 
            // CrearReglaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1008, 681);
            this.Controls.Add(this.pn_consola);
            this.Controls.Add(this.pnl_cuadroReglasKernel);
            this.Controls.Add(this.pnl_top);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CrearReglaForm";
            this.Text = "CrearReglaForm";
            this.pnl_cuadroReglasKernel.ResumeLayout(false);
            this.pnl_cuadroReglaAccion.ResumeLayout(false);
            this.pnl_cuadroReglaAccion.PerformLayout();
            this.pnl_cuadroReglaTop.ResumeLayout(false);
            this.pnl_cuadroReglaTop.PerformLayout();
            this.pnl_top.ResumeLayout(false);
            this.pnl_top.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnl_top;
        private System.Windows.Forms.RadioButton rd_junior;
        private System.Windows.Forms.RadioButton rd_senior;
        private System.Windows.Forms.Label lbl_modo;
        private System.Windows.Forms.Panel pnl_cuadroReglasKernel;
        private System.Windows.Forms.Panel pn_consola;
        private System.Windows.Forms.Button btn_cuadroReglas;
        private System.Windows.Forms.Panel pnl_cuadroReglaAccion;
        private System.Windows.Forms.Panel pnl_cuadroReglaTop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel link_editarReglasKernel;
        private System.Windows.Forms.FlowLayoutPanel pnl_cuadroContenedor;
    }
}