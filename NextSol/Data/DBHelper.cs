using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NextSol.Data
{
    public class DBHelper
    {
        public static string ConnectionString
        {
            get
            {
                return "server=DESKTOP-3AMACFN; database=NextSol; integrated security=true;";
                
            }
        }
    }
}
