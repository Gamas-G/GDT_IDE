using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using GDTKernel_Model;
using GDTKernel_Util.GenScript;
using GDTKernel_Util.Observador;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace GDTKernel_Bussiness.GDTKernel_EliminarBLL
{
    public class GDTKernel_EliminarBLL : IGDTKernel_EliminarBLL
    {
        private readonly IGenScript _genScript;
        const string _AC = "AC";
        const string _RAC = "RAC";

        public GDTKernel_EliminarBLL()
        {
            _genScript = new GenScript();
        }

        public void GenScriptDelete(DataTable reglasTable, DataTable reglasReverso, string UseSibItem)
        {
            List<ReglaK> listRegla;
            List<ReglaK> listReglaReverso;

            //Reglas modificadas
            listRegla = ObtenerListaReglas(reglasTable, reglasReverso);

            //Reverso
            listReglaReverso = ObtenerListaReglas(reglasReverso, reglasTable);


            string rules = buildReglas(listRegla);
            string rulesReverso = buildReglas(listReglaReverso, "Reverso");

            this._genScript.GenScriptDelete(rules, _AC, UseSibItem);
            this._genScript.GenScriptDelete(rulesReverso, _RAC, UseSibItem);
        }

        private List<ReglaK> ObtenerListaReglas(DataTable reglas, DataTable reglasReverso)
        {
            List<ReglaK> listRegla = new List<ReglaK>();

            foreach (DataRow regla in reglas.Rows)
            {
                ReglaK r = new ReglaK()
                {
                    fiItemId = Convert.ToInt32(regla.ItemArray[0]),
                    fiSubItemId = Convert.ToInt32(regla.ItemArray[1]),
                    fcValor = (string)regla.ItemArray[2],
                    fcCatDesc = (string)regla.ItemArray[3],
                    fiSubItemStat = Convert.ToInt32(regla.ItemArray[4])
                };
                listRegla.Add(r);
            }
            return listRegla;
        }

        private string buildReglas(List<ReglaK> listRegla, string tipoArchivo = "Normal")
        {
            StringBuilder sb = new StringBuilder();
            string _bloqueDelete = string.Empty;
            string _condicional = string.Empty;
            foreach (ReglaK item in listRegla)
            {
                if (tipoArchivo.Equals("Reverso"))
                {
                    _condicional = "IF NOT EXISTS";
                    _bloqueDelete = "INSERT INTO CatGdiDestec(fiItemId, fiSubItemId, fcValor, fcCatDesc, fiSubItemStat)\n" +
                                  $"VALUES({item.fiItemId}, {item.fiSubItemId}, '{item.fcValor}', '{item.fcCatDesc}', {item.fiSubItemStat})\n    ";
                }
                else
                {
                    _condicional = "IF EXISTS";
                    _bloqueDelete = $"DELETE CatGdiDestec WHERE fiItemId = {item.fiItemId} AND fiSubItemId = {item.fiSubItemId}";
                }

                sb.AppendLine($"{_condicional}(SELECT fiItemId FROM CatGdiDestec WITH(NOLOCK) WHERE fiItemId = {item.fiItemId} AND fiSubItemId = {item.fiSubItemId})");
                sb.AppendLine(" BEGIN");
                sb.AppendLine($"    {_bloqueDelete}");
                sb.AppendLine(" END");
            }
            return sb.ToString();
        }
        public bool ValidarFormatoReglas(DataTable reglas)
        {
            foreach (DataRow regla in reglas.Rows)
            {
                string _regla = regla["fcValor"].ToString().Replace("\n", "").Replace("\r", "");
                if (!JsonValido(_regla) && !string.IsNullOrEmpty(_regla))
                {
                    Observador._observadorEstatus($"La regla {_regla}, no cuenta con el formato correcto, favor de validar");
                    return false;
                }
            }
            Observador._observadorEstatus("Listo");
            return true;
        }
        private static bool JsonValido(string value)
        {
            try
            {
                if (int.TryParse(value, out _)) return false;

                JToken token = JToken.Parse(value);

                return true;
            }
            catch (JsonReaderException)
            {
                return false;
            }
        }
    }
}
