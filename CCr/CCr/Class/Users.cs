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
        private bool state;
        private string description;
        public static string id;

        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public bool State { get => state; set => state = value; }
        public string Description { get => description; set => description = value; }

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

        public bool signOut()
        {
            return true;
        }
        public bool signUp()
        {
            return true;
        }
        public bool shutdown()
        {
            return true;
        }
        public bool update()
        {
            return true;
        }
        public bool read()
        {
            return true;
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
    }
}
