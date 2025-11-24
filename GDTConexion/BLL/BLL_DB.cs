using GDTConexion.DAL;
using System;
using System.Collections.Generic;
using System.Data; 
using System.Linq;
using System.Text;

namespace GDTConexion.BLL
{
    public class BLL_DB : IBLL_DB
    {
        private IDAL_DB _dal_db;
        public BLL_DB( IDAL_DB dal_db )
        {
            _dal_db = dal_db;
        }

        public DataTable SelectRulesKrnl(string fcValor)
        {
            DataTable dt = new DataTable();
            try
            {
                //return DAL.DAL_DB.SelectRulesKrnl(fcValor);
                return _dal_db.SelecAdvancedtRulesKrnl( fcValor );
            }
            catch (Exception ex)
            {

                return dt;
            }

        }

        public DataTable SelectAdvancedRulesKrnl(string fcValor, string fiItemid, string fiSubItemId, string fcCatDesc, bool fiSubItemStat)
        {
            DataTable dt = new DataTable();
            try
            {
                return _dal_db.SelecAdvancedtRulesKrnl(fcValor);
            }
            catch (Exception ex)
            {

                return dt;
            }

        }

    }
}
