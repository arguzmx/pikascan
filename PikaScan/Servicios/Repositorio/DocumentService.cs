using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Linq.Expressions;
using System.Diagnostics;
using System.IO;
using PikaScan.Modelo;
using System.Data.Entity;

namespace PikaScan.Servicios.Repositorio
{
    public class DocumentService:  IDocumentService
    {
        internal DbSet<Documento> dbSet;
        private readonly DatabaseContext cx;
        public DocumentService(DatabaseContext cx) {
            this.cx = cx;
            this.dbSet = cx.Set<Documento>();
        }

        public Documento Add(Documento t)
        {
            int count = cx.Documentos.Where(x => x.IdLote == t.IdLote).Count();
            t.Indice = count + 1;

            cx.Documentos.Add(t);
            cx.SaveChanges();
            return t;
        }



        public void Delete(string Id)
        {
            Documento d = cx.Documentos.Find(Id);
            if (d != null)
            {
                cx.Documentos.Remove(d);
                cx.SaveChanges();

                if (Directory.Exists(d.Path)) {
                    try
                    {
                        Directory.Delete(d.Path, true);
                    }
                    catch (Exception ex)
                    {

                    }
                }

            }
            else
            {
                throw new EntityNotFound();
            }
        }

        public IEnumerable<Documento> Get(Expression<Func<Documento, bool>> filter = null, 
            Func<IQueryable<Documento>, IOrderedQueryable<Documento>> orderBy = null, 
            string includeProperties = "")
        {
            IQueryable<Documento> query = dbSet;

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

        public void Update(Documento t, string Id)
        {
            Documento d = cx.Documentos.Find(Id);
            if (d != null)
            {
                d.Nombre = t.Nombre;
                //d.CantidadPaginas  = t.CantidadPaginas;
                //d.EstadoTrabajo = t.EstadoTrabajo;
                //d.Indice = t.Indice;
                cx.SaveChanges();
            }
            else
            {
                throw new EntityNotFound();
            }
        }

        public void UpdateDate(string Id, DateTime date)
        {
            Documento d = cx.Documentos.Find(Id);
            if (d != null)
            {
                d.FechaModificacion = date;
                cx.SaveChanges();
            }
            else {
                throw new EntityNotFound();
            }
        }

        public void UpdatePageCount(string Id, int count)
        {
            Documento d = cx.Documentos.Find(Id);
            if (d != null)
            {
               
                d.CantidadPaginas =count;
               
                cx.SaveChanges();
            }
            else
            {
                throw new EntityNotFound();
            }
        }

        public void UpdatePageStatus(string Id, EstadoTrabajo s)
        {
            Documento d = cx.Documentos.Find(Id);
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

        public PagedResults<Documento> GetPage(int PageIndex, int PageSize, bool ReCount, Expression<Func<Documento, bool>> filter = null, Func<IQueryable<Documento>, IOrderedQueryable<Documento>> orderBy = null, string includeProperties = "")
        {
            PagedResults<Documento> p = new PagedResults<Documento>(PageIndex, PageSize) ;
            int skip = PageIndex * PageSize;

            if (ReCount) {
                p.TotalItems = cx.Documentos.Count();
            }

            IQueryable<Documento> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            p.FilteredItems = query.Count();

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                p.Results= orderBy(query).Skip(skip).Take(PageSize).ToList();
            }
            else
            {
                p.Results = query.Skip(skip).Take(PageSize).ToList();
            }


            Debug.Print($"{PageIndex} {PageSize} {p.Results.Count()} ++++++");

            return p;
        }

        public Documento Get(string Id)
        {
            return cx.Documentos.Find(Id);
        }

        public void AddPages(string Id, int count)
        {
            Documento d = cx.Documentos.Find(Id);
            if (d != null) {
                d.CantidadPaginas = d.CantidadPaginas + count;
                cx.SaveChanges();
            }
        }

        public void DelPages(string Id, int count)
        {
            Documento d = cx.Documentos.Find(Id);
            if (d != null)
            {
                d.CantidadPaginas = d.CantidadPaginas - count;
                cx.SaveChanges();
            }
        }

        public void RefreshPageCount(string Id)
        {
            Documento d = cx.Documentos.Find(Id);
            if (d != null)
            {
                d.CantidadPaginas = cx.Paginas.Where(x => x.DocId == Id).Count();
                cx.SaveChanges();
            }
        }

        public PagedResults<Documento> GetPage(int PageIndex, int PageSize, bool ReCount, Query Query, Func<IQueryable<Documento>, IOrderedQueryable<Documento>> orderBy = null, string includeProperties = "")
        {
            throw new NotImplementedException();
        }
    }

}
