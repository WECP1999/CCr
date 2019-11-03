using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CCr.Class
{
    class Capacitadores
    {
        private string nombre;
        private string apellido;
        private string id;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Id { get => id; set => id = value; }

        public bool create(string name, string lastname, int idU)
        {
            String query = "INSERT INTO Capacitadores(nombre, apellido, id_usuario) VALUES (@p1, @p2, @p3)";
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = query;
            comando.Connection = Class.Conexion.conexionSQL;
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
        public List<Capacitadores> read()
        {
            List<Capacitadores> lista = new List<Capacitadores>();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "SELECT ca.id,ca.nombre,ca.apellido from capacitadores ca INNER JOIN Usuarios us ON ca.id_usuario = us.id WHERE us.estado = 1 ORDER BY ca.apellido ASC";
            comando.Connection = Class.Conexion.conexionSQL;
            try
            {
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Capacitadores comp = new Capacitadores();
                    comp.Nombre = lector["nombre"].ToString();
                    comp.Apellido = lector["apellido"].ToString();
                    comp.id = lector["id"].ToString();
                    lista.Add(comp);
                }
                lector.Close();
                return lista;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public Capacitadores nombres(string id)
        {
            try
            {
                Capacitadores aux = new Capacitadores();
                SqlCommand comando = new SqlCommand();
                SqlDataReader lector;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT * FROM Capacitadores WHERE id_usuario = @p1";
                comando.Connection = Class.Conexion.conexionSQL;
                comando.Parameters.AddWithValue("@p1", id);
                lector = comando.ExecuteReader();
                if (lector.Read())
                {
                    aux.nombre = lector["nombre"].ToString();
                    aux.apellido = lector["apellido"].ToString();
                    lector.Close();
                    return aux;
                }
                else
                {
                    lector.Close();
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            
        }
        public void update(string nombre, string apellido, string id)
        {
            String query = "UPDATE Capacitadores SET nombre = @p1, apellido = @p2 WHERE id_usuario = @p3";
            SqlCommand comando = new SqlCommand();

            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = query;
            comando.Connection = Class.Conexion.conexionSQL;
            try
            {
                comando.Parameters.AddWithValue("@p1", nombre);
                comando.Parameters.AddWithValue("@p2", apellido);
                comando.Parameters.AddWithValue("@p3", id);
                comando.ExecuteNonQuery();
            }
            catch (Exception error)
            {
                throw;
            }
        }
    }
}
