﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CCr.Class
{
    class Capacitaciones
    {
        private int id;
        private DateTime diaInicio;
        private DateTime diaFinal;
        private string tipoCapacitacion;
        private string capacitador;
        private string empresa;
        private string tema;
        private double precio;

        public int Id { get => id; set => id = value; }
        public DateTime DiaInicio { get => diaInicio; set => diaInicio = value; }
        public DateTime DiaFinal { get => diaFinal; set => diaFinal = value; }
        public string TipoCapacitacion { get => tipoCapacitacion; set => tipoCapacitacion = value; }
        public string Capacitador { get => capacitador; set => capacitador = value; }
        public string Empresa { get => empresa; set => empresa = value; }
        public string Tema { get => tema; set => tema = value; }
        public double Precio { get => precio; set => precio = value; }

        public int create(DateTime diaI,DateTime diaF,string tema,string empresa,string capacitador)
        {
            String queryInsert = "INSERT INTO Capacitaciones(fecha_inicio,fecha_fin,id_tema,id_empresa,id_capacitador) VALUES (@p1,@p2,@p3,@p4,@p5)";
            SqlCommand comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = queryInsert;
            comando.Connection = Class.Conexion.conexionSQL;
            try
            {
                comando.Parameters.AddWithValue("@p1", diaI);
                comando.Parameters.AddWithValue("@p2", diaF);
                comando.Parameters.AddWithValue("@p3", tema);
                comando.Parameters.AddWithValue("@p4", empresa);
                comando.Parameters.AddWithValue("@p5", capacitador);
                return comando.ExecuteNonQuery();
            }
            catch (SqlException error)
            {
                return 0;
            }
        }
        public List<Capacitaciones> read()
        {
            List<Capacitaciones> lista = new List<Capacitaciones>();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "SELECT cap.id,em.nombre_empresa,te.descripcion,fecha_inicio,cap.id_empresa FROM Capacitaciones cap INNER JOIN Empresas em ON cap.id_empresa = em.id INNER JOIN Temas te ON cap.id_tema = te.id ORDER BY em.nombre_empresa ASC, te.precio DESC";
            comando.Connection = Class.Conexion.conexionSQL;
            try
            {
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Capacitaciones comp = new Capacitaciones();
                    comp.Empresa = lector["nombre_empresa"].ToString();
                    comp.Tema = lector["descripcion"].ToString();
                    comp.tipoCapacitacion = lector["id_empresa"].ToString();
                    comp.diaInicio = Convert.ToDateTime(lector["fecha_inicio"]);
                    comp.id = Convert.ToInt32(lector["id"]);
                    lista.Add(comp);
                }
                lector.Close();
                return lista;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<Capacitaciones> read(bool tipo)
        {
            List<Capacitaciones> lista = new List<Capacitaciones>();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            comando.CommandType = System.Data.CommandType.Text;
            if (tipo)
            {
                comando.CommandText = "SELECT cap.id,fecha_fin,fecha_inicio,em.nombre_empresa,ca.nombre,ca.apellido,te.descripcion, te.precio FROM Capacitaciones cap INNER JOIN Empresas em ON cap.id_empresa = em.id INNER JOIN Capacitadores ca ON cap.id_capacitador = ca.id INNER JOIN Temas te ON cap.id_tema = te.id WHERE precio != 0";
            }
            else
            {
                comando.CommandText = "SELECT cap.id,fecha_fin,fecha_inicio,em.nombre_empresa,ca.nombre,ca.apellido,te.descripcion, te.precio FROM Capacitaciones cap INNER JOIN Empresas em ON cap.id_empresa = em.id INNER JOIN Capacitadores ca ON cap.id_capacitador = ca.id INNER JOIN Temas te ON cap.id_tema = te.id WHERE precio = 0";
            }
            comando.Connection = Class.Conexion.conexionSQL;
            try
            {
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Capacitaciones comp = new Capacitaciones();
                    comp.Capacitador = lector["nombre"].ToString() +" "+lector["apellido"].ToString();
                    comp.diaFinal = Convert.ToDateTime(lector["fecha_fin"]);
                    comp.diaInicio = Convert.ToDateTime(lector["fecha_inicio"]);
                    comp.Empresa = lector["nombre_empresa"].ToString();
                    comp.Tema = lector["descripcion"].ToString();
                    comp.TipoCapacitacion = "$" + lector["precio"].ToString();
                    comp.id = Convert.ToInt32(lector["id"]);
                    lista.Add(comp);
                }
                lector.Close();
                return lista;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool update()
        {
            return true;
        }
        public bool delete()
        {
            return true;
        }
        public void generateCertificates (){ 
        
        }
        public bool Detalles(string idCap)
        {
            try
            {
                SqlCommand comando = new SqlCommand();
                SqlDataReader lector;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT * FROM Capacitaciones cap INNER JOIN DetallesParticipantesCapacitaciones dd ON dd.id_capacitacion = cap.id WHERE cap.id  = "+idCap;
                comando.Connection = Class.Conexion.conexionSQL;
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
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
