using CQRSlite.Domain;
using Domain.ValObj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product : AggregateRoot
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public ProductType ProductType { get; private set; }
        public Product(ProductType productType) {
            ProductType = productType;
        }

        //  Edit Name
        public void ChangeName(string name) { 
            //ApplyChanges()
        }

        public void ChangeDescription(string description)
        {

        }
        //  Change Products Type ()
        //  Add/Remove Item To/From List

    }
}
