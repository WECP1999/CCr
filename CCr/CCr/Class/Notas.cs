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
        private string nota;

        private string participante;
        private string evaluacion;

        public int Id { get => id; set => id = value; }
        public string Nota { get => nota; set => nota = value; }
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
            comando.CommandText = "BuscarParticipantes @p1, @p2";
            comando.Connection = Class.Conexion.conexionSQL;
            try
            {
                comando.Parameters.AddWithValue("@p1", Nombre);
                comando.Parameters.AddWithValue("@p2", Nombre);
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

    }
}
