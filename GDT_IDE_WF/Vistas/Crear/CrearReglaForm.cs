using GDT_IDE_WF.Componentes.CuadroReglaKernel;
using GDT_IDE_WF.Vistas.Crear;
using GDTKernel_Model.Componentes.CuadroReglaKernel;
using GDTKernel_Util.Observador;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace GDT_IDE_WF.Vista.Crear
{
    public partial class CrearReglaForm : Form, ICrearReglaForm
    {
        ISinior_Consola sinior_Consola;
        public CrearReglaForm()
        {
            InitializeComponent();
            rd_junior.Visible = false;
            rd_senior.Visible = false;

            pnl_cuadroReglasKernel.Visible = false;

            this.sinior_Consola = Program.ServiceProvider.GetRequiredService<ISinior_Consola>();

            Observador.SubscribirCuadroReglaKernel(RefreshCuadro);

            AbrirFormEnPanel(this.sinior_Consola);
            RenderCuadroReglas();
        }

        public void RefreshCuadro()
        {
            RenderCuadroReglas();
        }


        private void AbrirFormEnPanel(object formhija)
        {
            if (this.pn_consola.Controls.Count > 0)
                this.pn_consola.Controls.RemoveAt(0);
            Form fh = formhija as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.pn_consola.Controls.Add(fh);
            this.pn_consola.Tag = fh;
            fh.Show();
        }

        private void RenderCuadroReglas()
        {
            string json = File.ReadAllText("StorageScripts.json");
            List<GrupoScripts> grupos = JsonSerializer.Deserialize<List<GrupoScripts>>(json);

            pnl_cuadroContenedor.Controls.Clear();

            foreach (GrupoScripts grupo in grupos)
            {
                var formReglas = Program.ServiceProvider.GetRequiredService<IReglaKernelComponent>() as ReglaKernelComponent;
                formReglas.SetTitulo(grupo.Nombre);
                formReglas.SetListReglas(grupo.Scripts);
                formReglas.ListView_ReglaKernel.MouseDoubleClick += list_reglasKernel_MouseDoubleClick;

                formReglas.TopLevel = false;
                pnl_cuadroContenedor.WrapContents = false;
                pnl_cuadroContenedor.FlowDirection = FlowDirection.TopDown;
                pnl_cuadroContenedor.AutoScroll = true;

                pnl_cuadroContenedor.Controls.Add(formReglas);
                formReglas.Show();
            }

        }

        private void list_reglasKernel_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var _list = sender as ListView;
            if (_list.SelectedItems.Count > 0)
            {
                var item = _list.SelectedItems[0];
                string texto = item.Tag?.ToString(); // o item.Text, o cualquier dato que quieras mostrar

                sinior_Consola.SetCodigoConsola(texto);
            }
        }

        private void rd_senior_CheckedChanged(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new Sinior_Consola());
            lbl_modo.Text = "Senior";
        }

        private void rd_junior_CheckedChanged(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new Junior_Consola());
            lbl_modo.Text = "Junior";
        }

        private void btn_cuadroReglas_Click(object sender, EventArgs e)
        {
            pnl_cuadroReglasKernel.Visible = !pnl_cuadroReglasKernel.Visible;
            btn_cuadroReglas.Text = pnl_cuadroReglasKernel.Visible ? "◀ Cuadro Reglas Kernel" : "▶ Cuadro Reglas Kernel";
        }

        private void link_editarReglasKernel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (var frm = new EditarCuadroReglasKernel())
            {
                frm.ShowDialog();
            }
        }
    }
}
