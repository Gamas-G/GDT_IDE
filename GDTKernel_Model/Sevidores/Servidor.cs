using System.Collections.Generic;

namespace GDTKernel_Model.Sevidores
{
    public class Servidor
    {
        public List<Pais> Paises{ get; set; }
    }

    public class Pais
    {
        public string Nombre{ get; set; }
        public List<Canal> Canales { get; set; }
    }

    public class Canal
    {
        public string Nombre { get; set; }
        public List<DetalleServidor> Servidores { get; set; }
    }
    public class DetalleServidor
    {
        public string Nombre { get; set; }
        public string Ip { get; set; }
        public string Total { get; set; }
        public string TotalAct { get; set; }
        public string TotalDesac { get; set; }
        public string TotalAct100 { get; set; }
        public string TotalDesac100 { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
        public string BD { get; set; }
        public bool estatus { get; set; }
    }
}
