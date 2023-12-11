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


        public List<Models.Item> everyItems = null!;

        public List<Models.Item> TempItems = null!;


        [BindProperty]
        public string _ItemCode { set; get; } = "";

        [BindProperty]
        public string _Description { set; get; } = "";
        [BindProperty]
        public decimal _UnitPrice { set; get; } 

        [BindProperty]
        [Required(ErrorMessage = "Please Set Quantity")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be between 1 and the maximum value.")]
        public int _Quantity { set; get; }
     


        public void OnGet()
        {
         
            
            ABCPOS abcManager = new ABCPOS();
            everyItems = abcManager.GetEveryItems();
            GetCustomerInfo();



        }
        public void OnPostPurchaseItem()
        {
            string s = "";
            Models.Item tempItem = new()
            { 
               ItemCode = _ItemCode,
               Description = _Description,
               UnitPrice = _UnitPrice,
               Quantity = _Quantity
            };
            int n = TestTest;
            /* TempItems.Add(tempItem);*/
            TechService.Item itemManager = new TechService.Item();
            bool isAdded = itemManager.AddTempItem(tempItem);
            if (isAdded)
            {
                ABCPOS abcManager = new ABCPOS();
                everyItems = abcManager.GetEveryItems();
                GetCustomerInfo();
            }
            
            //SaleNum Return 
        }
        public void GetCustomerInfo()
        {
            TechService.Customer customerManager= new TechService.Customer();
            CustomerInfo = customerManager.GetCustomerInformation();
         
        }




        /*  
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

     }*/

    }
}
