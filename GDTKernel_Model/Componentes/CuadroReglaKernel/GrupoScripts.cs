using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GDTKernel_Model.Componentes.CuadroReglaKernel
{
    public class GrupoScripts
    {
        [JsonPropertyName("nombre")]
        public string Nombre { get; set; }
        [JsonPropertyName("modificar")]
        public bool Modificar { get; set; }
        [JsonPropertyName("scripts")]
        public List<FragmentoJson> Scripts { get; set; }
    }
    public class FragmentoJson
    {
        [JsonPropertyName("nombre")]
        public string Nombre { get; set; }
        [JsonPropertyName("descripcion")]
        public string Descripcion { get; set; }
        [JsonPropertyName("codigo")]
        public string Codigo { get; set; }
    }
}
