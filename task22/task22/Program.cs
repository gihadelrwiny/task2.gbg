using System.Globalization;
using task22.IServices;
using task22.Models;
using task22.Services;
using System.Globalization;
namespace task22
{
    internal class Program
    {


        static void Main(string[] args)
        {
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en-US");
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Iisvalidorder validator = new IsValidOrder();

            IcalculateShipping shipping = new StandardCalculateShipping();
            IDiscount discount = new PercentageDiscount(0.1m);

            IorderProcess process = new OrderProcess(shipping, discount, validator);

            ISaveOrder saveOrder = new SaveOrder();
            IgenerateInvoid invoice = new GenerateInVoice();
            IconfirmationEmail email = new ConfirmationEmail();

         
            Ihandelorder handler = new HandleOrder(process, saveOrder, email, invoice);


            Order order1 = new Order
            {
                Id = 1,
                CustomerEmail = "valid@gmail.com",
                TotalAmount = 1000,
                ShippingType = ShopingType.Standard
            };

            Order order2 = new Order
            {
                Id = 2,
                CustomerEmail = "invalid-email",
                TotalAmount = 1000,
                ShippingType = ShopingType.Standard
            };

            Order order3 = new Order
            {
                Id = 3,
                CustomerEmail = "test@gmail.com",
                TotalAmount = -50,
                ShippingType = ShopingType.Express
            };

            Order order4 = new Order
            {
                Id = 4,
                CustomerEmail = "",
                TotalAmount = 0,
                ShippingType = ShopingType.Standard
            };

           
            handler.handleorder(order1);
            handler.handleorder(order2);
            handler.handleorder(order3);
            handler.handleorder(order4);

        }
    
    }
}
