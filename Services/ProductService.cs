using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SwCommerce.Models;
using SwCommerce.Services.Exceptions;

namespace SwCommerce.Services
{
    public class ProductService
    {
        public readonly SwCommerceContext _context;

        public ProductService(SwCommerceContext context)
        {
            this._context = context;
        }
        public async Task AddAsync (Product product)
        {   
            if(product == null)
                throw new ArgumentNullException("product");
            _context.Product.Add(product);
            await _context.SaveChangesAsync();
        }
        public async Task<List<Product>> FindAllAsync()
        {
            return await _context.Product.ToListAsync();
        }
        public async Task<Product> FindByIdAsync(int id) 
        {
            return await _context.Product.FirstOrDefaultAsync(obj => obj.Id == id);
        }
        public async Task UpdateAsync(Product product)
        {
            bool hasAny = await _context.Product.AnyAsync(x=> x.Id == product.Id);
            if(!hasAny)
            {
                throw new NotFoundException("Id not Found");
            }
            try
            {
                _context.Update(product);
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
        public async Task DeleteAsync(int id)
        {
            var obj = await _context.Product.FindAsync(id);
            _context.Remove(obj);
            await _context.SaveChangesAsync();
        }
    }
}