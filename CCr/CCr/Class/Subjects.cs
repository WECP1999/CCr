using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCr.Class
{
    class Subjects
    {
        private string description;
        private double price;

        public string Description { get => description; set => description = value; }
        public double Price { get => price; set => price = value; }

        public int create(string descripcion, decimal pago)
        {
            String queryInsert = "INSERT INTO Temas(descripcion, precio) VALUES(@p1, @p2)";
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = queryInsert;
            comando.Connection = Class.Connection.conexionSQL;
            try
            {
                comando.Parameters.AddWithValue("@p1", descripcion);
                comando.Parameters.AddWithValue("@p2", pago);
                return comando.ExecuteNonQuery();
            }
            catch (SqlException error)
            {
                return 0;
            }
        }
        public bool read()
        {
            return true;
        }
        public bool update()
        {
            return true;
        }
        public bool delete()
        {
            return true;
        }
    }
}
