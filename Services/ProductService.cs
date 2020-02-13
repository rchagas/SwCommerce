using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SwCommerce.Models;

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
    }
}