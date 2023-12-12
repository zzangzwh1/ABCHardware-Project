using ABCHardware_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ABCHardware_Project.Pages
{
    public class TESTModel : PageModel
    {
        public List<Models.Item> everyItems = null!;

        public List<Models.Customer> CustomerInfo = null!;
        public void OnGet()
        {

            ABCPOS abcManager = new ABCPOS();
            everyItems = abcManager.GetEveryItems();
            GetCustomerInfo();
        }

        public void GetCustomerInfo()
        {
            TechService.Customer customerManager = new TechService.Customer();
            CustomerInfo = customerManager.GetCustomerInformation();

        }


    }
}
