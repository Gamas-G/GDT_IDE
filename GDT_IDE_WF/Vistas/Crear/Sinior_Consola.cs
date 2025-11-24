using GDT_IDE_WF.Componentes.Editor;
using GDT_IDE_WF.Componentes.SelectedReglas;
using GDT_IDE_WF.Vistas.Crear;
using GDTKernel_Bussiness.GDTKernel_CrearBLL;
using GDTKernel_Util.Observador;
using GDTKernel_Util.Servidores;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Data;
using System.Text.Json;
using System.Windows.Forms;


namespace GDT_IDE_WF.Vista
{
    public partial class Sinior_Consola : Form, ISinior_Consola
    {
        private readonly IGDTKernel_CrearBLL _crearReglaBLL;
        private readonly ISelectedReglasComponent _selectedReglasComponent;
        private readonly EditorComponent _editorComponente;
        private int MAX526, MAX100;
        string _UseSubItem = "526";
        public Sinior_Consola()
        {
            InitializeComponent();
            rd_526.Checked = true;
            ckb_fisubItemStat.Checked = true;

            this._crearReglaBLL = Program.ServiceProvider.GetRequiredService<IGDTKernel_CrearBLL>();
            _editorComponente = Program.ServiceProvider.GetRequiredService<IEditorComponent>() as EditorComponent;
            _selectedReglasComponent = Program.ServiceProvider.GetRequiredService<ISelectedReglasComponent>();

            SetModuloFiltradoSelectedRegla(_selectedReglasComponent);


            _editorComponente.TopLevel = false;
            _editorComponente.Dock = DockStyle.Fill;
            pnl_consolaBody.Dock = DockStyle.Fill;
            pnl_consolaBody.AutoSize = true;
            pnl_consolaBody.Controls.Add(_editorComponente);
            _editorComponente.OnEnviarTexto += ObtenerReglaKernel;
            _editorComponente.Show();

        }

        private void SetModuloFiltradoSelectedRegla(object component)
        {
            //Se elimina el el form en turno para colocar el segundo
            if (this.pnl_contGrid.Controls.Count > 0)
            {
                this.pnl_contGrid.Controls.RemoveAt(0);
            }

            //Se coloca el form dentro del panel
            Form fh = component as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Bottom;
            this.pnl_contGrid.AutoSize = true;
            this.pnl_contGrid.Controls.Add(fh);
            this.pnl_contGrid.Tag = fh;
            fh.Show();
        }

        public void SetCodigoConsola(string codigo)
        {
            _editorComponente.SetReglaEditor(codigo);
        }

        private void ObtenerReglaKernel(string texto, bool Is526 = true)
        {
            DataTable tabla;
            if (Is526)
            {
                tabla = ConvertJsonToDataTable(texto);
                if (tabla == null) return; //Si captura algun error
                _selectedReglasComponent.setGridViewReglas(tabla.Copy());
                Observador._observadorEstatus("Listo");
                return;
            }

            tabla = ConvertStringToDataTable(texto);
            if (tabla == null) return; // Si captura algun error. NOTA: ESTO ES DIFICIL AQUI YA QUE NO VALIDA TIPO JSON
            _selectedReglasComponent.setGridViewReglas(tabla.Copy());
            Observador._observadorEstatus("Listo");
        }

        private DataTable ConvertStringToDataTable(string texto)
        {
            DataTable tb = TablaGenerica();
            int _itemdId = Convert.ToInt32(_UseSubItem);
            int _subItemId = Convert.ToInt32(lbl_MAXValue.Text);
            int _estatus = ckb_fisubItemStat.Checked ? 1 : 0;
            // Separar líneas
            string[] lineas = texto.Split('|');

            foreach (string descripcion in lineas)
            {
                _subItemId++;
                string _descripcion = descripcion.Trim().Replace("\t", "").Replace("\r", "");
                tb.Rows.Add(_itemdId, _subItemId, _descripcion, "Tu descripción", _estatus);
            }

            return tb;
        }

        public DataTable ConvertJsonToDataTable(string json)
        {
            DataTable tb = TablaGenerica();
            try
            {

                var doc = JsonDocument.Parse(json);


                int _itemdId = Convert.ToInt32(_UseSubItem);
                int _subItemId = Convert.ToInt32(lbl_MAXValue.Text);
                int _estatus = ckb_fisubItemStat.Checked ? 1 : 0;

                foreach (var _regla in doc.RootElement.EnumerateArray())
                {
                    _subItemId++;
                    tb.Rows.Add(_itemdId, _subItemId, _regla.GetRawText(), "Tu descripción", _estatus);

                }
            }
            catch (Exception ex)
            {
                Observador._observadorEstatus($"Ocurrio un error: {ex.Message}");
                return null;
            }

            return tb;
        }

        private DataTable TablaGenerica()
        {
            DataTable tb = new DataTable();
            tb.Columns.Add("fiItemId", typeof(int));
            tb.Columns.Add("fiSubItemId", typeof(int));
            tb.Columns.Add("fcValor", typeof(string));
            tb.Columns.Add("fcCatDesc", typeof(string));
            tb.Columns.Add("fiSubItemStat", typeof(bool));
            return tb;
        }

        private void Sinior_Consola_Load(object sender, EventArgs e)
        {
            (MAX526, MAX100) = Servidores.GetMAXSubItem_526_100();
            lbl_MAXValue.Text = _UseSubItem.Equals("526") ? MAX526.ToString() : MAX100.ToString();
        }

        private void rd_526_CheckedChanged(object sender, EventArgs e)
        {
            _UseSubItem = "526";
            lbl_MAXValue.Text = MAX526.ToString();
            if (_editorComponente != null) _editorComponente.SetValidarRegla(true);
        }

        private void rd_100_CheckedChanged(object sender, EventArgs e)
        {
            _UseSubItem = "100";
            lbl_MAXValue.Text = MAX100.ToString();
            if (_editorComponente != null) _editorComponente.SetValidarRegla(false);
        }

        private void btn_GenerarScript_Click(object sender, EventArgs e)
        {
            DataTable tb = _selectedReglasComponent.getGridViewReglas();

            if (tb == null || tb.Rows.Count <= 0) return;

            _crearReglaBLL.GenScriptUpdate(tb, _UseSubItem);
            MessageBox.Show("Script generado\nArchvio almacenado en Documentos\\IDEGDTKernelScripts\\RulesUpdate");
        }
    }
}
