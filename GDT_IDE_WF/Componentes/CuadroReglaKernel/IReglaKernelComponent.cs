using GDTKernel_Model.Componentes.CuadroReglaKernel;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GDT_IDE_WF.Componentes.CuadroReglaKernel
{
    internal interface IReglaKernelComponent
    {
        ListView ListView_ReglaKernel { get; }
        void SetTitulo(string titulo);
        void SetListReglas(List<FragmentoJson> scripts);
    }
}
