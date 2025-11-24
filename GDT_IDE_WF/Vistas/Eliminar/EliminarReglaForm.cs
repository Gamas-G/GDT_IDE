using System;
using System.Data;
using System.Windows.Forms;
using GDT_IDE_WF.Componentes;
using GDT_IDE_WF.Vistas.Eliminar;
using Microsoft.Extensions.DependencyInjection;
using GDT_IDE_WF.Componentes.GridReglas;
using GDT_IDE_WF.Componentes.SelectedReglas;
using GDTKernel_Bussiness.GDTKernel_EliminarBLL;
using GDTKernel_Util.Observador;
using GDTKernel_Interprete.Almacen;
using GDTKernel_Bussiness.GDTKernel_Buscar;

namespace GDT_IDE_WF.Vista.Eliminar
{
    public partial class EliminarReglaForm : Form, IEliminarReglaForm
    {
        private readonly IBusquedaComponent _componentFiltrado;
        private readonly IGridReglasComponent _componentGridRegla;
        private readonly ISelectedReglasComponent _componentSelectedRegla;

        private readonly IGDTKernel_EliminarBLL _eliminarBLL;

        private readonly Button _btnBuscRegla;
        private readonly Button _btnSelectRegla;
        private readonly Button _btnGenScripRegla;

        private readonly RadioButton _btnRadio_526;
        private readonly RadioButton _btnRadio_100;

        private readonly ComboBox _cbx_CatalogoRegla;

        //DataSet donde guardaremos las reglas del 526 y 100
        DataSet tablaReglas526_100;
        DataTable _reglasReverso;

        string _UseSubItem = "526";

        public EliminarReglaForm()
        {
            InitializeComponent();

            this._componentFiltrado  = Program.ServiceProvider.GetRequiredService<IBusquedaComponent>();
            this._componentGridRegla = Program.ServiceProvider.GetRequiredService<IGridReglasComponent>();
            this._componentSelectedRegla = Program.ServiceProvider.GetRequiredService<ISelectedReglasComponent>();

            this._eliminarBLL = Program.ServiceProvider.GetRequiredService<IGDTKernel_EliminarBLL>();


            //Configuración de componentes
            SetModuloFiltrado( this._componentFiltrado );
            SetModuloFiltradoGridSelect(_componentGridRegla);
            SetModuloFiltradoSelectedRegla(_componentSelectedRegla);

            Observador.SubscribirVentanaDepuracion(RefreshData);

            //Preparamos el boton
            _btnBuscRegla = this._componentFiltrado.btn;
            _btnBuscRegla.Click += BtnBuscar_Click;

            //Preparamos el radio button
            _btnRadio_526 = this._componentFiltrado.btn_Radio526;
            _btnRadio_526.Click += RadioButton526_Click;

            _btnRadio_100 = this._componentFiltrado.btn_Radio100;
            _btnRadio_100.Click += RadioButton100_Click;

            _btnSelectRegla = this._componentGridRegla.BtnSelectReglas;
            _btnSelectRegla.Click += BtnSelectReglas_Click;

            _btnGenScripRegla = this._componentGridRegla.BtnGenScript;
            _btnGenScripRegla.Click += BtnGenScripRegla_Click;

            _cbx_CatalogoRegla = this._componentFiltrado._cb_CatalogoReglas;
            _cbx_CatalogoRegla.SelectedValueChanged += Cbx_CatalogoRegla;
        }

        private void RefreshData()
        {
            this._componentSelectedRegla.CleanData();
            CargaDeDataPrincipal();
        }

        private void Cbx_CatalogoRegla(object sender, EventArgs e)
        {
            ComboBox _controlCbx = (ComboBox)sender;
            if (String.IsNullOrEmpty(_controlCbx.Text) || _controlCbx.Text.Equals("System.Data.DataRowView")) return;

            _componentGridRegla.setGrid(GDTKernel_BuscarReglaBLL.CustomGridViewBuscarEliminarRegla(Almacen.ConsultarReglas(_controlCbx.Text)));
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            _componentGridRegla.setGrid(GDTKernel_BuscarReglaBLL.CustomGridViewBuscarEliminarRegla(this._componentFiltrado.BuscarReglaFiltro()));
        }

