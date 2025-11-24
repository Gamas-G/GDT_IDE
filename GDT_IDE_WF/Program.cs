using GDT_IDE_WF.IForm;
using GDTKernel_Bussiness.GDTKernel_EliminarBLL;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Windows.Forms;
using GDTKernel_Util.GenScript;
using GDT_IDE_WF.Componentes;
using GDT_IDE_WF.Vista.Eliminar;
using GDT_IDE_WF.Vistas.Eliminar;
using GDT_IDE_WF.Vista.Buscar;
using GDT_IDE_WF.Vistas.Buscar;
using GDT_IDE_WF.Vista;
using GDT_IDE_WF.Vista.Actualizar;
using GDT_IDE_WF.Vistas.Actualizar;
using GDT_IDE_WF.Vista.Crear;
using GDT_IDE_WF.Vistas.Crear;
using GDT_IDE_WF.Vista.DBA;
using GDT_IDE_WF.Vistas.DBA;
using GDT_IDE_WF.Componentes.InfoMessage;
using GDTKernel_Bussiness.GDTKernel_Buscar;
using GDTKernel_Bussiness.GDTKernel_BuscarBLL;
using GDT_IDE_WF.Componentes.GridReglas;
using GDT_IDE_WF.Componentes.SelectedReglas;
using GDTKernel_Bussiness.GDTKernel_ActualizarBLL;
using GDTKernel_Bussiness.GDTKernel;
using GDTKernel_Bussiness.GDTKernel_CrearBLL;
using GDT_IDE_WF.Componentes.CuadroReglaKernel;
using GDT_IDE_WF.Componentes.Editor;

namespace GDT_IDE_WF
{
    static class Program
    {
        public static IServiceProvider ServiceProvider { get; private set; }
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /*
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            */
            //Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var host = CreateHostBuilder().Build();
            ServiceProvider = host.Services;
            Application.Run(ServiceProvider.GetRequiredService<Form1>());
        }

        static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) => {
                    
                    //Se agregan dependencias
                    //Vistas
                    services.AddTransient<IForm1, Form1>();
                    services.AddTransient<IInicioForm, InicioForm>();
                    services.AddTransient<IActualizaReglaForm, ActualizarReglaForm>();
                    services.AddTransient<IBuscarReglaForm, BuscarReglaForm>();
                    services.AddTransient<ICrearReglaForm, CrearReglaForm>();
                    services.AddTransient<IJunior_Consola, Junior_Consola>();
                    services.AddTransient<ISinior_Consola, Sinior_Consola>();
                    services.AddTransient<IServidor_Form, Servidor_Form>();
                    services.AddTransient<IEliminarReglaForm, EliminarReglaForm>();


                    /// Capa BLL
                    services.AddTransient<IGDTKernel_CrearBLL, GDTKernel_CrearBLL>();
                    services.AddTransient<IGDTKernel_BuscarReglaBLL, GDTKernel_BuscarReglaBLL>();
                    services.AddTransient<IGDTKernel_EliminarBLL, GDTKernel_EliminarBLL>();
                    services.AddTransient<IGDTKernel_ActualizarBLL, GDTKernel_ActualizarBLL>();
                    services.AddTransient<IGDTKernel_BLL, GDTKernel_BLL>();
                    //services.AddTransient<IBLL_DB, BLL_DB>();


                    /// Capa DAL
                    //services.AddTransient<IGDTKernel_BuscarDAL, GDTKernel_BuscarDAL>();
                    //services.AddTransient<IDAL_DB, DAL_DB>();


                    //Util
                    //services.AddTransient<GDTKernel_Util.BD.IBD, GDTKernel_Util.BD.BD>();
                    services.AddTransient<IGenScript, GenScript>();
                    //services.AddTransient<IServidores, Servidores>();



                    //Componentes
                    services.AddTransient<IBusquedaComponent, BusquedaComponent>();
                    services.AddTransient<IGridReglasComponent, GridReglasComponent>();
                    services.AddTransient<ISelectedReglasComponent, SelectedReglasComponent>();
                    services.AddTransient<IInfoMessage, InfoForm>();
                    services.AddTransient<IReglaKernelComponent, ReglaKernelComponent>();
                    services.AddTransient<IEditorComponent, EditorComponent>();


                    services.AddTransient<Form1>();
                });
        }
    }
}
