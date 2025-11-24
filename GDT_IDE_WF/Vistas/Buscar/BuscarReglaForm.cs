using System;
using System.Data;
using System.Windows.Forms;
using GDT_IDE_WF.Componentes;
using Microsoft.Extensions.DependencyInjection;
using GDT_IDE_WF.Vistas.Buscar;
using GDT_IDE_WF.Componentes.GridReglas;
using GDTKernel_Interprete.Almacen;
using GDTKernel_Util.Observador;
using GDTKernel_Model;

namespace GDT_IDE_WF.Vista.Buscar
{
    public partial class BuscarReglaForm : Form, IBuscarReglaForm
    {
        private readonly IBusquedaComponent _componentFiltrado;
        private readonly IGridReglasComponent _componentGridReglas;
        public static IServiceProvider ServiceProvider { get; private set; }

        private readonly Button _btnBuscRegla;

        private readonly RadioButton _btnRadio_526;
        private readonly RadioButton _btnRadio_100;

        private readonly ComboBox _cbx_CatalogoRegla;
        private readonly DataGridView _gdt_viewReglas;

        //DataSet donde guardaremos las reglas del 526 y 100
        DataSet tablaReglas526_100;

        public BuscarReglaForm()
        {
            InitializeComponent();

            this._componentFiltrado = Program.ServiceProvider.GetRequiredService<IBusquedaComponent>();
            this._componentGridReglas = Program.ServiceProvider.GetRequiredService<IGridReglasComponent>();

            SetModuloFiltrado(_componentFiltrado);

            SetModuloFiltradoGrid(this._componentGridReglas);

            Observador.SubscribirVentanaDepuracion(RefreshData);

            //Preparamos el boton de busqueda
            _btnBuscRegla = _componentFiltrado.btn;
            _btnBuscRegla.Click += BtnBuscar_Click;

            //Preparamos el radio button
            _btnRadio_526 = this._componentFiltrado.btn_Radio526;
            _btnRadio_526.Click += RadioButton526_Click;

            _btnRadio_100 = this._componentFiltrado.btn_Radio100;
            _btnRadio_100.Click += RadioButton100_Click;

            _cbx_CatalogoRegla = this._componentFiltrado._cb_CatalogoReglas;
            _cbx_CatalogoRegla.SelectedValueChanged += Cbx_CatalogoRegla;

            _gdt_viewReglas = this._componentGridReglas.DataGridViewReglas;
            _gdt_viewReglas.CellContentDoubleClick += GridViewReglas_DobleClick;

        }

        private void RefreshData()
        {
            CargaDeDataPrincipal();
        }

        private async void GridViewReglas_DobleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_btnRadio_100.Checked) return;

            if (e.RowIndex < 0) return;

            DataGridViewRow reglaSeleccionada = _gdt_viewReglas.Rows[e.RowIndex];

            using (ReglaKernelTree.ReglaTreeForm arbolSeguimiento = new ReglaKernelTree.ReglaTreeForm(new ReglaK
            {
                ReglaBloque = _cbx_CatalogoRegla.Text,
                fiItemId = Convert.ToInt32(reglaSeleccionada.Cells[0].Value),
                fiSubItemId = Convert.ToInt32(reglaSeleccionada.Cells[1].Value),
                fcValor = (string)reglaSeleccionada.Cells[2].Value,
                fcCatDesc = (string)reglaSeleccionada.Cells[3].Value,
                fiSubItemStat = Convert.ToInt32(reglaSeleccionada.Cells[4].Value),
            }))
            {
                arbolSeguimiento.ShowDialog();
            }
        }

        private void Cbx_CatalogoRegla(object sender, EventArgs e)
        {
            ComboBox _controlCbx = (ComboBox)sender;
            if (String.IsNullOrEmpty(_controlCbx.Text) || _controlCbx.Text.Equals("System.Data.DataRowView")) return;

            _componentGridReglas.setGrid(Almacen.ConsultarReglas(_controlCbx.Text));
        }

        private void BuscarReglaForm_Load(object sender, EventArgs e)
        {
            CargaDeDataPrincipal();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            _componentGridReglas.setGrid(this._componentFiltrado.BuscarReglaFiltro());
        }

        private void RadioButton526_Click(object sender, EventArgs e)
        {
            _componentGridReglas.setGrid(tablaReglas526_100.Tables[2]);
            _componentFiltrado._cb_CatalogoReglas.Visible = true;
        }

        private void RadioButton100_Click(object sender, EventArgs e)
        {
            _componentGridReglas.setGrid(tablaReglas526_100.Tables[3]);
            _componentFiltrado._cb_CatalogoReglas.Visible = false;
        }

        private void SetModuloFiltrado(object modFiltrado)
        {
            //Se elimina el form en turno para colocar el segundo
            if (this.pnl_moduloFiltrar.Controls.Count > 0)
            {
                MessageBox.Show("Más de uno");
                this.pnl_moduloFiltrar.Controls.RemoveAt(0);
            }

            //Se coloca el form dentro del panel
            Form fh = modFiltrado as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Top;
            this.pnl_moduloFiltrar.AutoSize = true;
            this.pnl_moduloFiltrar.Controls.Add(fh);
            this.pnl_moduloFiltrar.Tag = fh;
            fh.Show();
        }

        private void SetModuloFiltradoGrid(object modFiltrado)
        {
            //Se elimina el el form en turno para colocar el segundo
            if (this.containerGridReglas.Controls.Count > 0)
            {
                this.containerGridReglas.Controls.RemoveAt(0);
            }

            //Se coloca el form dentro del panel
            Form fh = modFiltrado as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.containerGridReglas.AutoSize = true;
            this.containerGridReglas.Controls.Add(fh);
            this.containerGridReglas.Tag = fh;
            fh.Show();
        }

        private void CargaDeDataPrincipal()
        {
            tablaReglas526_100 = this._componentFiltrado.BuscarRegla();
            this._componentFiltrado.btn_Radio526.Checked = true;
            _componentFiltrado.SetCatalogoReglas(this._componentFiltrado.BuscarCatalogo());
            _componentGridReglas.setGrid(tablaReglas526_100.Tables[2]);
        }

    }
}
