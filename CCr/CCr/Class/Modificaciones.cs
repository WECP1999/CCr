using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCr.Class
{
    class Modificaciones
    {
        private int id;
        private int nota;
        private int user;

        public int Id { get => id; set => id = value; }
        public int Nota { get => nota; set => nota = value; }
        public int User { get => user; set => user = value; }

        public int crear(int Nota, int User)
        {
            String queryInsert = "INSERT INTO Modificaciones (estado, id_nota, id_usuario) VALUES (1, @p2, @p3)";
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = queryInsert;
            comando.Connection = Class.Conexion.conexionSQL;
            try
            {
                comando.Parameters.AddWithValue("@p2", Nota);
                comando.Parameters.AddWithValue("@p3", User);
                return comando.ExecuteNonQuery();
            }
            catch (Exception error)
            {
                return 0;
            }
        }

        public void update(int estado, int id)
        {
            String queryInsert = "UPDATE Modificaciones SET estado = @p2 WHERE id = @p1";
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = queryInsert;
            comando.Connection = Class.Conexion.conexionSQL;
            try
            {
                comando.Parameters.AddWithValue("@p1", id);
                comando.Parameters.AddWithValue("@p2", estado);
                comando.ExecuteNonQuery();
            }
            catch (Exception error)
            {

            }
        }

        public int buscarNotas(int Nota, int User)
        {
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "SELECT * FROM Modificaciones WHERE id_nota = @p1 AND id_usuario = @p2";
            comando.Connection = Class.Conexion.conexionSQL;
            try
            {
                comando.Parameters.AddWithValue("@p1", Nota);
                comando.Parameters.AddWithValue("@p2", User);
                lector = comando.ExecuteReader();
                if (lector.HasRows)
                {
                    lector.Close();
                    return 1;
                }
                lector.Close();
                return 0;
            }
            catch (Exception error)
            {
                return 0;
            }
        }

        public int buscarNota(int Nota, int User)
        {
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "SELECT * FROM Modificaciones WHERE id_nota = @p1 AND id_usuario = @p2";
            comando.Connection = Class.Conexion.conexionSQL;
            try
            {
                comando.Parameters.AddWithValue("@p1", Nota);
                comando.Parameters.AddWithValue("@p2", User);
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Notas comp = new Notas();
                    comp.Id = int.Parse(lector["id"].ToString());
                    lector.Close();
                    return comp.Id;
                }
                lector.Close();
                return 0;
            }
            catch (Exception error)
            {
                return 0;
            }
        }

        public int buscarNotasMod(int Nota, int User)
        {
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "SELECT * FROM Modificaciones WHERE id_nota = @p1 AND id_usuario = @p2 AND estado = 0";
            comando.Connection = Class.Conexion.conexionSQL;
            try
            {
                comando.Parameters.AddWithValue("@p1", Nota);
                comando.Parameters.AddWithValue("@p2", User);
                lector = comando.ExecuteReader();
                if (lector.HasRows)
                {
                    lector.Close();
                    return 1;
                }
                lector.Close();
                return 0;
            }
            catch (Exception error)
            {
                return 0;
            }
        }
    }
}