        private void RadioButton526_Click(object sender, EventArgs e)
        {
            _componentGridRegla.setGrid(GDTKernel_BuscarReglaBLL.CustomGridViewBuscarEliminarRegla(tablaReglas526_100.Tables[2]));
            _componentFiltrado._cb_CatalogoReglas.Visible = true;
            _UseSubItem = "526";
        }

        private void RadioButton100_Click(object sender, EventArgs e)
        {
            _componentGridRegla.setGrid(GDTKernel_BuscarReglaBLL.CustomGridViewBuscarEliminarRegla(tablaReglas526_100.Tables[3]));
            _componentFiltrado._cb_CatalogoReglas.Visible = false;
            _UseSubItem = "100";
        }

        private void SetModuloFiltrado(object modFiltrado)
        {
            //Se elimina el el form en turno para colocar el segundo
            if (this.pnl_moduloFiltrar.Controls.Count > 0)
            {
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

        private void SetModuloFiltradoSelectedRegla(object component)
        {
            //Se elimina el el form en turno para colocar el segundo
            if (this.containerGridSelectedReglas.Controls.Count > 0)
            {
                this.containerGridSelectedReglas.Controls.RemoveAt(0);
            }

            //Se coloca el form dentro del panel
            Form fh = component as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Bottom;
            this.containerGridSelectedReglas.AutoSize = true;
            this.containerGridSelectedReglas.Controls.Add(fh);
            this.containerGridSelectedReglas.Tag = fh;
            fh.Show();
        }

        private void BtnSelectReglas_Click(object sender, EventArgs e)
        {
            _reglasReverso = GDTKernel_BuscarReglaBLL.FilterReglasSelectedUser(_componentGridRegla.getGrid() as DataTable);
            if (_reglasReverso == null)
            {
                return;
            }

            _componentSelectedRegla.setGridViewReglas(_reglasReverso.Copy());
        }

        private void BtnGenScripRegla_Click(object sender, EventArgs e)
        {
            DataTable tb = _componentSelectedRegla.getGridViewReglas();

            if (tb == null || tb.Rows.Count <= 0) return;

            if (!_eliminarBLL.ValidarFormatoReglas(tb)) return;

            _eliminarBLL.GenScriptDelete(tb, _reglasReverso, _UseSubItem);
            MessageBox.Show("Script generado\nArchvio almacenado en Documentos\\IDEGDTKernelScripts\\RulesDelete");
        }

        private void SetModuloFiltradoGridSelect(object component)
        {
            //Se elimina el el form en turno para colocar el segundo
            if (this.containerGridReglas.Controls.Count > 0)
            {
                this.containerGridReglas.Controls.RemoveAt(0);
            }

            //Se coloca el form dentro del panel
            Form fh = component as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Top;
            this.containerGridReglas.AutoSize = true;
            this.containerGridReglas.Controls.Add(fh);
            this.containerGridReglas.Tag = fh;
            this._componentGridRegla.showControllers();
            fh.Show();
        }

        private void EliminarReglaForm_Load(object sender, EventArgs e)
        {
            CargaDeDataPrincipal();
        }

        private void CargaDeDataPrincipal()
        {
            tablaReglas526_100 = this._componentFiltrado.BuscarRegla();
            this._componentFiltrado.btn_Radio526.Checked = true;
            _componentFiltrado.SetCatalogoReglas(this._componentFiltrado.BuscarCatalogo());
            _componentGridRegla.setGrid(GDTKernel_BuscarReglaBLL.CustomGridViewBuscarEliminarRegla(tablaReglas526_100.Tables[2]));
        }
    }
}
