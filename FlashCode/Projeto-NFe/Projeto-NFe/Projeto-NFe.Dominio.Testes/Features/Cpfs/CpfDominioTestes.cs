using FluentAssertions;
using NUnit.Framework;
using Projeto_NFe.Comuns.Testes.Features.Cpfs;
using Projeto_NFe.Dominio.Excecoes;
using Projeto_NFe.Infra.Documentos.Features.Cpfs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Dominio.Testes.Features.Cpfs
{
    [TestFixture]
    public class CpfDominioTestes
    {
        Cpf _cpf;

        [Test]
        public void Cpf_Dominio_Validar_ComPontosTracos_EsperadoOK()
        {
            _cpf = CpfObjetoMae.ObterValidoComPontosTracos();

            //acao
            Action action = () => _cpf.Validar();

            //verificar
            action.Should().NotThrow();
        }
        [Test]
        public void Cpf_Dominio_Validar_SemPontosTracos_EsperadoOK()
        {
            _cpf = CpfObjetoMae.ObterValidoSemPontosTracos();

            //acao
            Action action = () => _cpf.Validar();

            //verificar
            action.Should().NotThrow();
        }
        [Test]
        public void Cpf_Dominio_Validar_NumerosIguais_EsperadoFalha()
        {
            _cpf = CpfObjetoMae.ObterNumerosIguais();
            //acao
            Action action = () => _cpf.Validar();

            //verificar
            action.Should().Throw<ExcecaoCPFInvalido>();
        }
        [Test]
        public void Cpf_Dominio_Validar_PrimeiroDigitoInvalido_EsperadoFalha()
        {
            _cpf = CpfObjetoMae.ObterPrimeiroDigitoInvalido();

            //acao
            Action action = () => _cpf.Validar();

            //verificar
            action.Should().Throw<ExcecaoCPFInvalido>();
        }
        [Test]
        public void Cpf_Dominio_Validar_SegundoDigito_EsperadoFalha()
        {
            _cpf = CpfObjetoMae.ObterSegundoDigitoInvalido();

            //acao
            Action action = () => _cpf.Validar();

            //verificar
            action.Should().Throw<ExcecaoCPFInvalido>();
        }
        [Test]
        public void Cpf_Dominio_Validar_NumerosMenorQueOnze_EsperadoFalha()
        {
            _cpf = null;
            //acao
            Action action = () => { _cpf = new Cpf(); _cpf.SetarNumeros("111.111.111-1"); };

            //verificar
            action.Should().Throw<ExcecaoCPFInvalido>();
        }
        [Test]
        public void Cpf_Dominio_Validar_NumerosMaiorQueOnze_EsperadoFalha()
        {
            _cpf = null;
            //acao
            Action action = () => { _cpf = new Cpf(); _cpf.SetarNumeros("111.111.111-111"); };

            //verificar
            action.Should().Throw<ExcecaoCPFInvalido>();
        }
    }
}
