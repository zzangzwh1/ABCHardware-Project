using ABCHardware_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace ABCHardware_Project.Pages
{
    public class TESTModel : PageModel
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
        [Required(ErrorMessage = "Please Selectd Customer")]
        public int CustomerIDSelect { get; set; }


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

        public string myDecimal = "";

        [BindProperty]
        public List<string> list { set; get; } = null;

        public void OnGet()
        {


            ABCPOS abcManager = new ABCPOS();
            everyItems = abcManager.GetEveryItems();
            GetCustomerInfo();
            /*
                        HttpContext.Session.SetString("iCode", _ItemCode);
                        HttpContext.Session.SetString("iDescription", _Description);

                        HttpContext.Session.SetString("iUnit", _UnitPrice.ToString());

                        HttpContext.Session.SetString("iQuantity", _Quantity.ToString());
                        string iCode = (string)HttpContext.Session.GetString("iCode")!;
                        string iDescription = (string)HttpContext.Session.GetString("iDescription")!;
                        string iUnit = (string)HttpContext.Session.GetString("iUnit")!;
                        string iQuantity = (string)HttpContext.Session.GetString("iQuantity")!;
                        list.Add(iCode);
                        list.Add(iDescription);
                        list.Add(iUnit);
                        list.Add(iQuantity);*/

        }
        public void OnPost()
        {
            ABCPOS abcManager = new ABCPOS();
                everyItems = abcManager.GetEveryItems();
                GetCustomerInfo();
            

               /* CustomerIDSelect = 0;
                HttpContext.Session.SetString("iCode", _ItemCode);
                HttpContext.Session.SetString("iDescription", _Description);

                HttpContext.Session.SetString("iUnit", _UnitPrice.ToString());

                HttpContext.Session.SetString("iQuantity", _Quantity.ToString());
                string iCode = (string)HttpContext.Session.GetString("iCode")!;
                string iDescription = (string)HttpContext.Session.GetString("iDescription")!;
                string iUnit = (string)HttpContext.Session.GetString("iUnit")!;
                string iQuantity = (string)HttpContext.Session.GetString("iQuantity")!;
                Models.Item tempItem = new()
                {
                    ItemCode = _ItemCode,
                    Description = _Description,
                    UnitPrice = _UnitPrice,
                    Quantity = _Quantity
                };

                list = new List<string>();

                list.Add(iCode);
                list.Add(iDescription);
                list.Add(iUnit);
                list.Add(iQuantity);
*/

            string s = "";
        }

        public void GetCustomerInfo()
        {
            TechService.Customer customerManager = new TechService.Customer();
            CustomerInfo = customerManager.GetCustomerInformation();

        }



    }
}
