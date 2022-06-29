using DemoLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    public class Class1
    {
        public delegate void MensionDiscount(decimal productTotal);
        public static ShoppingCartModel cartModel = new ShoppingCartModel();
        public static decimal ProductTotal { get; set; }
        public static void LoadShoppingCartData()
        {
            cartModel.productModels.Add(new ProductModel() { ItemName = "Cotton Sofa", Price = 3.54M });
            cartModel.productModels.Add(new ProductModel() { ItemName = "Cereal", Price = 5.34M });
            cartModel.productModels.Add(new ProductModel() { ItemName = "Banana", Price = 1.24M });
            cartModel.productModels.Add(new ProductModel() { ItemName = "Milk", Price = 7.94M });

            ProductTotal = GenerateTotal(SubTotalAlert);
        }

        public static decimal GenerateTotal(MensionDiscount mensionDiscount)
        {
            var productTotal = cartModel.productModels.Sum(e => e.Price);
            mensionDiscount(productTotal);
            if (productTotal > 100)
                return productTotal * 0.80M;
            else if (productTotal > 50)
                return productTotal * 0.85M;
            else if (productTotal > 10)
                return productTotal * 0.90M;
            else
                return productTotal;
        }

        private static void SubTotalAlert(decimal subTotal)
        {
            Console.WriteLine($"The Sub total is ${subTotal}");
        }
    }
}
