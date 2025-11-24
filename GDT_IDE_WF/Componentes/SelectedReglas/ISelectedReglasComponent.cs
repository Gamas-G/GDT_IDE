using System.Data;

namespace GDT_IDE_WF.Componentes.SelectedReglas
{
    public interface ISelectedReglasComponent
    {
        void setGridViewReglas( DataTable dt );
        DataTable getGridViewReglas();
        void CleanData();
        void SetUso();
        void SetIs526(bool valor);
    }
}
