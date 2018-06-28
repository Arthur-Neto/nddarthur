using Projeto_NFe.Infra.Documentos.Features.Cnpjs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Comuns.Testes.Features.Cnpjs
{
    public static class CnpjObjetoMae
    {
        public static Cnpj ObterValidoComPontosTracos()
        {
            var cnpj = new Cnpj();
            cnpj.SetarNumeros("10.151.618/0001-06");
            return cnpj;
        }
        public static Cnpj ObterValidoSemPontosTracos()
        {
            var cnpj = new Cnpj();
            cnpj.SetarNumeros("10151618000106");
            return cnpj;
        }
        public static Cnpj ObterPrimeiroDigitoInvalido()
        {
            var cnpj = new Cnpj();
            cnpj.SetarNumeros("10.151.618/0001-16");
            return cnpj;
        }
        public static Cnpj ObterSegundoDigitoInvalido()
        {
            var cnpj = new Cnpj();
            cnpj.SetarNumeros("10.151.618/0001-00");
            return cnpj;
        }
        public static Cnpj ObterNumerosIguais()
        {
            var cnpj = new Cnpj();
            cnpj.SetarNumeros("11.111.111/1111-11");
            return cnpj;
        }
        public static Cnpj ObterNumerosMenorQueQuatorze()
        {
            var cnpj = new Cnpj();
            cnpj.SetarNumeros("11.111.111/1111-1");
            return cnpj;
        }
        public static Cnpj ObterNumerosMaiorQueQuatorze()
        {
            var cnpj = new Cnpj();
            cnpj.SetarNumeros("11.111.111/1111-111");
            return cnpj;
        }

    }
}
