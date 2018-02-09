using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loteria.Domain
{
    public class Ganhador
    {
        public int IdGanhador { get; private set; }
        public int IdJogo { get; private set; }
        public TipoPremio TipoPremio { get; private set; }
        public decimal ValorPremio { get; private set; }
        public Jogo Jogo { get; private set; }

        public Ganhador() {}

        public Ganhador(TipoPremio tipo, decimal valorPremio, Jogo jogo)
        {
            if (jogo == null)
                throw new Exception("O jogo não pode ser null");

            this.TipoPremio = tipo;
            this.ValorPremio = valorPremio;
            this.Jogo = jogo;
        }

    }
}
