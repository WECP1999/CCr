using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CCr.Class
{
    class Pagos
    {
        private string id;
        private DateTime fecha;
        private double pago;
        private double falta;
        private string empresa;

        public DateTime Fecha { get => fecha; set => fecha = value; }
        public double Pago { get => pago; set => pago = value; }
        public double Falta { get => falta; set => falta = value; }
        public string Id { get => id; set => id = value; }
        public string Empresa { get => empresa; set => empresa = value; }

        public List<Pagos> leer()
        {
            try
            {

                List<Pagos> kk = new List<Pagos>();
                SqlCommand comando = new SqlCommand();
                SqlDataReader lector;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT fecha_pago, pago, ee.nombre_empresa FROM pagos pp INNER JOIN  Capacitaciones cc ON pp.id_capacitacion = cc.id INNER JOIN Empresas ee ON cc.id_empresa = ee.id ORDER BY nombre_empresa ASC";
                comando.Connection = Class.Conexion.conexionSQL;
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Pagos aux = new Pagos();
                    aux.fecha = Convert.ToDateTime(lector["fecha_pago"]);
                    aux.pago = Convert.ToDouble(lector["pago"]);
                    aux.empresa = lector["nombre_empresa"].ToString();
                    kk.Add(aux);
                }
                lector.Close();
                return kk;
            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
        }
        public void crear(DateTime aa, string pago, string idcapa)
        {
            String queryInsert = "INSERT INTO Pagos(fecha_pago,pago,id_capacitacion) VALUES (@p1,@p2,@p3)";
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = queryInsert;
            comando.Connection = Class.Conexion.conexionSQL;
            try
            {
                comando.Parameters.AddWithValue("@p1", aa);
                comando.Parameters.AddWithValue("@p2", pago);
                comando.Parameters.AddWithValue("@p3", idcapa);
                comando.ExecuteNonQuery();
            }
            catch (SqlException error)
            {
                throw;
            }
        }
        public bool actualizar()
        {
            return true;
        }
        public double deuda(string idCapa, double total)
        {
            try
            {
                SqlCommand comando = new SqlCommand();
                SqlDataReader lector;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT SUM (pago) AS paguis FROM Pagos WHERE id_capacitacion = " + idCapa;
                comando.Connection = Class.Conexion.conexionSQL;
                lector = comando.ExecuteReader();
                double y = 0;
                while (lector.Read())
                {
                    if (lector["paguis"].ToString() != "")
                    {
                        y = y + Convert.ToDouble(lector["paguis"].ToString());
                    }
                }
                lector.Close();
                return total - y;
            }
            catch (Exception ex)
            {
                return 0;
                throw;
            }
        }
    }
}
