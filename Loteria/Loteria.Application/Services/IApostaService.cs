using Loteria.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loteria.Application.Services
{
    public interface IApostaService
    {
        void CriarLotoFacil();

        List<MegaSena> ListarMegaSenas();
        List<MegaSena> CriarMegaSena(MegaSena megaSena);
        List<Ganhador> SortearMegaSena();

    }
}
