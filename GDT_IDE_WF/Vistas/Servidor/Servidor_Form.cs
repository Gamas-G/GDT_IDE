using GDT_IDE_WF.Vistas.DBA;
using GDTKernel_Model.Sevidores;
using GDTKernel_Util.Servidores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using GDT_IDE_WF.Componentes.EliminarServidor;
using GDTKernel_Util.Observador;

namespace GDT_IDE_WF.Vista.DBA
{
    public partial class Servidor_Form : Form, IServidor_Form
    {
        private List<DetalleServidor> detalleServidors;
        
        private DetalleServidor _detalle;
        private Canal _canal;

        private const string expresion = "\\A[0-9]{1,3}(.)[0-9]{1,3}(.)[0-9]{1,3}(.)[0-9]{1,3}\\Z"; //Estructuracion de la expresion regular, obteniendo una validacion para las IPs de la Red de uso laboral

        public string Ip { get; set; }
        public string User { get; set; }
        public string Pwd { get; set; }

        private string _tempPais, 
                       _tempCanal, 
                       _tempLab;
        public Servidor_Form()
        {
            InitializeComponent();

            Observador.SubscribirVentana(RefreshServidores);

            txt_ip.Text   = Ip;
            txt_user.Text = User;
            txt_pwd.Text  = Pwd;

            CargarPaisesCanales();

            detalleServidors = Servidores.ConsultarServidores(cb_pais.Text, cb_canal.Text);

            FiltrarServidores();
            CargarDetalleServidor();

            _tempPais  = cb_pais.Text;
            _tempCanal = cb_canal.Text;
            _tempLab   = cb_laboratorios.Text;
        }

        public void RefreshServidores()
        {
            CargarPaisesCanales();
            FiltrarServidores();
            CargarDetalleServidor();
        }

        private void CargarPaisesCanales()
        {
            BindingSource bindingSourcePais = new BindingSource();
            BindingSource bindingSourceCanal = new BindingSource();

            bindingSourcePais.DataSource  = Servidores.ConsultarPaises();
            cb_pais.DataSource  = bindingSourcePais;

            bindingSourceCanal.DataSource = Servidores.ConsultarCanales(cb_pais.Text);
            cb_canal.DataSource = bindingSourceCanal;
        }

        private void FiltrarServidores()
        {
            List<string> nombreServidores = new List<string>();

            detalleServidors.ForEach(servidor => {
                nombreServidores.Add(servidor.Nombre);
            });

            cb_laboratorios.DataSource = nombreServidores;
        }

        private void CargarDetalleServidor()
        {
            DetalleServidor detalleServidor = Servidores.ConsultarDetalleServidor(cb_laboratorios.Text, cb_pais.Text, cb_canal.Text);


            txt_ip.Text   = detalleServidor.Ip;
            txt_user.Text = detalleServidor.Usuario;
            txt_bd.Text   = detalleServidor.BD;
            txt_pwd.Text  = detalleServidor.Password;
            //cb_laboratorios.DataSource = detalleServidor.Nombre.ToList();
        }

        private bool LimpiarCampos()
        {
            if (string.IsNullOrEmpty(txt_ip.Text) && string.IsNullOrEmpty(txt_user.Text)
                && string.IsNullOrEmpty(txt_bd.Text) && string.IsNullOrEmpty(txt_pwd.Text)) return true;

            //Reset de todos los campor de textbox
            txt_ip.ResetText();
            txt_user.ResetText();
            txt_bd.ResetText();
            txt_pwd.ResetText();

            return false;
        }

        private void ResetTemp(out string resetTemp)
        {
            resetTemp = "Reset";
        }

        private void btn_credenciales_Click(object sender, EventArgs e)
        {
            if (Servidores.ValidarServidorUso(cb_laboratorios.Text.ToUpper()))
            {
                MessageBox.Show("Este servidor esta siendo utilizado, favor de desconectar para realizar actualizaciones");
                return;
            }

            if ( String.IsNullOrEmpty(cb_pais.Text.ToUpper()) || String.IsNullOrEmpty(cb_canal.Text.ToUpper().ToUpper()) || String.IsNullOrEmpty(cb_laboratorios.Text.ToUpper()) || 
                 String.IsNullOrEmpty(txt_ip.Text) || String.IsNullOrEmpty(cb_laboratorios.Text.ToUpper()) || 
                 String.IsNullOrEmpty(txt_user.Text.ToUpper()) || String.IsNullOrEmpty(txt_pwd.Text))
            {
                return;
            }


            _detalle = new DetalleServidor {
                Nombre = cb_laboratorios.Text.ToUpper(),
                Ip            = txt_ip.Text,
                Total         = "0",
                TotalAct      = "0",
                TotalDesac    = "0",
                TotalAct100   = "0",
                TotalDesac100 = "0",
                Usuario  = txt_user.Text,
                Password = txt_pwd.Text,
                BD = txt_bd.Text
            };

            _canal = new Canal {
                Nombre = cb_canal.Text.ToUpper(),
                Servidores = new List<DetalleServidor>{ _detalle }
            };

            NuevoServidor _nuevoServidor = new NuevoServidor {
                PaisNombre = cb_pais.Text.ToUpper(),
                InfoServidor = _canal
            };

            Servidores.ActualizarGuardarServidor(_nuevoServidor);
            Observador._observadorEstatus("Elementos Guardados");
        }
        
