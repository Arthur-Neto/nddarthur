using System.Linq;
using TutorialORM.Dominio.Features.Enderecos;
using TutorialORM.Infra.Data.Base;

namespace TutorialORM.Infra.Data.Features.Enderecos
{
    public class EnderecoRepositorio : RepositorioGenerico<Endereco>, IEnderecoRepositorio
    {
        public EnderecoRepositorio(EscolaContext context) : base(context)
        {
        }

        public void VerificaDependencia(Endereco endereco)
        {
            if (_contexto.Alunos.Where(x => x.Endereco.Id == endereco.Id).FirstOrDefault() != null)
                throw new EnderecoReferenciadoException();
        }
    }
}
