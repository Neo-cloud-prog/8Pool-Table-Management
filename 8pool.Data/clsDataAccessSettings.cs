using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8pool.Data
{
    internal sealed class clsDataAccessSettings
    {
        public static string ConnectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
    }
}
