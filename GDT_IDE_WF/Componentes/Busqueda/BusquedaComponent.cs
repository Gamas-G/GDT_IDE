using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using GDTKernel_Interprete.Almacen;
using GDTKernel_Bussiness.GDTKernel;

namespace GDT_IDE_WF.Componentes
{
    public enum ActivosDesactivod
    {
        Activas = 1,
        Desactivas = 0,
        Todos = 2
    }
    public partial class BusquedaComponent : Form, IBusquedaComponent
    {
        const int _heightfiltrado = 62
                 , _heightfiltradoAvanz = 138;

        private int _regla526_100Selected = 2;
        private int _activas_desac_todos = (int)ActivosDesactivod.Todos;

        private IGDTKernel_BLL _bll;
        public static IServiceProvider ServiceProvider { get; private set; }
        public Button btn
        {
            get { return this.btn_buscarRegla; }
        }

        public RadioButton btn_Radio526
        {
            get { return this.rbtn_526; }
        }
        public RadioButton btn_Radio100
        {
            get { return this.rbtn_100; }
        }

        public void SetCatalogoReglas( DataTable data )
        {
            this.cbx_catalogoReglas.DataSource = data;
            this.cbx_catalogoReglas.DisplayMember = "BloqueRegla";
        }

        public ComboBox _cb_CatalogoReglas
        {
            get { return this.cbx_catalogoReglas; }
        }

        public BusquedaComponent()
        {
            InitializeComponent();

            this._bll = Program.ServiceProvider.GetRequiredService<IGDTKernel_BLL>();

            pnl_opciones_avanzadas.Visible = false;

            //Opciones avanzadas minimizadas por default
            this.Size = ResizeForm(_heightfiltrado);

            this.rd_todos.Checked = true;
        }

        public DataSet BuscarRegla()
        {
            return this._bll.ConsultarReglas();
        }

        public DataTable BuscarReglaFiltro()
        {
            if (string.IsNullOrEmpty(cbx_catalogoReglas.Text)) return new DataTable();

            int subitem = !string.IsNullOrEmpty(txt_fiSubItemId.Text) ? Convert.ToInt32(txt_fiSubItemId.Text) : 0;

            return ck_opciones_avanzadas.Checked
                 ? this._bll.BuscarReglaFiltro(reglaValor: txt_buscarRegla.Text, catDesc: txt_fcCatDesc.Text, status: _activas_desac_todos, regla526_100: _regla526_100Selected, fisubItemId: subitem, bloqueRegla: cbx_catalogoReglas.Text)
                 : this._bll.BuscarReglaFiltro(reglaValor: txt_buscarRegla.Text, catDesc: "", status: (int)ActivosDesactivod.Todos, regla526_100: _regla526_100Selected, fisubItemId: 0, bloqueRegla: cbx_catalogoReglas.Text);
        }

        public DataTable BuscarCatalogo()
        {
            return Almacen.ConsultarCatalogo();
        }
        
        private void ck_opciones_avanzadas_CheckedChanged(object sender, EventArgs e)
        {
            if (ck_opciones_avanzadas.Checked)
            {
                pnl_opciones_avanzadas.Visible = true;
                this.Size = ResizeForm(_heightfiltradoAvanz);
            }
            else
            {
                pnl_opciones_avanzadas.Visible = false;
                this.Size = ResizeForm(_heightfiltrado);
            }
        }

        private void rbtn_526_CheckedChanged(object sender, EventArgs e)
        {
            _regla526_100Selected = 2;
        }

        private void rbtn_100_CheckedChanged(object sender, EventArgs e)
        {
            _regla526_100Selected = 3;
        }

        private void rd_todos_CheckedChanged(object sender, EventArgs e)
        {
            _activas_desac_todos = (int)ActivosDesactivod.Todos;
        }

        private void rd_desactivas_CheckedChanged(object sender, EventArgs e)
        {
            _activas_desac_todos = (int)ActivosDesactivod.Desactivas;
        }

        private void rd_activas_CheckedChanged(object sender, EventArgs e)
        {
            _activas_desac_todos = (int)ActivosDesactivod.Activas;
        }

        private void txt_fiSubItemId_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite solo dígitos y teclas de control como Backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void BusquedaComponent_Load(object sender, EventArgs e)
        {
            cbx_catalogoReglas.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbx_catalogoReglas.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private Size ResizeForm(int height)
        {
            return new Size(this.Width, height);
        }
    }
}
