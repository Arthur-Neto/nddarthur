using FluentAssertions;
using NUnit.Framework;
using Projeto_NFe.Comuns.Testes.Features.Base;
using Projeto_NFe.Comuns.Testes.Features.Enderecos;
using Projeto_NFe.Dominio.Excecoes;
using Projeto_NFe.Dominio.Features.Enderecos;
using Projeto_NFe.Dominio.Features.Enderecos.Excecoes;
using Projeto_NFe.Infra.Data.Features.Enderecos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.Data.Testes.Features.Enderecos
{
    [TestFixture]
    public class EnderecoInfraSqlTestes
    {
        private IEnderecoRepositorio _enderecoRepositorio;
        private Endereco _endereco;

        [SetUp]
        public void SetUp()
        {
            _enderecoRepositorio = new EnderecoRepositorioSql();
            _endereco = new Endereco();
        }

        [Test]
        public void Endereco_InfraData_Inserir_EsperadoOK()
        {
            //cenário
            BaseSqlTeste.SemearBancoParaEndereco();
            _endereco = EnderecoObjetoMae.ObterValido();
            _endereco.ID = 0;
          
            //Ação
            Endereco endereco = _enderecoRepositorio.Inserir(_endereco);

            //Verificação
            endereco.ID.Should().BeGreaterThan(0);

        }

        [Test]
        [Order (2)]
        public void Endereco_InfraData_Deletar_EsperadoOK()
        {
            //cenário           
            BaseSqlTeste.SemearBancoParaEndereco();

            _endereco.ID = 2;

            //Ação
            bool deletado = _enderecoRepositorio.Deletar(_endereco.ID);

            //Verificação
            deletado.Should().BeTrue();
        }

        [Test]
        public void Endereco_InfraData_Atualizar_EsperadoOK()
        {
            //cenário
            BaseSqlTeste.SemearBancoParaEndereco();
            _endereco = EnderecoObjetoMae.ObterValido();
            _endereco.ID = 1;
            _endereco.Pais = "Argentina";

            //Ação
            Endereco endereco = _enderecoRepositorio.Atualizar(_endereco);

            //Verificação
            endereco.Pais.Should().Be(_endereco.Pais);
        }

        [Test]
        public void Endereco_InfraData_PegarPorID_EsperadoOK()
        {
            //cenário
            BaseSqlTeste.SemearBancoParaEndereco();
            _endereco.ID = 1;

            //Ação
            Endereco endereco = _enderecoRepositorio.ObterPorId(_endereco.ID);

            //Verificação
            endereco.Should().NotBeNull();
            endereco.ID.Should().Be(_endereco.ID);
        }

        [Test]
        public void Endereco_InfraData_PegarTodos_EsperadoOK()
        {
            //Cenário
            BaseSqlTeste.SemearBancoParaEndereco();

            //Ação
            List<Endereco> listaEnderecos = _enderecoRepositorio.ObterTodos();

            //Verificação
            listaEnderecos.Should().NotBeNull();
            listaEnderecos.Count.Should().BeGreaterThan(0);
        }

        [Test]
        public void Endereco_InfraData_Inserir_RuaInvalida_EsperadoFalha()
        {
            //Cenário
            _endereco = EnderecoObjetoMae.ObterValido();
            _endereco.Rua = String.Empty;
            //Ação
            Action action = () => _enderecoRepositorio.Inserir(_endereco);

            //Verificação
            action.Should().Throw<ExcecaoRuaInvalida>();
        }

        [Test]
        public void Endereco_InfraData_Atualizar_RuaInvalida_EsperadoFalha()
        {
            //Cenário
            _endereco = EnderecoObjetoMae.ObterValido();
            _endereco.Rua = String.Empty;
            //Ação
            Action action = () => _enderecoRepositorio.Atualizar(_endereco);

            //Verificação
            action.Should().Throw<ExcecaoRuaInvalida>();
        }

        [Test]
        public void Endereco_InfraData_Inserir_CepInvalido_EsperadoFalha()
        {
            //Cenário
            _endereco = EnderecoObjetoMae.ObterValido();
            _endereco.Cep = String.Empty;
            //Ação
            Action action = () => _enderecoRepositorio.Inserir(_endereco);

            //Verificação
            action.Should().Throw<ExcecaoCepInvalido>();
        }

        [Test]
        public void Endereco_InfraData_Atualizar_CepInvalido_EsperadoFalha()
        {
            //Cenário
            _endereco = EnderecoObjetoMae.ObterValido();
            _endereco.Cep = String.Empty;
            //Ação
            Action action = () => _enderecoRepositorio.Atualizar(_endereco);

            //Verificação
            action.Should().Throw<ExcecaoCepInvalido>();
        }

        [Test]
        public void Endereco_InfraData_Inserir_BairroInvalido_EsperadoFalha()
        {
            //Cenário
            _endereco = EnderecoObjetoMae.ObterValido();
            _endereco.Bairro = String.Empty;
            //Ação
            Action action = () => _enderecoRepositorio.Inserir(_endereco);

            //Verificação
            action.Should().Throw<ExcecaoBairroInvalido>();
        }

        [Test]
        public void Endereco_InfraData_Atualizar_BairroInvalido_EsperadoFalha()
        {
            //Cenário
            _endereco = EnderecoObjetoMae.ObterValido();
            _endereco.Bairro = String.Empty;
            //Ação
            Action action = () => _enderecoRepositorio.Atualizar(_endereco);

            //Verificação
            action.Should().Throw<ExcecaoBairroInvalido>();
        }

        [Test]
        public void Endereco_InfraData_Inserir_CidadeInvalida_EsperadoFalha()
        {
            //Cenário
            _endereco = EnderecoObjetoMae.ObterValido();
            _endereco.Cidade = String.Empty;
            //Ação
            Action action = () => _enderecoRepositorio.Inserir(_endereco);

            //Verificação
            action.Should().Throw<ExcecaoCidadeInvalida>();
        }

        [Test]
        public void Endereco_InfraData_Atualizar_CidadeInvalida_EsperadoFalha()
        {
            //Cenário
            _endereco = EnderecoObjetoMae.ObterValido();
            _endereco.Cidade = String.Empty;
            //Ação
            Action action = () => _enderecoRepositorio.Atualizar(_endereco);

            //Verificação
            action.Should().Throw<ExcecaoCidadeInvalida>();
        }

        [Test]
        public void Endereco_InfraData_Inserir_NumeroInvalido_EsperadoFalha()
        {
            //Cenário
            _endereco = EnderecoObjetoMae.ObterValido();
            _endereco.Numero = 0;
            //Ação
            Action action = () => _enderecoRepositorio.Inserir(_endereco);

            //Verificação
            action.Should().Throw<ExcecaoNumeroInvalido>();
        }

        [Test]
        public void Endereco_InfraData_Atualizar_NumeroInvalido_EsperadoFalha()
        {
            //Cenário
            _endereco = EnderecoObjetoMae.ObterValido();
            _endereco.Numero = 0;
            //Ação
            Action action = () => _enderecoRepositorio.Atualizar(_endereco);

            //Verificação
            action.Should().Throw<ExcecaoNumeroInvalido>();
        }

        [Test]
        public void Endereco_InfraData_Inserir_PaisInvalido_EsperadoFalha()
        {
            //Cenário
            _endereco = EnderecoObjetoMae.ObterValido();
            _endereco.Pais = String.Empty;
            //Ação
            Action action = () => _enderecoRepositorio.Inserir(_endereco);

            //Verificação
            action.Should().Throw<ExcecaoPaisInvalido>();
        }

        [Test]
        public void Endereco_InfraData_Atualizar_PaisInvalido_EsperadoFalha()
        {
            //Cenário
            _endereco = EnderecoObjetoMae.ObterValido();
            _endereco.Pais = String.Empty;
            //Ação
            Action action = () => _enderecoRepositorio.Atualizar(_endereco);

            //Verificação
            action.Should().Throw<ExcecaoPaisInvalido>();
        }

        [Test]
        public void Endereco_InfraData_Inserir_UFInvalido_EsperadoFalha()
        {
            //Cenário
            _endereco = EnderecoObjetoMae.ObterValido();
            _endereco.UF = String.Empty;
            //Ação
            Action action = () => _enderecoRepositorio.Inserir(_endereco);

            //Verificação
            action.Should().Throw<ExcecaoUFInvalido>();
        }

        [Test]
        public void Endereco_InfraData_Atualizar_UFInvalido_EsperadoFalha()
        {
            //Cenário
            _endereco = EnderecoObjetoMae.ObterValido();
            _endereco.UF = String.Empty;
            //Ação
            Action action = () => _enderecoRepositorio.Atualizar(_endereco);

            //Verificação
            action.Should().Throw<ExcecaoUFInvalido>();
        }
        [Test]
        public void Endereco_InfraData_Deletar_IDInvalido_EsperadoFalso()
        {
            //Cenário
            BaseSqlTeste.SemearBancoParaEndereco();
            _endereco.ID = 23;
            //Ação
            bool deletado = _enderecoRepositorio.Deletar(_endereco.ID);

            //Verificação
            deletado.Should().BeFalse();
        }

        [Test]
        public void Endereco_InfraData_ObterPorID_IDInvalido_EsperadoFalha()
        {
            //Cenário
            BaseSqlTeste.SemearBancoParaEndereco();
            _endereco.ID = 23;
            //Ação
            Endereco endereco = _enderecoRepositorio.ObterPorId(_endereco.ID);

            //Verificação
            endereco.Should().BeNull();
        }

        [Test]
        public void Endereco_InfraData_ObterPorID_IDZero_EsperadoFalha()
        {
            //Cenário
            _endereco.ID = 0;
            //Ação
           Action action =()=> _enderecoRepositorio.ObterPorId(_endereco.ID);

            //Verificação
            action.Should().Throw<ExcecaoIdentificadorInvalido>();
        }

        [Test]
        public void Endereco_InfraData_Deletar_IDZero_EsperadoFalha()
        {
            //Cenário
            _endereco.ID = 0;
            //Ação
            Action action = () => _enderecoRepositorio.Deletar(_endereco.ID);

            //Verificação
            action.Should().Throw<ExcecaoIdentificadorInvalido>();
        }

        [Test]
        public void Endereco_InfraData_Atualizar_IDZero_EsperadoFalha()
        {
            //Cenário
            _endereco = EnderecoObjetoMae.ObterValido();
            _endereco.ID = 0;
            //Ação
            Action action = () => _enderecoRepositorio.Atualizar(_endereco);

            //Verificação
            action.Should().Throw<ExcecaoIdentificadorInvalido>();
        }
    }
}
