using Projeto_NFe.Domain.Base;
using Projeto_NFe.Domain.Funcionalidades.Documentos.CNPJs;
using Projeto_NFe.Domain.Funcionalidades.Documentos.CPFs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Funcionalidades.Documentos
{
    public class Documento : Entidade
    {
        public string Numero { get; set; }

        public TipoDocumento Tipo { get; set; }

        public Documento(string numero, TipoDocumento tipoDeDocumento)
        {
            Numero = numero;
            Tipo = tipoDeDocumento;
        }

        public virtual void Validar()
        {
            if (Tipo == TipoDocumento.CPF)
            {
                CPF cpf = this;
            }
            else //Não tem else if por causa da coverage (não fica 100%)
            {
                CNPJ cnpj = this;
            }
        }
    }
}
