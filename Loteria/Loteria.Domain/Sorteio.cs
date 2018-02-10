using Loteria.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loteria
{
    public class Sorteio
    {
        public List<int> NumerosSorteados { get; private set; }
        public DateTime Data { get; private set; }
        public List<MegaSena> ListaJogos { get; private set; }

        public Sorteio(List<int> numerosSorteados)
        {
            this.NumerosSorteados = numerosSorteados;
            this.Data = DateTime.Now;
        }
        public Sorteio(List<int> numerosSorteados, DateTime data, List<MegaSena> listaJogos)
        {
            this.NumerosSorteados = numerosSorteados;
            this.Data = data;
            this.ListaJogos = listaJogos;
        }
    }
}
