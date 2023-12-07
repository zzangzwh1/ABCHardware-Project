using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace ABCHardware_Project.Pages
{
    public class UpdateCustomerModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "Please insert FirstName or LastName  Before Update User Information!")]
        public string FindLastName { get; set; } = string.Empty;

        public string Message { get; set; } = string.Empty;
        public void OnGet()
        {
            Message = "Please insert FirstName or LastName  before find customer";
        }
        public void OnFindCustomer()
        {
            

        }
    }
}
