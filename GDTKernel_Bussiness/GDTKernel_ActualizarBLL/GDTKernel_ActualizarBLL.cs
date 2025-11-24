using GDTKernel_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using GDTKernel_Util.GenScript;
using GDTKernel_Util.Observador;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace GDTKernel_Bussiness.GDTKernel_ActualizarBLL
{
    public class GDTKernel_ActualizarBLL : IGDTKernel_ActualizarBLL
    {
        private readonly IGenScript _genScript;
        const string _AC = "AC";
        const string _RAC = "RAC";
        public GDTKernel_ActualizarBLL()
        {
            _genScript = new GenScript();
        }
        public void GenScriptUpdate(DataTable reglasTable, DataTable reglasReverso, string UseSubItem)
        {
            List<ReglaK> listRegla;
            List<ReglaK> listReglaReverso;


            //Reglas modificadas
            listRegla = ObtenerListaReglas(reglasTable, reglasReverso);
            
            //Reverso
            listReglaReverso = ObtenerListaReglas(reglasReverso, reglasTable);

            string rules = buildReglas(listRegla);
            string rulesReverso = buildReglas(listReglaReverso);

            this._genScript.GenScriptUpdate(rules, _AC, UseSubItem);
            this._genScript.GenScriptUpdate(rulesReverso, _RAC, UseSubItem);
        }

        private List<ReglaK> ObtenerListaReglas(DataTable reglas, DataTable reglasReverso = null)
        {
            List<ReglaK> listRegla = new List<ReglaK>();
            int _index = 0;
            foreach (DataRow regla in reglas.Rows)
            {
                DataRow _rw = reglasReverso.Rows[_index];
                if (regla.ItemArray[0].Equals(_rw.ItemArray[0]) 
                    && regla.ItemArray[1].Equals(_rw.ItemArray[1]) 
                    && regla.ItemArray[2].Equals(_rw.ItemArray[2]) 
                    && regla.ItemArray[3].Equals(_rw.ItemArray[3]) 
                    && regla.ItemArray[4].Equals(_rw.ItemArray[4]))
                {
                    _index++;
                    continue;
                }

                ReglaK r = new ReglaK()
                {
                    fiItemId = Convert.ToInt32(regla.ItemArray[0]),
                    fiSubItemId = Convert.ToInt32(regla.ItemArray[1]),
                    fcValor = regla.ItemArray[2].Equals(_rw.ItemArray[2]) ? "NA" : (string)regla.ItemArray[2],
                    fcCatDesc = regla.ItemArray[3].Equals(_rw.ItemArray[3]) ? "NA" : (string)regla.ItemArray[3],
                    fiSubItemStat = regla.ItemArray[4].Equals(_rw.ItemArray[4]) ? 2 : Convert.ToInt32(regla.ItemArray[4])
                };
                listRegla.Add(r);
                _index++;
            }
            return listRegla;
        }

        private string buildReglas(List<ReglaK> listRegla)
        {
            StringBuilder sb = new StringBuilder();
            foreach (ReglaK item in listRegla)
            {
                string _bloqueUpdate = "UPDATE CatGdiDestec SET ";
                string _fcValor = !item.fcValor.Equals("NA") ? $"fcValor = '{item.fcValor}'" : string.Empty;
                string _fcCatDesc = !item.fcCatDesc.Equals("NA") ? $"fcCatDesc = '{item.fcCatDesc}'" : string.Empty;
                string _fisubItemStat = !item.fiSubItemStat.Equals(2) ? $"fiSubItemStat = {item.fiSubItemStat}" : string.Empty;

                if (!string.IsNullOrEmpty(_fcValor)) _bloqueUpdate += _fcValor;
                if (!string.IsNullOrEmpty(_fcCatDesc))
                {
                    if (string.IsNullOrEmpty(_fcValor))
                    {
                        _bloqueUpdate += _fcCatDesc;
                    }
                    else
                    {
                        _bloqueUpdate+= ", "+_fcCatDesc;
                    }
                }
                if (!string.IsNullOrEmpty(_fisubItemStat))
                {
                    if (string.IsNullOrEmpty(_fcValor) && string.IsNullOrEmpty(_fcCatDesc))
                    {
                        _bloqueUpdate += _fisubItemStat;
                    }
                    else
                    {
                        _bloqueUpdate += ", " + _fisubItemStat;
                    }
                }



                sb.AppendLine($"IF EXISTS(SELECT fiItemId FROM CatGdiDestec WITH(NOLOCK)");
                sb.AppendLine($"          WHERE fiItemId = {item.fiItemId} AND fiSubItemId = {item.fiSubItemId}" +
                              $"         )");
                sb.AppendLine(" BEGIN");
                sb.AppendLine(_bloqueUpdate);
                sb.AppendLine($"    WHERE fiItemId = {item.fiItemId} AND fiSubItemId = {item.fiSubItemId}");
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
