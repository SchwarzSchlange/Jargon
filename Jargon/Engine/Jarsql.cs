using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Jargon
{
    internal class Jarsql
    {
        public SQLiteConnection connection;


        public Jarsql()
        {
            connection = new SQLiteConnection();
        }
        

        public bool IsConnected()
        {
            if(connection.State == System.Data.ConnectionState.Open)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
