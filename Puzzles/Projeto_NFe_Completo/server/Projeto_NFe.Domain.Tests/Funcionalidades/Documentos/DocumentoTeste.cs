using FluentAssertions;
using NUnit.Framework;
using Projeto_NFe.Domain.Funcionalidades.Documentos;
using Projeto_NFe.Domain.Funcionalidades.Documentos.CNPJs;
using Projeto_NFe.Domain.Funcionalidades.Documentos.CPFs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Tests.Funcionalidades.Documentos
{
    [TestFixture]
    public class DocumentoTeste
    {
        private Documento _cpf;
        private Documento _cnpj;

        [Test]
        public void Documento_Dominio_CPF_Validar_Sucesso()
        {
            _cpf = new Documento("783.119.500-91", TipoDocumento.CPF);
            _cpf.Validar();

            //Action acaoResultado => _cpf.Validar();
        }


        [Test]
        public void Documento_Dominio_CNPJ_Validar_Sucesso()
        {
            _cnpj = new Documento("98.862.511/0001-17", TipoDocumento.CNPJ);
            _cnpj.Validar();
        }

    }
}
