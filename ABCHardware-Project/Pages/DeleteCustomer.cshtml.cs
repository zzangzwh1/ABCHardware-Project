using ABCHardware_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace ABCHardware_Project.Pages
{
    public class DeleteCustomerModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "Please insert Last name")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Only Alphabet is Valid ex) Cho/cho")]
        public string FindLastName { get; set; } = string.Empty;

        public List<Models.Customer> customers = null!;

        public string Message { get; set; } = string.Empty;

        [BindProperty]
        public int _CustomerID { set; get; }

        [BindProperty]

        public string _FirstName { get; set; } = string.Empty;

        [BindProperty]

        public string _LastName { get; set; } = string.Empty;

        [BindProperty]
        public string _Address { get; set; } = string.Empty;


        public Models.Customer customerInformation = null!;

 
        public void OnGet()
        {
            Message = "Please insert LastName  before find customer";
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
            else
            {
                Message = "Please Select for Deleting Customer Information";
            }
        }
        public void OnPostDelete()
        {
            int customerId = _CustomerID;
            ABCPOS abcHardwareCustomer = new ABCPOS();
            bool isDeleted = abcHardwareCustomer.DeleteCustomer(customerId);
            if (isDeleted)
            {

                Message = "Customer is Successfully Deleted!";
            }
            else
            {
                Message = "Failed Please Try Again!";
            }
            


        }
  
    }
}
