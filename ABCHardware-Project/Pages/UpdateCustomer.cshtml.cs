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
        [Required(ErrorMessage = "Please Insert Customer's  Last name")]
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

        [BindProperty]
        public int aCustomerID { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "Please Update the First name if required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Only Alphabet is Valid ex) mike/Mike")]
        public string aFirstName { get; set; } = string.Empty;
        [BindProperty]
        [Required(ErrorMessage = "Please Update the Last name if required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Only Alphabet is Valid ex) cho/Cho")]
        public string aLastName { get; set; } = string.Empty;
        [BindProperty]
        [Required(ErrorMessage = "Please Update Address if required")]
        public string aAddress { get; set; } = string.Empty;
        [BindProperty]
        [Required(ErrorMessage = "Please Update City if required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Only Alphabet is Valid ex) Edmonton/edmonton")]
        public string aCity { get; set; } = string.Empty;
        [BindProperty]
        [Required(ErrorMessage = "Please Update Province if required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Only Alphabet is Valid ex) Alberta/AB")]
        public string aProvince { get; set; } = string.Empty;
        [BindProperty]
        [Required(ErrorMessage = "Please Update the Postal Code if required")]
        [RegularExpression(@"[A-Z][0-9][A-Z] [0-9][A-Z][0-9]", ErrorMessage = "Invalid PostalCode format ex)T6G 0Z4")]
        public string aPostalCode { get; set; } = string.Empty;


        public void OnGet()
        {
            Message = "Please insert LastName  before find customer";
        }
        public void OnPostFindCustomer()
        {

            ABCPOS abcHardwareCustomer = new ABCPOS();
            customers = abcHardwareCustomer.FindCustomerWtihName(FindLastName);

            if (customers is null )
            {
                Message = "Customer is not Exists! please try again!";
                customers = null!;
                customerInformation = null;
            }
            else
            {
                Message = "Please Select for Updating Customer Information";
            }
        }
        public void OnPostEdit()
        {
            int customerId = _CustomerID;
            ABCPOS abcHardwareCustomer = new ABCPOS();
            customerInformation = abcHardwareCustomer.GetCustomerInfo(customerId);
            if (customerInformation != null)
            {
                customers = null!;
            }


        }
        public void OnPostUpdate()
        {
            Message = "Please Modify information! ";
            Models.Customer updateCustomer = new()
            {
                CustomerID = aCustomerID,
                FirstName = aFirstName,
                LastName = aLastName,
                Address = aAddress,
                City = aCity,
                Province = aProvince,
                PostalCode = aPostalCode

            };

            ABCPOS abcHardwareCustomer = new ABCPOS();

            bool isUpdateCustomer = abcHardwareCustomer.UpdateCustomer(updateCustomer);

            if (isUpdateCustomer ||ModelState.IsValid)
            {
                Message = "Customer information is Successfully Modified!";
                customerInformation = null!;
            }
            else
            {
                Message = "Failed - Modify customer information please Try again!";
            }
        }


}
}
