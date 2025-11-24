namespace GDT_IDE_WF.Componentes.CuadroReglaKernel.BloqueKernelComponent
{
    partial class BloqueKernelComponent
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
            this.lbl_nombreBloque = new System.Windows.Forms.Label();
            this.pnl_top = new System.Windows.Forms.Panel();
            this.btn_EliminarBloque = new System.Windows.Forms.Button();
            this.txt_nombreBloque = new System.Windows.Forms.TextBox();
            this.pnl_acciones = new System.Windows.Forms.Panel();
            this.btn_AgregarRegla = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.pnl_reglasContenedor = new System.Windows.Forms.FlowLayoutPanel();
            this.pnl_regla = new System.Windows.Forms.Panel();
            this.btn_Eliminarregla = new System.Windows.Forms.Button();
            this.txt_codigo = new System.Windows.Forms.TextBox();
            this.txt_descripcion = new System.Windows.Forms.TextBox();
            this.txt_nombre = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_MinMax = new System.Windows.Forms.Button();
            this.pnl_top.SuspendLayout();
            this.pnl_acciones.SuspendLayout();
            this.pnl_reglasContenedor.SuspendLayout();
            this.pnl_regla.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_nombreBloque
            // 
            this.lbl_nombreBloque.AutoSize = true;
            this.lbl_nombreBloque.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_nombreBloque.Location = new System.Drawing.Point(3, 13);
            this.lbl_nombreBloque.Name = "lbl_nombreBloque";
            this.lbl_nombreBloque.Size = new System.Drawing.Size(133, 14);
            this.lbl_nombreBloque.TabIndex = 0;
            this.lbl_nombreBloque.Text = "Nombre del Bloque:";
            // 
            // pnl_top
            // 
            this.pnl_top.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_top.Controls.Add(this.btn_EliminarBloque);
            this.pnl_top.Controls.Add(this.txt_nombreBloque);
            this.pnl_top.Controls.Add(this.lbl_nombreBloque);
            this.pnl_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_top.Location = new System.Drawing.Point(0, 0);
            this.pnl_top.Name = "pnl_top";
            this.pnl_top.Size = new System.Drawing.Size(816, 43);
            this.pnl_top.TabIndex = 1;
            // 
            // btn_EliminarBloque
            // 
            this.btn_EliminarBloque.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_EliminarBloque.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_EliminarBloque.Location = new System.Drawing.Point(654, 9);
            this.btn_EliminarBloque.Name = "btn_EliminarBloque";
            this.btn_EliminarBloque.Size = new System.Drawing.Size(138, 25);
            this.btn_EliminarBloque.TabIndex = 6;
            this.btn_EliminarBloque.Text = "Eliminar Bloque";
            this.btn_EliminarBloque.UseVisualStyleBackColor = true;
            this.btn_EliminarBloque.Click += new System.EventHandler(this.btn_EliminarBloque_Click);
            // 
            // txt_nombreBloque
            // 
            this.txt_nombreBloque.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_nombreBloque.Location = new System.Drawing.Point(142, 9);
            this.txt_nombreBloque.Name = "txt_nombreBloque";
            this.txt_nombreBloque.Size = new System.Drawing.Size(199, 22);
            this.txt_nombreBloque.TabIndex = 1;
            // 
            // pnl_acciones
            // 
            this.pnl_acciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_acciones.Controls.Add(this.btn_MinMax);
            this.pnl_acciones.Controls.Add(this.btn_AgregarRegla);
            this.pnl_acciones.Controls.Add(this.label2);
            this.pnl_acciones.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_acciones.Location = new System.Drawing.Point(0, 43);
            this.pnl_acciones.Name = "pnl_acciones";
            this.pnl_acciones.Size = new System.Drawing.Size(816, 30);
            this.pnl_acciones.TabIndex = 2;
            // 
            // btn_AgregarRegla
            // 
            this.btn_AgregarRegla.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_AgregarRegla.Location = new System.Drawing.Point(688, 3);
            this.btn_AgregarRegla.Name = "btn_AgregarRegla";
            this.btn_AgregarRegla.Size = new System.Drawing.Size(49, 23);
            this.btn_AgregarRegla.TabIndex = 1;
            this.btn_AgregarRegla.Text = "✚";
            this.btn_AgregarRegla.UseVisualStyleBackColor = true;
            this.btn_AgregarRegla.Click += new System.EventHandler(this.btn_AgregarRegla_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Reglas";
            // 
            // pnl_reglasContenedor
            // 
            this.pnl_reglasContenedor.AutoScroll = true;
            this.pnl_reglasContenedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_reglasContenedor.Controls.Add(this.pnl_regla);
            this.pnl_reglasContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_reglasContenedor.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnl_reglasContenedor.Location = new System.Drawing.Point(0, 73);
            this.pnl_reglasContenedor.Name = "pnl_reglasContenedor";
            this.pnl_reglasContenedor.Size = new System.Drawing.Size(816, 286);
            this.pnl_reglasContenedor.TabIndex = 3;
            this.pnl_reglasContenedor.WrapContents = false;
            // 
            // pnl_regla
            // 
            this.pnl_regla.Controls.Add(this.btn_Eliminarregla);
            this.pnl_regla.Controls.Add(this.txt_codigo);
            this.pnl_regla.Controls.Add(this.txt_descripcion);
            this.pnl_regla.Controls.Add(this.txt_nombre);
            this.pnl_regla.Controls.Add(this.label5);
            this.pnl_regla.Controls.Add(this.label4);
            this.pnl_regla.Controls.Add(this.label3);
            this.pnl_regla.Location = new System.Drawing.Point(3, 3);
            this.pnl_regla.Name = "pnl_regla";
            this.pnl_regla.Size = new System.Drawing.Size(792, 134);
            this.pnl_regla.TabIndex = 0;
            this.pnl_regla.Visible = false;
            // 
            // btn_Eliminarregla
            // 
            this.btn_Eliminarregla.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Eliminarregla.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Eliminarregla.Location = new System.Drawing.Point(664, 85);
            this.btn_Eliminarregla.Name = "btn_Eliminarregla";
            this.btn_Eliminarregla.Size = new System.Drawing.Size(120, 32);
            this.btn_Eliminarregla.TabIndex = 4;
            this.btn_Eliminarregla.Text = "Eliminar Regla";
            this.btn_Eliminarregla.UseVisualStyleBackColor = true;
            // 
            // txt_codigo
            // 
            this.txt_codigo.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold);
            this.txt_codigo.Location = new System.Drawing.Point(87, 64);
            this.txt_codigo.Multiline = true;
            this.txt_codigo.Name = "txt_codigo";
            this.txt_codigo.Size = new System.Drawing.Size(574, 53);
            this.txt_codigo.TabIndex = 5;
            // 
            // txt_descripcion
            // 
            this.txt_descripcion.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold);
            this.txt_descripcion.Location = new System.Drawing.Point(87, 31);
            this.txt_descripcion.Name = "txt_descripcion";
            this.txt_descripcion.Size = new System.Drawing.Size(574, 20);
            this.txt_descripcion.TabIndex = 4;
            // 
            // txt_nombre
            // 
            this.txt_nombre.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_nombre.Location = new System.Drawing.Point(87, 5);
            this.txt_nombre.Name = "txt_nombre";
            this.txt_nombre.Size = new System.Drawing.Size(251, 20);
            this.txt_nombre.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(10, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Codigo:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(6, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Descripción:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Nombre:";
            // 
            // btn_MinMax
            // 
            this.btn_MinMax.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_MinMax.Location = new System.Drawing.Point(743, 3);
            this.btn_MinMax.Name = "btn_MinMax";
            this.btn_MinMax.Size = new System.Drawing.Size(49, 23);
            this.btn_MinMax.TabIndex = 2;
            this.btn_MinMax.Text = "▼";
            this.btn_MinMax.UseVisualStyleBackColor = true;
            this.btn_MinMax.Click += new System.EventHandler(this.btn_MinMax_Click);
            // 
            // BloqueKernelComponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 359);
            this.Controls.Add(this.pnl_reglasContenedor);
            this.Controls.Add(this.pnl_acciones);
            this.Controls.Add(this.pnl_top);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BloqueKernelComponent";
            this.Text = "BloqueKernelComponent";
            this.pnl_top.ResumeLayout(false);
            this.pnl_top.PerformLayout();
            this.pnl_acciones.ResumeLayout(false);
            this.pnl_acciones.PerformLayout();
            this.pnl_reglasContenedor.ResumeLayout(false);
            this.pnl_regla.ResumeLayout(false);
            this.pnl_regla.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_nombreBloque;
        private System.Windows.Forms.Panel pnl_top;
        private System.Windows.Forms.Panel pnl_acciones;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_nombreBloque;
        private System.Windows.Forms.Button btn_AgregarRegla;
        private System.Windows.Forms.FlowLayoutPanel pnl_reglasContenedor;
        private System.Windows.Forms.Panel pnl_regla;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_codigo;
        private System.Windows.Forms.TextBox txt_descripcion;
        private System.Windows.Forms.TextBox txt_nombre;
        private System.Windows.Forms.Button btn_EliminarBloque;
        private System.Windows.Forms.Button btn_Eliminarregla;
        private System.Windows.Forms.Button btn_MinMax;
    }
}