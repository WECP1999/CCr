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
        private int id;
        private string description;
        private double price;
        public int Id { get => id; set => id = value; }
        public string Description { get => description; set => description = value; }
        public double Price { get => price; set => price = value; }
        

        public int create(string descripcion, double pago)
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
        public List<Subjects> read()
        {
            List<Subjects> ss = new List<Subjects>();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "SELECT * FROM temas";
            comando.Connection = Class.Connection.conexionSQL;
            try
            {
                lector = comando.ExecuteReader();
                
                while (lector.Read())
                {
                    Subjects aux = new Subjects();
                    aux.id = Convert.ToInt16(lector["id"]);
                    aux.price = Convert.ToDouble(lector["precio"]);
                    aux.description = lector["descripcion"].ToString();
                    ss.Add(aux);
                }
                lector.Close();
                return ss;
            }
            catch (Exception error)
            {
                return null;
                throw;
            }
        }
        public int update(string descripcion, double pago, int id)
        {
            String query = "UPDATE Temas SET descripcion = @p1, precio = @p2 WHERE id = @p3";
            SqlCommand comando = new SqlCommand();

            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = query;
            comando.Connection = Class.Connection.conexionSQL;
            try
            {
                comando.Parameters.AddWithValue("@p1", descripcion);
                comando.Parameters.AddWithValue("@p2", pago);
                comando.Parameters.AddWithValue("@p3", id);
                return comando.ExecuteNonQuery();
            }
            catch (Exception error)
            {
                return 0;
                throw;
            }
        }
        public bool delete()
        {
            return true;
        }
    }
}
