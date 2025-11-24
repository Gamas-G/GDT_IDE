using System.Data;
using System.Windows.Forms;

namespace GDT_IDE_WF.Componentes.GridReglas
{
    internal interface IGridReglasComponent
    {
        void setGrid( DataTable gdt);
        DataTable getGrid();
        void showControllers();
        Button BtnSelectReglas { get; }
        Button BtnGenScript { get; }
        DataGridView DataGridViewReglas { get; }
    }
}
