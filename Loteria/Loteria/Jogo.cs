using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loteria
{
    public abstract class Jogo
    {
        public int IdJogo { get; set; }
        public List<int> Numeros { get; set; }
        public List<string> Jogadores { get; set; }
        public DateTime DataHora { get; set; }


        public abstract void CriarJogo(List<int> numeros, List<string> nome, int idJogo);
    }
}
