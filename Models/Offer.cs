using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SwCommerce.Services.Exceptions;

namespace SwCommerce.Models
{
    public class Offer
    {  
        //Aqui será implementada promoções
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage="Field Required")]
        [MaxLength(60,ErrorMessage="Field must be up 60 characters")]
        [MinLength(3,ErrorMessage="Field must have at least 3 characters")]
        public string Name { get; set; }
        /*Valor para ser avaliado como sera avaliado a variável desconto:
            1 - Desconto Bruto a ser subtraido do Valor Total de cada Pacote
            2 - Desconto Percentual a ser subtraido do Valor Total de cada Pacote
            3 - Valor Bruto do pacote e.g: Valor X na compra de 3 unidades
        */
        [Required(ErrorMessage="Field Required")]
        [Range(1,2, ErrorMessage="TypeOffer must be value registered")]
        public int TypeOffer { get; set; }
        //Quantidade minima de compra para adicao do desconto
        //Default: 1
        [Required(ErrorMessage="Field Required")]
        [Range(1,int.MaxValue, ErrorMessage="Price must be greater than zero")]
        public int MinSale { get; set; }
        //Tamanho do pacote para adicao do desconto
        //Default: 1 Desconto dado em cada produto e nao por pacote
        [Required(ErrorMessage="Field Required")]
        [Range(1,int.MaxValue, ErrorMessage="Price must be greater than zero")]
        public int PackSize { get; set; }
        //Valor do Desconto a ser subtraido
        public decimal Discount { get; set; }

        public Offer()
        {
            
        }
        public Offer(
            int Id,
            string Name,
            int TypeOffer,
            int MinSale,
            int PackSize,
            decimal Discount
        )
        {
            this.Id = Id;
            this.Name = Name;
            this.TypeOffer = TypeOffer;
            this.MinSale = MinSale;
            this.PackSize = PackSize;
            this.Discount = Discount;
        }
        /*
            Função decimal calcDiscount(int amount, Product product)
            retorna o valor bruto de desconto a ser subtraido da compra baseado 
            na oferta cadastrada.
            params: int amount: Quantidade do produto na compra.
                    Product product: Produto na compra.
        */
        public decimal calcDiscount(int amount, Product product)
        {
            if(amount >= MinSale)
            {
                if(TypeOffer == 1)
                {
                    return Discount;
                }
                else if(TypeOffer == 2)
                {
                    return (amount/PackSize)*product.Price*Discount;
                }
                else if(TypeOffer == 3)
                {
                    return (amount/PackSize)*(PackSize*product.Price-Discount);
                }
                else throw new OfferErrorException("TypeOffer Inexistente");
            }
            return 0;
        }
    }
}