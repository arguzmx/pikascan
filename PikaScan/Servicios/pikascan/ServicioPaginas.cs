using PikaScan.Modelo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;

namespace PikaScan.Servicios.pikascan
{
    public class ServicioPaginas : IPageService
    {
        private string docId;
        public ServicioPaginas(string docId)
        {
            this.docId = docId;
        }

        public void SaveChanges()
        {
            var file = Path.Combine(Form1.documento.Path, $"doc.json");
            if (!Directory.Exists(Form1.documento.Path))
            {
                Directory.CreateDirectory(Form1.documento.Path);
            }

            else
            {
                if (File.Exists(file))
                {
                    try
                    {
                        File.Delete(file);
                    }
                    catch { }
                }
            }

            File.AppendAllText(file, Newtonsoft.Json.JsonConvert.SerializeObject(Form1.documento));
        }

        public Pagina Add(Pagina t)
        {
            t.Name = t.GetNameFromIndex();
            t.DocId = docId;
            t.Index = Form1.documento.Paginas.Count ==0 ? 1: Form1.documento.Paginas.Max(p => p.Index) + 1;
            Form1.documento.Paginas.Add(t);

            SaveChanges();
            return t;
        }

        public void AddAtIndex(List<Pagina> paginas, string DocId, int Index)
        {
            throw new NotImplementedException();
        }

        public void Delete(string DocId, List<int> idx)
        {
            var eliminar = Form1.documento.Paginas.Where(p => p.DocId == DocId && idx.Contains(p.Index)).ToList();
            if(eliminar.Any())
            {
                foreach (var p in eliminar)
                {
                    Form1.documento.Paginas.Remove(p);
                }
            }
            SaveChanges();
        }

        public void Delete(string DocId, List<string> names)
        {
            throw new NotImplementedException();
        }

        public void Delete(string DocId, int idx)
        {
            throw new NotImplementedException();
        }

        public void Delete(string Id)
        {
            throw new NotImplementedException();
        }

        public Pagina Get(string DocId, int idx)
        {
            throw new NotImplementedException();
        }

        public Pagina Get(string Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pagina> Get(Expression<Func<Pagina, bool>> filter = null, Func<IQueryable<Pagina>, IOrderedQueryable<Pagina>> orderBy = null, string includeProperties = "")
        {
            throw new NotImplementedException();
        }

        public int GetNextPageIndex(string DocId)
        {
            return Form1.documento.Paginas.Count == 0 ? 1 : Form1.documento.Paginas.Max(p => p.Index) + 1;
        }

        public PagedResults<Pagina> GetPage(int PageIndex, int PageSize, bool ReCount, Expression<Func<Pagina, bool>> filter = null, Func<IQueryable<Pagina>, IOrderedQueryable<Pagina>> orderBy = null, string includeProperties = "")
        {
            throw new NotImplementedException();
        }

        public PagedResults<Pagina> GetPage(int PageIndex, int PageSize, bool ReCount, Query Query, Func<IQueryable<Pagina>, IOrderedQueryable<Pagina>> orderBy = null, string includeProperties = "")
        {
            throw new NotImplementedException();
        }

        public void Update(Pagina t, string Id)
        {
            var pag = Form1.documento.Paginas.FirstOrDefault(p => p.Index == t.Index);
            if (pag != null)
            {
                pag.Name = t.GetNameFromIndex();
                pag = t;
            }
        }
    }
}
