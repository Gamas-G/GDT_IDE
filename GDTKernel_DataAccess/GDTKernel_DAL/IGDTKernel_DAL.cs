using GDTKernel_Model;
using System.Data;
using System.Threading.Tasks;

namespace GDTKernel_DataAccess.GDTKernel_DAL
{
    public interface IGDTKernel_DAL
    {
        Task<DataSet> CargarReglasKernel(CredencialesServidor credenciales);
    }
}
