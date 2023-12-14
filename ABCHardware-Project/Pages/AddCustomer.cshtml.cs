using ABCHardware_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace ABCHardware_Project.Pages
{
    public class AddCustomerModel : PageModel
    {
        public string Message { get; set; } = string.Empty;

        [BindProperty]
        [Required(ErrorMessage = "Please insert Customer First name")]

        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Only Alphabet is Valid ex) mike/Mike")]
        public string FirstName { get; set; } = string.Empty;
        [BindProperty]
        [Required(ErrorMessage = "Please insert Customer Last name")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Only Alphabet is Valid ex) Cho/cho")]
        public string LastName { get; set; } = string.Empty;
        [BindProperty]
        [Required(ErrorMessage = "Please insert Customer Address")]
        public string Address { get; set; } = string.Empty;
        [BindProperty]
        [Required(ErrorMessage = "Please insert Customer City")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Only Alphabet is Valid ex) Edmonton/edmonton")]
        public string City { get; set; } = string.Empty;
        [BindProperty]
        [Required(ErrorMessage = "Please insert Customer Province")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Only Alphabet is Valid ex) Alberta/AB")]
        public string Province { get; set; } = string.Empty;
        [BindProperty]
        [Required(ErrorMessage = "Please insert Customer Postal Code")]
        [RegularExpression(@"[A-Z][0-9][A-Z] [0-9][A-Z][0-9]", ErrorMessage = "Invalid PostalCode format ex)T6G 0Z4")]
        public string PostalCode { get; set; } = string.Empty;
        public void OnGet()
        {
            Message = "Please Insert Customer Information ";
        }
        public void OnPost()
        {
            Customer Customer = new()
            {
                FirstName = FirstName,
                LastName = LastName,
                Address = Address,
                City = City,
                Province = Province,
                PostalCode = PostalCode,
            };
            ABCPOS ABCHardWARE = new ABCPOS();
            bool isCustomerAdd = ABCHardWARE.AddCustomer(Customer);
            if (ModelState.IsValid && isCustomerAdd)
            {
                Message = "Customer is successfully Added";
                FirstName = string.Empty;
                LastName = string.Empty;
                Address = string.Empty;
                City = string.Empty;
                Province = string.Empty;
                PostalCode = string.Empty;  

            }
            else
            {
                Message = "Failed Try Again!";
            }
        }
    }
}
