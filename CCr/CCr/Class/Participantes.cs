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

        public bool crear()
        {
            return true;
        }
        public List<Participantes> leer()
        {
            List<Participantes> participantes = new List<Participantes>();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "SELECT * FROM Participantes ORDER BY nombre DESC";
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
        public bool actualizar()
        {
            return true;
        }
        public bool borrar()
        {
            return true;
        }
    }
}
