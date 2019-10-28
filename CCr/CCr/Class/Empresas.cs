using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCr.Class
{
    class Empresas
    {
        private int id;
        private string nombre;
        private string direccion;
        private int numeroParticipantes;
        private string email;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public int NumeroParticipantes { get => numeroParticipantes; set => numeroParticipantes = value; }
        public string Email { get => email; set => email = value; }

        public int create(string nombre, int cant, string direccion, string correo)
        {
            String queryInsert = "INSERT INTO Empresas(nombre_empresa, cantidad_empleado, direccion, correo) VALUES(@p1, @p2, @p3, @p4)";
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = queryInsert;
            comando.Connection = Class.Conexion.conexionSQL;
            try
            {
                comando.Parameters.AddWithValue("@p1", nombre);
                comando.Parameters.AddWithValue("@p2", cant);
                comando.Parameters.AddWithValue("@p3", direccion);
                comando.Parameters.AddWithValue("@p4", correo);
                return comando.ExecuteNonQuery();
            }
            catch (SqlException error)
            {
                return 0;
            }
        }
        public List<Empresas> read()
        {
            List<Empresas> companys = new List<Empresas>();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "SELECT * FROM Empresas WHERE id != 1 ORDER BY nombre_empresa DESC";
            comando.Connection = Class.Conexion.conexionSQL;
            try
            {
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Empresas comp = new Empresas();
                    comp.Id = int.Parse(lector["id"].ToString());
                    comp.Nombre = lector["nombre_empresa"].ToString();
                    comp.Direccion = lector["direccion"].ToString();
                    comp.Email = lector["correo"].ToString();
                    comp.NumeroParticipantes = int.Parse(lector["cantidad_empleado"].ToString());
                    companys.Add(comp);
                }
                lector.Close();
                return companys;
            }
            catch (SqlException error)
            {
                return null;
            }
        }
        public int update(int id, string nombre, int cant, string direccion, string correo)
        {
            try
            {
                String queryInsert = "UPDATE Empresas SET nombre_empresa = @p1, cantidad_empleado = @p2, direccion = @p3, correo = @p4 WHERE id = " + id;
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = queryInsert;
                comando.Connection = Class.Conexion.conexionSQL;

                comando.Parameters.AddWithValue("@p1", nombre);
                comando.Parameters.AddWithValue("@p2", cant);
                comando.Parameters.AddWithValue("@p3", direccion);
                comando.Parameters.AddWithValue("@p4", correo);

                return comando.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                return 0;
            }
        }
        public bool delete()
        {
            return true;
        }
    }
}
