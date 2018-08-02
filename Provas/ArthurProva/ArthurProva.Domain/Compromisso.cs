using ArthurProva.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArthurProva.Domain
{
    public class Compromisso : Entidade
    {
        public Compromisso()
        {
            Contatos = new List<Contato>();
        }

        public string Assunto { get; set; }

        public IList<Contato> Contatos { get; set; }

        public string Local { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime DataTermino { get; set; }

        public bool IsDiaInteiro { get; set; } = false;

        public override void Validar()
        {
            if (Assunto.Length > 50 || Local.Length > 50)
                throw new ValidacaoException("O número máximo de caracteres para cada campo é 50");
            if (Contatos.Count <= 0)
                throw new ValidacaoException("Deve conter pelo menos um contato");
            if (!IsDiaInteiro)
            {
                if (DataInicio == null || DataTermino == null)
                    throw new ValidacaoException("O compromisso deve ter uma data de inicio e termino válidas");
                if (DataTermino < DataInicio)
                    throw new ValidacaoException("A data de termino não pode ser antes da data de inicio");
            }
                
        }

        public override string ToString()
        {
            if (IsDiaInteiro)
                return String.Format("Assunto: {0} Local: {1} Data inicio: dia inteiro", Assunto, Local);
            else
                return String.Format("Assunto: {0} Local: {1} Data inicio: {2} Data termino: {3}", Assunto, Local, DataInicio, DataTermino);
        }
    }
}
