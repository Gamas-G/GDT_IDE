using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace GDTConexion.DAL
{
    public interface IDAL_DB
    {
        DataTable SelectRulesKrnl(string fcValor);

        DataTable SelecAdvancedtRulesKrnl(string fcValor);
    }
}
