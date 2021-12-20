using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Stock.Models
{
    public interface IBaseItem
    {
        string Unit { get; set; }
    }

    public interface IDiscontinued
    {
        DateTime DateOfDiscontinuation { get; set; }
    }

    public interface IDiscontinuedItem : IBaseItem, IDiscontinued { }

    public class ItemViewModel : IDiscontinuedItem
    {
        public string Unit { get; set; }

        //  Possible removal into own Class - but not necessary
        [DisplayName("Date Of:")]
        public DateTime DateOfDiscontinuation { get; set; }

        public ItemViewModel()
        {

        }

    }

    //  TODO: One Possible Way Of Degree Of Separation
    public class DisContinuedItemViewModel : ItemViewModel, IDiscontinuedItem
    {
        //[DisplayName("Date Of:")]
        //public DateTime DateOfDiscontinuation { get; set; }
    }

}
