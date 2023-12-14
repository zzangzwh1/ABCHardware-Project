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

        public List<Customer> FindCustomerWtihName(string firstOrLastName)
        {
            TechService.Customer customer = new TechService.Customer();
            List<Customer> customers = customer.FindCustomerWtihLastName(firstOrLastName);


            return customers;
        }
        public Models.Customer GetCustomerInfo(int customerID)
        {
            TechService.Customer customer = new TechService.Customer();
            Models.Customer customerInformation = customer.GetCustomerInfo(customerID);
            return customerInformation;
        }
        public bool UpdateCustomer(Models.Customer customers)
        {
            TechService.Customer customer = new TechService.Customer();
            bool isSuccess = customer.UpdateCustomers(customers);


            return isSuccess;
        }
        public bool DeleteCustomer(int customerID)
        {
            TechService.Customer customer = new TechService.Customer();
            bool isSuccess = customer.DeleteCustomers(customerID);


            return isSuccess;
        }
        public bool AddItem(SaleItem item)
        {
            TechService.Item itemManager = new TechService.Item();
            bool isSuccess = itemManager.AddItem(item);
            return isSuccess;
        }
        public Models.SaleItem FindItemInformation(string itemCode)
        {
            TechService.Item itemManager = new TechService.Item();
            Models.SaleItem customerInformation = itemManager.GetItemInformation(itemCode);
            return customerInformation;
        }
        public bool UpdateItem(SaleItem item)
        {
            TechService.Item itemManager = new TechService.Item();
            bool isSuccess = itemManager.UpdateItems(item);


            return isSuccess;
        }
        public bool DeleteItem(string itemCode)
        {
            TechService.Item itemManager = new TechService.Item();
            bool isSuccess = itemManager.DeleteItem(itemCode);


            return isSuccess;
        }
        public List<Models.SaleItem> GetEveryItems()
        {
            TechService.Item itemManager = new TechService.Item();
            List<Models.SaleItem> items = itemManager.GetEveryItem();


            return items;
        }
        public int ProcessSale(Sale ABCSale)
        {
            TechService.Sales SaleManager = new TechService.Sales();
            int saleNum = SaleManager.AddSale(ABCSale);

            return saleNum;
        }
        public bool UpdateItemQuantity(Models.SaleItem item)
        {
            TechService.Item itemManager = new TechService.Item();
            bool isSuccess = itemManager.UpdateQuantityItem(item);


            return isSuccess;
        }
   

    }
}

