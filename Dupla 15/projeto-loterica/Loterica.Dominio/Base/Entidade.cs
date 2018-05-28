namespace Loterica.Dominio.Base
{
    public abstract class Entidade
    {
        public long Id { get; set; }

        public abstract void Validar();
    }
}
