using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductTest();
            //CategoryTest();
            
        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDao());
            foreach (var category in categoryManager.getAll().Data)
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDao(),new CategoryManager(new EfCategoryDao()));

            var result = productManager.GetProductDetails(); // SUCCES FALSE DÖNÜYOR TRUE DÖNMELİ



            if (result.success==true) 
            {
                foreach (var product in result.Data)
                {
                    Console.WriteLine(product.ProductName + " " + product.CategoryName + "    " + result.success);
                }
            }
            else
            {
                Console.WriteLine(result.message);
            }

        }
    }
}
