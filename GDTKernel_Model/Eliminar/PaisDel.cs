using GDTKernel_Model.Sevidores;
using System.Collections.Generic;

namespace GDTKernel_Model.Eliminar
{
    public class PaisDel : Pais
    {
        public bool Seleccionado { get; set; }
        public List<CanalDel> CanalesDel { get; set; }
    }
}
