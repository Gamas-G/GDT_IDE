
namespace GDTKernel_Model
{
    /// <summary>
    /// Modelo para enviar las credenciales de conexión
    /// </summary>
    public static class CredencialesBD
    {
        /// <summary>
        /// Nombre del servidor
        /// </summary>
        public static string NombreServidor { get; set; }
        /// <summary>
        /// Ip del servidor
        /// </summary>
        public static string Ip { get; set; }
        /// <summary>
        /// Usuario de conexión
        /// </summary>
        public static string Usuario { get; set; }
        /// <summary>
        /// Password de conexión
        /// </summary>
        public static string Password { get; set; }
    }
}
