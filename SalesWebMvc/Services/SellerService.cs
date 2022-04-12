using System.Collections.Generic;
using SalesWebMvc.Data;
using SalesWebMvc.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Services.Exceptions;

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
        }

        public Seller FindById(int id)
        {
            return _Context.Seller.Include(x => x.Department).FirstOrDefault(x => x.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _Context.Seller.Find(id);
            _Context.Remove(obj);
            _Context.SaveChanges();

        }

        public void Update(Seller obj)
        {
            if (!_Context.Seller.Any(x => x.Id == obj.Id))
            {
                throw new NotFoundException("Id not found!");
            }
            try
            {
                _Context.Update(obj);
                _Context.SaveChanges();
            }
            catch(DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }

        }
    }
}
