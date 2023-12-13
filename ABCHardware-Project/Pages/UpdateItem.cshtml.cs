using ABCHardware_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Net;


namespace ABCHardware_Project.Pages
{
    public class UpdateItemModel : PageModel
    {
        [BindProperty]
        public string Message { get; set; } = string.Empty;


        [BindProperty]
        [Required(ErrorMessage = "Please insert ItemCode")]
        [RegularExpression(@"^[A-Z]\d{5}$", ErrorMessage = "First letter must be a capital alphabet, followed by exactly 5 digits (e.g., A12345)")]
        public string FindItemCode { get; set; } = string.Empty;

        public Models.SaleItem items = null!;

        [BindProperty]
        public string _ItemCode { get; set; } = string.Empty;

        [BindProperty]
        [Required(ErrorMessage = "Please Update Description if Required")]
        public string _Description { get; set; } = string.Empty;
        [BindProperty]
        [Required(ErrorMessage = "Please Update Unit Price if Required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Unit Price must be greater than 0")]
        [RegularExpression(@"^\d*\.?\d*$", ErrorMessage = "Unit Price must be a valid number")]
        public decimal _UnitPrice { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "Please Update Quantity if Required")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0")]
        public int _Quantity { get; set; }
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
        public void OnPostModify()
        {
            Message = "Please Modify information! ";
            Models.SaleItem items = new()
            {
                ItemCode = _ItemCode,
                Description = _Description,
                Quantity = _Quantity,
                UnitPrice = _UnitPrice

            };

            ABCPOS abcHardwareCustomer = new ABCPOS();

            bool isUpdateCustomer = abcHardwareCustomer.UpdateItem(items);

            if (isUpdateCustomer)
            {
                Message = "Item is Successfully Modified!";
               
            }
            else
            {
                Message = "Failed -  please Try again!";
            }
        }

    }
}
