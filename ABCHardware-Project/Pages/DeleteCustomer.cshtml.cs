using ABCHardware_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace ABCHardware_Project.Pages
{
    public class DeleteCustomerModel : PageModel
    {
        public List<Models.Customer> customers = null!;
        
        [BindProperty]
        [Required(ErrorMessage = "Please insert FirstName or LastName  Before Update User Information!")]

        public string FindLastName { get; set; } = string.Empty;
        [BindProperty]
        public int _CustomerID { get; set; }
        [BindProperty]
        public string _FirstName { get; set; } = string.Empty;

        [BindProperty]
        public string _LastName { get; set; } = string.Empty;

        [BindProperty]
        public string _Address { get; set; } = string.Empty;

        [BindProperty]
        public string _City { get; set; } = string.Empty;

        [BindProperty]
        public string _Province { get; set; } = string.Empty;

        [BindProperty]
        public string _PostalCode { get; set; } = string.Empty;

        public string Message { get; set; } = string.Empty;


 

        public void OnGet()
        {
            Message = "Please insert FirstName or LastName  before find customer";
        }
        public void OnPostFindCustomer()
        {

            ABCPOS abcHardwareCustomer = new ABCPOS();
            customers = abcHardwareCustomer.FindCustomerWtihfirstOrLastName(FindLastName);

            if (customers.Count == 0)
            {
                Message = "Customer is not Exists!";
                customers = null!;
            }
        }
        public void OnPostDelete()
        {
            Models.Customer customer = new()
            {
                CustomerID = _CustomerID,
                FirstName = _FirstName,
                LastName = _LastName,
                City = _City,
                Province = _Province,
                PostalCode = _PostalCode,
                Address = _Address

            };
            int n = customer.CustomerID;
            ABCPOS abcHardwareCustomer = new ABCPOS();

            bool isDeleteCustomer = abcHardwareCustomer.DeleteCustomer(n);

            if (ModelState.IsValid || isDeleteCustomer)
            {


                Message = "Customer IsSuccessfully Deleted";
            }
            else
            {

                Message = "Fail Please Try Again!";
            }
        }
    }
}
