
namespace GDT_IDE_WF.Componentes
{
    partial class BusquedaComponent
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
            this.pnl_opciones_avanzadas = new System.Windows.Forms.Panel();
            this.txt_fiSubItemId = new System.Windows.Forms.TextBox();
            this.lbl_fisubItemId = new System.Windows.Forms.Label();
            this.rd_todos = new System.Windows.Forms.RadioButton();
            this.rd_desactivas = new System.Windows.Forms.RadioButton();
            this.rd_activas = new System.Windows.Forms.RadioButton();
            this.lbl_fcCatDesc = new System.Windows.Forms.Label();
            this.txt_fcCatDesc = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.cbx_catalogoReglas = new System.Windows.Forms.ComboBox();
            this.rbtn_100 = new System.Windows.Forms.RadioButton();
            this.rbtn_526 = new System.Windows.Forms.RadioButton();
            this.lbl_mensajeRegla = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ck_opciones_avanzadas = new System.Windows.Forms.CheckBox();
            this.txt_buscarRegla = new System.Windows.Forms.TextBox();
            this.btn_buscarRegla = new System.Windows.Forms.Button();
            this.pnl_opciones_avanzadas.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_opciones_avanzadas
            // 
            this.pnl_opciones_avanzadas.BackColor = System.Drawing.Color.Transparent;
            this.pnl_opciones_avanzadas.Controls.Add(this.txt_fiSubItemId);
            this.pnl_opciones_avanzadas.Controls.Add(this.lbl_fisubItemId);
            this.pnl_opciones_avanzadas.Controls.Add(this.rd_todos);
            this.pnl_opciones_avanzadas.Controls.Add(this.rd_desactivas);
            this.pnl_opciones_avanzadas.Controls.Add(this.rd_activas);
            this.pnl_opciones_avanzadas.Controls.Add(this.lbl_fcCatDesc);
            this.pnl_opciones_avanzadas.Controls.Add(this.txt_fcCatDesc);
            this.pnl_opciones_avanzadas.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_opciones_avanzadas.Location = new System.Drawing.Point(0, 62);
            this.pnl_opciones_avanzadas.Name = "pnl_opciones_avanzadas";
            this.pnl_opciones_avanzadas.Size = new System.Drawing.Size(800, 76);
            this.pnl_opciones_avanzadas.TabIndex = 11;
            // 
            // txt_fiSubItemId
            // 
            this.txt_fiSubItemId.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_fiSubItemId.Location = new System.Drawing.Point(109, 6);
            this.txt_fiSubItemId.Name = "txt_fiSubItemId";
            this.txt_fiSubItemId.Size = new System.Drawing.Size(81, 20);
            this.txt_fiSubItemId.TabIndex = 7;
            this.txt_fiSubItemId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_fiSubItemId_KeyPress);
            // 
            // lbl_fisubItemId
            // 
            this.lbl_fisubItemId.AutoSize = true;
            this.lbl_fisubItemId.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_fisubItemId.Location = new System.Drawing.Point(15, 11);
            this.lbl_fisubItemId.Name = "lbl_fisubItemId";
            this.lbl_fisubItemId.Size = new System.Drawing.Size(91, 14);
            this.lbl_fisubItemId.TabIndex = 6;
            this.lbl_fisubItemId.Text = "fisubItemId:";
            // 
            // rd_todos
            // 
            this.rd_todos.AutoSize = true;
            this.rd_todos.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rd_todos.Location = new System.Drawing.Point(539, 7);
            this.rd_todos.Name = "rd_todos";
            this.rd_todos.Size = new System.Drawing.Size(55, 17);
            this.rd_todos.TabIndex = 5;
            this.rd_todos.TabStop = true;
            this.rd_todos.Text = "Todos";
            this.rd_todos.UseVisualStyleBackColor = true;
            this.rd_todos.CheckedChanged += new System.EventHandler(this.rd_todos_CheckedChanged);
            // 
            // rd_desactivas
            // 
            this.rd_desactivas.AutoSize = true;
            this.rd_desactivas.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rd_desactivas.Location = new System.Drawing.Point(453, 7);
            this.rd_desactivas.Name = "rd_desactivas";
            this.rd_desactivas.Size = new System.Drawing.Size(85, 17);
            this.rd_desactivas.TabIndex = 4;
            this.rd_desactivas.TabStop = true;
            this.rd_desactivas.Text = "Desactivas";
            this.rd_desactivas.UseVisualStyleBackColor = true;
            this.rd_desactivas.CheckedChanged += new System.EventHandler(this.rd_desactivas_CheckedChanged);
            // 
            // rd_activas
            // 
            this.rd_activas.AutoSize = true;
            this.rd_activas.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rd_activas.Location = new System.Drawing.Point(385, 7);
            this.rd_activas.Name = "rd_activas";
            this.rd_activas.Size = new System.Drawing.Size(67, 17);
            this.rd_activas.TabIndex = 3;
            this.rd_activas.TabStop = true;
            this.rd_activas.Text = "Activas";
            this.rd_activas.UseVisualStyleBackColor = true;
            this.rd_activas.CheckedChanged += new System.EventHandler(this.rd_activas_CheckedChanged);
            // 
            // lbl_fcCatDesc
            // 
            this.lbl_fcCatDesc.AutoSize = true;
            this.lbl_fcCatDesc.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_fcCatDesc.Location = new System.Drawing.Point(15, 34);
            this.lbl_fcCatDesc.Name = "lbl_fcCatDesc";
            this.lbl_fcCatDesc.Size = new System.Drawing.Size(77, 14);
            this.lbl_fcCatDesc.TabIndex = 2;
            this.lbl_fcCatDesc.Text = "fcCatDesc:";
            // 
            // txt_fcCatDesc
            // 
            this.txt_fcCatDesc.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_fcCatDesc.Location = new System.Drawing.Point(108, 31);
            this.txt_fcCatDesc.Name = "txt_fcCatDesc";
            this.txt_fcCatDesc.Size = new System.Drawing.Size(213, 20);
            this.txt_fcCatDesc.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.Controls.Add(this.cbx_catalogoReglas);
            this.panel4.Controls.Add(this.rbtn_100);
            this.panel4.Controls.Add(this.rbtn_526);
            this.panel4.Controls.Add(this.lbl_mensajeRegla);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.ck_opciones_avanzadas);
            this.panel4.Controls.Add(this.txt_buscarRegla);
            this.panel4.Controls.Add(this.btn_buscarRegla);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(800, 62);
            this.panel4.TabIndex = 10;
            // 
            // cbx_catalogoReglas
            // 
            this.cbx_catalogoReglas.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_catalogoReglas.FormattingEnabled = true;
            this.cbx_catalogoReglas.Items.AddRange(new object[] {
            "Todos"});
            this.cbx_catalogoReglas.Location = new System.Drawing.Point(383, 30);
            this.cbx_catalogoReglas.Name = "cbx_catalogoReglas";
            this.cbx_catalogoReglas.Size = new System.Drawing.Size(221, 26);
            this.cbx_catalogoReglas.TabIndex = 9;
            // 
            // rbtn_100
            // 
            this.rbtn_100.AutoSize = true;
            this.rbtn_100.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtn_100.Location = new System.Drawing.Point(477, 10);
            this.rbtn_100.Name = "rbtn_100";
            this.rbtn_100.Size = new System.Drawing.Size(85, 17);
            this.rbtn_100.TabIndex = 8;
            this.rbtn_100.TabStop = true;
            this.rbtn_100.Text = "Reglas 100";
            this.rbtn_100.UseVisualStyleBackColor = true;
            this.rbtn_100.CheckedChanged += new System.EventHandler(this.rbtn_100_CheckedChanged);
            // 
            // rbtn_526
            // 
            this.rbtn_526.AutoSize = true;
            this.rbtn_526.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtn_526.Location = new System.Drawing.Point(386, 10);
            this.rbtn_526.Name = "rbtn_526";
            this.rbtn_526.Size = new System.Drawing.Size(85, 17);
            this.rbtn_526.TabIndex = 7;
            this.rbtn_526.TabStop = true;
            this.rbtn_526.Text = "Reglas 526";
            this.rbtn_526.UseVisualStyleBackColor = true;
            this.rbtn_526.CheckedChanged += new System.EventHandler(this.rbtn_526_CheckedChanged);
            // 
            // lbl_mensajeRegla
            // 
            this.lbl_mensajeRegla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_mensajeRegla.AutoSize = true;
            this.lbl_mensajeRegla.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_mensajeRegla.Location = new System.Drawing.Point(680, 35);
            this.lbl_mensajeRegla.Name = "lbl_mensajeRegla";
            this.lbl_mensajeRegla.Size = new System.Drawing.Size(115, 13);
            this.lbl_mensajeRegla.TabIndex = 6;
            this.lbl_mensajeRegla.Text = "fiItemDefault: 526";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "Buscar Regla en Kernel:";
            // 
            // ck_opciones_avanzadas
            // 
            this.ck_opciones_avanzadas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ck_opciones_avanzadas.AutoSize = true;
            this.ck_opciones_avanzadas.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ck_opciones_avanzadas.Location = new System.Drawing.Point(665, 10);
            this.ck_opciones_avanzadas.Name = "ck_opciones_avanzadas";
            this.ck_opciones_avanzadas.Size = new System.Drawing.Size(128, 17);
            this.ck_opciones_avanzadas.TabIndex = 5;
            this.ck_opciones_avanzadas.Text = "Busqueda Avanzada";
            this.ck_opciones_avanzadas.UseVisualStyleBackColor = true;
            this.ck_opciones_avanzadas.CheckedChanged += new System.EventHandler(this.ck_opciones_avanzadas_CheckedChanged);
            // 
            // txt_buscarRegla
            // 
            this.txt_buscarRegla.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_buscarRegla.Location = new System.Drawing.Point(15, 35);
            this.txt_buscarRegla.Name = "txt_buscarRegla";
            this.txt_buscarRegla.Size = new System.Drawing.Size(267, 20);
            this.txt_buscarRegla.TabIndex = 3;
            // 
            // btn_buscarRegla
            // 
            this.btn_buscarRegla.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_buscarRegla.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_buscarRegla.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_buscarRegla.Location = new System.Drawing.Point(288, 34);
            this.btn_buscarRegla.Name = "btn_buscarRegla";
            this.btn_buscarRegla.Size = new System.Drawing.Size(64, 21);
            this.btn_buscarRegla.TabIndex = 4;
            this.btn_buscarRegla.Text = "Buscar";
            this.btn_buscarRegla.UseVisualStyleBackColor = true;
            // 
            // BusquedaComponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 123);
            this.Controls.Add(this.pnl_opciones_avanzadas);
            this.Controls.Add(this.panel4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BusquedaComponent";
            this.Text = "BusquedaComponent";
            this.Load += new System.EventHandler(this.BusquedaComponent_Load);
            this.pnl_opciones_avanzadas.ResumeLayout(false);
            this.pnl_opciones_avanzadas.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_opciones_avanzadas;
        private System.Windows.Forms.Label lbl_fcCatDesc;
        private System.Windows.Forms.TextBox txt_fcCatDesc;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lbl_mensajeRegla;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox ck_opciones_avanzadas;
        private System.Windows.Forms.TextBox txt_buscarRegla;
        private System.Windows.Forms.Button btn_buscarRegla;
        private System.Windows.Forms.RadioButton rbtn_100;
        private System.Windows.Forms.RadioButton rbtn_526;
        private System.Windows.Forms.ComboBox cbx_catalogoReglas;
        private System.Windows.Forms.RadioButton rd_todos;
        private System.Windows.Forms.RadioButton rd_desactivas;
        private System.Windows.Forms.RadioButton rd_activas;
        private System.Windows.Forms.Label lbl_fisubItemId;
        private System.Windows.Forms.TextBox txt_fiSubItemId;
    }
}