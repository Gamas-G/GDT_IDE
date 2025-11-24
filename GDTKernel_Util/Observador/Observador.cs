using System.Collections.Generic;

namespace GDTKernel_Util.Observador
{
    public static class Observador
    {
        //Observador para marcar mensajes de estatus en el form padre
        public delegate void ObservadorEstatus(string estatus);
        public static ObservadorEstatus _observadorEstatus;

        public delegate void ObservadorServidor(string ip, string bd, string usuario);
        public static ObservadorServidor _observadorServidor;

        public delegate void ObservadorVentana();
        public static List<ObservadorVentana> _observadoresVentana = new List<ObservadorVentana>();

        public delegate void ObservadorVentanaDepuracion();
        public static List<ObservadorVentanaDepuracion> _observadoresVentanaDepuracion = new List<ObservadorVentanaDepuracion>();

        public delegate void ObservadorCuadroReglasKernel();
        public static ObservadorCuadroReglasKernel _observadorCuadroReglasKernel;

        //static Dictionary<string, List<object>> _listObservadoresForm = new Dictionary<string, List<object>>();
        //static Dictionary<string, Dictionary<string, List<ObservadorServidoresInicio>>> _listObservadores2 = new Dictionary<string, Dictionary<string, List<ObservadorServidoresInicio>>>();

        public static void SubscribirCuadroReglaKernel(ObservadorCuadroReglasKernel observador)
        {
            _observadorCuadroReglasKernel = observador;
        }

        public static void NotificarCuadroReglaKernel()
        {
            //Notificar a componentes subscritos
            _observadorCuadroReglasKernel.Invoke();
        }

        public static void SubscribirVentanaDepuracion(ObservadorVentanaDepuracion observador)
        {
            _observadoresVentanaDepuracion.Add(observador);
        }

        public static void NotificarVentanaDepuracion()
        {
            //Notificar a componentes subscritos
            _observadoresVentanaDepuracion.ForEach(observador => {
                observador.Invoke();
            });
        }


        /// <summary>
        /// Subscribir ventana la notificación de estado
        /// </summary>
        /// <param name="observador"></param>
        public static void SubscribirVentana(ObservadorVentana observador)
        {
            _observadoresVentana.Add(observador);
        }

        /// <summary>
        /// Desubscribir ventana
        /// </summary>
        /// <param name="observador"></param>
        public static void DesubscribireVentana(ObservadorVentana observador)
        {
            _observadoresVentana.Remove(observador);
        }

        /// <summary>
        /// Notificar a las ventanas subscritar
        /// </summary>
        public static void NotificarVentana()
        {
            //Notificar a componentes subscritos
            _observadoresVentana.ForEach( observador => {
                observador.Invoke();
            });
        }
    }
}
