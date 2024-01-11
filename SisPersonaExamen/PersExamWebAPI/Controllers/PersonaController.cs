using PersExamWebAPI.Data;
using PersExamWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PersExamWebAPI.Controllers
{
    public class PersonaController : ApiController
    {
        /// <summary>
        /// Lista de Persona
        /// </summary>
        /// <returns></returns>
        public List<Persona> GetPersona()
        {
            return DataSP.PersonaLista();
        }

        // GET api/<controller>/5
        public List<Examen> GetExamen()
        {
            return DataSP.ExamenLista();
        }

        // POST api/<controller>
        public bool Post([FromBody]int personaId, [FromBody]int examenId, [FromBody]DateTime fechaAsignacion)
        {
            return DataSP.AsignaPersonaExamen(personaId, examenId, fechaAsignacion);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}