using ABCHardware_Project.Models;
using ABCHardware_Project.TechService;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
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
        [Required(ErrorMessage = "Please Selected Customer")]
        public int CustomerIDSelect { get; set; }


        public List<Models.SaleItem> everyItems = null!;

        public List<Models.SaleItem> TempItems = null!;


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
       /* public int SaleNumber { get; set; }
*/
        public int ResultSaleNumber { get; set; }
        [BindProperty]
        public int SelectValue { set; get; }

        public Models.Sale sale { get; set; } = null!;
        [BindProperty]
        public List<string> list { set; get; } = null;

        public void OnGet()
        {

            ABCPOS abcManager = new ABCPOS();
            everyItems = abcManager.GetEveryItems();
            GetCustomerInfo();


        }
        public void OnPost()
        {
            ABCPOS abcManager = new ABCPOS();
            everyItems = abcManager.GetEveryItems();
            GetCustomerInfo();


            SaleItem item = new()
            {
                ItemCode = _ItemCode,
                Quantity = _Quantity,
                Description = _Description,
                UnitPrice = _UnitPrice
            
            };

            ABCPOS ABCHardware = new ABCPOS();
            Sale ABCSALE = new Sale()
            {
                CustomerID = SelectValue,
                SaleDate = DateTime.Now,
                SaleNumber = GenerateNineDigitRandomNum(),
                SalePerson = "Jenny Brooks",
                SaleItem = item
          


            };


            int customerIDD = ABCSALE.CustomerID;
            DateTime SaleDa = ABCSALE.SaleDate;
            int SaleNum = ABCSALE.SaleNumber;
            string SalePerson = ABCSALE.SalePerson;
            string itemCode = ABCSALE.SaleItem.ItemCode;





        }

        public int GenerateNineDigitRandomNum()
        {
            Random random = new Random();
            int randomNumber = random.Next(100000000, 999999999);
            return randomNumber;

        }


        public void GetCustomerInfo()
        {
            TechService.Customer customerManager = new TechService.Customer();
            CustomerInfo = customerManager.GetCustomerInformation();

        }


    }
}
