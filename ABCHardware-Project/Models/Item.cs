using Microsoft.AspNetCore.Mvc;

namespace ABCHardware_Project.Models
{
    public class Item
    {

        public string ItemCode { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }

        public decimal ItemTotal { get; set; }
    }
}
