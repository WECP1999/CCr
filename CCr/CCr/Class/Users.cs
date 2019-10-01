using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CCr.Class
{
    class Users
    {
        private string username;
        private string password;
        private string state;
        private string description;
        public static string id;
        private int idtipo;
        private string xid;
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string State { get => state; set => state = value; }
        public string Description { get => description; set => description = value; }
        public int Idtipo { get => idtipo; set => idtipo = value; }
        public string Xid { get => xid; set => xid = value; }

        public bool login(string user, string pass)
        {
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "SELECT * FROM Usuarios WHERE nombre_usuario = @p1 AND password = @p2 AND estado = 1";
            comando.Connection = Class.Connection.conexionSQL;
            try
            {
                comando.Parameters.AddWithValue("@p1", user);
                comando.Parameters.AddWithValue("@p2", Class.Validations.GetSHA256(pass));
                lector = comando.ExecuteReader();
                if (lector.Read())
                {
                    id = lector["id"].ToString();
                    lector.Close();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException error)
            {
                return false;
            }
        }
        public int signUp(string username, string pass, int id_tipo)
        {
            string query = "INSERT INTO Usuarios(nombre_usuario, password, estado, id_tipo_usuario) VALUES (@p1,@p2,1,@p3)";
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = query;
            comando.Connection = Class.Connection.conexionSQL;
            if (GetId(username) != 0)
            {
                return 0;
            }
            try
            {
                comando.Parameters.AddWithValue("@p1", username);
                comando.Parameters.AddWithValue("@p2", Class.Validations.GetSHA256(pass));
                comando.Parameters.AddWithValue("@p3", id_tipo);
                comando.ExecuteNonQuery();
                return GetId(username);
            }
            catch (Exception e)
            {
                return 0;
                throw;
            }
        }
        public bool shutdown()
        {
            return true;
        }
        public int update(string id, bool activar)
        {
            String query = "UPDATE Usuarios SET estado = @p1 WHERE id = @p2";
            SqlCommand comando = new SqlCommand();

            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = query;
            comando.Connection = Class.Connection.conexionSQL;
            try
            {
                comando.Parameters.AddWithValue("@p1", activar);
                comando.Parameters.AddWithValue("@p2", id);
                return comando.ExecuteNonQuery();
            }
            catch (Exception error)
            {
                return 0;
                throw;
            }
        }
        public List<Users> read()
        {
            List<Users> ss = new List<Users>();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "SELECT u.id, nombre_usuario,t.descripcion,u.estado FROM Usuarios u INNER JOIN Tipos_Usuarios t ON t.id = u.id_tipo_usuario";
            comando.Connection = Class.Connection.conexionSQL;
            try
            {
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Users aux = new Users();
                    aux.xid = lector["id"].ToString();
                    aux.Username = lector["nombre_usuario"].ToString();
                    aux.Description = lector["descripcion"].ToString();
                    if (lector["estado"].ToString() != "False")
                    {
                        aux.state = "Activo";
                    }
                    else
                    {
                        aux.state = "Inactivo";
                    }
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
            return ss;
        }

        public Users getUser(int id)
        {
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            Users us = new Users();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "SELECT * FROM Usuarios WHERE id = @p1";
            comando.Connection = Class.Connection.conexionSQL;
            try
            {
                comando.Parameters.AddWithValue("@p1", id);
                lector = comando.ExecuteReader();
                if (lector.Read())
                {
                    us.Username = lector["nombre_usuario"].ToString();
                    us.Description = lector["id_tipo_usuario"].ToString();
                    lector.Close();
                    return us;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException error)
            {
                return null;
            }
        }
        public int GetId(string user)
        {
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "SELECT * FROM Usuarios WHERE nombre_usuario = @p1";
            comando.Connection = Class.Connection.conexionSQL;
            try
            {
                comando.Parameters.AddWithValue("@p1", user);
                lector = comando.ExecuteReader();
                if (lector.Read())
                {
                    int a =  Convert.ToInt32(lector["id"]);
                    lector.Close();
                    return a;
                }
                else
                {
                    lector.Close();
                    return 0;
                }
            }
            catch (SqlException error)
            {
                return 0;
            }
        }
    }
}
