
namespace SwCommerce.Models.ViewModel{

    public class SaleFormatFrontEndViewModel{
        public int Amount {get; set;}
        public int ProductId {get; set;}
        public SaleFormatFrontEndViewModel(){

        }
        public SaleFormatFrontEndViewModel(int a, int b){
            this.Amount = a;
            this.ProductId = b;
        }
    }
}