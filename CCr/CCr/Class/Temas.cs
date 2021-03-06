﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCr.Class
{
    class Temas
    {
        private int id;
        private string descripcion;
        private double precio;

        public int Id { get => id; set => id = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public double Precio { get => precio; set => precio = value; }

        public int create(string descripcion, double pago)
        {
            String queryInsert = "INSERT INTO Temas(descripcion, precio) VALUES(@p1, @p2)";
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = queryInsert;
            comando.Connection = Class.Conexion.conexionSQL;
            try
            {
                comando.Parameters.AddWithValue("@p1", descripcion);
                comando.Parameters.AddWithValue("@p2", pago);
                return comando.ExecuteNonQuery();
            }
            catch (SqlException error)
            {
                return 0;
            }
        }
        public List<Temas> read(int tipo)
        {
            List<Temas> ss = new List<Temas>();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            comando.CommandType = System.Data.CommandType.Text;
            if (tipo == 1)
            {
                comando.CommandText = "SELECT * FROM temas";
            }
            else if (tipo == 2)
            {
                comando.CommandText = "SELECT * FROM temas WHERE precio = 0";
            }
            else
            {
                comando.CommandText = "SELECT * FROM temas WHERE precio != 0";
            }
            comando.Connection = Class.Conexion.conexionSQL;
            try
            {
                lector = comando.ExecuteReader();
                
                while (lector.Read())
                {
                    Temas aux = new Temas();
                    aux.Id = Convert.ToInt16(lector["id"]);
                    aux.Precio = Convert.ToDouble(lector["precio"]);
                    aux.Descripcion = lector["descripcion"].ToString();
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
        public int update(string descripcion, double pago, int id)
        {
            String query = "UPDATE Temas SET descripcion = @p1, precio = @p2 WHERE id = @p3";
            SqlCommand comando = new SqlCommand();

            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = query;
            comando.Connection = Class.Conexion.conexionSQL;
            try
            {
                comando.Parameters.AddWithValue("@p1", descripcion);
                comando.Parameters.AddWithValue("@p2", pago);
                comando.Parameters.AddWithValue("@p3", id);
                return comando.ExecuteNonQuery();
            }
            catch (Exception error)
            {
                return 0;
                throw;
            }
        }
        public bool delete()
        {
            return true;
        }
    }
}
