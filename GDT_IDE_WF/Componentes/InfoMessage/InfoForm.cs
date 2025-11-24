using System.Windows.Forms;

namespace GDT_IDE_WF.Componentes.InfoMessage
{
    public class InfoForm : Form, IInfoMessage
    {
        private Panel panel1;
        private Label lbl_destec;
        private Label lbl_text;

        public void setMessage( string msg )
        {
            lbl_text.Text = msg;
        }

        public InfoForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.lbl_text = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_destec = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_text
            // 
            this.lbl_text.AutoSize = true;
            this.lbl_text.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_text.Location = new System.Drawing.Point(138, 56);
            this.lbl_text.Name = "lbl_text";
            this.lbl_text.Size = new System.Drawing.Size(382, 19);
            this.lbl_text.TabIndex = 0;
            this.lbl_text.Text = "ESTO ES UN MENSAJE DE REFERENCIA LOREMIPSUM";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(98)))), ((int)(((byte)(66)))));
            this.panel1.Controls.Add(this.lbl_destec);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 143);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(593, 36);
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
            // InfoForm
            // 
            this.ClientSize = new System.Drawing.Size(593, 179);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbl_text);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InfoForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
