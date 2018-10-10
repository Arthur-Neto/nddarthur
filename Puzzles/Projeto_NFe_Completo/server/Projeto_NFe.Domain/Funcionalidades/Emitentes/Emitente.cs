using Projeto_NFe.Domain.Base;
using Projeto_NFe.Domain.Funcionalidades.Documentos;
using Projeto_NFe.Domain.Funcionalidades.Enderecos;

namespace Projeto_NFe.Domain.Funcionalidades.Emitentes
{
    public class Emitente : Entidade
    {
        public string NomeFantasia { get; set; }
        public string RazaoSocial { get; set; }
        public virtual Documento CNPJ { get; set; }
        public string InscricaoEstadual { get; set; }
        public string InscricaoMunicipal { get; set; }
        public virtual Endereco Endereco { get; set; }
    }
}
