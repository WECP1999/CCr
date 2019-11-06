using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CCr.Class
{
    class Contactos
    {
        private string descripcion;
        private string tel;
        private string extension;

        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string Tel { get => tel; set => tel = value; }
        public string Extension { get => extension; set => extension = value; }

        public int create(string num, string ext)
        {
            String queryInsert = "INSERT INTO NumerosTelefonos(numero,extension) VALUES (@p1,@p2)";
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = queryInsert;
            comando.Connection = Class.Conexion.conexionSQL;
            try
            {
                comando.Parameters.AddWithValue("@p1", num);
                comando.Parameters.AddWithValue("@p2", ext);
                comando.ExecuteNonQuery();
                int nuevoID = obtenerID(num);
                //INSERT INTO Contactos(descripcion, id_numero_telefono, id_empresa) VALUES()
                return nuevoID;
            }
            catch (SqlException error)
            {
                return 1;
            }
        }
        public void create(string descripcion, int numero, int empresa)
        {
            String queryInsert = "INSERT INTO Contactos(descripcion, id_numero_telefono, id_empresa) VALUES(@p1,@p2,@p3)";
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = queryInsert;
            comando.Connection = Class.Conexion.conexionSQL;
            try
            {
                comando.Parameters.AddWithValue("@p1", descripcion);
                comando.Parameters.AddWithValue("@p2", numero);
                comando.Parameters.AddWithValue("@p3", empresa);
                comando.ExecuteNonQuery();
            }
            catch (SqlException error)
            {
                throw;
            }
        }
        public bool read()
        {
            return true;
        }
        public bool update()
        {
            return true;
        }
        public bool delete()
        {
            return true;
        }
        public int obtenerID(string num)
        {
            try
            {

                int kk = 1;
                SqlCommand comando = new SqlCommand();
                SqlDataReader lector;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT * FROM NumerosTelefonos WHERE numero = '" + num +"'";
                comando.Connection = Class.Conexion.conexionSQL;
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    kk = Convert.ToInt32(lector["id"]);
                }
                lector.Close();
                return kk;
            }
            catch (Exception ex)
            {
                return 0;
                throw;
            }
        }
    }
}
