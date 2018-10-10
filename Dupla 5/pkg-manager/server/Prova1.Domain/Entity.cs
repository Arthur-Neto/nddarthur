using Prova1.Infra.Validation;

namespace Prova1.Domain
{
    /// <summary>
    /// Todas as classes que representam entidades de negócio, devem herdar de Entity. 
    /// Entity é uma abstração de funcionalidades comuns à entidades de negócio.
    ///
    /// Por exemplo: Id, método de comparação (Equals) e validação (Validate)
    /// 
    /// </summary>
    public abstract class Entity : IValidationEntity
    {
        /// <summary>
        /// Identificador único
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        /// Compara dois objetos com base no id e referencia de memória.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            var other = obj as Entity;

            if (ReferenceEquals(other, null))
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (Id == 0 || other.Id == 0)
                return false;

            return Id == other.Id;
        }

        /// <summary>
        /// Sobrecarga do operado "==" que compara dois objetos. Nesse caso, será comparada a referencia de memória e identificador.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(Entity a, Entity b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        /// <summary>
        ///     Sobrecarga do operado "!=" que compara dois objetos. Nesse caso, será comparada a referencia de memória e identificador.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }

        /// <summary>
        ///     Sobrecarga do método GetHashCode() para retornar o HashCode do Id
        /// </summary>
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        /// <summary>
        /// Valida a entidade com base em suas regras de negócio.
        /// </summary>
        /// <returns></returns>
        public virtual bool Validate()
        {
            return true;
        }
    }
}
