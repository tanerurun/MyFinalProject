using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()//consturctor
        {
            _products = new List<Product> { 
                        new Product{CategoryId=1,ProductId=1,ProductName="Bardak",UnitPrice=15,UnitsInStock=14},
                        new Product{ProductId=2,CategoryId=1,ProductName="Kamera",UnitPrice=5,UnitsInStock=300},
                        new Product{ProductId=3,CategoryId=2,ProductName="Telefon",UnitPrice=500,UnitsInStock=10},
                        new Product{ProductId=4,CategoryId=2,ProductName="Klavye",UnitsInStock=1500,UnitPrice=4},
                        new Product{ProductId=5,CategoryId=2,ProductName="Fare",UnitPrice=54,UnitsInStock=1}

            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //LINQ -Language Integrated Query //dile gömülü sorgulama
            //Lambda p=> bu işarettir.
            //Product productToDelete=null;
            //foreach(var p in _products)
            //{
            //     if(product.ProductId==p.ProductId)
            //    {
            //        productToDelete = p;
            //    }
            //}
          Product  productToDelete = _products.SingleOrDefault(p=>p.ProductId==product.ProductId);

            _products.Remove(productToDelete);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> Filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
          return  _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public void Update(Product product)
        {
            Product ProductToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            //yukardaki sorgulama linq modelidir.
            ProductToUpdate.ProductName = product.ProductName;
            ProductToUpdate.ProductId = product.CategoryId;
            ProductToUpdate.UnitPrice = product.UnitPrice;
            ProductToUpdate.UnitsInStock = product.UnitsInStock;

        }
    }
}
