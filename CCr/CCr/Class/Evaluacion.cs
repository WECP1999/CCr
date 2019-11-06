using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCr.Class
{
    class Evaluacion
    {
        private int id;
        private string descripcion;

        public int Id { get => id; set => id = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }

        public List<Evaluacion> listarEvaluaciones()
        {
            List<Evaluacion> evas = new List<Evaluacion>();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "SELECT * FROM TiposNotas ORDER BY id ASC";
            comando.Connection = Class.Conexion.conexionSQL;
            try
            {
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Evaluacion comp = new Evaluacion();
                    comp.Id = int.Parse(lector["id"].ToString());
                    comp.Descripcion = lector["descripcion"].ToString();
                    evas.Add(comp);
                }
                lector.Close();
                return evas;
            }
            catch (Exception error)
            {
                return null;
            }
        }
    }
}
