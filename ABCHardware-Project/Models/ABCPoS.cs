using ABCHardware_Project.Models;
using ABCHardware_Project.TechService;

namespace ABCHardware_Project.Models
{
    public class ABCPOS
    {
        public bool AddCustomer(Customer customer)
        {
            TechService.Customer customerManager = new TechService.Customer();
            bool isAddCustomer = customerManager.AddCustomer(customer);
            return isAddCustomer;
        }
    }
}
