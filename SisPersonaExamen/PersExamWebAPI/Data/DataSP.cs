using PersExamWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PersExamWebAPI.Data
{
    public class DataSP
    {
        /// <summary>
        /// Obtiene Lista de Personas.
        /// </summary>
        /// <returns></returns>
        public static List<Persona> PersonaLista()
        {
            List<Persona> oListaPersonas = new List<Persona>();

            using (SqlConnection oConn = new SqlConnection(Conexion.conn))
            {
                SqlCommand cmd = new SqlCommand("ListaPersona", oConn);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oListaPersonas.Add(new Persona()
                            {
                                IdPersona = Convert.ToInt32(dr["IdPersona"]),
                                Nombre = dr["Nombre"].ToString(),
                                ApellidoP = dr["ApellidoP"].ToString(),
                                ApellidoM = dr["ApellidoM"].ToString(),
                                Correoe = dr["Correoe"].ToString()
                            });
                        }
                    }

                    return oListaPersonas;
                }
                catch (Exception)
                {
                    return oListaPersonas;
                }
            }
        }

        /// <summary>
        /// Obtiene lista de Examenes.
        /// </summary>
        /// <returns></returns>
        public static List<Examen> ExamenLista()
        {
            List<Examen> oListaExamenes = new List<Examen>();

            using (SqlConnection oConn = new SqlConnection(Conexion.conn))
            {
                SqlCommand cmd = new SqlCommand("ListaExamen", oConn);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oListaExamenes.Add(new Examen()
                            {
                                IdExamen = Convert.ToInt32(dr["IdExamen"]),
                                Descripcion = dr["Descripcion"].ToString()
                            });
                        }
                    }

                    return oListaExamenes;
                }
                catch (Exception)
                {
                    return oListaExamenes;
                }
            }

        }

        /// <summary>
        /// Relacionar Fecha de Asignación de Examen a Persona.
        /// </summary>
        /// <param name="persona">Entero IdPersona</param>
        /// <param name="examen">Entero IdExamen</param>
        /// <param name="fechaasigna">DateTime Fecha de Asignación</param>
        /// <returns>Si es asignado regresa TRUE</returns>
        public static bool AsignaPersonaExamen(int persona, int examen, DateTime fechaasigna)
        {
            using (SqlConnection oConn = new SqlConnection(Conexion.conn))
            {
                SqlCommand cmd = new SqlCommand("AsignarExamenAPersona", oConn);
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@personaId", persona);
                    cmd.Parameters.AddWithValue("@examenId", examen);
                    cmd.Parameters.AddWithValue("@fechaAsignacion", fechaasigna);

                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Obtiene lista de personas asignadas a un Examenpor según IdExamen.
        /// </summary>
        /// <param name="Id">Id Examen</param>
        /// <returns></returns>
        public static List<Persona> ObtenerPersonaId(int Id)
        {
            List<Persona> oListaPersonas = new List<Persona>();

            using (SqlConnection oConn = new SqlConnection(Conexion.conn))
            {
                SqlCommand cmd = new SqlCommand("ListaPersonaXEval", oConn);
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@examenId", Id);

                    oConn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oListaPersonas.Add(new Persona()
                            {
                                IdPersona = Convert.ToInt32(dr["IdPersona"]),
                                Nombre = dr["Nombre"].ToString(),
                                ApellidoP = dr["ApellidoP"].ToString(),
                                ApellidoM = dr["ApellidoM"].ToString(),
                                Correoe = dr["Correoe"].ToString()
                            });
                        }
                    }

                    return oListaPersonas;
                }
                catch (Exception)
                {
                    return oListaPersonas;
                }
            }
        }

    }
}