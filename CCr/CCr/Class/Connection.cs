using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCr.Class
{
    class Connection
    {
        private String stringConnection = @"Data Source=.;Initial Catalog=BDDCRr;Integrated Security=True"
        //private String stringConnection = @"Data Source=DESKTOP-GGVQ47S\SQLEXPRESS;Initial Catalog=BDDCRr;Integrated Security=True";
        public static SqlConnection conexionSQL;
        public Connection()
        {
        }
        public string StringConnection { get => stringConnection; set => stringConnection = value; }

        public bool startConnection() {
            try
            {
                conexionSQL = new SqlConnection(this.stringConnection);
                conexionSQL.Open();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public void closeConnection()
        {
            conexionSQL.Close();
        }
        public bool stateConnection()
        {
            switch (conexionSQL.State)
            {
                case System.Data.ConnectionState.Broken:
                    return true;
                case System.Data.ConnectionState.Open:
                    return true;
                default:
                    return false;
            }
        }
    }
}
