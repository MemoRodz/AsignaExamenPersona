using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersExamWebAPI.Models
{
    public class Persona
    {
        public int IdPersona { get; set; }
        public string Nombre { get; set; }
        public string ApellidoP { get; set; }
        public string ApellidoM { get; set; }
        public string Correoe { get; set; }
    }
}