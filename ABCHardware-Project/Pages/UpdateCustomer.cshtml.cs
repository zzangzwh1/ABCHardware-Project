using ABCHardware_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using ABCHardware_Project.TechService;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace ABCHardware_Project.Pages
{
    public class UpdateCustomerModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "Please insert FirstName or LastName  Before Update User Information!")]
        public string FindLastName { get; set; } = string.Empty;

        public List<Models.Customer> customers = null!;

        public string Message { get; set; } = string.Empty;

        [BindProperty]
        
        public int _CustomerID { set; get; }

        [BindProperty]
        [Required(ErrorMessage = "Please insert your First name")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Only Alphabet is Valid ex) mike/Mike")]
        public string _FirstName { get; set; } = string.Empty;
        [BindProperty]
        [Required(ErrorMessage = "Please insert your Last name")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Only Alphabet is Valid ex) cho/Cho")]
        public string _LastName { get; set; } = string.Empty;
        [BindProperty]
        [Required(ErrorMessage = "Please insert your Address")]
        public string _Address { get; set; } = string.Empty;
        [BindProperty]
        [Required(ErrorMessage = "Please insert your City")]
        public string _City { get; set; } = string.Empty;
        [BindProperty]
        [Required(ErrorMessage = "Please insert your Province")]
        public string _Province { get; set; } = string.Empty;
        [BindProperty]
        [Required(ErrorMessage = "Please insert your Postal Code")]
        [RegularExpression(@"[A-Z][0-9][A-Z] [0-9][A-Z][0-9]", ErrorMessage = "Invalid PostalCode format ex)T6G 0Z4")]
        public string _PostalCode { get; set; } = string.Empty;


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
       public void OnPostUpdate()
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
            ABCPOS abcHardwareCustomer = new ABCPOS();
            bool isUpdateCustomer = abcHardwareCustomer.UpdateCustomer(customer);

            if (ModelState.IsValid || isUpdateCustomer)
            {
                Message = "Successfully Updated";
            }
            else
            {
                Message = "Failed! Try Again!";
            }
        }
    }
}
