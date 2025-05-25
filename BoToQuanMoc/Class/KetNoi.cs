using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoToQuanMoc
{
    internal class KetNoi
    {
        static string connectString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Lenovo\Desktop\Stuff\BTQM\BoToQuanMoc\BTQM.mdf;Integrated Security=True;Connect Timeout=30";
        SqlConnection sqlConnect = new SqlConnection(connectString);
        public SqlConnection KetN()
        {
            sqlConnect.Open();
            return sqlConnect;
        }
    }
}
