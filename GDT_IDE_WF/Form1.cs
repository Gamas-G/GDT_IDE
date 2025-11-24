using System;
using System.Drawing;
using System.Windows.Forms;
using GDT_IDE_WF.IForm;
using GDT_IDE_WF.Vista;
using GDT_IDE_WF.Vistas.Actualizar;
using GDT_IDE_WF.Vistas.Buscar;
using GDT_IDE_WF.Vistas.Crear;
using GDT_IDE_WF.Vistas.Eliminar;
using Microsoft.Extensions.DependencyInjection;
using GDTKernel_Util.Servidores;
using GDTKernel_Util.Observador;

namespace GDT_IDE_WF
{
    public partial class Form1 : Form, IForm1
    {
        private ICrearReglaForm _crearForm;
        private IInicioForm _inicioForm;
        private IActualizaReglaForm _actualizarForm;
        private IEliminarReglaForm _eliminaForm;
        private IBuscarReglaForm _buscarForm;

        private Panel bordeBotones;
        private Button currentBtn;


        private readonly string chromePath = @"C:\Program Files\Google\Chrome\Application\chrome.exe"; //Para abrir el manual con el navegador (deshabilitado en la publicación)

        public static IServiceProvider ServiceProvider { get; }

        public Form1()
        {
            InitializeComponent();

            Observador._observadorEstatus = ActualizarEstado;
            Observador._observadorServidor = SetServidorUsando;

            this._crearForm      = Program.ServiceProvider.GetRequiredService<ICrearReglaForm>();
            this._actualizarForm = Program.ServiceProvider.GetRequiredService<IActualizaReglaForm>();
            this._inicioForm     = Program.ServiceProvider.GetRequiredService<IInicioForm>();
            this._eliminaForm    = Program.ServiceProvider.GetRequiredService<IEliminarReglaForm>();
            this._buscarForm     = Program.ServiceProvider.GetRequiredService<IBuscarReglaForm>();

            AbrirFormEnPanel(this._inicioForm);


            //Texto predefinido
            lbl_db.Text = "Sin DB";
            lbl_usuario.Text = "Sin usuario";
            lbl_copyright.Text = $"\u00a9 {DateTime.Now.Year} - Todos los derechos reservados - Desarrollo Tecnológico";

            bordeBotones = new Panel
            {
                Size = new Size(7, 64)
            };
            pnlContButtons.Controls.Add(bordeBotones);//Agregando al panel de botones un borde
        }

        private void ActualizarEstado(string mensaje)
        {
            this.lbl_estatus.Text = mensaje;
        }

        public void btn_crear_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Servidores.ObtenerServidorUsando())) return;

            ActivarBotones(sender);
            AbrirFormEnPanel( this._crearForm );
        }

        public void btn_buscar_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Servidores.ObtenerServidorUsando())) return;

            ActivarBotones(sender);
            AbrirFormEnPanel(this._buscarForm);
        }

        public void btn_actualizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Servidores.ObtenerServidorUsando())) return;

            ActivarBotones(sender);
            AbrirFormEnPanel( this._actualizarForm );
        }

        public void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Servidores.ObtenerServidorUsando())) return;

            ActivarBotones(sender);
            AbrirFormEnPanel( this._eliminaForm );
        }

        private void menu_header_Paint(object sender, PaintEventArgs e)
        {
            if (string.IsNullOrEmpty(Servidores.ObtenerServidorUsando())) return;

            AbrirFormEnPanel( this._inicioForm );
        }

        public void link_dbForm_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (Vista.DBA.Servidor_Form fm = new Vista.DBA.Servidor_Form())
            {
                //Mostrar Ventana emergente
                DialogResult result = fm.ShowDialog();
                if (result != DialogResult.OK) return;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DisableButton();
            AbrirFormEnPanel(this._inicioForm);
        }

        public void AbrirFormEnPanel(object formhija)
        {
            //Se evita volver a instanciar el mismo form
            if (this.body.Controls.Count > 0 && this.body.Controls[0].Text.Equals(formhija.GetType().Name))
            {
                return;
            }

            //Se elimina el el form en turno para colocar el segundo
            if (this.body.Controls.Count > 0)
            {
                this.body.Controls.RemoveAt(0);
            }

            //Se coloca el form dentro del panel
            Form fh = formhija as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.body.Controls.Add(fh);
            this.body.Tag = fh;
            fh.Show();

        }

        public void ValidateFormmode()
        {
            var respMessage = MessageBox.Show("¿Estas seguro de cambiar de modo?, tus cambios no de guardaran", "Advertencia", MessageBoxButtons.YesNo);
            if (respMessage == DialogResult.No)
            {
                return;
            }
        }

        private void btn_manual_Click(object sender, EventArgs e)
        {
            MessageBox.Show("MANUAL DESHABILITADO");
        }
        public void SetServidorUsando(string ip, string bd, string usuario)
        {
            this.lbl_ipServ.Text = ip;
            this.lbl_db.Text = bd;
            this.lbl_usuario.Text = usuario;
        }

        private void ActivarBotones(object senderBtn)
        {
            if (senderBtn != null)
            {
                DisableButton();
                //Button
                currentBtn = (Button)senderBtn;//Casteo
                currentBtn.BackColor = Color.White;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                //Borde Izquierdo del Button
                bordeBotones.BackColor = Color.FromArgb(0, 98, 66);
                bordeBotones.Location = new Point(0, currentBtn.Location.Y);
                bordeBotones.Visible = true;
                bordeBotones.BringToFront();
            }

        }

        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = SystemColors.Control;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
                bordeBotones.Visible = false;
            }
        }
    }
}
