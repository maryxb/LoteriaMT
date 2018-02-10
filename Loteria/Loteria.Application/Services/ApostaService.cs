using Loteria.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loteria.Application.Services
{
    public class ApostaService : IApostaService
    {
        List<MegaSena> listaJogosMegaSena;

        public ApostaService()
        {
            listaJogosMegaSena = new List<MegaSena>();

        }

        public void CriarLotoFacil()
        {
            throw new NotImplementedException();
        }

        public List<MegaSena> CriarMegaSena(MegaSena megaSena)
        {
            listaJogosMegaSena.Add(megaSena);
            return listaJogosMegaSena;
        }

        public List<MegaSena> ListarMegaSenas()
        {
            //Inicia com jogos aleatórios
            for (int i = 0; i < 1000; i++)
            {
                var jogadores = new List<string> { "João", "Maria" };
                var jogo = new MegaSena();
                var numeros = jogo.SorteiaNumeros();

                if (i > 0)
                {
                    while (listaJogosMegaSena[i - 1].Numeros.Union(numeros).ToList().Count() == 6)
                    {
                        numeros = jogo.SorteiaNumeros();
                    }
                }

                jogo.CriarJogo(numeros, jogadores, i);

                listaJogosMegaSena.Add(jogo);
            }

            return listaJogosMegaSena;
        }

        public Sorteio SortearMegaSena()
        {
            var ms = new MegaSena();
            return new Sorteio(ms.SorteiaNumeros());
        }

        public List<Ganhador> RetornaGanhadores(Sorteio sorteio)
        {
            var ganhadores = new List<Ganhador>();
            int acertos = 0;

            foreach (var item in sorteio.ListaJogos)
            {
                acertos = item.Numeros.Intersect(sorteio.NumerosSorteados).Count();

                switch (acertos)
                {
                    case 6:
                        ganhadores.Add(new Ganhador(TipoPremio.Sena, 1000000, item));
                        break;
                    case 5:
                        ganhadores.Add(new Ganhador(TipoPremio.Quina, 500000, item));
                        break;
                    case 4:
                        ganhadores.Add(new Ganhador(TipoPremio.Quadra, 40000, item));
                        break;
                }
            }
            return ganhadores;
        }
    }
}
