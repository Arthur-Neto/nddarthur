using NFe.Dominio.Base;
using NFe.Dominio.Exceptions;

namespace NFe.Dominio.Features.Transportadores
{
    public enum Frete
    {
        EMITENTE = 0, DESTINATARIO
    }

    public class Transportador : Contribuinte
    {
        public Frete ResponsabilidadeFrete { get; set; }

        public override void Validar()
        {
            if (string.IsNullOrEmpty(Nome) && string.IsNullOrEmpty(RazaoSocial))
                throw new TransportadorEmptyNomeRazaoException();
            if (string.IsNullOrEmpty(InscricaoEstadual))
                throw new TransportadorEmptyInscricaoEstadualException();
            if (string.IsNullOrEmpty(Cpf.valor) && string.IsNullOrEmpty(Cnpj.valor))
                throw new TransportadorEmptyCpfCnpjException();
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
