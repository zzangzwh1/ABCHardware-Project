namespace ABCHardware_Project.Models
{
    public class Sale
    {
        public int SaleNumber { get; set; }
        public int CustomerID { get; set; }
        public DateTime SaleDate { get; set; }
        public string SalePerson { get; set; }

        public SaleItem SaleItem { get; set; }

    }
}
