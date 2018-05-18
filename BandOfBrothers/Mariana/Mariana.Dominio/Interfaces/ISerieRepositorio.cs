using System.Collections.Generic;

namespace Mariana.Dominio.Interfaces
{
    public interface ISerieRepositorio : IRepositorio<Serie>
    {
        IList<Serie> ConsultarPorNumero(int numero);

        IList<Serie> ConsultarPorNumeroEId(int numero, int id);
    }
}
