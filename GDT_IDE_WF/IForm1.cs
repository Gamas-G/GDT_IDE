using System;
using System.Windows.Forms;

namespace GDT_IDE_WF.IForm
{
    public interface IForm1
    {
        void AbrirFormEnPanel(object formhija);
        void btn_crear_Click(object sender, EventArgs e);
        void btn_buscar_Click_1(object sender, EventArgs e);
        void link_dbForm_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e);
        void btn_actualizar_Click(object sender, EventArgs e);
        void btn_eliminar_Click(object sender, EventArgs e);
    }
}
