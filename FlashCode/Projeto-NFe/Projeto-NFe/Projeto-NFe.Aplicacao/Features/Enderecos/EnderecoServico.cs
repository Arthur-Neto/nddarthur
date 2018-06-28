using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto_NFe.Dominio.Features.Enderecos;
using Projeto_NFe.Dominio.Excecoes;
using Projeto_NFe.Dominio.Features.Destinatarios;
using Projeto_NFe.Dominio.Features.Emitentes;
using Projeto_NFe.Dominio.Features.Transportadores;

namespace Projeto_NFe.Aplicacao.Features.Enderecos
{
    public class EnderecoServico : IEnderecoServico
    {
        private IEnderecoRepositorio _enderecoRepositorio;
        private IDestinatarioRepositorio _destinatarioRepositorio;
        private IEmitenteRepositorio _emitenteRepositorio;
        private ITransportadorRepositorio _transportadorRepositorio;

        public EnderecoServico(IEnderecoRepositorio enderecoRepositorio, IDestinatarioRepositorio destinatarioRepositorio, IEmitenteRepositorio emitenteRepositorio, ITransportadorRepositorio transportadorRepositorio)
        {
            _enderecoRepositorio = enderecoRepositorio;
            _destinatarioRepositorio = destinatarioRepositorio;
            _emitenteRepositorio = emitenteRepositorio;
            _transportadorRepositorio = transportadorRepositorio;
        }
        public bool Deletar(long id)
        {
            if (id <= 0)
                throw new ExcecaoIdentificadorInvalido();

            var destinatario = _destinatarioRepositorio.ObterPorEnderecoID(id);
            if (destinatario != null)
                throw new ExcecaoChaveEstrangeira();

            var emitente = _emitenteRepositorio.ObterPorEnderecoID(id);
            if (emitente != null)
                throw new ExcecaoChaveEstrangeira();

            var transportador = _transportadorRepositorio.ObterPorEnderecoID(id);
            if (transportador != null)
                throw new ExcecaoChaveEstrangeira();


            return _enderecoRepositorio.Deletar(id);
        }

        public List<Endereco> ObterTodos()
        {
            return _enderecoRepositorio.ObterTodos();
        }
        public Endereco ObterPorId(long id)
        {
            if (id <= 0)
                throw new ExcecaoIdentificadorInvalido();

            return _enderecoRepositorio.ObterPorId(id);
        }

        public Endereco Inserir(Endereco endereco)
        {
            endereco.Validar();

            return _enderecoRepositorio.Inserir(endereco);
        }

        public Endereco Atualizar(Endereco endereco)
        {
            if (endereco.ID <= 0)
                throw new ExcecaoIdentificadorInvalido();

            endereco.Validar();

            return _enderecoRepositorio.Atualizar(endereco);
        }
    }
}
