﻿using ABCHardware_Project.Models;
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

        public List<Customer> FindCustomerWtihfirstOrLastName(string firstOrLastName)
        {
            TechService.Customer customer = new TechService.Customer();
            List<Customer> customers = customer.FindCustomerWtihName(firstOrLastName);


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
        public bool AddItem(Item item)
        {
            TechService.Item itemManager = new TechService.Item();
            bool isSuccess = itemManager.AddItem(item);
            return isSuccess;
        }
        public Models.Item FindItemInformation(string itemCode)
        {
            TechService.Item itemManager = new TechService.Item();
            Models.Item customerInformation = itemManager.GetItemInformation(itemCode);
            return customerInformation;
        }
        public bool UpateItem(Item item)
        {
            TechService.Item itemManager = new TechService.Item();
            bool isSuccess = itemManager.UpdateItems(item);


            return isSuccess;
        }
    }
}

