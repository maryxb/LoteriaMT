using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Loteria.Api.Models
{
    public class GanhadorModel
    {
        public int IdGanhador { get; set; }
        public int IdJogo { get; set; }
        public string TipoPremio { get; set; }
        public decimal ValorPremio { get; set; }
        public MegaSenaModel Jogo { get; set; }
        public List<int> NumerosSorteados { get; set; }
    }
}