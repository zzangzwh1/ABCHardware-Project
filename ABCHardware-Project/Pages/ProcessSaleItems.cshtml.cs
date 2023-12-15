using ABCHardware_Project.Models;
using ABCHardware_Project.TechService;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;



namespace ABCHardware_Project.Pages
{
    public class ProcessSaleModel : PageModel
    {

        public List<Models.Customer> CustomerInfo = null!;
        public string Message { get; set; } = string.Empty;
  

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
  
        public int ResultSaleNumber { get; set; }
        [BindProperty]
        public int SelectValue { set; get; }

        public Models.Sale ABCSALE { get; set; } = new Models.Sale();  

        [BindProperty]
        public List<Sale> ABCSale { get; set; } = new List<Sale>();        

        public void OnGet()
        {

            DisplayItems();


        }
        public void OnPost()
        {
            DisplayItems();
            int SaleNumber = 0;
            int saleNumber = GenerateNineDigitRandomNum();


            foreach (var AbcSale in ABCSale)
            {
                ABCPOS ABCHardWare = new ABCPOS(); 
                AbcSale.SaleNumber = saleNumber;
                AbcSale.SaleDate = DateTime.Now;
                SaleNumber = ABCHardWare.ProcessSale(AbcSale);


            }
            if (SaleNumber != 0 || ModelState.IsValid)
            {
               
                Message = "Item is SuccessFully Processed ";
            }
            else
            {
                Message = "Fail";
            }
           
        }
        public void DisplayItems()
        {
            ABCPOS abcManager = new ABCPOS();
            everyItems = abcManager.GetEveryItems();
            GetCustomerInfo();
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
