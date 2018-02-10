using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Loteria.Domain;

namespace Loteria.Tests
{
    [TestClass]
    public class UnitTestJogo
    {
        int contSena, contQuina, contQuadra = 0;

        [TestMethod]
        public void DeveCriarMegaSena()
        {
            var ms = new MegaSena();

            var numeros = new List<int> { 1, 2, 3, 4, 5, 6 };
            var jogadores = new List<string> { "João", "Maria" };

            ms.CriarJogo(numeros, jogadores, 1);

            Assert.IsNotNull(ms);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void DeveVerificarNumeroRepetidos()
        {
            var ms = new MegaSena();

            var numeros = new List<int> { 1, 1, 3, 3, 5, 5 };
            var jogadores = new List<string> { "João", "Maria" };

            ms.CriarJogo(numeros, jogadores, 1);
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void DeveVerificarFaixaDeNumeros()
        {
            var ms = new MegaSena();

            var numeros = new List<int> { 0, 80, 3, 3, 5, 5 };
            var jogadores = new List<string> { "João", "Maria" };

            ms.CriarJogo(numeros, jogadores, 1);
            Assert.Fail();
        }

        [TestMethod]
        public void DeveSortearSeisNumerosDiferentes()
        {
            var ms = new MegaSena();

            var sorteio = ms.SorteiaNumeros();

            Assert.AreEqual(6, sorteio.Count);
        }

        //Deverá mostrar os Acertadores da Sena, Quina e Quadra. 
        [TestMethod]
        public void DeveCriarListaDeJogosESortear()
        {
            List<MegaSena> listaJogosMegaSena = new List<MegaSena>();

            //for (int i = 0; i < 10000; i++)
            //{
            //    var jogadores = new List<string> { "João", "Maria" };
            //    var jogo = new MegaSena();
            //    jogo.CriarJogo(SorteiaNumeros(), jogadores, i);
            //    listaJogosMegaSena.Add(jogo);
            //}

            //Ganhador Sena
            var jogoSena = new MegaSena();
            jogoSena.CriarJogo(new List<int> { 7, 10, 19, 29, 33, 60 }, new List<string> { "João", "Maria" }, 1);
            listaJogosMegaSena.Add(jogoSena);

            //Ganhador Quina
            var jogoQuina = new MegaSena();
            jogoQuina.CriarJogo(new List<int> { 5, 10, 19, 29, 33, 60 }, new List<string> { "João", "Maria" }, 2);
            listaJogosMegaSena.Add(jogoQuina);

            //Ganhador Quadra
            var jogoQuadra = new MegaSena();
            jogoQuadra.CriarJogo(new List<int> { 5, 1, 19, 29, 33, 60 }, new List<string> { "João", "Maria" }, 3);
            listaJogosMegaSena.Add(jogoQuadra);

            //Sorteio
            var ms = new MegaSena();
            var numerosGanhadores = new List<int> { 7, 10, 19, 29, 33, 60 };
            var ganhadores = new List<Ganhador>();
            int acertos = 0;

            foreach (var item in (List<MegaSena>)listaJogosMegaSena)
            {
                acertos = item.Numeros.Intersect(numerosGanhadores).Count();

                switch (acertos)
                {
                    case 6:
                        ganhadores.Add(new Ganhador(TipoPremio.Sena, 1000000, item));
                        contSena++;
                        break;
                    case 5:
                        ganhadores.Add(new Ganhador(TipoPremio.Quina, 500000, item));
                        contQuina++;
                        break;
                    case 4:
                        ganhadores.Add(new Ganhador(TipoPremio.Quadra, 40000, item));
                        contQuadra++;
                        break;
                }
            }
            int totalGanhadores = contSena + contQuina + contQuadra;

            Assert.AreEqual(3, totalGanhadores);
        }
        
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
