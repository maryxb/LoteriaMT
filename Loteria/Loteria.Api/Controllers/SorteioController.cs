using Loteria.Api.Models;
using Loteria.Application.Services;
using Loteria.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Loteria.Api.Controllers
{
    [RoutePrefix("sorteio")]
    public class SorteioController : ApiController
    {
        ApostaService apostaService;
        public SorteioController()
        {
            apostaService = new ApostaService();
        }

        [HttpGet]
        [Route("sortearMegaSena")]
        public HttpResponseMessage SortearMegaSena()
        {
            try
            {
                var ganhadores = apostaService.SortearMegaSena();
                var model = new List<GanhadorModel>();

                foreach (var item in ganhadores)
                {
                    model.Add(new GanhadorModel()
                    {
                        IdGanhador = item.IdGanhador,
                        IdJogo = item.IdJogo,
                        Jogo = new MegaSenaModel()
                        {
                            IdJogo = item.Jogo.IdJogo,
                            Jogadores = item.Jogo.Jogadores,
                            Numeros = item.Jogo.Numeros
                        },
                        TipoPremio = item.TipoPremio.ToString(),
                        ValorPremio = item.ValorPremio
                    });
                }

                return Request.CreateResponse(HttpStatusCode.OK, model);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}