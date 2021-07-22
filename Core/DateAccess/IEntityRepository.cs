using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{// dataaccess ve entities classlar kesip alıp buraya taşınmıştır.
 //generic constraint
 //class:referans tip
 //IEntity :IEntity olabilir veya IEntity implement eden bir nesen olabilir.
 //new() : new'lenebilir olmalı.
    public interface IEntityRepository<T> where T : class, IEntity, new()//int yazılamaz class demek referans tip olabilir.
    {
        List<T> GetAll(Expression<Func<T, bool>> Filter = null);//getirlen filtriyoruz.bu bir kategorinin ürünleri listeler örnek
        T Get(Expression<Func<T, bool>> filter);//bu da bir ürünün detaylarını getiriri. Bu tek yukardaki çok getiriri 
        void Add(T entity);//default public olarak kullanıyoruz.
        void Delete(T entity);
        void Update(T entity);

    }
}
