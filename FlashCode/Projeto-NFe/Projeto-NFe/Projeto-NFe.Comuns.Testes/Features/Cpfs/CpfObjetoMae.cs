using Projeto_NFe.Infra.Documentos.Features.Cpfs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Comuns.Testes.Features.Cpfs
{
    public static class CpfObjetoMae
    {
        public static Cpf ObterValidoComPontosTracos()
        {
            var cpf = new Cpf();
            cpf.SetarNumeros("966.864.300-30");
            return cpf;
        }
        public static Cpf ObterValidoSemPontosTracos()
        {
            var cpf = new Cpf();
            cpf.SetarNumeros("96686430030");
            return cpf;
        }
        public static Cpf ObterSegundoDigitoInvalido()
        {
            var cpf = new Cpf();
            cpf.SetarNumeros("966.864.300-33");
            return cpf;
        }
        public static Cpf ObterPrimeiroDigitoInvalido()
        {
            var cpf = new Cpf();
            cpf.SetarNumeros("966.864.300-10");
            return cpf;
        }
        public static Cpf ObterNumerosIguais()
        {
            var cpf = new Cpf();
            cpf.SetarNumeros("111.111.111-11");
            return cpf;
        }

    }
}
