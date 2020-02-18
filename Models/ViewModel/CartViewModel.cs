using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;      
namespace SwCommerce.Models.ViewModel
{
    public class CartViewModel
    {   
        public ICollection<SaleViewModel> Products { get; set; } = new List<SaleViewModel>();
        public decimal TotalWithoutDiscount { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
        public CartViewModel()
        {
            this.Discount = 0;
            this.TotalWithoutDiscount = 0;
            this.Total = 0;
        }
        public void CartAddProduct(SaleViewModel product){
            this.Products.Add(product);
            this.TotalWithoutDiscount += product.totalWithoutDiscount;
            this.Discount += product.discount;
            this.Total += product.total;
        }
        public void CartDelProduct(SaleViewModel product){
            this.Products.Remove(product);
            this.TotalWithoutDiscount -= product.totalWithoutDiscount;
            this.Discount -= product.discount;
            this.Total -= product.total;
        }
    }
}