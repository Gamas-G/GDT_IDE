using GDTKernel_Model;
using GDTKernel_Util.GenScript;
using GDTKernel_Util.Observador;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace GDTKernel_Bussiness.GDTKernel_CrearBLL
{
    public class GDTKernel_CrearBLL : IGDTKernel_CrearBLL
    {
        private readonly IGenScript _genScript;
        const string _AC = "AC";
        const string _RAC = "RAC";

        public GDTKernel_CrearBLL()
        {
            _genScript = new GenScript();
        }

        public Tuple<string, bool> ValidarFormatoReglas(string reglas)
        {
            foreach (string regla in reglas.Split(';'))
            {
                string _regla = regla.Replace("\n","").Replace("\r","");
                if (!JsonValido(_regla) && !string.IsNullOrEmpty(_regla))
                {
                    Observador._observadorEstatus($"La regla {_regla}, no cuenta con el formato correcto, favor de validar");
                    return new Tuple<string, bool>($"La regla {_regla}, no cuenta con el formato correcto, favor de validar", false);
                }
            }
            Observador._observadorEstatus("Listo");
            return new Tuple<string, bool>(string.Empty, true);
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

        public void GenScriptUpdate(DataTable reglasTable, string UseSubItem)
        {
            List<ReglaK> listRegla;

            listRegla = ObtenerListaReglas(reglasTable);
            string rules = BuildReglas(listRegla);
            string rulesReverso = BuildReglas(listRegla, "Reverso");

            this._genScript.GenScriptAdd(rules, _AC, UseSubItem);
            this._genScript.GenScriptAdd(rulesReverso, _RAC, UseSubItem);
        }

        private List<ReglaK> ObtenerListaReglas(DataTable reglas)
        {
            List<ReglaK> listRegla = new List<ReglaK>();
            int _index = 0;
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
                _index++;
            }
            return listRegla;
        }

        private string BuildReglas(List<ReglaK> listRegla, string tipoArchivo = "Normal")
        {
            StringBuilder sb = new StringBuilder();
            string _bloqueDelete = string.Empty;
            string _condicional = string.Empty;
            foreach (ReglaK item in listRegla)
            {
                if (tipoArchivo.Equals("Normal"))
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
    }
}
