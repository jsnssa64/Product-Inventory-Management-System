using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using SharedKernel;

namespace Domain.ValObj
{

    public class ProductType : ValueObject
    {
        public string Title { get; private set; }
        public string @Type { get; private set; }
        //  Can be developed further at a later date
        public string Brand { get; private set; }
    
        public ProductType(string title, string @type, string brand)
        {
            Title = title;
            @Type = @type;
            Brand = brand;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Title;
            yield return @Type;
            yield return Brand;
        }
    }
}
