using Projeto_NFe.Domain.Base;
using Projeto_NFe.Domain.Funcionalidades.Documentos;
using Projeto_NFe.Domain.Funcionalidades.Enderecos;

namespace Projeto_NFe.Domain.Funcionalidades.Transportadoras
{
    public class Transportador : Entidade
    {
        public string NomeRazaoSocial { get; set; }
        public string InscricaoEstadual { get; set; }
        public bool ResponsabilidadeFrete { get; set; }

        public long? EnderecoId { get; set; }
        public Endereco Endereco { get; set; }

        public long? DocumentoId { get; set; }
        public Documento Documento { get; set; }
    }
}
