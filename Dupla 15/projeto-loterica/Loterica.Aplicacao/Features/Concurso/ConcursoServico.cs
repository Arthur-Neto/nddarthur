using Loterica.Aplicacao.Base;
using Loterica.Dominio.Base;
using Loterica.Dominio.Features.Concursos;
using Loterica.Infra.CSV.Features.Concursos;
using System.Collections.Generic;

namespace Loterica.Aplicacao.Features.Concursos
{
    public class ConcursoServico : Servico<Concurso>
    {
        public ConcursoServico(IRepository<Concurso> repositorio) : base(repositorio)
        {
        }

        public override Concurso Adicionar(Concurso entidade)
        {
            return base.Adicionar(entidade);
        }

        public override Concurso Atualizar(Concurso entidade)
        {
            return base.Atualizar(entidade);
        }

        public override IEnumerable<Concurso> BuscarTodos()
        {
            return base.BuscarTodos();
        }

        public override Concurso ConsultarPorId(long id)
        {
            return base.ConsultarPorId(id);
        }

        public override void Excluir(Concurso entidade)
        {
            base.Excluir(entidade);
        }

        public string RelatorioFaturamento()
        {
            return ((IConcursoRepository)Repositorio).RelatorioFaturamento();
        }

        public void GerarCSVConcursos(string caminho)
        {
            ConcursoCSVRepository.GerarCSV(BuscarTodos(), caminho);
        }
    }
}
