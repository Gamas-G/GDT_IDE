using System.Data;

namespace GDTKernel_Bussiness.GDTKernel_BuscarBLL
{
    public interface IGDTKernel_BuscarReglaBLL
    {
        void CargarReglasKernel(string ip, string usuer, string password, string db);
        DataTable SelectRulesKrnl(string fcValor);
        DataTable SelectAdvancedRulesKrnl(string fcValor, string fiItemid, string fiSubItemId, string fcCatDesc, bool fiSubItemStat);
    }
}
