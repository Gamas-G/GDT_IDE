using GDT_IDE_WF.Componentes.InfoServer;
using GDTKernel_Model.Sevidores;
using GDTKernel_Util.Observador;
using GDTKernel_Util.Servidores;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GDT_IDE_WF.Vista
{
    public partial class InicioForm : Form, IInicioForm
    {
        public static IServiceProvider ServiceProvider { get; private set; }
        List<DetalleServidor> servidores;
        public InicioForm()
        {
            InitializeComponent();

            Observador.SubscribirVentana(RefreshServidores);

            CargarHash();

            cargarBases();
            CargarPaisesCanales();
            cargarServidores();
        }

        public void RefreshServidores()
        {
            CargarPaisesCanales();
            cargarServidores();
        }
        private void CargarHash()
        {
            Servidores.ActualizarHash();
        }

        private void cargarBases()
        {
            Servidores.CargarServidores();
        }
        private void CargarPaisesCanales()
        {
            BindingSource bindingSourcePais = new BindingSource();
            bindingSourcePais.DataSource = Servidores.ConsultarPaises();
            cbx_pais.DataSource = bindingSourcePais;

            BindingSource bindingSourceCanal = new BindingSource();
            bindingSourceCanal.DataSource = Servidores.ConsultarCanales(cbx_pais.Text);
            cbx_canal.DataSource = bindingSourceCanal;
        }
        private void cargarServidores()
        {
            InfoServerForm inf;
            servidores = Servidores.ConsultarServidores(cbx_pais.Text, cbx_canal.Text);
            
            if (this.containerServidores.Controls.Count > 0)
            {
                this.containerServidores.Controls.Clear();
            }
            
            servidores.ForEach( servidor => {
                inf = new InfoServerForm();
            
                inf.setInfoServidor(servidor);
                inf.setPaisCanal( pais: cbx_pais.Text, canal: cbx_canal.Text );
                inf.TopLevel = false;
                this.containerServidores.Controls.Add(inf);
                this.containerServidores.Tag = inf;
                inf.Show();
            });
        }

        private void cbx_pais_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbx_canal.DataSource = Servidores.ConsultarCanales(cbx_pais.Text);

            cargarServidores();
        }

        private void cbx_canal_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarServidores();
        }
    }
}
