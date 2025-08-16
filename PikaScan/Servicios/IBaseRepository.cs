using PikaScan.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace PikaScan.Servicios
{
    public interface IBaseRepository<T>
    {
        T Add(T t);
        void Update(T t, string Id);
        void Delete(string Id);

        T Get(string Id);

        IEnumerable<T> Get(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "");

        PagedResults<T> GetPage(int PageIndex, int PageSize, bool ReCount, Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        string includeProperties = "");

        PagedResults<T> GetPage(int PageIndex, int PageSize, bool ReCount, Query Query,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "");

    }
}
