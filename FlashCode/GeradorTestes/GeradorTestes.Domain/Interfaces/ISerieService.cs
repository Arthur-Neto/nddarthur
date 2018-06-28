using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorTestes.Domain.Interfaces
{
    public interface ISerieService : IService<Serie>
    {
        void Adicionar(Serie serie);
        void Editar(Serie serie);
    }
}
