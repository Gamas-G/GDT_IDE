using GDTKernel_Model.Sevidores;
using System.Collections.Generic;

namespace GDTKernel_Util.Servidores
{
    //public delegate void ObservadorServi(string estatus);  //Declaramos el delegado indicando que vamos a mandar un string
    public interface IServidores
    {
        //delegate void ObservadorServi(string estatus);  //Declaramos el delegado indicando que vamos a mandar un string
        //event ObservadorServi OnEstatus;  //Declaramos el evento

        //void OnEstatus();

        Servidor CargarServidores();
        //void AgregarServidor();
        bool ActualizarGuardarServidor( NuevoServidor servidor );
        void EliminarServidor( string pais, string canal, string lab );

        void ObtenerHash();
        string ObtenerServidorUsando();
        void SetServidorUsando(string servidor);
        List<DetalleServidor> ConsultarServidores(string keyPais, string keyCanal);
        List<string> ConsultarPaises();
        List<string> ConsultarCanales(string keyPais);
        //void AddSubscriptor(IObservador observador);
        DetalleServidor ConsultarDetalleServidor(string nombreServidor, string keyPais = "MX", string keyCanal = "EKT");
    }
}
