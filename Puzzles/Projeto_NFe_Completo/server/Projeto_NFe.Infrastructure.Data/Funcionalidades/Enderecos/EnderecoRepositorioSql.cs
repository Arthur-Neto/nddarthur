using Projeto_NFe.Domain.Funcionalidades.Enderecos;
using Projeto_NFe.Infrastructure.Data.Base;
using System.Linq;

namespace Projeto_NFe.Infrastructure.Data.Funcionalidades.Enderecos
{
    public class EnderecoRepositorioSql : IEnderecoRepositorio
    {
        ProjetoNFeContexto _contexto;

        public EnderecoRepositorioSql(ProjetoNFeContexto contexto)
        {
            _contexto = contexto;
        }       

        public long Adicionar(Endereco endereco)
        {
            endereco = _contexto.Enderecos.Add(endereco);
            _contexto.SaveChanges();
            return endereco.Id;
        }

        public bool Atualizar(Endereco endereco)
        {
            return _contexto.SaveChanges() != 0;
        }

        public Endereco BuscarPorId(long Id)
        {
            Endereco endereco = _contexto.Enderecos.Find(Id);
            return endereco;
        }

        public IQueryable<Endereco> BuscarTodos()
        {
            return _contexto.Enderecos;
        }

        public bool Excluir(Endereco endereco)
        {
            _contexto.Enderecos.Remove(endereco);
            return _contexto.SaveChanges() != 0;
        }

    }
}
