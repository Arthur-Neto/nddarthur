using NFe.Dominio.Base;
using NFe.Dominio.Exceptions;
using NFe.Dominio.Features.Enderecos;

namespace NFe.Dominio.Features.Emitentes
{
    public class Emitente : Contribuinte
    {
        public string InscricaoMunicipal { get; set; }

        public override void Validar()
        {
            if (string.IsNullOrEmpty(Nome))
                throw new EmitenteEmptyNomeException();
            if (string.IsNullOrEmpty(RazaoSocial))
                throw new EmitenteEmptyRazaoSocialException();
            if (string.IsNullOrEmpty(InscricaoEstadual))
                throw new EmitenteEmptyInscricaoEstadualException();
            if (string.IsNullOrEmpty(InscricaoMunicipal))
                throw new EmitenteEmptyInscricaoMunicipalException();
            if (string.IsNullOrEmpty(Cpf.valor) && string.IsNullOrEmpty(Cnpj.valor))
                throw new EmitenteEmptyCpfCnpjException();
            if (!string.IsNullOrEmpty(Cnpj.valor) && string.IsNullOrEmpty(Cpf.valor))
                if (Cnpj.EhValido == false)
                    throw new CnpjInvalidoException();

            Endereco.Validar();    
        }
    }
}
