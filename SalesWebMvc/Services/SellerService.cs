﻿using System.Collections.Generic;
using SalesWebMvc.Data;
using SalesWebMvc.Models;
using System.Linq;

namespace SalesWebMvc.Services
{
    public class SellerService
    {
        private readonly SalesWebMvcContext _Context;

        public SellerService(SalesWebMvcContext context)
        {
            _Context = context;
        }

        public List<Seller> FindAll()
        {
            return _Context.Seller.ToList();

        }
        public void Insert(Seller obj)
        {
            _Context.Add(obj);
            _Context.SaveChanges();
            _Context.SaveChanges();
        }
    }
}