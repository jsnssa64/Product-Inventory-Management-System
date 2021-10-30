using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class Shipment
    {
        public int Id { get; set; }
        public ICollection<Shipment_StatusLog> ShipmentLog { get; set; }
        public ICollection<ProductOrder> ProductsOrder { get; set; }
    }

    public class Shipment_StatusLog
    {
        public int Id { get; set; }
        public int ShipmentId { get; set; }
        public int ShipmentStatusId { get; set; }
        public string LoggedDate { get; set; }
        public Shipment Shipment { get; set; }
        public ShipmentStatus ShipmentStatus { get; set; }
    }

    public class ShipmentStatus
    {
        public int Id { get; set; }
        //e.g Ordered, InTransit, Delivered
        public string Status { get; set; }
        public ICollection<Shipment_StatusLog> ShipmentStatusLogs { get; set; }

    }

    public class ProductOrder
    {
        public int Id { get; set; }
        public int ShipmentId { get; set; }
        public int ProductId { get; set; }
        public int Units { get; set; }
        public Shipment Shipment { get; set; }
        public Product Product { get; set; }
    }
}
