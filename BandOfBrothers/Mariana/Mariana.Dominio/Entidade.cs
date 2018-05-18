namespace Mariana.Dominio
{
    public abstract class Entidade
    {
        public int Id { get; set; }

        public abstract void Validar();

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            Entidade entidade = obj as Entidade;
            if (entidade == null)
                return false;
            else
                return Id.Equals(entidade.Id);
        }
    }
}
