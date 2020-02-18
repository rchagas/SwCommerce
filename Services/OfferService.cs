using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SwCommerce.Models;
using SwCommerce.Services.Exceptions;

namespace SwCommerce.Services
{
    public class OfferService
    {
        public readonly SwCommerceContext _context;
        public OfferService(SwCommerceContext context)
        {
            this._context = context;
        }
        public async Task AddAsync(Offer offer)
        {
            if(offer == null)
                throw new ArgumentNullException("offer");
            _context.Offer.Add(offer);
            await _context.SaveChangesAsync();
        }
        public async Task<List<Offer>> FindAllAsync()
        {
            return await _context.Offer.ToListAsync();
        }
        public async Task<Offer> FindByIdAsync(int id)
        {
            return await _context.Offer.FirstOrDefaultAsync(obj => obj.Id == id);
        }
        public async Task UpdateAsync(Offer offer)
        {
            bool hasAny = await _context.Offer.AnyAsync(x=> x.Id == offer.Id);
            if(!hasAny)
            {
                throw new NotFoundException("Id not Found");
            }
            try
            {
                _context.Update(offer);
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
        public async Task DeleteAsync(int id)
        {
            var obj = await _context.Offer.FindAsync(id);
            _context.Remove(obj);
            await _context.SaveChangesAsync();
        }        
    }
}