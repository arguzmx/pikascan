using PikaScan.Modelo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PikaScan.Servicios.Repositorio
{
    public class LotesService: ILotesService
    {
        internal DbSet<Lote> dbSet;
        private readonly DatabaseContext cx;
        public LotesService(DatabaseContext cx)
        {
            this.cx = cx;
            this.dbSet = cx.Set<Lote>();
        }

        public Lote Add(Lote t)
        {
            cx.Lotes.Add(t);
            cx.SaveChanges();
            return t;
        }

        public void Delete(string Id)
        {
            Lote d = cx.Lotes.Find(Id);
            if (d != null)
            {

                try
                {
                    Directory.Delete(d.Path, true);
                }
                catch (Exception ex){}

                ///La eliminación de los Lotes esta como un trigger de cascada
                cx.Lotes.Remove(d);
                cx.SaveChanges();


            }
            else
            {
                throw new EntityNotFound();
            }
        }

        public IEnumerable<Lote> Get(Expression<Func<Lote, bool>> filter = null,
    Func<IQueryable<Lote>, IOrderedQueryable<Lote>> orderBy = null,
    string includeProperties = "")
        {
            IQueryable<Lote> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }

        }


        public void Update(Lote t, string Id)
        {
            Lote d = cx.Lotes.Find(Id);
            if (d != null)
            {
                d.Nombre = t.Nombre;
                d.EstadoTrabajo = t.EstadoTrabajo;
                cx.SaveChanges();
            }
            else
            {
                throw new EntityNotFound();
            }
        }


        public void UpdateDate(string Id, DateTime date)
        {
            Lote d = cx.Lotes.Find(Id);
            if (d != null)
            {
                d.FechaModificacion = date;
                cx.SaveChanges();
            }
            else
            {
                throw new EntityNotFound();
            }
        }


        public void UpdateStatus(string Id, EstadoTrabajo s)
        {
            Lote d = cx.Lotes.Find(Id);
            if (d != null)
            {
                d.EstadoTrabajo = s;
                cx.SaveChanges();
            }
            else
            {
                throw new EntityNotFound();
            }
        }

        public Lote Get(string Id)
        {

            return cx.Lotes.Where(x => x.Id == Id).SingleOrDefault();
        }

        public PagedResults<Lote> GetPage(int PageIndex, int PageSize, bool ReCount, Expression<Func<Lote, bool>> filter = null, Func<IQueryable<Lote>, IOrderedQueryable<Lote>> orderBy = null, string includeProperties = "")
        {
            //PagedResults<Lote> p = new Repository.PagedResults<Lote>(PageIndex, PageSize);
            //int skip = PageIndex * PageSize;

            //if (ReCount)
            //{
            //    p.TotalItems = cx.Lotes.Count();
            //}

            //IQueryable<Lote> query = dbSet;

            //if (filter != null)
            //{
            //    query = query.Where(filter);
            //}

            //p.FilteredItems = query.Count();

            //foreach (var includeProperty in includeProperties.Split
            //    (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            //{
            //    query = query.Include(includeProperty);
            //}

            //if (orderBy != null)
            //{
            //    p.Results = orderBy(query).Skip(skip).Take(PageSize).ToList();
            //}
            //else
            //{
            //    p.Results = query.Skip(skip).Take(PageSize).ToList();
            //}


            //Debug.Print($"{PageIndex} {PageSize} {p.Results.Count()} ++++++");

            //return p;
            return null;
        }

        public PagedResults<Lote> GetPage(int PageIndex, int PageSize, bool ReCount, Query Query, Func<IQueryable<Lote>, IOrderedQueryable<Lote>> orderBy = null, string includeProperties = "")
        {
            throw new NotImplementedException();
        }
    }
}
