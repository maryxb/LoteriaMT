﻿using System;
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

            for (int i = 0; i < 100; i++)
            {
                var jogadores = new List<string> { "João", "Maria" };
                var jogo = new MegaSena();
                
                jogo.CriarJogo(jogo.SorteiaNumeros(), jogadores, i);

                listaJogosMegaSena.Add(jogo);
            }
        }

        public void CriarLotoFacil()
        {
            throw new NotImplementedException();
        }

        public void CriarMegaSena(MegaSena megaSena)
        {
            listaJogosMegaSena.Add(megaSena);
        }

        public List<MegaSena> ListarMegaSenas()
        {
            return listaJogosMegaSena;
        }

        public List<Ganhador> SortearMegaSena()
        {
            //Sorteio Mega Sena
            var ms = new MegaSena();
            var numerosGanhadores = ms.SorteiaNumeros();
            var ganhadores = new List<Ganhador>();
            int acertos = 0;

            foreach (var item in this.listaJogosMegaSena)
            {
                acertos = item.Numeros.Intersect(numerosGanhadores).Count();

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