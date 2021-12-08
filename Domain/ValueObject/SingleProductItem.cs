using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValObj
{
    //  Cannot Update because this counts for what we have in our inventory
    //  If the supplier changes the ItemsPerUnit it becomes a whole new product in
    //  itself. ValueObject
    public class SingleProductItem : ValueObject
    {
        public Guid ProductId { get; private set; }
        public decimal WeightPerUnit { get; private set; }
        public int ItemsPerUnit { get; set; }

        public SingleProductItem(Guid productId, decimal weightPerUnit, int itemsPerUnit) {
            ProductId = productId;
            WeightPerUnit = weightPerUnit;
            ItemsPerUnit = itemsPerUnit;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return WeightPerUnit;
            yield return ItemsPerUnit;
        }
    }
}
