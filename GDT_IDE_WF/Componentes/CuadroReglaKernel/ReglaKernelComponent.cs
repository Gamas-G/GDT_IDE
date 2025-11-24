using GDTKernel_Model.Componentes.CuadroReglaKernel;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GDT_IDE_WF.Componentes.CuadroReglaKernel
{
    public partial class ReglaKernelComponent : Form, IReglaKernelComponent
    {
        public ReglaKernelComponent()
        {
            InitializeComponent();

            list_reglasKernel.ShowItemToolTips = true;
            this.Height = 35;
        }

        public ListView ListView_ReglaKernel
        {
            get { return list_reglasKernel; }
        }

        public void SetTitulo(string titulo)
        {
            lbl_titulo.Text = titulo;
        }

        public void SetListReglas(List<FragmentoJson> scripts)
        {
            list_reglasKernel.Items.Clear();

            foreach (var script in scripts)
            {
                var item = new ListViewItem(script.Nombre);
                item.SubItems.Add(script.Nombre);
                item.Tag = script.Codigo;
                item.ToolTipText = script.Descripcion;
                list_reglasKernel.Items.Add(item);
            }
        }

        private void btn_accionPnl_Click(object sender, EventArgs e)
        {
            pnl_body.Visible = !pnl_body.Visible;
            btn_accionPnl.Text = pnl_body.Visible ? "▲ Ocultar Default" : "▼ Mostrar Default";
            this.Height = pnl_body.Visible ? 337 : 35;
        }
    }
}
