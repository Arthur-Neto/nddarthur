using Projeto_NFe.Domain.Base;
using Projeto_NFe.Domain.Funcionalidades.Destinatarios.Excecoes;
using Projeto_NFe.Domain.Funcionalidades.Documentos;
using Projeto_NFe.Domain.Funcionalidades.Enderecos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Funcionalidades.Destinatarios
{
    public class Destinatario : Entidade
    {
        public string NomeRazaoSocial { get; set; }

        public virtual Documento Documento { get; set; }

        public string InscricaoEstadual { get ; set; }

        public Endereco Endereco { get; set; }        
    }
}
