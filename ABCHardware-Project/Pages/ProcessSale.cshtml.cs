using ABCHardware_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace ABCHardware_Project.Pages
{
    public class ProcessSaleModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "Please insert Sales FullName")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Only alphabet characters and spaces are valid, e.g., Mike Cho")]
        public string _SalePerson { get; set; } = string.Empty;

        public List<Models.Customer> CustomerInfo = null!;
        public string Message { get; set; } = string.Empty;
        [BindProperty]
        [Required(ErrorMessage = "Please insert Customer Last name")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Only Alphabet is Valid ex) Cho/cho")]
        public string FindLastName { get; set; } = string.Empty;
        [BindProperty]
        public int TestTest { get; set; }
      

        public List<Models.Customer> customers = null!;


        public void OnGet()
        {
            Message = "Please Insert Sale person Name and Select Customer Info";
           // GetCustomerInfo();
            //CustomerInfo =
        }
        public void OnPostFindCustomer()
        {
            ABCPOS abcHardwareCustomer = new ABCPOS();
            customers = abcHardwareCustomer.FindCustomerWtihfirstOrLastName(FindLastName);
            DateOnly currentDate = new DateOnly();

          
            Sales sales = new()
            {
                SalePerson = _SalePerson,
                SaleDate = currentDate,



            };
          foreach(var val in customers)
          /*  int customerId = 0;
            foreach(var customer in customers)
            {
                customerId = customer.CustomerID;
            }*/
            if (customers.Count == 0)
            {
                Message = "Customer is not Exists!";
                customers = null!;
            }
            else
            {

                Message = "Customer Select for Updating Customer Information";
            }
         
        }
        public void OnPostGetItems()
        {

            int d = TestTest;
            string h = _SalePerson;
            string s = "";

        }
        /*    public void GetCustomerInfo()
            {
                TechService.Customer customer = new TechService.Customer();
                // string query = @"select ProgramCode from Program ";
                CustomerInfo = customer.GetCustomerInformation();
            }*/
    }
}
