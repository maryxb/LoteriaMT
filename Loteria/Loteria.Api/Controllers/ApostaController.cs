using Loteria.Api.Models;
using Loteria.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Loteria.Api.Controllers
{
    [RoutePrefix("aposta")]
    public class ApostaController : ApiController
    {
        ApostaService apostaService;
        public ApostaController()
        {
            apostaService = new ApostaService();
        }

        [HttpPost]
        [Route("criarMegaSena")]
        public HttpResponseMessage CriarMegaSena(MegaSenaModel model)
        {
            try
            {
                var megaSena = new MegaSena();
                megaSena.CriarJogo(model.Numeros, model.Jogadores, apostaService.ListarMegaSenas().Count + 1);
                apostaService.CriarMegaSena(megaSena);

                return Request.CreateResponse(HttpStatusCode.OK, model);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}