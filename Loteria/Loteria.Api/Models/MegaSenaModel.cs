using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Loteria.Api.Models
{
    public class MegaSenaModel
    {
        public int IdJogo { get; set; }
        public List<int> Numeros { get; set; }
        public List<string> Jogadores { get; set; }
        //public DateTime DataHora { get; set; }
    }
}