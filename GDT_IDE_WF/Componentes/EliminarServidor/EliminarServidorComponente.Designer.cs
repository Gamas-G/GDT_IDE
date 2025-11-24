
namespace GDT_IDE_WF.Componentes.EliminarServidor
{
    partial class EliminarServidorComponente
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
            this.treeView_DataServidor = new System.Windows.Forms.TreeView();
            this.btn_Eliminar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_destec = new System.Windows.Forms.Label();
            this.groupBox_info = new System.Windows.Forms.GroupBox();
            this.lbl_info = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox_info.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView_DataServidor
            // 
            this.treeView_DataServidor.CheckBoxes = true;
            this.treeView_DataServidor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.treeView_DataServidor.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView_DataServidor.Location = new System.Drawing.Point(12, 33);
            this.treeView_DataServidor.Name = "treeView_DataServidor";
            this.treeView_DataServidor.Size = new System.Drawing.Size(388, 417);
            this.treeView_DataServidor.TabIndex = 0;
            this.treeView_DataServidor.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeView_DataServidor_AfterCheck);
            // 
            // btn_Eliminar
            // 
            this.btn_Eliminar.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Eliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_Eliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Eliminar.FlatAppearance.BorderSize = 0;
            this.btn_Eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Eliminar.Location = new System.Drawing.Point(415, 397);
            this.btn_Eliminar.Name = "btn_Eliminar";
            this.btn_Eliminar.Size = new System.Drawing.Size(289, 53);
            this.btn_Eliminar.TabIndex = 1;
            this.btn_Eliminar.Text = "Eliminar";
            this.btn_Eliminar.UseVisualStyleBackColor = false;
            this.btn_Eliminar.Click += new System.EventHandler(this.btn_Eliminar_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(98)))), ((int)(((byte)(66)))));
            this.panel1.Controls.Add(this.lbl_destec);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 456);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1164, 36);
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
            // groupBox_info
            // 
            this.groupBox_info.Controls.Add(this.lbl_info);
            this.groupBox_info.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_info.Location = new System.Drawing.Point(415, 12);
            this.groupBox_info.Name = "groupBox_info";
            this.groupBox_info.Size = new System.Drawing.Size(727, 144);
            this.groupBox_info.TabIndex = 11;
            this.groupBox_info.TabStop = false;
            this.groupBox_info.Text = "Información";
            // 
            // lbl_info
            // 
            this.lbl_info.AutoSize = true;
            this.lbl_info.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_info.Location = new System.Drawing.Point(6, 27);
            this.lbl_info.Name = "lbl_info";
            this.lbl_info.Size = new System.Drawing.Size(49, 14);
            this.lbl_info.TabIndex = 12;
            this.lbl_info.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 18);
            this.label1.TabIndex = 12;
            this.label1.Text = "Lista de servidores";
            // 
            // EliminarServidorComponente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ClientSize = new System.Drawing.Size(1164, 492);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox_info);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_Eliminar);
            this.Controls.Add(this.treeView_DataServidor);
            this.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "EliminarServidorComponente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Eliminar laboratorios";
            this.Load += new System.EventHandler(this.EliminarServidorComponente_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox_info.ResumeLayout(false);
            this.groupBox_info.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView_DataServidor;
        private System.Windows.Forms.Button btn_Eliminar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_destec;
        private System.Windows.Forms.GroupBox groupBox_info;
        private System.Windows.Forms.Label lbl_info;
        private System.Windows.Forms.Label label1;
    }
}