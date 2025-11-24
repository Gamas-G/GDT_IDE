using System.Windows.Forms;

namespace GDT_IDE_WF.Componentes.Editor
{
    internal interface IEditorComponent
    {
        void SetReglaEditor(string regla);
        void SetValidarRegla(bool valor);
        void SetTipo(TipoEnum tipo);
        Button BtnSelectReglas { get; }
    }
}
