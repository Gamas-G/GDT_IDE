
namespace GDT_IDE_WF
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lbl_ipServTag = new System.Windows.Forms.Label();
            this.lbl_ipServ = new System.Windows.Forms.Label();
            this.link_dbForm = new System.Windows.Forms.LinkLabel();
            this.footer = new System.Windows.Forms.Panel();
            this.pnl_infoStatus = new System.Windows.Forms.Panel();
            this.lbl_estatus = new System.Windows.Forms.Label();
            this.lbl_copyright = new System.Windows.Forms.Label();
            this.lbl_redelektra = new System.Windows.Forms.Label();
            this.lbl_destec = new System.Windows.Forms.Label();
            this.pnl_menu = new System.Windows.Forms.Panel();
            this.pnlContButtons = new System.Windows.Forms.Panel();
            this.btn_manual = new System.Windows.Forms.Button();
            this.btn_eliminar = new System.Windows.Forms.Button();
            this.btn_actualizar = new System.Windows.Forms.Button();
            this.btn_buscar = new System.Windows.Forms.Button();
            this.btn_crear = new System.Windows.Forms.Button();
            this.menu_header = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnl_top = new System.Windows.Forms.Panel();
            this.lbl_usuario = new System.Windows.Forms.Label();
            this.lbl_usuarioTag = new System.Windows.Forms.Label();
            this.lbl_db = new System.Windows.Forms.Label();
            this.lbl_dbTag = new System.Windows.Forms.Label();
            this.body = new System.Windows.Forms.Panel();
            this.footer.SuspendLayout();
            this.pnl_infoStatus.SuspendLayout();
            this.pnl_menu.SuspendLayout();
            this.pnlContButtons.SuspendLayout();
            this.menu_header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnl_top.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_ipServTag
            // 
            this.lbl_ipServTag.AutoSize = true;
            this.lbl_ipServTag.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ipServTag.ForeColor = System.Drawing.Color.White;
            this.lbl_ipServTag.Location = new System.Drawing.Point(10, 6);
            this.lbl_ipServTag.Name = "lbl_ipServTag";
            this.lbl_ipServTag.Size = new System.Drawing.Size(80, 18);
            this.lbl_ipServTag.TabIndex = 5;
            this.lbl_ipServTag.Text = "Servidor:";
            // 
            // lbl_ipServ
            // 
            this.lbl_ipServ.AutoSize = true;
            this.lbl_ipServ.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ipServ.ForeColor = System.Drawing.Color.White;
            this.lbl_ipServ.Location = new System.Drawing.Point(92, 6);
            this.lbl_ipServ.Name = "lbl_ipServ";
            this.lbl_ipServ.Size = new System.Drawing.Size(64, 18);
            this.lbl_ipServ.TabIndex = 4;
            this.lbl_ipServ.Text = "0.0.0.0";
            // 
            // link_dbForm
            // 
            this.link_dbForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.link_dbForm.AutoSize = true;
            this.link_dbForm.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.link_dbForm.LinkColor = System.Drawing.Color.White;
            this.link_dbForm.Location = new System.Drawing.Point(875, 6);
            this.link_dbForm.Name = "link_dbForm";
            this.link_dbForm.Size = new System.Drawing.Size(136, 18);
            this.link_dbForm.TabIndex = 3;
            this.link_dbForm.TabStop = true;
            this.link_dbForm.Text = "Agregar Servidor";
            this.link_dbForm.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_dbForm_LinkClicked);
            // 
            // footer
            // 
            this.footer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(98)))), ((int)(((byte)(66)))));
            this.footer.Controls.Add(this.pnl_infoStatus);
            this.footer.Controls.Add(this.lbl_copyright);
            this.footer.Controls.Add(this.lbl_redelektra);
            this.footer.Controls.Add(this.lbl_destec);
            this.footer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footer.Location = new System.Drawing.Point(0, 719);
            this.footer.Name = "footer";
            this.footer.Size = new System.Drawing.Size(1180, 89);
            this.footer.TabIndex = 4;
            // 
            // pnl_infoStatus
            // 
            this.pnl_infoStatus.Controls.Add(this.lbl_estatus);
            this.pnl_infoStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_infoStatus.Location = new System.Drawing.Point(0, 0);
            this.pnl_infoStatus.Name = "pnl_infoStatus";
            this.pnl_infoStatus.Size = new System.Drawing.Size(1180, 31);
            this.pnl_infoStatus.TabIndex = 3;
            // 
            // lbl_estatus
            // 
            this.lbl_estatus.AutoSize = true;
            this.lbl_estatus.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_estatus.ForeColor = System.Drawing.Color.White;
            this.lbl_estatus.Location = new System.Drawing.Point(11, 8);
            this.lbl_estatus.Name = "lbl_estatus";
            this.lbl_estatus.Size = new System.Drawing.Size(133, 14);
            this.lbl_estatus.TabIndex = 0;
            this.lbl_estatus.Text = "Estatus aplicación";
            // 
            // lbl_copyright
            // 
            this.lbl_copyright.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_copyright.AutoSize = true;
            this.lbl_copyright.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_copyright.ForeColor = System.Drawing.Color.White;
            this.lbl_copyright.Location = new System.Drawing.Point(346, 60);
            this.lbl_copyright.Name = "lbl_copyright";
            this.lbl_copyright.Size = new System.Drawing.Size(80, 18);
            this.lbl_copyright.TabIndex = 2;
            this.lbl_copyright.Text = "copyright";
            // 
            // lbl_redelektra
            // 
            this.lbl_redelektra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_redelektra.AutoSize = true;
            this.lbl_redelektra.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_redelektra.ForeColor = System.Drawing.Color.White;
            this.lbl_redelektra.Location = new System.Drawing.Point(1016, 60);
            this.lbl_redelektra.Name = "lbl_redelektra";
            this.lbl_redelektra.Size = new System.Drawing.Size(144, 18);
            this.lbl_redelektra.TabIndex = 1;
            this.lbl_redelektra.Text = "Red Grupo Elektra";
            // 
            // lbl_destec
            // 
            this.lbl_destec.AutoSize = true;
            this.lbl_destec.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_destec.ForeColor = System.Drawing.Color.White;
            this.lbl_destec.Location = new System.Drawing.Point(12, 60);
            this.lbl_destec.Name = "lbl_destec";
            this.lbl_destec.Size = new System.Drawing.Size(56, 18);
            this.lbl_destec.TabIndex = 0;
            this.lbl_destec.Text = "DesTec";
            // 
            // pnl_menu
            // 
            this.pnl_menu.Controls.Add(this.pnlContButtons);
            this.pnl_menu.Controls.Add(this.menu_header);
            this.pnl_menu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnl_menu.Location = new System.Drawing.Point(0, 0);
            this.pnl_menu.Name = "pnl_menu";
            this.pnl_menu.Size = new System.Drawing.Size(156, 719);
            this.pnl_menu.TabIndex = 5;
            // 
            // pnlContButtons
            // 
            this.pnlContButtons.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlContButtons.Controls.Add(this.btn_manual);
            this.pnlContButtons.Controls.Add(this.btn_eliminar);
            this.pnlContButtons.Controls.Add(this.btn_actualizar);
            this.pnlContButtons.Controls.Add(this.btn_buscar);
            this.pnlContButtons.Controls.Add(this.btn_crear);
            this.pnlContButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContButtons.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlContButtons.Location = new System.Drawing.Point(0, 72);
            this.pnlContButtons.Name = "pnlContButtons";
            this.pnlContButtons.Size = new System.Drawing.Size(156, 647);
            this.pnlContButtons.TabIndex = 1;
            // 
            // btn_manual
            // 
            this.btn_manual.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_manual.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_manual.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_manual.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_manual.Image = global::GDT_IDE_WF.Properties.Resources.manualcono;
            this.btn_manual.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_manual.Location = new System.Drawing.Point(0, 256);
            this.btn_manual.Name = "btn_manual";
            this.btn_manual.Size = new System.Drawing.Size(154, 64);
            this.btn_manual.TabIndex = 4;
            this.btn_manual.Text = "Manual Kernel";
            this.btn_manual.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_manual.UseVisualStyleBackColor = true;
            this.btn_manual.Click += new System.EventHandler(this.btn_manual_Click);
            // 
            // btn_eliminar
            // 
            this.btn_eliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_eliminar.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_eliminar.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_eliminar.Image = ((System.Drawing.Image)(resources.GetObject("btn_eliminar.Image")));
            this.btn_eliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_eliminar.Location = new System.Drawing.Point(0, 192);
            this.btn_eliminar.Name = "btn_eliminar";
            this.btn_eliminar.Size = new System.Drawing.Size(154, 64);
            this.btn_eliminar.TabIndex = 3;
            this.btn_eliminar.Text = "Eliminar Regla";
            this.btn_eliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_eliminar.UseVisualStyleBackColor = true;
            this.btn_eliminar.Click += new System.EventHandler(this.btn_eliminar_Click);
            // 
            // btn_actualizar
            // 
            this.btn_actualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_actualizar.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_actualizar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_actualizar.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_actualizar.Image = ((System.Drawing.Image)(resources.GetObject("btn_actualizar.Image")));
            this.btn_actualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_actualizar.Location = new System.Drawing.Point(0, 128);
            this.btn_actualizar.Name = "btn_actualizar";
            this.btn_actualizar.Size = new System.Drawing.Size(154, 64);
            this.btn_actualizar.TabIndex = 2;
            this.btn_actualizar.Text = "Actualizar Regla";
            this.btn_actualizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_actualizar.UseVisualStyleBackColor = true;
            this.btn_actualizar.Click += new System.EventHandler(this.btn_actualizar_Click);
            // 
            // btn_buscar
            // 
            this.btn_buscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_buscar.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_buscar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_buscar.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_buscar.Image = ((System.Drawing.Image)(resources.GetObject("btn_buscar.Image")));
            this.btn_buscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_buscar.Location = new System.Drawing.Point(0, 64);
            this.btn_buscar.Name = "btn_buscar";
            this.btn_buscar.Size = new System.Drawing.Size(154, 64);
            this.btn_buscar.TabIndex = 1;
            this.btn_buscar.TabStop = false;
            this.btn_buscar.Text = "Buscar Regla";
            this.btn_buscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_buscar.UseVisualStyleBackColor = true;
            this.btn_buscar.Click += new System.EventHandler(this.btn_buscar_Click_1);
            // 
            // btn_crear
            // 
            this.btn_crear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_crear.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_crear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_crear.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_crear.Image = ((System.Drawing.Image)(resources.GetObject("btn_crear.Image")));
            this.btn_crear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_crear.Location = new System.Drawing.Point(0, 0);
            this.btn_crear.Name = "btn_crear";
            this.btn_crear.Size = new System.Drawing.Size(154, 64);
            this.btn_crear.TabIndex = 0;
            this.btn_crear.Text = "Crear nueva Regla";
            this.btn_crear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_crear.UseVisualStyleBackColor = true;
            this.btn_crear.Click += new System.EventHandler(this.btn_crear_Click);
            // 
            // menu_header
            // 
            this.menu_header.BackColor = System.Drawing.SystemColors.Control;
            this.menu_header.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.menu_header.Controls.Add(this.label2);
            this.menu_header.Controls.Add(this.pictureBox1);
            this.menu_header.Dock = System.Windows.Forms.DockStyle.Top;
            this.menu_header.Location = new System.Drawing.Point(0, 0);
            this.menu_header.Name = "menu_header";
            this.menu_header.Size = new System.Drawing.Size(156, 72);
            this.menu_header.TabIndex = 0;
            this.menu_header.Paint += new System.Windows.Forms.PaintEventHandler(this.menu_header_Paint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(75, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Kernel";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(24, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pnl_top
            // 
            this.pnl_top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(98)))), ((int)(((byte)(66)))));
            this.pnl_top.Controls.Add(this.lbl_usuario);
            this.pnl_top.Controls.Add(this.lbl_usuarioTag);
            this.pnl_top.Controls.Add(this.lbl_db);
            this.pnl_top.Controls.Add(this.lbl_dbTag);
            this.pnl_top.Controls.Add(this.lbl_ipServTag);
            this.pnl_top.Controls.Add(this.link_dbForm);
            this.pnl_top.Controls.Add(this.lbl_ipServ);
            this.pnl_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_top.Location = new System.Drawing.Point(156, 0);
            this.pnl_top.Name = "pnl_top";
            this.pnl_top.Size = new System.Drawing.Size(1024, 33);
            this.pnl_top.TabIndex = 6;
            // 
            // lbl_usuario
            // 
            this.lbl_usuario.AutoSize = true;
            this.lbl_usuario.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_usuario.ForeColor = System.Drawing.Color.White;
            this.lbl_usuario.Location = new System.Drawing.Point(469, 6);
            this.lbl_usuario.Name = "lbl_usuario";
            this.lbl_usuario.Size = new System.Drawing.Size(56, 18);
            this.lbl_usuario.TabIndex = 9;
            this.lbl_usuario.Text = "label6";
            // 
            // lbl_usuarioTag
            // 
            this.lbl_usuarioTag.AutoSize = true;
            this.lbl_usuarioTag.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_usuarioTag.ForeColor = System.Drawing.Color.White;
            this.lbl_usuarioTag.Location = new System.Drawing.Point(389, 6);
            this.lbl_usuarioTag.Name = "lbl_usuarioTag";
            this.lbl_usuarioTag.Size = new System.Drawing.Size(80, 18);
            this.lbl_usuarioTag.TabIndex = 8;
            this.lbl_usuarioTag.Text = "Usuario: ";
            // 
            // lbl_db
            // 
            this.lbl_db.AutoSize = true;
            this.lbl_db.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_db.ForeColor = System.Drawing.Color.White;
            this.lbl_db.Location = new System.Drawing.Point(259, 6);
            this.lbl_db.Name = "lbl_db";
            this.lbl_db.Size = new System.Drawing.Size(56, 18);
            this.lbl_db.TabIndex = 7;
            this.lbl_db.Text = "label4";
            // 
            // lbl_dbTag
            // 
            this.lbl_dbTag.AutoSize = true;
            this.lbl_dbTag.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_dbTag.ForeColor = System.Drawing.Color.White;
            this.lbl_dbTag.Location = new System.Drawing.Point(224, 6);
            this.lbl_dbTag.Name = "lbl_dbTag";
            this.lbl_dbTag.Size = new System.Drawing.Size(32, 18);
            this.lbl_dbTag.TabIndex = 6;
            this.lbl_dbTag.Text = "DB:";
            // 
            // body
            // 
            this.body.AutoScroll = true;
            this.body.BackColor = System.Drawing.SystemColors.Control;
            this.body.Dock = System.Windows.Forms.DockStyle.Fill;
            this.body.Location = new System.Drawing.Point(156, 33);
            this.body.Name = "body";
            this.body.Size = new System.Drawing.Size(1024, 686);
            this.body.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1180, 808);
            this.Controls.Add(this.body);
            this.Controls.Add(this.pnl_top);
            this.Controls.Add(this.pnl_menu);
            this.Controls.Add(this.footer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Interprete Kernel";
            this.footer.ResumeLayout(false);
            this.footer.PerformLayout();
            this.pnl_infoStatus.ResumeLayout(false);
            this.pnl_infoStatus.PerformLayout();
            this.pnl_menu.ResumeLayout(false);
            this.pnlContButtons.ResumeLayout(false);
            this.menu_header.ResumeLayout(false);
            this.menu_header.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnl_top.ResumeLayout(false);
            this.pnl_top.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.LinkLabel link_dbForm;
        private System.Windows.Forms.Label lbl_ipServ;
        private System.Windows.Forms.Label lbl_ipServTag;
        private System.Windows.Forms.Panel footer;
        private System.Windows.Forms.Label lbl_destec;
        private System.Windows.Forms.Label lbl_redelektra;
        private System.Windows.Forms.Label lbl_copyright;
        private System.Windows.Forms.Panel pnl_menu;
        private System.Windows.Forms.Panel pnlContButtons;
        private System.Windows.Forms.Panel menu_header;
        private System.Windows.Forms.Button btn_crear;
        private System.Windows.Forms.Button btn_eliminar;
        private System.Windows.Forms.Button btn_actualizar;
        private System.Windows.Forms.Button btn_buscar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel pnl_top;
        private System.Windows.Forms.Panel body;
        private System.Windows.Forms.Label lbl_db;
        private System.Windows.Forms.Label lbl_dbTag;
        private System.Windows.Forms.Label lbl_usuario;
        private System.Windows.Forms.Label lbl_usuarioTag;
        private System.Windows.Forms.Panel pnl_infoStatus;
        private System.Windows.Forms.Label lbl_estatus;
        private System.Windows.Forms.Button btn_manual;
    }
}

