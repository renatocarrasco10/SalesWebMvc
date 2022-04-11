﻿using SalesWebMvc.Services;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;

namespace SalesWebMvc.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _SellerService;
      

        public SellersController(SellerService sellerService)
        {
            _SellerService = sellerService;
        } 
        
        public IActionResult Index()
        {
            var list = _SellerService.FindAll();
            return View(list);
        }
        public IActionResult Create()
        { 
            return View();
        } 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        { 
            _SellerService.Insert(seller);
            return RedirectToAction(nameof(Index));
        }
    }
}
