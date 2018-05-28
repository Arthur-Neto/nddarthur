using Loterica.Aplicacao.Base;
using Loterica.Dominio.Base;
using Loterica.Dominio.Features.Boloes;
using Loterica.Dominio.Features.Concursos;
using System;
using System.Collections.Generic;

namespace Loterica.Aplicacao.Features.Boloes
{
    public class BolaoServico : Servico<Bolao>
    {
        public BolaoServico(IRepository<Bolao> repositorio) : base(repositorio)
        {
        }

        public override Bolao Adicionar(Bolao entidade)
        {
            return base.Adicionar(entidade);
        }

        public override Bolao Atualizar(Bolao entidade)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Bolao> BuscarTodos()
        {
            return base.BuscarTodos();
        }

        public override Bolao ConsultarPorId(long id)
        {
            return base.ConsultarPorId(id);
        }

        public override void Excluir(Bolao entidade)
        {
            base.Excluir(entidade);
        }

        public Bolao GerarBolao(int quantidadeApostas, Concurso concurso)
        {
            Bolao bolao = new Bolao();
            bolao = bolao.GerarBolao(quantidadeApostas, concurso);
            return Adicionar(bolao);
        }
    }
}
