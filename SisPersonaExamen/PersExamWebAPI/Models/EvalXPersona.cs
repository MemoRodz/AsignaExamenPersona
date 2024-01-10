using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersExamWebAPI.Models
{
    public class EvalXPersona
    {
        public int IdevalXPersona { get; set; }
        public int IdExamen { get; set; }
        public int IdPersona { get; set; }
        public DateTime FecAsignacion { get; set; }
    }
}