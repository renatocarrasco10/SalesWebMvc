using System.Collections.Generic;
using SalesWebMvc.Data;
using SalesWebMvc.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Services.Exceptions;
using System.Threading.Tasks;

namespace SalesWebMvc.Services
{
    public class SellerService
    {
        private readonly SalesWebMvcContext _Context;


        public SellerService(SalesWebMvcContext context)
        {
            _Context = context;
        }

        public async Task<List<Seller>> FindAllAsync()
        {
            return await _Context.Seller.ToListAsync();

        }
        public async Task InsertAsync(Seller obj)
        {
            _Context.Add(obj);
            await _Context.SaveChangesAsync();
        }

        public async Task<Seller> FindByIdAsync(int id)
        {
            return await _Context.Seller.Include(x => x.Department).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            var obj = await _Context.Seller.FindAsync(id);
            _Context.Remove(obj);
            await _Context.SaveChangesAsync();

        }

        public async Task UpdateAsync(Seller obj)
        {
            bool hasAny = await _Context.Seller.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id not found!");
            }
            try
            {
                _Context.Update(obj);
                await _Context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }

        }
    }
}
