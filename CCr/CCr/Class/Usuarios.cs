using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CCr.Class
{
    class Usuarios
    {
        private string nombreUsuario;
        private string contra;
        private string estado;
        private string descripcion;
        private static string id;
        private int idtipo;
        private string xid;

        public string NombreUsuario { get => nombreUsuario; set => nombreUsuario = value; }
        public string Contra { get => contra; set => contra = value; }
        public string Estado { get => estado; set => estado = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public static string Id { get => id; set => id = value; }
        public int Idtipo { get => idtipo; set => idtipo = value; }
        public string Xid { get => xid; set => xid = value; }

        public bool login(string user, string pass)
        {
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "SELECT * FROM Usuarios WHERE nombre_usuario = @p1 AND password = @p2 AND estado = 1";
            comando.Connection = Class.Conexion.conexionSQL;
            try
            {
                comando.Parameters.AddWithValue("@p1", user);
                comando.Parameters.AddWithValue("@p2", Class.Validaciones.GetSHA256(pass));
                lector = comando.ExecuteReader();
                if (lector.Read())
                {
                    Id = lector["id"].ToString();
                    lector.Close();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception error)
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
            comando.Connection = Class.Conexion.conexionSQL;
            if (GetId(username) != 0)
            {
                return 0;
            }
            try
            {
                comando.Parameters.AddWithValue("@p1", username);
                comando.Parameters.AddWithValue("@p2", Class.Validaciones.GetSHA256(pass));
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
        public int shutdown(string id, bool activar)
        {
            String query = "UPDATE Usuarios SET estado = @p1 WHERE id = @p2";
            SqlCommand comando = new SqlCommand();

            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = query;
            comando.Connection = Class.Conexion.conexionSQL;
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
        public bool update(string nombre, string id)
        {
            if (ver(nombre,id))
            {
                String query = "UPDATE Usuarios SET nombre_usuario = @p1 WHERE id = @p2";
                SqlCommand comando = new SqlCommand();

                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = query;
                comando.Connection = Class.Conexion.conexionSQL;
                try
                {
                    comando.Parameters.AddWithValue("@p1", nombre);
                    comando.Parameters.AddWithValue("@p2", id);
                    comando.ExecuteNonQuery();
                    return true;
                }
                catch (Exception error)
                {
                    return false;
                    throw;
                }
            }
            else
            {
                return false;
            }
        }
        public bool update(string nombre, string contra,string id)
        {
            if (ver(nombre, id))
            {

                String query = "UPDATE Usuarios SET nombre_usuario = @p1, password = @p2 WHERE id = @p3";
                SqlCommand comando = new SqlCommand();

                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = query;
                comando.Connection = Class.Conexion.conexionSQL;
                try
                {
                    comando.Parameters.AddWithValue("@p1", nombre);
                    comando.Parameters.AddWithValue("@p2", Class.Validaciones.GetSHA256(contra));
                    comando.Parameters.AddWithValue("@p3", id);
                    comando.ExecuteNonQuery();
                    return true;
                }
                catch (Exception error)
                {
                    return false;
                    throw;
                }
            }
            else
            {
                return false;
            }
        }
        private bool ver(string nombre, string id)
        {
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "SELECT * FROM Usuarios where nombre_usuario = @p1 and id != @p2";
            comando.Connection = Class.Conexion.conexionSQL;
            try
            {
                comando.Parameters.AddWithValue("@p1", nombre);
                comando.Parameters.AddWithValue("@p2", id);
                lector = comando.ExecuteReader();
                if (lector.Read())
                {
                    lector.Close();
                    return false;
                }
                else
                {
                    lector.Close();
                    return true;
                }
            }
            catch (SqlException error)
            {
                return false;
            }
        }
        public List<Usuarios> read()
        {
            List<Usuarios> ss = new List<Usuarios>();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "SELECT u.id, nombre_usuario,t.descripcion,u.estado FROM Usuarios u INNER JOIN Tipos_Usuarios t ON t.id = u.id_tipo_usuario";
            comando.Connection = Class.Conexion.conexionSQL;
            try
            {
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Usuarios aux = new Usuarios();
                    aux.Xid = lector["id"].ToString();
                    aux.nombreUsuario = lector["nombre_usuario"].ToString();
                    aux.descripcion = lector["descripcion"].ToString();
                    if (lector["estado"].ToString() != "False")
                    {
                        aux.estado = "Activo";
                    }
                    else
                    {
                        aux.estado = "Inactivo";
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
        }

        public Usuarios getUser(int id)
        {
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            Usuarios us = new Usuarios();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "SELECT * FROM Usuarios WHERE id = @p1";
            comando.Connection = Class.Conexion.conexionSQL;
            try
            {
                comando.Parameters.AddWithValue("@p1", id);
                lector = comando.ExecuteReader();
                if (lector.Read())
                {
                    us.nombreUsuario = lector["nombre_usuario"].ToString();
                    us.descripcion = lector["id_tipo_usuario"].ToString();
                    us.Xid = lector["id"].ToString();
                    us.estado = lector["estado"].ToString();
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
            comando.Connection = Class.Conexion.conexionSQL;
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
