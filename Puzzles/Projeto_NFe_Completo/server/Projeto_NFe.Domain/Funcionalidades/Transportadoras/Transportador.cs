using Projeto_NFe.Domain.Funcionalidades.Transportadoras.Excecoes;
using Projeto_NFe.Domain.Funcionalidades.Enderecos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto_NFe.Domain.Base;
using Projeto_NFe.Domain.Funcionalidades.Documentos;

namespace Projeto_NFe.Domain.Funcionalidades.Transportadoras
{
    public class Transportador : Entidade
    {
        public string NomeRazaoSocial { get; set; }
        public string InscricaoEstadual { get; set; }
        public bool ResponsabilidadeFrete { get; set; }

        public Endereco Endereco { get; set; }
        public Documento Documento { get; set; }
    }
}
