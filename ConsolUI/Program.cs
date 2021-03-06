using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsolUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductTest();
            // CategoryTest();
            //CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            //foreach(var category in categoryManager.GetAll())
            //{
            //    Console.WriteLine(category.CategoryName);
            //}


        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var item in categoryManager.GetAll())
            {
                Console.WriteLine(item.CategoryName);
            }
        }
        private static void ProductTest()
        {

            ProductManager productManager = new ProductManager(new EfProductDal());

            var result = productManager.GetProductDetails();
            if (result.Success == true)
            {
                foreach (var item in result.Data)
                {
                    Console.WriteLine(item.ProductName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

        }
    }
}
