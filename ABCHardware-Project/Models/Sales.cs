namespace ABCHardware_Project.Models
{
    public class Sales
    {
        public int SaleNumber { get; set; }
        public int CustomerID { get; set; }
        public DateOnly SaleDate { get; set; }
        public string SalePerson { get; set; }
    }
}
