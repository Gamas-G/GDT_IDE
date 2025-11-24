
namespace GDT_IDE_WF.Vista.DBA
{
    partial class Servidor_Form
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_laboratorios = new System.Windows.Forms.ComboBox();
            this.txt_user = new System.Windows.Forms.TextBox();
            this.txt_pwd = new System.Windows.Forms.TextBox();
            this.btn_credenciales = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_destec = new System.Windows.Forms.Label();
            this.lbl_pais = new System.Windows.Forms.Label();
            this.lbl_canal = new System.Windows.Forms.Label();
            this.cb_pais = new System.Windows.Forms.ComboBox();
            this.cb_canal = new System.Windows.Forms.ComboBox();
            this.lbl_nombreServidor = new System.Windows.Forms.Label();
            this.txt_bd = new System.Windows.Forms.TextBox();
            this.txt_ip = new System.Windows.Forms.TextBox();
            this.btn_borrar = new System.Windows.Forms.Button();
            this.errorProviderIP = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderIP)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(46, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP Servidor";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(406, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "DB";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(223, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Usuario";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(50, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = "Password";
            // 
            // cb_laboratorios
            // 
            this.cb_laboratorios.Font = new System.Drawing.Font("Consolas", 9F);
            this.cb_laboratorios.FormattingEnabled = true;
            this.cb_laboratorios.Location = new System.Drawing.Point(407, 39);
            this.cb_laboratorios.Name = "cb_laboratorios";
            this.cb_laboratorios.Size = new System.Drawing.Size(166, 22);
            this.cb_laboratorios.TabIndex = 14;
            this.cb_laboratorios.SelectedIndexChanged += new System.EventHandler(this.cb_laboratorios_SelectedIndexChanged);
            this.cb_laboratorios.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cb_laboratorios_KeyDown);
            // 
            // txt_user
            // 
            this.txt_user.Font = new System.Drawing.Font("Consolas", 9F);
            this.txt_user.Location = new System.Drawing.Point(222, 94);
            this.txt_user.Name = "txt_user";
            this.txt_user.Size = new System.Drawing.Size(166, 22);
            this.txt_user.TabIndex = 16;
            // 
            // txt_pwd
            // 
            this.txt_pwd.Font = new System.Drawing.Font("Consolas", 9F);
            this.txt_pwd.Location = new System.Drawing.Point(42, 152);
            this.txt_pwd.Name = "txt_pwd";
            this.txt_pwd.Size = new System.Drawing.Size(166, 22);
            this.txt_pwd.TabIndex = 18;
            // 
            // btn_credenciales
            // 
            this.btn_credenciales.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_credenciales.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_credenciales.Location = new System.Drawing.Point(222, 248);
            this.btn_credenciales.Name = "btn_credenciales";
            this.btn_credenciales.Size = new System.Drawing.Size(166, 41);
            this.btn_credenciales.TabIndex = 19;
            this.btn_credenciales.Text = "Guardar";
            this.btn_credenciales.UseVisualStyleBackColor = true;
            this.btn_credenciales.Click += new System.EventHandler(this.btn_credenciales_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(98)))), ((int)(((byte)(66)))));
            this.panel1.Controls.Add(this.lbl_destec);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 295);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(619, 36);
            this.panel1.TabIndex = 9;
            // 
            // lbl_destec
            // 
            this.lbl_destec.AutoSize = true;
            this.lbl_destec.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_destec.ForeColor = System.Drawing.Color.White;
            this.lbl_destec.Location = new System.Drawing.Point(8, 6);
            this.lbl_destec.Name = "lbl_destec";
            this.lbl_destec.Size = new System.Drawing.Size(70, 22);
            this.lbl_destec.TabIndex = 1;
            this.lbl_destec.Text = "DesTec";
            // 
            // lbl_pais
            // 
            this.lbl_pais.AutoSize = true;
            this.lbl_pais.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_pais.Location = new System.Drawing.Point(47, 20);
            this.lbl_pais.Name = "lbl_pais";
            this.lbl_pais.Size = new System.Drawing.Size(40, 18);
            this.lbl_pais.TabIndex = 10;
            this.lbl_pais.Text = "País";
            // 
            // lbl_canal
            // 
            this.lbl_canal.AutoSize = true;
            this.lbl_canal.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_canal.Location = new System.Drawing.Point(224, 20);
            this.lbl_canal.Name = "lbl_canal";
            this.lbl_canal.Size = new System.Drawing.Size(48, 18);
            this.lbl_canal.TabIndex = 11;
            this.lbl_canal.Text = "Canal";
            // 
            // cb_pais
            // 
            this.cb_pais.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_pais.FormattingEnabled = true;
            this.cb_pais.Location = new System.Drawing.Point(42, 39);
            this.cb_pais.Name = "cb_pais";
            this.cb_pais.Size = new System.Drawing.Size(166, 22);
            this.cb_pais.TabIndex = 12;
            this.cb_pais.SelectedIndexChanged += new System.EventHandler(this.cb_pais_SelectedIndexChanged);
            this.cb_pais.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cb_pais_KeyDown);
            // 
            // cb_canal
            // 
            this.cb_canal.Font = new System.Drawing.Font("Consolas", 9F);
            this.cb_canal.FormattingEnabled = true;
            this.cb_canal.Location = new System.Drawing.Point(222, 39);
            this.cb_canal.Name = "cb_canal";
            this.cb_canal.Size = new System.Drawing.Size(166, 22);
            this.cb_canal.TabIndex = 13;
            this.cb_canal.SelectedIndexChanged += new System.EventHandler(this.cb_canal_SelectedIndexChanged);
            this.cb_canal.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cb_canal_KeyDown);
            // 
            // lbl_nombreServidor
            // 
            this.lbl_nombreServidor.AutoSize = true;
            this.lbl_nombreServidor.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_nombreServidor.Location = new System.Drawing.Point(404, 20);
            this.lbl_nombreServidor.Name = "lbl_nombreServidor";
            this.lbl_nombreServidor.Size = new System.Drawing.Size(72, 18);
            this.lbl_nombreServidor.TabIndex = 14;
            this.lbl_nombreServidor.Text = "Servidor";
            // 
            // txt_bd
            // 
            this.txt_bd.Font = new System.Drawing.Font("Consolas", 9F);
            this.txt_bd.Location = new System.Drawing.Point(407, 94);
            this.txt_bd.Name = "txt_bd";
            this.txt_bd.Size = new System.Drawing.Size(166, 22);
            this.txt_bd.TabIndex = 17;
            // 
            // txt_ip
            // 
            this.txt_ip.Font = new System.Drawing.Font("Consolas", 9F);
            this.txt_ip.Location = new System.Drawing.Point(42, 94);
            this.txt_ip.Name = "txt_ip";
            this.txt_ip.Size = new System.Drawing.Size(166, 22);
            this.txt_ip.TabIndex = 15;
            this.txt_ip.Validating += new System.ComponentModel.CancelEventHandler(this.txt_ip_Validating);
            // 
            // btn_borrar
            // 
            this.btn_borrar.BackColor = System.Drawing.Color.Transparent;
            this.btn_borrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_borrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_borrar.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_borrar.Image = global::GDT_IDE_WF.Properties.Resources.trash;
            this.btn_borrar.Location = new System.Drawing.Point(565, 248);
            this.btn_borrar.Name = "btn_borrar";
            this.btn_borrar.Size = new System.Drawing.Size(42, 41);
            this.btn_borrar.TabIndex = 20;
            this.btn_borrar.UseVisualStyleBackColor = false;
            this.btn_borrar.Click += new System.EventHandler(this.btn_borrar_Click);
            // 
            // errorProviderIP
            // 
            this.errorProviderIP.ContainerControl = this;
            // 
            // DBA_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 331);
            this.Controls.Add(this.btn_borrar);
            this.Controls.Add(this.txt_ip);
            this.Controls.Add(this.txt_bd);
            this.Controls.Add(this.lbl_nombreServidor);
            this.Controls.Add(this.cb_canal);
            this.Controls.Add(this.cb_pais);
            this.Controls.Add(this.lbl_canal);
            this.Controls.Add(this.lbl_pais);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_credenciales);
            this.Controls.Add(this.txt_pwd);
            this.Controls.Add(this.txt_user);
            this.Controls.Add(this.cb_laboratorios);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DBA_Form";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Información de servidor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DBA_Form_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderIP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cb_laboratorios;
        private System.Windows.Forms.TextBox txt_user;
        private System.Windows.Forms.TextBox txt_pwd;
        private System.Windows.Forms.Button btn_credenciales;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_destec;
        private System.Windows.Forms.Label lbl_pais;
        private System.Windows.Forms.Label lbl_canal;
        private System.Windows.Forms.ComboBox cb_pais;
        private System.Windows.Forms.ComboBox cb_canal;
        private System.Windows.Forms.Label lbl_nombreServidor;
        private System.Windows.Forms.TextBox txt_bd;
        private System.Windows.Forms.TextBox txt_ip;
        private System.Windows.Forms.Button btn_borrar;
        private System.Windows.Forms.ErrorProvider errorProviderIP;
    }
}