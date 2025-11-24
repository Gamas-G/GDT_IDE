using System;
using System.IO;
using System.Text;

namespace GDTKernel_Util.GenScript
{
    public class GenScript : IGenScript
    {
        const string _carpeta = "IDEGDTKernelScripts";
        const string _carpetaDelete = "RulesDelete";
        const string _carpetaUpdate = "RulesUpdate";
        const string _carpetaCreate = "RulesCreate";
        private string _pathC = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), _carpeta);

        public GenScript()
        {
            if (!Directory.Exists($"{_pathC}"))
            {
                Directory.CreateDirectory($"{_pathC}");
            }
        }
        public void GenScriptAdd(string reglas, string tipo, string UseSibItem)
        {
            string pathValidado = ObtenerPath(_carpetaCreate, tipo, UseSibItem, "createRule.sql");
            File.WriteAllText(pathValidado, renderScript(reglas, tipo), Encoding.Default);
        }

        public void GenScriptUpdate(string reglas, string tipo, string UseSibItem)
        {
            string pathValidado = ObtenerPath(_carpetaUpdate, tipo, UseSibItem, "updateRule.sql");
            File.WriteAllText(pathValidado, renderScript(reglas, tipo), Encoding.Default);
        }

        public void GenScriptDelete(string reglas, string tipo, string UseSibItem)
        {
            string pathValidado = ObtenerPath(_carpetaDelete,tipo,UseSibItem, "deleteRule.sql");
            File.WriteAllText(pathValidado, renderScript(reglas, tipo), Encoding.Default);
        }

        private string ObtenerPath(string carpeta, string tipo, string UseSibItem, string archivo)
        {
            string _pathToday = Path.Combine(_pathC,carpeta,$"Reglas_{UseSibItem}",$"{carpeta}_{DateTime.Now.ToString("ddMMyyyy")}");

            if (!Directory.Exists(_pathToday))
            {
                Directory.CreateDirectory(_pathToday);
            }

            return Path.Combine(_pathToday,$"{tipo}{archivo}");

        }

        private string renderScript(string reglas, string tipo)
        {
            string script = "--SCRIPT GENERADO CON HERRAMIENTA DE GDTKERNEL\n" +
                            "USE ADN\n" +
                            "GO\n" +
                            "---------------------------------------------------\n" +
                            "--Responsable: NombreDesarrollador\n" +
                           $"--Fecha: {DateTime.Today.ToString("dd-MM-yyyy")}\n" +
                           $"--Descripción: {(tipo.Equals("RAC") ? "Reverso del folío AC00" : "Descripción del AC")}\n" +
                            "--Aplicación: StatusADN.exe\n" +
                            "---------------------------------------------------\n" +
                            "BEGIN TRY\n" +
                            "   {list}" +
                            "END TRY\n" +
                            "BEGIN CATCH\n" +
                            "-- EJECUTA TU LOGÍCA\n" +
                            "END CATCH";
            script = script.Replace("{list}", reglas);
            return script;
        }
    }
}
