using System.Data;
using System.Windows.Forms;

namespace GDT_IDE_WF.Componentes
{
    public interface IBusquedaComponent
    {
        Button btn { get; }
        RadioButton btn_Radio526 { get; }
        RadioButton btn_Radio100 { get; }
        DataSet BuscarRegla();
        DataTable BuscarCatalogo();
        DataTable BuscarReglaFiltro();
        void SetCatalogoReglas(DataTable data);
        ComboBox _cb_CatalogoReglas { get; }
    }
}
