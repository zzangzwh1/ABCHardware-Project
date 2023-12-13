using ABCHardware_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Net;


namespace ABCHardware_Project.Pages
{
    public class AdditemModel : PageModel
    {
        public string Message { get; set; } = string.Empty;

        [BindProperty]
        [Required(ErrorMessage = "Please insert ItemCode")]
        [RegularExpression(@"^[A-Z]\d{5}$", ErrorMessage = "First letter must be a capital alphabet, followed by exactly 5 digits (e.g., A12345)")]

        public string _ItemCode { get; set; } = string.Empty;
        [BindProperty]
        [Required(ErrorMessage = "Please insert Description")]
        public string _Description { get; set; } = string.Empty;
        [BindProperty]
        [Required(ErrorMessage = "Please insert Unit Price")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Unit Price must be greater than 0")]
        [RegularExpression(@"^\d*\.?\d*$", ErrorMessage = "Unit Price must be a valid number")]
        public decimal _UnitPrice { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "Please insert Quantity")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0")]
        public int _Quantity { get; set; }

        public void OnGet()
        {
            Message = "Please Insert Item information";
        }
        public void OnPost()
        {
            SaleItem items = new()
            {
                ItemCode = _ItemCode,
                Description = _Description,
                UnitPrice = _UnitPrice, 
                Quantity = _Quantity
            
            };
            ABCPOS ABCHardWARE = new ABCPOS();
            bool isItemAdded = ABCHardWARE.AddItem(items);
            if (ModelState.IsValid && isItemAdded)
            {
                Message = "Item is successfully Added";
                _ItemCode = string.Empty;
                _Description = string.Empty;
                _UnitPrice = 0;
                _Quantity = 0;
              

            }
            else
            {
                Message = "Item Code Is Exists! Please  Try Again!";
            }
        }
    }
}
