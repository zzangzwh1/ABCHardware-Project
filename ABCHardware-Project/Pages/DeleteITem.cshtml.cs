using ABCHardware_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace ABCHardware_Project.Pages
{
    public class DeleteITemModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "Please insert ItemCode")]
        [RegularExpression(@"^[A-Z]\d{5}$", ErrorMessage = "First letter must be a capital alphabet, followed by exactly 5 digits (e.g., A12345)")]
        public string FindItemCode { get; set; } = string.Empty;
        public Models.Item items = null!;

        [BindProperty]
        public string _ItemCode { get; set; } = string.Empty;

        [BindProperty]

        public string _Description { get; set; } = string.Empty;
        [BindProperty]

        public decimal _UnitPrice { get; set; }
        [BindProperty]

        public int _Quantity { get; set; }

        [BindProperty]
        public string Message { get; set; } = "";
        public void OnGet()
        {
            Message = "";
        }
        public void OnPostFindItem()
        {
            string itemCode = FindItemCode;
            ABCPOS abcHardwareCustomer = new ABCPOS();
            items = abcHardwareCustomer.FindItemInformation(itemCode);
            if (items == null)
            {
                Message = "Item is not Exists! Please insert right Item Code!";

            }
            else
            {
                Message = "Modify Item Information";
                if (items.ItemCode == "")
                {
                    items = null!;
                    Message = "Item is not Exists! Please insert right Item Code!";
                }
            }
        }
        public void OnPostDelete()
        {
            Message = "Please Modify information! ";
            string itemCode = _ItemCode;

            ABCPOS abcHardwareCustomer = new ABCPOS();

            bool isUpdateCustomer = abcHardwareCustomer.DeleteItem(itemCode);

            if (isUpdateCustomer || ModelState.IsValid)
            {
                Message = "Item is Successfully Deleted!";

            }
            else
            {
                Message = "Failed -  please Try again!";
            }
        }
    }
}
