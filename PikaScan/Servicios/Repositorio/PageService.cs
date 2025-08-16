using PikaScan.Modelo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Linq.Expressions;

namespace PikaScan.Servicios.Repositorio
{
    public class PageService : IPageService
    {
        internal DbSet<Pagina> dbSet;
        private readonly DatabaseContext cx;
        public PageService(DatabaseContext cx)
        {
            this.cx = cx;
            this.dbSet = cx.Set<Pagina>();
        }

        public Pagina Add(Pagina t)
        {
            cx.Paginas.Add(t);
            cx.SaveChanges();
            return t;
        }


        public void Delete(string Id)
        {
            throw new NotImplementedException();
        }

        public void Delete(string Id, int idx)
        {
            Pagina d = cx.Paginas.Where(x => x.DocId == Id && x.Index == idx).SingleOrDefault();
            if (d != null)
            {
                cx.Paginas.Remove(d);
                cx.SaveChanges();
                ResetNamesByIndex(Id);
            }
            else
            {
                throw new EntityNotFound();
            }
        }

        public Pagina Get(string Id)
        {
            throw new NotImplementedException();
        }

        public Pagina Get(string Id, int idx)
        {
            return  cx.Paginas.Where(x => x.DocId == Id && x.Index == idx).SingleOrDefault();
        }

        public IEnumerable<Pagina> Get(Expression<Func<Pagina, bool>> filter = null, Func<IQueryable<Pagina>, IOrderedQueryable<Pagina>> orderBy = null, string includeProperties = "")
        {
       
                IQueryable<Pagina> query = dbSet;

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

        public int GetNextPageIndex(string DocId)
        {
            try
            {
                int max = cx.Paginas.Where(x=>x.DocId== DocId).Max(x => x.Index);
                return max + 1;
            }
            catch (Exception ex)
            {

                return 1;
            }
            
        }


        private void ResetNamesByIndex(string DocId) {

            Documento d = cx.Documentos.Find(DocId);
            string renExt = ".ren";
            List<Pagina> ps = cx.Paginas.Where(x => x.DocId == DocId).OrderBy(x=>x.Index).ToList();
            

            int idx = 1;

            foreach (Pagina p in ps) {
                string oldname = Path.Combine(d.Path, p.Name);
                p.Index = idx;
                p.Name = p.GetNameFromIndex();

                string NewName = Path.Combine(d.Path, p.Name + renExt);

                if (File.Exists(NewName)) {
                    File.Delete(NewName);
                }

                if (File.Exists(oldname)) {
                    File.Move(oldname, NewName);
                }

                List<string> fs = Directory.GetFiles(d.Path, "*.*").ToList();
                foreach (string f in fs) {
                    if (!f.EndsWith(renExt)) {
                        File.Delete(f);
                    }
                }

                fs = Directory.GetFiles(d.Path, "*" + renExt).ToList();
                foreach (string f in fs)
                {
                    File.Move(f, f.Replace(renExt, ""));
                }

                idx++;
            }

            cx.SaveChanges();

        }

        public PagedResults<Pagina> GetPage(int PageIndex, int PageSize, bool ReCount, Expression<Func<Pagina, bool>> filter = null, Func<IQueryable<Pagina>, IOrderedQueryable<Pagina>> orderBy = null, string includeProperties = "")
        {
            PagedResults<Pagina> p = new PagedResults<Pagina>(PageIndex, PageSize);
            int skip = PageIndex * PageSize;

            if (ReCount)
            {
                p.TotalItems = cx.Lotes.Count();
            }

            IQueryable<Pagina> query = dbSet;

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
                p.Results = orderBy(query).Skip(skip).Take(PageSize).ToList();
            }
            else
            {
                p.Results = query.Skip(skip).Take(PageSize).ToList();
            }


  
            return p;
        }

        public void Update(Pagina t, string Id)
        {
            Pagina d = cx.Paginas.Where(x => x.DocId == t.DocId && x.Index == t.Index).SingleOrDefault();
            if (d != null)
            {
                d.Extension = t.Extension;
                d.Index = t.Index;
                d.Name = t.GetNameFromIndex();
                cx.SaveChanges();
            }
            else
            {
                throw new EntityNotFound();
            }
        }

        public void AddAtIndex(List<Pagina> paginas, string DocId, int Index)
        {
            throw new NotImplementedException();

        }

        public void Delete(string DocId, List<int> idx)
        {
            Documento d = cx.Documentos.Find(DocId);
            foreach (int i in idx) {
                Pagina p = cx.Paginas.Where(x => x.DocId == DocId && x.Index == i).SingleOrDefault();
                if (p != null) {
                    string path = Path.Combine(d.Path, p.GetNameFromIndex());
                    if (File.Exists(path)) {

                        try
                        {
                            File.Delete(path);
                        }
                        catch (Exception ex)
                        {

                            throw;
                        }
                      
                    }
                    cx.Paginas.Remove(p);
                }
            }
            cx.SaveChanges();
        }

        public PagedResults<Pagina> GetPage(int PageIndex, int PageSize, bool ReCount, Query Query, Func<IQueryable<Pagina>, IOrderedQueryable<Pagina>> orderBy = null, string includeProperties = "")
        {
            throw new NotImplementedException();
        }

        public void Delete(string DocId, List<string> names)
        {
            Documento d = cx.Documentos.Find(DocId);
            foreach (string name in names)
            {
                Pagina p = cx.Paginas.Where(x => x.DocId == DocId && x.Name == name).SingleOrDefault();
                if (p != null)
                {
                    string path = Path.Combine(d.Path, p.GetNameFromIndex());
                    if (File.Exists(path))
                    {

                        try
                        {
                            File.Delete(path);
                        }
                        catch (Exception ex)
                        {

                            throw;
                        }

                    }
                    cx.Paginas.Remove(p);
                }
            }
            cx.SaveChanges();
        }
    }
}