        private void btn_borrar_Click(object sender, EventArgs e)
        {
            if (Servidores.ValidarServidorEnCanal(cb_pais.Text))
            {
                MessageBox.Show("Se detecta el uso de un servidor en este país, favor de liberar las reglas del kernel para realizar eliminación");
                return;
            }

            if (String.IsNullOrEmpty(cb_pais.Text) || String.IsNullOrEmpty(cb_canal.Text) || String.IsNullOrEmpty(cb_laboratorios.Text))
            {
                return;
            }            

            int i = 0;

            using (EliminarServidorComponente f = new EliminarServidorComponente())
            {
                List<string> _laboratorios = cb_laboratorios.Items.Cast<string>().Select(item => item).ToList();

                Dictionary<string, List<string>> _canal = new Dictionary<string, List<string>> {
                    { cb_canal.Text ,_laboratorios }
                };

                Dictionary<string, Dictionary<string, List<string>>> _dataDelete = new Dictionary<string, Dictionary<string, List<string>>> {
                    { cb_pais.Text, _canal }
                };

                f.pais = cb_pais.Text;
                f.ShowDialog();

            }
        }

        private void cb_pais_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox objSender = (ComboBox)sender;
            if (string.IsNullOrEmpty(_tempPais) || _tempPais.Equals(objSender.Text) ) return;

            cb_canal.DataSource = Servidores.ConsultarCanales(cb_pais.Text);
            detalleServidors    = Servidores.ConsultarServidores(cb_pais.Text, cb_canal.Text);
            FiltrarServidores();
            CargarDetalleServidor();

            //Pais pivote para la validación
            _tempPais = objSender.Text;
        }

        private void cb_pais_KeyDown(object sender, KeyEventArgs e)
        {
            if( String.IsNullOrEmpty(cb_pais.Text) 
                && (String.IsNullOrEmpty(cb_laboratorios.Text) && cb_laboratorios.DataSource == null) 
                && (String.IsNullOrEmpty(cb_canal.Text) && cb_canal.DataSource == null) ) return;


            if (LimpiarCampos()
                && (String.IsNullOrEmpty(cb_laboratorios.Text) && cb_laboratorios.DataSource == null)
                && (String.IsNullOrEmpty(cb_canal.Text) && cb_canal.DataSource == null) ) return;

            //Colocamos una palabra para volver a realizar la consulta en cb_pais
            ResetTemp(out _tempPais);
            
            //Se limpia el value principal
            cb_pais.ResetText();
            cb_canal.ResetText();
            cb_laboratorios.ResetText();

            //Se limpia el DataSoruce de los dos combobox
            cb_laboratorios.DataSource = null;
            cb_canal.DataSource = null;
        }

        private void cb_canal_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox objSender = (ComboBox)sender;
            if (string.IsNullOrEmpty(_tempCanal) || _tempCanal.Equals(objSender.Text) || string.IsNullOrEmpty(objSender.Text)) return;

            detalleServidors = Servidores.ConsultarServidores(cb_pais.Text, cb_canal.Text);
            FiltrarServidores();
            CargarDetalleServidor();

            //Canal pivote para la validación
            _tempCanal = objSender.Text;
        }
        
        private void cb_canal_KeyDown(object sender, KeyEventArgs e)
        {
            if ((String.IsNullOrEmpty(cb_canal.Text))
                && (String.IsNullOrEmpty(cb_laboratorios.Text) && cb_laboratorios.DataSource == null)) return;

            if (LimpiarCampos()
                && (String.IsNullOrEmpty(cb_laboratorios.Text) && cb_laboratorios.DataSource == null)) return;

            ResetTemp(out _tempCanal);
            ResetTemp(out _tempLab);

            cb_canal.ResetText();
            cb_laboratorios.ResetText();
            cb_laboratorios.DataSource = null;
        }

        private void DBA_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            Observador.DesubscribireVentana(RefreshServidores);
        }

        private void txt_ip_Validating(object sender, CancelEventArgs e)
        {
            //if (txt_ip.Text == "")
            //{
            //    errorProviderIP.SetError(txt_ip, "");
            //    return;
            //}
            //System.Text.RegularExpressions.Regex auto = new System.Text.RegularExpressions.Regex(expresion); //Se invoca la clase 'RegularExpressions' en el mismo metodo ya que solo se utiliza una vez no se coloca desde el inicio del codigo.

            //if (!auto.IsMatch(this.txt_ip.Text)) //Validamos si la IP cumple con nuestra expresion regular, la libreria tira por default 'TRUE', asi que si es diferente que osea 'FALSE'
            //{
            //    errorProviderIP.SetError(txt_ip, "IP INCORRECTA");
            //    e.Cancel = true;
            //}
            //else
            //{
            //    errorProviderIP.SetError(txt_ip, "");
            //}
        }

        private void cb_laboratorios_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox objSender = (ComboBox)sender;
            if (String.IsNullOrEmpty(_tempLab) || _tempLab.Equals(objSender.Text) 
                || (String.IsNullOrEmpty(cb_pais.Text) || String.IsNullOrEmpty(cb_canal.Text) || String.IsNullOrEmpty(objSender.Text)))
            {
                return;
            }

            CargarDetalleServidor();

            //Canal pivote para la validación
            _tempLab = objSender.Text;
        }

        private void cb_laboratorios_KeyDown(object sender, KeyEventArgs e)
        {
            if (string.IsNullOrEmpty(cb_laboratorios.Text) || string.IsNullOrEmpty(cb_canal.Text)) return;

            if (LimpiarCampos()) return;
            
            ResetTemp( out _tempLab );
            cb_laboratorios.ResetText();
        }
    }
}
