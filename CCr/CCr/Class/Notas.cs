using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCr.Class
{
    class Notas
    {
        private int id;
        private double nota;

        private string participante;
        private string evaluacion;

        public int Id { get => id; set => id = value; }
        public double Nota { get => nota; set => nota = value; }
        public string Participante { get => participante; set => participante = value; }
        public string Evaluacion { get => evaluacion; set => evaluacion = value; }

        public List<Notas> listarParticipantes()
        {
            List<Notas> participantes = new List<Notas>();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "ListarParticipantes";
            comando.Connection = Class.Conexion.conexionSQL;
            try
            {
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Notas comp = new Notas();
                    comp.Participante = lector["Nombre"].ToString();
                    comp.Evaluacion = lector["Descripcion"].ToString();
                    comp.Id = int.Parse(lector["Id"].ToString());
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

        public List<Notas> buscarParticipante(string Nombre)
        {
            List<Notas> participantes = new List<Notas>();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "BuscarParticipantes @p1";
            comando.Connection = Class.Conexion.conexionSQL;
            try
            {
                comando.Parameters.AddWithValue("@p1", Nombre);
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Notas comp = new Notas();
                    comp.Participante = lector["Nombre"].ToString();
                    comp.Evaluacion = lector["Descripcion"].ToString();
                    comp.Id = int.Parse(lector["Id"].ToString());
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
        
        public int buscarNotas(Notas notas)
        {
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "ObtenerNotas @p1, @p2";
            comando.Connection = Class.Conexion.conexionSQL;
            try
            {
                comando.Parameters.AddWithValue("@p1", notas.Id);
                comando.Parameters.AddWithValue("@p2", int.Parse(notas.Evaluacion));
                lector = comando.ExecuteReader();
                if(lector.HasRows)
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


        public  Notas obtenerNotas(Notas notas)
        {
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "ObtenerNotas @p1, @p2";
            comando.Connection = Class.Conexion.conexionSQL;
            try
            {
                comando.Parameters.AddWithValue("@p1", notas.Id);
                comando.Parameters.AddWithValue("@p2", int.Parse(notas.Evaluacion));
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Notas comp = new Notas();
                    comp.Id = int.Parse(lector["id"].ToString());
                    lector.Close();
                    return comp;
                }
                lector.Close();
                return null;
            }
            catch (Exception error)
            {
                return null;
            }
        }

        public int crear(Notas notas)
        {
            String queryInsert = "INSERT INTO Notas(nota, id_detalle_participante_capacitacion, id_tipo_nota) VALUES(@p1, @p2, @p3)";
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = queryInsert;
            comando.Connection = Class.Conexion.conexionSQL;
            try
            {
                comando.Parameters.AddWithValue("@p1", notas.Nota);
                comando.Parameters.AddWithValue("@p2", notas.Id);
                comando.Parameters.AddWithValue("@p3", int.Parse(notas.Evaluacion));
                return comando.ExecuteNonQuery();
            }
            catch (Exception error)
            {
                return 0;
            }
        }

        public int actualizar(Notas notas, int id)
        {
            String queryInsert = "UPDATE Notas SET nota = @p1, id_detalle_participante_capacitacion = @p2, id_tipo_nota = @p3 WHERE id = " + id;
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = queryInsert;
            comando.Connection = Class.Conexion.conexionSQL;
            try
            {
                comando.Parameters.AddWithValue("@p1", notas.Nota);
                comando.Parameters.AddWithValue("@p2", notas.Id);
                comando.Parameters.AddWithValue("@p3", int.Parse(notas.Evaluacion));
                return comando.ExecuteNonQuery();
            }
            catch (Exception error)
            {
                return 0;
            }
        }
    }
}
