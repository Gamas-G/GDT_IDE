using System.Collections.Generic;
using System.Text.Json;

namespace GDTKernel_Model.Semantico
{
    public class Evento
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public List<Propiedades> propiedades{ get; set; }
    }

    public class Propiedades
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public JsonValueKind TipoDato { get; set; }
        public bool IsRequerido { get; set; }
        public bool IsTipoEvento { get; set; }
        public List<Propiedades> SubPropidads { get; set; }
    }
}
