using GDTKernel_Bussiness.GDTKernel;
using GDTKernel_Model.Sevidores;
using GDTKernel_Util.Observador;
using GDTKernel_Util.Servidores;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GDT_IDE_WF.Componentes.InfoServer
{
    public partial class InfoServerForm : Form, IInfoServerForm
    {
        public static IServiceProvider ServiceProvider { get; }
        private bool _usandoServidor = false; //Indica el uso del servidor en turno
        private IGDTKernel_BLL _bll;
        private DetalleServidor gbDetalleServidor;
        private string _pais, _canal;
        public InfoServerForm()
        {
            InitializeComponent();

            this._bll = Program.ServiceProvider.GetRequiredService<IGDTKernel_BLL>();
        }

        public void setPaisCanal( string pais, string canal )
        {
            _pais  = pais;
            _canal = canal;
        }

        public void setInfoServidor( DetalleServidor detServidor)
        {
            gbDetalleServidor = detServidor;
            this.lblName.Text = detServidor.Nombre;
            this.lbl_ip.Text = detServidor.Ip;
            this.lbl_reglas526ActivasValue.Text = detServidor.TotalAct;
            this.lbl_reglasInactivas526Value.Text = detServidor.TotalDesac;
            this.lbl_reglas100ActivasValue.Text = detServidor.TotalAct100;
            this.lbl_reglasInactivas100Value.Text = detServidor.TotalDesac100;
        }
        private async Task<bool> ConectarServidor() 
        {
            return await this._bll.CargarReglasKernel(detalleServidor: gbDetalleServidor, pais: _pais, canal: _canal);
        }

        private async void btn_changeCredentials_Click(object sender, EventArgs e)
        {
            if (!ValidarEstatusServidor()) return;

            this.btn_changeCredentials.Enabled = false;

            bool resp = await ConectarServidor();

            if (!resp)
            {
                this.btn_changeCredentials.Enabled = true;
                Observador._observadorServidor("","","");
                return;
            }
            Servidores.SetServidorUsando(this.lblName.Text);
            this.lbl_estado.Text = "Usando reglas";
            this.btn_changeCredentials.Text = "Desconectar";
            this._usandoServidor = true;
            this.img_estado.Image = Properties.Resources.conectado;
            this.btn_changeCredentials.Enabled = true;
            Observador._observadorServidor(this.gbDetalleServidor.Ip, this.gbDetalleServidor.BD, this.gbDetalleServidor.Usuario);
            Observador.NotificarVentana();
        }

        private bool ValidarEstatusServidor()
        {
            string currentServidor = Servidores.ObtenerServidorUsando();
            if (!string.IsNullOrEmpty(currentServidor) && !ValidaServidorUso())
            {
                MessageBox.Show($"Se esta utilizando las reglas del servidor: {currentServidor}, favor de desconectar");
                return false;
            }

            if (ValidaServidorUso())
            {

                this.lbl_estado.Text = "Desconectado";
                this.btn_changeCredentials.Text = "Conectar";
                this._usandoServidor = false;
                this.img_estado.Image = Properties.Resources.desconectado;
                Observador._observadorServidor("", "", "");
                Observador.NotificarVentanaDepuracion();


                Servidores.SetServidorUsando(string.Empty);
                return false;
            }
            return true;
        }

        private async void btn_Credenciales_Click(object sender, EventArgs e)
        {
            if (!ValidarEstatusServidor()) return;

            bool resp = await ConectarServidor();

            if (!resp) return;

            Servidores.SetServidorUsando(this.lblName.Text);
            this.lbl_estado.Text = "Usando reglas";
            this.btn_changeCredentials.Text = "Desconectar";
            this._usandoServidor = true;
            this.img_estado.Image = Properties.Resources.conectado;
        }

        private void InfoServerForm_Load(object sender, EventArgs e)
        {
            if (!ValidaServidorUso()) return;

            Servidores.SetServidorUsando(this.lblName.Text);
            this.lbl_estado.Text = "Usando reglas";
            this.btn_changeCredentials.Text = "Desconectar";
            this._usandoServidor = true;
            this.img_estado.Image = Properties.Resources.conectado;
        }

        private bool ValidaServidorUso()
        {
            return Servidores.ValidarServidorUso(this.lblName.Text);
        }
    }

    public enum TipoDispositivo
    {
        AWS,
        Servidor,
        Dispositivo
    }
}
