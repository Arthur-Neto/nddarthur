using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorTestes.Domain.Interfaces
{
    public interface ISerieRepository : IRepository<Serie>
    {
        bool GetByName(Serie serie);
    }
}
