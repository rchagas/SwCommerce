using System.ComponentModel.DataAnnotations;   
   
namespace SwCommerce.Models.ViewModel
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage="Field Required")]
        [MaxLength(100,ErrorMessage="Field must be up 100 characters")]
        [MinLength(3,ErrorMessage="Field must have at least 3 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage="Field Required")]
        [Range(0.01,int.MaxValue, ErrorMessage="Price must be greater than zero")]
        public decimal Price { get; set; }
        public string Image { get; set; }
        public int OfferId { get; set; }
    }
}