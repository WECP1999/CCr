using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CCr.Class
{
    class Trainers
    {
        private string name;
        private string lastname;

        public string Name { get => name; set => name = value; }
        public string Lastname { get => lastname; set => lastname = value; }

        public bool create(string name, string lastname, int idU)
        {
            String query = "INSERT INTO Capacitadores(nombre, apellido, id_usuario) VALUES (@p1, @p2, @p3)";
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = query;
            comando.Connection = Class.Connection.conexionSQL;
            try
            {
                comando.Parameters.AddWithValue("@p1", name);
                comando.Parameters.AddWithValue("@p2",lastname);
                comando.Parameters.AddWithValue("@p3", idU);
                comando.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                return false;
                throw;
            }
            return true;
        }
        public bool read()
        {
            return true;
        }
        public bool update()
        {
            return true;
        }
    }
}
