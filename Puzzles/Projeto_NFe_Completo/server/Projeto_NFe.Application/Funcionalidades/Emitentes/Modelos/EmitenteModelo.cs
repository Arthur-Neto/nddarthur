using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Funcionalidades.Emitentes.Modelos
{
    public class EmitenteModelo
    {
        public long Id { get; set; }

        public string NomeFantasia { get; set; }

        public string RazaoSocial { get; set; }

        public string CNPJ { get; set; }

        public string InscricaoEstadual { get; set; }

        public string InscricaoMunicipal { get; set; }

        public string EnderecoLogradouro { get; set; }

        public int EnderecoNumero { get; set; }

        public string EnderecoBairro { get; set; }

        public string EnderecoMunicipio { get; set; }

        public string EnderecoEstado { get; set; }

        public string EnderecoPais { get; set; }

    }
}
