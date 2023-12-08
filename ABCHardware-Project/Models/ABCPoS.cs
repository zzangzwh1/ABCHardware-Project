using ABCHardware_Project.Models;
using ABCHardware_Project.TechService;
using System.Reflection.Metadata.Ecma335;

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

        public List<Customer> FindCustomerWtihfirstOrLastName(string firstOrLastName)
        {
            TechService.Customer customer = new TechService.Customer();
            List<Customer> customers = customer.FindCustomerWtihName(firstOrLastName);


            return customers;
        }
        public bool UpdateCustomer(Models.Customer customers)
        {
            TechService.Customer customer = new TechService.Customer();
            bool isSuccess = customer.UpdateCustomers(customers);


            return isSuccess;
        }
    }
}
