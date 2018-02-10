using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Loteria.Api.Models
{
    public class SorteioModel
    {
        public List<int> NumerosSorteados { get; set; }
        public DateTime Data { get; set; }
        public List<MegaSenaModel> ListaJogos { get; set; }

    }
}