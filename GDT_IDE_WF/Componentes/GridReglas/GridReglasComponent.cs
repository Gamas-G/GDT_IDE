using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace GDT_IDE_WF.Componentes.GridReglas
{
    public class GridReglasComponent : Form, IGridReglasComponent
    {
        private Panel pnlContainerControlls;
        private Panel pnlBtnAccionReglas;
        private Panel pnlBtnSelectReglas;
        private Panel pnlControlSelectdReglas;
        private TextBox textBox1;
        private Panel panel1;
        private DataGridView gdt_Reglas;
        private Button btnGenScript;
        private Button btnSelectRegla;
        private Label lbl_findRegla;

        public Button BtnSelectReglas
        {
            get { return this.btnSelectRegla; }
        }

        public Button BtnGenScript
        {
            get { return this.btnGenScript; }
        }
        public DataGridView DataGridViewReglas
        {
            get { return this.gdt_Reglas; }
        }

        public GridReglasComponent()
        {
            InitializeComponent();

            this.pnlContainerControlls.Hide();
        }

        public void setGrid( DataTable gdt)
        {
            gdt_Reglas.DataSource = gdt;

        }

        public DataTable getGrid()
        {
            return (DataTable)this.gdt_Reglas.DataSource;
        }

        public void showControllers()
        {
            this.pnlContainerControlls.Show();
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlContainerControlls = new System.Windows.Forms.Panel();
            this.pnlBtnAccionReglas = new System.Windows.Forms.Panel();
            this.btnGenScript = new System.Windows.Forms.Button();
            this.pnlBtnSelectReglas = new System.Windows.Forms.Panel();
            this.btnSelectRegla = new System.Windows.Forms.Button();
            this.pnlControlSelectdReglas = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lbl_findRegla = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gdt_Reglas = new System.Windows.Forms.DataGridView();
            this.pnlContainerControlls.SuspendLayout();
            this.pnlBtnAccionReglas.SuspendLayout();
            this.pnlBtnSelectReglas.SuspendLayout();
            this.pnlControlSelectdReglas.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdt_Reglas)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlContainerControlls
            // 
            this.pnlContainerControlls.BackColor = System.Drawing.Color.Transparent;
            this.pnlContainerControlls.Controls.Add(this.pnlBtnAccionReglas);
            this.pnlContainerControlls.Controls.Add(this.pnlBtnSelectReglas);
            this.pnlContainerControlls.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlContainerControlls.Location = new System.Drawing.Point(0, 418);
            this.pnlContainerControlls.Name = "pnlContainerControlls";
            this.pnlContainerControlls.Size = new System.Drawing.Size(734, 39);
            this.pnlContainerControlls.TabIndex = 1;
            // 
            // pnlBtnAccionReglas
            // 
            this.pnlBtnAccionReglas.BackColor = System.Drawing.Color.Transparent;
            this.pnlBtnAccionReglas.Controls.Add(this.btnGenScript);
            this.pnlBtnAccionReglas.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlBtnAccionReglas.Location = new System.Drawing.Point(165, 0);
            this.pnlBtnAccionReglas.Name = "pnlBtnAccionReglas";
            this.pnlBtnAccionReglas.Size = new System.Drawing.Size(140, 39);
            this.pnlBtnAccionReglas.TabIndex = 2;
            // 
            // btnGenScript
            // 
            this.btnGenScript.BackColor = System.Drawing.Color.LightGray;
            this.btnGenScript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGenScript.FlatAppearance.BorderSize = 0;
            this.btnGenScript.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenScript.Location = new System.Drawing.Point(0, 0);
            this.btnGenScript.Name = "btnGenScript";
            this.btnGenScript.Size = new System.Drawing.Size(140, 39);
            this.btnGenScript.TabIndex = 0;
            this.btnGenScript.Text = "Generar Script";
            this.btnGenScript.UseVisualStyleBackColor = false;
            // 
            // pnlBtnSelectReglas
            // 
            this.pnlBtnSelectReglas.BackColor = System.Drawing.Color.Transparent;
            this.pnlBtnSelectReglas.Controls.Add(this.btnSelectRegla);
            this.pnlBtnSelectReglas.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlBtnSelectReglas.Location = new System.Drawing.Point(0, 0);
            this.pnlBtnSelectReglas.Name = "pnlBtnSelectReglas";
            this.pnlBtnSelectReglas.Size = new System.Drawing.Size(165, 39);
            this.pnlBtnSelectReglas.TabIndex = 1;
            // 
            // btnSelectRegla
            // 
            this.btnSelectRegla.BackColor = System.Drawing.Color.Green;
            this.btnSelectRegla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSelectRegla.FlatAppearance.BorderSize = 0;
            this.btnSelectRegla.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectRegla.ForeColor = System.Drawing.Color.White;
            this.btnSelectRegla.Location = new System.Drawing.Point(0, 0);
            this.btnSelectRegla.Name = "btnSelectRegla";
            this.btnSelectRegla.Size = new System.Drawing.Size(165, 39);
            this.btnSelectRegla.TabIndex = 0;
            this.btnSelectRegla.Text = "Seleccionar";
            this.btnSelectRegla.UseVisualStyleBackColor = false;
            // 
            // pnlControlSelectdReglas
            // 
            this.pnlControlSelectdReglas.Controls.Add(this.textBox1);
            this.pnlControlSelectdReglas.Controls.Add(this.lbl_findRegla);
            this.pnlControlSelectdReglas.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlControlSelectdReglas.Location = new System.Drawing.Point(0, 0);
            this.pnlControlSelectdReglas.Name = "pnlControlSelectdReglas";
            this.pnlControlSelectdReglas.Size = new System.Drawing.Size(734, 41);
            this.pnlControlSelectdReglas.TabIndex = 2;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(194, 9);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(129, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.Visible = false;
            // 
            // lbl_findRegla
            // 
            this.lbl_findRegla.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_findRegla.Location = new System.Drawing.Point(3, 10);
            this.lbl_findRegla.Name = "lbl_findRegla";
            this.lbl_findRegla.Size = new System.Drawing.Size(147, 19);
            this.lbl_findRegla.TabIndex = 0;
            this.lbl_findRegla.Text = "Buscar Regla rules:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gdt_Reglas);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(734, 377);
            this.panel1.TabIndex = 3;
            // 
            // gdt_Reglas
            // 
            this.gdt_Reglas.AllowUserToAddRows = false;
            this.gdt_Reglas.AllowUserToDeleteRows = false;
            this.gdt_Reglas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.gdt_Reglas.BackgroundColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gdt_Reglas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gdt_Reglas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gdt_Reglas.DefaultCellStyle = dataGridViewCellStyle5;
            this.gdt_Reglas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdt_Reglas.EnableHeadersVisualStyles = false;
            this.gdt_Reglas.Location = new System.Drawing.Point(0, 0);
            this.gdt_Reglas.Name = "gdt_Reglas";
            this.gdt_Reglas.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gdt_Reglas.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.gdt_Reglas.RowHeadersVisible = false;
            this.gdt_Reglas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gdt_Reglas.Size = new System.Drawing.Size(734, 377);
            this.gdt_Reglas.TabIndex = 0;
            this.gdt_Reglas.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.gdt_Reglas_DataBindingComplete);
            // 
            // GridReglasComponent
            // 
            this.ClientSize = new System.Drawing.Size(734, 457);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlControlSelectdReglas);
            this.Controls.Add(this.pnlContainerControlls);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GridReglasComponent";
            this.pnlContainerControlls.ResumeLayout(false);
            this.pnlBtnAccionReglas.ResumeLayout(false);
            this.pnlBtnSelectReglas.ResumeLayout(false);
            this.pnlControlSelectdReglas.ResumeLayout(false);
            this.pnlControlSelectdReglas.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gdt_Reglas)).EndInit();
            this.ResumeLayout(false);

        }

        private void gdt_Reglas_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Recorre todas las filas del DataGridView
            foreach (DataGridViewRow row in gdt_Reglas.Rows)
            {
                // Verifica si la fila es impar
                if (row.Index % 2 != 0)
                {
                    // Establece el color de fondo para las filas impares
                    row.DefaultCellStyle.BackColor = Color.LightGray;
                }
            }
        }
    }
}
