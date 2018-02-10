using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loteria.Domain
{
    public class MegaSena : Jogo
    {
        public override void CriarJogo(List<int> numeros, List<string> jogadores, int idJogo)
        {
            if (numeros.Count() == 0)
                throw new Exception("Favor inserir números");

            if (jogadores.Count() == 0)
                throw new Exception("Favor inserir um jogador");

            this.Numeros = numeros;
            this.DataHora = DateTime.Now;
            this.Jogadores = jogadores;
            this.IdJogo = idJogo;

            VerificaFaixaNumeros(numeros);
            VerificaNumeroRepetidos(numeros);
        }

        public void VerificaFaixaNumeros(List<int> numeros)
        {
            foreach (var item in numeros)
            {
                if ((item > 60) || (item < 1))
                    throw new Exception("Por favor, informe números entre 1 e 60");
            }
        }

        public void VerificaNumeroRepetidos(List<int> numeros)
        {
            var repetidos = numeros
                 .GroupBy(item => item)
                 .Where(g => g.Count() > 1)
                 .Select(g => g.Key)
                 .Count();

            if (repetidos > 0)
                throw new Exception("Por favor, informe números diferentes");
        }

        //Mega sena pode sortear 6 números, por isso não está na class Jogo
        public List<int> SorteiaNumeros()
        {
            int cont = 0,
                numero = 0;

            var listaSorteio = new List<int>();
            Random random = new Random();
            while (cont < 6)
            {
                numero = random.Next(1, 60);
                if (!listaSorteio.Contains(numero))
                {
                    listaSorteio.Add(numero);
                    cont++;
                }
            }
            return listaSorteio;

        }

    }
}
