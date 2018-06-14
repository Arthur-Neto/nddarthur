using NFe.Dominio.Base;
using NFe.Dominio.Exceptions;

namespace NFe.Dominio.Features.Destinatarios
{
    public class Destinatario : Contribuinte
    {

        public override void Validar()
        {
            if (string.IsNullOrWhiteSpace(Nome) && string.IsNullOrWhiteSpace(RazaoSocial))
                throw new DestinatarioEmptyRazaoNomeException();
            if (string.IsNullOrWhiteSpace(InscricaoEstadual))
                throw new DestinatarioEmptyInscricaoEstadualException();
            if (string.IsNullOrEmpty(Cpf.valor) && string.IsNullOrEmpty(Cnpj.valor))
                throw new DestinatarioEmptyCpfCnpjException();
            if (!string.IsNullOrEmpty(Cpf.valor) && string.IsNullOrEmpty(Cnpj.valor))
                if (Cpf.EhValido == false)
                    throw new CpfInvalidoException();
            if (!string.IsNullOrEmpty(Cnpj.valor) && string.IsNullOrEmpty(Cpf.valor))
                if (Cnpj.EhValido == false)
                    throw new CnpjInvalidoException();

            Endereco.Validar();
        }   
    }
}
