using Projeto_NFe.Dominio.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Dominio.Features.Destinatarios
{
    public interface IDestinatarioRepositorio : IRepositorio<Destinatario>
    {
        Destinatario ObterPorEnderecoID(long id);
    }
}
