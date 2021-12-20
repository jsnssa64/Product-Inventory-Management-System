using Stock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.ApplicationModel
{
    public interface IProductAppModel
    {
        string FormatUnits(int? ItemsPerUnit, decimal WeightPerUnit, string UnitName);
    }
    public class ProductAppModel : IProductAppModel
    {

        public string FormatUnits(int? ItemsPerUnit, decimal WeightPerUnit, string UnitName)
        {
            StringBuilder sb = new StringBuilder();
            //  " 6 x 400g"
            //  " 6 x 4.5g"
            //  " 450g"
            if(ItemsPerUnit != null)
            {
                sb.Append(ItemsPerUnit + " X ");
            }

            var wnum = Math.Truncate(WeightPerUnit);
            var @decimal = WeightPerUnit - wnum;

            if (@decimal.Equals(0))
                sb.Append(wnum);
            else
                sb.Append(WeightPerUnit);
            sb.Append(UnitName);

            return sb.ToString();
            
        }
    }
}
