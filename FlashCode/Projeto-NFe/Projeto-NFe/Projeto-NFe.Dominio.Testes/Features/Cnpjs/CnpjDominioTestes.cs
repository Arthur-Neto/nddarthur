using FluentAssertions;
using NUnit.Framework;
using Projeto_NFe.Comuns.Testes.Features.Cnpjs;
using Projeto_NFe.Dominio.Excecoes;
using Projeto_NFe.Infra.Documentos.Features.Cnpjs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Dominio.Testes.Features.Cnpjs
{
    [TestFixture]
    public class CnpjDominioTestes
    {
        Cnpj _cnpj;

        [Test]
        public void Cnpj_Dominio_Validar_ComPontosTracos_EsperadoOK()
        {
            _cnpj = CnpjObjetoMae.ObterValidoComPontosTracos();

            //acao
            Action action = () => _cnpj.Validar();

            //verificar
            action.Should().NotThrow();
        }
        [Test]
        public void Cnpj_Dominio_Validar_SemPontosTracos_EsperadoOK()
        {
            _cnpj = CnpjObjetoMae.ObterValidoSemPontosTracos();

            //acao
            Action action = () => _cnpj.Validar();

            //verificar
            action.Should().NotThrow();
        }
        [Test]
        public void Cnpj_Dominio_Validar_PrimeiroDigitoInvalido_EsperadoFalha()
        {
            _cnpj = CnpjObjetoMae.ObterPrimeiroDigitoInvalido();

            //acao
            Action action = () => _cnpj.Validar();

            //verificar
            action.Should().Throw<ExcecaoCNPJInvalido>();
        }
        [Test]
        public void Cnpj_Dominio_Validar_SegundoDigitoInvalido_EsperadoFalha()
        {
            _cnpj = CnpjObjetoMae.ObterSegundoDigitoInvalido();

            //acao
            Action action = () => _cnpj.Validar();

            //verificar
            action.Should().Throw<ExcecaoCNPJInvalido>();
        }
        [Test]
        public void Cnpj_Dominio_Validar_NumerosIguais_EsperadoFalha()
        {
            _cnpj = CnpjObjetoMae.ObterNumerosIguais();

            //acao
            Action action = () => _cnpj.Validar();

            //verificar
            action.Should().Throw<ExcecaoCNPJInvalido>();
        }
        [Test]
        public void Cnpj_Dominio_Validar_NumerosMenorQueQuatorze_EsperadoFalha()
        {
            //cenario
            _cnpj = null;

            //acao
            Action action = () => { _cnpj = new Cnpj(); _cnpj.SetarNumeros("11.111.111/1111-1"); };

            //verificar
            action.Should().Throw<ExcecaoCNPJInvalido>();
        }
        [Test]
        public void Cnpj_Dominio_Validar_NumerosMaiorQueQuatorze_EsperadoFalha()
        {
            //cenario
            _cnpj = null;

            //acao
            Action action = () => { _cnpj = new Cnpj(); _cnpj.SetarNumeros("11.111.111/1111-111"); };

            //verificar
            action.Should().Throw<ExcecaoCNPJInvalido>();
        }
    }
}
