using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;//BİR İŞ SINIFI BAŞAK BİR İŞ SINIFINA NEW YAPILMAZ O YÜZDEN BÖYLE 

        public ProductManager(IProductDal productDal)
            //BURASI ÖNEMLİDİR.
        {
            _productDal = productDal;
        }

        //İNECTİON YAPIYORUZ.//SOYUT NESEN İLE BAĞLANTI KURUACAĞIZ.

        public List<Product> GetAll()
        {
            //iş kodları buraya artık yazacağız.
            //yetkisi var mı?
            return _productDal.GetAll();
        }

        public List<Product> GetAllByCategoryId(int Id)
        {
            return _productDal.GetAll(p => p.CategoryId == Id);
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max);
        }
    }
}
