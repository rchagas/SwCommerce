using System.ComponentModel.DataAnnotations;      
namespace SwCommerce.Models.ViewModel
{
    public class SaleViewModel
    {   
        public Product product { get; set; }
        public int amount { get; set; }
        public decimal totalWithoutDiscount { get; set; }
        public decimal discount { get; set; }
        public decimal total { get; set; }

        public SaleViewModel(
            int amount,
            Product product
        ){
            this.product = product;
            this.amount = amount;
            this.totalWithoutDiscount = this.amount*this.product.Price;
            this.discount = this.product.Offer.calcDiscount(this.amount, this.product);
            this.total = this.totalWithoutDiscount - this.discount;
        }

    }
}
   