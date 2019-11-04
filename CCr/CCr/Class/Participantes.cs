using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCr.Class
{
    class Participantes
    {
        private int id;
        private string nombre;
        private string apellido;
        private string dui;
        private string email;
        private string telmov;
        private string telfij;
        private string telem;


        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Dui { get => dui; set => dui = value; }
        public string Email { get => email; set => email = value; }
        public string Telmov { get => telmov; set => telmov = value; }
        public string Telfij { get => telfij; set => telfij = value; }
        public string Telem { get => telem; set => telem = value; }

        public int crear(Participantes participantes)
        {
            String queryInsert = "INSERT INTO Participantes(nombre, apellido, dui, correo, num_tel, num_casa, num_trab) VALUES(@p1, @p2, @p3, @p4, @p5, @p6, @p7)";
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = queryInsert;
            comando.Connection = Class.Conexion.conexionSQL;
            try
            {
                comando.Parameters.AddWithValue("@p1", participantes.Nombre);
                comando.Parameters.AddWithValue("@p2", participantes.Apellido);
                comando.Parameters.AddWithValue("@p3", participantes.Dui);
                comando.Parameters.AddWithValue("@p4", participantes.Email);
                comando.Parameters.AddWithValue("@p5", participantes.Telmov);
                comando.Parameters.AddWithValue("@p6", participantes.Telfij);
                comando.Parameters.AddWithValue("@p7", participantes.Telem);
                return comando.ExecuteNonQuery();
            }
            catch (Exception error)
            {
                return 0;
            }
        }
        public List<Participantes> leer()
        {
            List<Participantes> participantes = new List<Participantes>();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "SELECT * FROM Participantes ORDER BY nombre ASC";
            comando.Connection = Class.Conexion.conexionSQL;
            try
            {
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Participantes comp = new Participantes();
                    comp.Id = int.Parse(lector["id"].ToString());
                    comp.Nombre = lector["nombre"].ToString();
                    comp.apellido = lector["apellido"].ToString();
                    comp.Email = lector["correo"].ToString();
                    comp.Dui = lector["Dui"].ToString();
                    comp.Telfij = lector["num_casa"].ToString();
                    comp.Telem = lector["num_tel"].ToString();
                    comp.Telmov = lector["num_trab"].ToString();
                    participantes.Add(comp);
                }
                lector.Close();
                return participantes;
            }
            catch (Exception error)
            {
                return null;
            }
        }
        public List<Participantes> leer(string parametro)
        {
            List<Participantes> participantes = new List<Participantes>();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "SELECT * FROM Participantes  WHERE nombre LIKE '%"+parametro+"%' or apellido LIKE '%"+parametro+"%' or dui LIKE '%"+parametro+"%' ORDER BY nombre ASC";
            comando.Connection = Class.Conexion.conexionSQL;
            try
            {
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Participantes comp = new Participantes();
                    comp.Id = int.Parse(lector["id"].ToString());
                    comp.Nombre = lector["nombre"].ToString();
                    comp.apellido = lector["apellido"].ToString();
                    comp.Email = lector["correo"].ToString();
                    comp.Dui = lector["Dui"].ToString();
                    comp.Telfij = lector["num_casa"].ToString();
                    comp.Telem = lector["num_tel"].ToString();
                    comp.Telmov = lector["num_trab"].ToString();
                    participantes.Add(comp);
                }
                lector.Close();
                return participantes;
            }
            catch (Exception error)
            {
                return null;
            }
        }
        public int actualizar(Participantes participantes)
        {
            String queryInsert = "UPDATE Participantes SET nombre = @p1, apellido = @p2, dui = @p3, correo = @p4, num_tel = @p5, num_casa = @p6, num_trab = @p7 WHERE id = " + participantes.id;
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = queryInsert;
            comando.Connection = Class.Conexion.conexionSQL;
            try
            {
                comando.Parameters.AddWithValue("@p1", participantes.Nombre);
                comando.Parameters.AddWithValue("@p2", participantes.Apellido);
                comando.Parameters.AddWithValue("@p3", participantes.Dui);
                comando.Parameters.AddWithValue("@p4", participantes.Email);
                comando.Parameters.AddWithValue("@p5", participantes.Telmov);
                comando.Parameters.AddWithValue("@p6", participantes.Telfij);
                comando.Parameters.AddWithValue("@p7", participantes.Telem);
                return comando.ExecuteNonQuery();
            }
            catch (Exception error)
            {
                return 0;
            }
        }
        public bool borrar()
        {
            return true;
        }
    }
}
