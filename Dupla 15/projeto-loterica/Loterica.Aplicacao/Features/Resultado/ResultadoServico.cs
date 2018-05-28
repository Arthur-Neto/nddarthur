using Loterica.Aplicacao.Base;
using Loterica.Dominio.Base;
using Loterica.Dominio.Features.Resultados;
using System.Collections.Generic;

namespace Loterica.Aplicacao.Features.Resultados
{
    public class ResultadoServico : Servico<Resultado>
    {
        public ResultadoServico(IRepository<Resultado> repositorio) : base(repositorio)
        {
        }

        public override Resultado Adicionar(Resultado entidade)
        {
            return base.Adicionar(entidade);
        }

        public override Resultado Atualizar(Resultado entidade)
        {
            entidade.GerarNovosNumeros();
            return base.Atualizar(entidade);
        }

        public override IEnumerable<Resultado> BuscarTodos()
        {
            return base.BuscarTodos();
        }

        public override Resultado ConsultarPorId(long id)
        {
            return base.ConsultarPorId(id);
        }

        public override void Excluir(Resultado entidade)
        {
            base.Excluir(entidade);
        }
    }
}
