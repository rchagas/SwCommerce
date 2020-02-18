
namespace SwCommerce.Models.ViewModel{

    public class SalesCartViewModel{
        public int Amount {get; set;}
        public int ProductId {get; set;}
        public SalesCartViewModel(){

        }
        public SalesCartViewModel(int a, int b){
            this.Amount = a;
            this.ProductId = b;
        }
    }
}