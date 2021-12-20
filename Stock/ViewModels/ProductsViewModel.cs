using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Stock.Models
{
    public interface IBaseProduct { 
        int Id { get; set; }
        string Name { get; set; }
        string ProductTitle { get; set; }
        string Type { get; set; }
        string Brand { get; set; }
        int ProductCount { get; set; }
    }

    public class BaseProductViewModel : IBaseProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [DisplayName("Title")]
        public string ProductTitle { get; set; }
        public string Type { get; set; }
        public string Brand { get; set; }

        [DisplayName("No. Products")]
        public int ProductCount { get; set; }
    }

    public class DetailProductViewModel : BaseProductViewModel
    {
        public string Description { get; set; }
        public List<ItemViewModel> Items { get; set; }

    }
}
