using GDT_IDE_WF.Componentes.Editor;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace GDT_IDE_WF.Componentes.SelectedReglas
{
    public class SelectedReglasComponent : Form, ISelectedReglasComponent
    {
        private Panel pnlControlSelectdReglas;
        private DataGridView dtReglasGenScript;
        private Panel pnlContainerReglas;
        private int FilaUso = 0;
        private Label label1;
        private readonly EditorComponent _editorComponente;
        private bool IsActualiza = false;
        private bool Is526 = true;

        public SelectedReglasComponent()
        {
            InitializeComponent();

            _editorComponente = Program.ServiceProvider.GetRequiredService<IEditorComponent>() as EditorComponent;
            _editorComponente.OnEnviarTexto += ObtenerReglaKernel;
        }
        private void ObtenerReglaKernel(string texto, bool Is526 = true)
        {
            dtReglasGenScript.Rows[FilaUso].Cells["fcValor"].Value = texto;
        }

        public void SetUso()
        {
            IsActualiza = true;
        }

        public void SetIs526(bool valor)
        {
            Is526 = valor;
        }

        public void setGridViewReglas(DataTable dt)
        {
            this.dtReglasGenScript.DataSource = dt;
        }
        public DataTable getGridViewReglas()
        {
            return (DataTable)this.dtReglasGenScript.DataSource;
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlControlSelectdReglas = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlContainerReglas = new System.Windows.Forms.Panel();
            this.dtReglasGenScript = new System.Windows.Forms.DataGridView();
            this.pnlControlSelectdReglas.SuspendLayout();
            this.pnlContainerReglas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtReglasGenScript)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlControlSelectdReglas
            // 
            this.pnlControlSelectdReglas.Controls.Add(this.label1);
            this.pnlControlSelectdReglas.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlControlSelectdReglas.Location = new System.Drawing.Point(0, 0);
            this.pnlControlSelectdReglas.Name = "pnlControlSelectdReglas";
            this.pnlControlSelectdReglas.Size = new System.Drawing.Size(731, 22);
            this.pnlControlSelectdReglas.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Reglas kernel";
            // 
            // pnlContainerReglas
            // 
            this.pnlContainerReglas.Controls.Add(this.dtReglasGenScript);
            this.pnlContainerReglas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainerReglas.Location = new System.Drawing.Point(0, 22);
            this.pnlContainerReglas.Name = "pnlContainerReglas";
            this.pnlContainerReglas.Size = new System.Drawing.Size(731, 363);
            this.pnlContainerReglas.TabIndex = 1;
            // 
            // dtReglasGenScript
            // 
            this.dtReglasGenScript.AllowUserToAddRows = false;
            this.dtReglasGenScript.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtReglasGenScript.BackgroundColor = System.Drawing.Color.Black;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtReglasGenScript.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.dtReglasGenScript.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtReglasGenScript.DefaultCellStyle = dataGridViewCellStyle14;
            this.dtReglasGenScript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtReglasGenScript.EnableHeadersVisualStyles = false;
            this.dtReglasGenScript.Location = new System.Drawing.Point(0, 0);
            this.dtReglasGenScript.Name = "dtReglasGenScript";
            this.dtReglasGenScript.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtReglasGenScript.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.dtReglasGenScript.RowHeadersVisible = false;
            this.dtReglasGenScript.Size = new System.Drawing.Size(731, 363);
            this.dtReglasGenScript.TabIndex = 0;
            this.dtReglasGenScript.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtReglasGenScript_CellDoubleClick);
            this.dtReglasGenScript.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dtReglasGenScript_RowPrePaint);
            // 
            // SelectedReglasComponent
            // 
            this.ClientSize = new System.Drawing.Size(731, 385);
            this.Controls.Add(this.pnlContainerReglas);
            this.Controls.Add(this.pnlControlSelectdReglas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SelectedReglasComponent";
            this.pnlControlSelectdReglas.ResumeLayout(false);
            this.pnlControlSelectdReglas.PerformLayout();
            this.pnlContainerReglas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtReglasGenScript)).EndInit();
            this.ResumeLayout(false);

        }

        private void dtReglasGenScript_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (dtReglasGenScript.Rows == null || dtReglasGenScript.Rows.Count <= 0) return;
            // Recorre todas las filas del DataGridView
            foreach (DataGridViewRow row in dtReglasGenScript.Rows)
            {
                // Verifica si la fila es impar
                if (row.Index % 2 != 0)
                {
                    // Establece el color de fondo para las filas impares
                    row.DefaultCellStyle.BackColor = Color.LightGray;
                }
            }
        }

        public void CleanData()
        {
            if(dtReglasGenScript.Rows.Count > 0) dtReglasGenScript.DataSource = null;
        }

        private void dtReglasGenScript_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (!IsActualiza) return;
                string columna = dtReglasGenScript.Columns[e.ColumnIndex].Name;

                if (columna == "fiItemId") return;

                // Solo ejecutar si la columna es "Nombre"
                if (columna == "fcValor")
                {
                    FilaUso = e.RowIndex;
                    string reglaKernel = dtReglasGenScript.Rows[e.RowIndex].Cells["fcValor"].Value.ToString();
                    _editorComponente.SetTipo(TipoEnum.Actualizacion);
                    _editorComponente.SetReglaEditor(reglaKernel);
                    _editorComponente.ShowDialog();
                    dtReglasGenScript.Refresh();
                    if (Is526)
                        _editorComponente.SetValidarRegla(true);
                    else
                        _editorComponente.SetValidarRegla(false);
                    label1.Focus(); //Hacemos pequeño truco para cambiar focus y actualice el dato correctamente
                }
            }
        }
    }
}
