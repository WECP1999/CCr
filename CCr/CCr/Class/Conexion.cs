using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCr.Class
{
    class Conexion
    {
        private String stringConnection = CCr.Properties.Settings.Default.BDDCRrConnectionString;
        public static SqlConnection conexionSQL;
        public Conexion()
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
