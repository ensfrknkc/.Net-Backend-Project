using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    //DTO = Data Transformation Object
    //SOLID
    //Open Closed Principle
    //Yaptıgın yazılıma yeni özellik ekliyorsan mevcut kodunda hıc bır yere dokunamazsın solidin in (O) su
    class Program
    {
        static void Main(string[] args)
        {
            //ProductTest();
            ProductDetailTest();
            //CategoryTest();
        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var category in categoryManager.GetAll().Data)
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal(), new CategoryManager(new EfCategoryDal()));
            foreach (var product in productManager.GetByUnitPrice(40, 100).Data)
            {
                Console.WriteLine(product.ProductName);
            }
        }
        private static void ProductDetailTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal(), new CategoryManager(new EfCategoryDal()));

            var result = productManager.GetProductDetails();

            if (result.Succes)//İşlem başarılıysa
            {
                foreach (var product in result.Data)
                {
                    Console.WriteLine(product.ProductName + "/" + product.CategoryName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

            
        }
    }
}
