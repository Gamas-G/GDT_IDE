using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace GDTConexion.BLL
{
    public interface IBLL_DB
    {
        DataTable SelectRulesKrnl(string fcValor);
        DataTable SelectAdvancedRulesKrnl(string fcValor, string fiItemid, string fiSubItemId, string fcCatDesc, bool fiSubItemStat);
    }
}
