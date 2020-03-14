using System.Linq;
using SwCommerce.Models;

namespace SwCommerce.Data
{
    public class SeedingService
    {
        private SwCommerceContext _context;

        public SeedingService(SwCommerceContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if(_context.Product.Any() ||
               _context.Offer.Any())
            {
                return;
            }
            Offer[] offers = {
                new Offer(1, "Sem Oferta", TypeOffer.ValorBruto, 1, 1, 0),
                new Offer(2, "Leve 2 Pague 1", TypeOffer.Percentual, 2, 2, 1),
                new Offer(3, "Leve 3 por 10", TypeOffer.ValorBruto, 3, 3, 10),
                new Offer(4, "30% de Desconto", TypeOffer.Percentual, 1, 1, 0.3m),
                new Offer(5, "Cupom 10 reais", TypeOffer.ValorBruto, 1, 1, 10)
            };
            Product[] products = {
                new Product(1,"Chocolate Wafer Bis ao Leite c/20 - Lacta",4.99m,
                "https://images-americanas.b2w.io/produtos/01/00/img/19602/9/19602908_1GG.jpg",
                offers[1]),
                new Product(2,"Chocolate Kit Kat ao Leite Nestlé 41,5g",2.99m,
                "https://images-americanas.b2w.io/produtos/01/00/oferta/44414/1/44414154_1GG.jpg",
                offers[1]),
                new Product(3,"Chocolate Bombom Ouro Branco 1kg Lacta",31.99m,
                "https://images-americanas.b2w.io/produtos/01/00/oferta/19583/0/19583072_1GG.jpg",
                offers[0]),
                new Product(4,"Chocolate Bombom Sonho De Valsa 1kg Lacta",31.99m,
                "https://images-americanas.b2w.io/produtos/01/00/item/19583/0/19583030_1GG.jpg",
                offers[0]),
                new Product(5,"Bala de Gelatina Beijos Morango 100g - Fini",4.69m,
                "https://images-americanas.b2w.io/produtos/01/00/item/6889/6/6889657g1.jpg",
                offers[2]),
                new Product(6,"Bala de Gelatina e Marshmallows Dentadura 100g - Fini",4.69m,
                "https://images-americanas.b2w.io/produtos/01/00/item/6889/6/6889655_1GG.jpg",
                offers[2]),
                new Product(7,"Bala de Gelatina Minhocas 100g - Fini",4.69m,
                "https://images-americanas.b2w.io/produtos/01/00/item/6889/6/6889649_1GG.jpg",
                offers[2])
            };

            _context.Offer.AddRange(offers);
            _context.Product.AddRange(products);
            _context.SaveChanges();
        }
    }
}