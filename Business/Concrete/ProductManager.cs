using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
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

       
        public IResult Add(Product product)
        {
              
           //Validation
           //bussiness codes
            //business codes buraya yazılır.

            if(product.ProductName.Length<2)
            {
                return new ErrorResult(Messages.ProductNameInValid);
            }
            _productDal.Add(product);

            return new SuccessResult( Messages.ProductAdded);
        }

        //İNECTİON YAPIYORUZ.//SOYUT NESEN İLE BAĞLANTI KURUACAĞIZ.

        public IDataResult<List<Product>> GetAll()
        {
            if(DateTime.Now.Hour==22)
            {
                return new ErroDataResult<List<Product>>(Messages.MaintenaceTime);
            }
            //iş kodları buraya artık yazacağız.
            //yetkisi var mı?
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(),Messages.ProductListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int Id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == Id));
        }

        public IDataResult<Product> GetById(int ProductId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == ProductId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult< List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }
    }
}
