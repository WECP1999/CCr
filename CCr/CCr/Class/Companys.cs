using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCr.Class
{
    class Companys
    {
        private int id;
        private string name;
        private string address;
        private int numberParticipants;
        private string email;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Address { get => address; set => address = value; }
        public int NumberParticipants { get => numberParticipants; set => numberParticipants = value; }
        public string Email { get => email; set => email = value; }


        public int create(string nombre, int cant, string direccion, string correo)
        {
            String queryInsert = "INSERT INTO Empresas(nombre_empresa, cantidad_empleado, direccion, correo) VALUES(@p1, @p2, @p3, @p4)";
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = queryInsert;
            comando.Connection = Class.Connection.conexionSQL;
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
        public List<Companys> read()
        {
            List<Companys> companys = new List<Companys>();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "SELECT * FROM Empresas WHERE id != 1 ORDER BY nombre_empresa DESC";
            comando.Connection = Class.Connection.conexionSQL;
            try
            {
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Companys comp = new Companys();
                    comp.id = int.Parse(lector["id"].ToString());
                    comp.Name = lector["nombre_empresa"].ToString();
                    comp.Address = lector["direccion"].ToString();
                    comp.email = lector["correo"].ToString();
                    comp.NumberParticipants = int.Parse(lector["cantidad_empleado"].ToString());
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
                comando.Connection = Class.Connection.conexionSQL;

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
