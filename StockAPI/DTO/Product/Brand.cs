using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockAPI.DTO.Product
{
    public class BasicBrandDTO
    {
        public string Name { get; set; }
        public BasicBrandDTO(string name)
        {
            Name = name;
        }
    }

}
