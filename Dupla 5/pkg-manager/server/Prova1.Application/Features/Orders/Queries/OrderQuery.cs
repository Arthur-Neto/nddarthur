using System.Diagnostics.CodeAnalysis;

namespace Prova1.Application.Features.Orders.Queries
{
    [ExcludeFromCodeCoverage]
    public class OrderQuery
    {
        public virtual int Size { get; set; }

        public OrderQuery(int _size)
        {
            Size = _size;
        }
    }
}
