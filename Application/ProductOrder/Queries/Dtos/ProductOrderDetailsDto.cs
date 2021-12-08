using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ProductOrder.Queries.Dtos
{
    public class ProductOrder
    {
        public Guid Id { get; set; }
        public string Name;
        public int CurrentCount;
        public int Version;

        public ProductOrder(Guid id, string name, int currentCount, int version)
        {
            Id = id;
            Name = name;
            CurrentCount = currentCount;
            Version = version;
        }
    }
}
