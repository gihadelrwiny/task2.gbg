using System;
using System.Collections.Generic;
using task22.IService;
using task22.Models;
using task22.Service;

namespace task22.Services
{
    public class ReportService :IreportService
    {
        private readonly ProductService ProductService;
       

        public void PrintAll(List<Product> products)
        {
            foreach (var product in products) {
                switch (product.Category)
                {
                    case Category.Clothing:
                        var _clothingService = new ClothingService();
                        _clothingService.GetDetails(product);
                        break;

                    case Category.Food:
                        var _foodService = new FoodSerivece();
                        _foodService.GetDetails(product);
                        break;

                    case Category.Electronics:
                       var _electronicservice= new ElectronicService();
                        _electronicservice.GetDetails(product);
                        break;
                }
            }
        }
    }
}