using Ninject.Planning;
using PikaScan.Controles;
using PikaScan.Modelo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PikaScan.Servicios
{
    public class PikaScanDocumentService : IDocumentService
    {
        public Documento Add(Documento t)
        {
            // throw new NotImplementedException();
            return null;
        }

        public void AddPages(string Id, int count)
        {
            // throw new NotImplementedException();
        }

        public void Delete(string Id)
        {
            // throw new NotImplementedException();
        }

        public void DelPages(string Id, int count)
        {
            // throw new NotImplementedException();
        }

        //documento = new Documento()
        //{
        //    CantidadPaginas = 0, Nombre = scanner.NombreDocumento, Id = scanner.ElementoId, Paginas = new List<Pagina>(), 
        //                Path = Path.Combine(Application.StartupPath, "scan", scanner.ElementoId) };
        //            if (!Directory.Exists(documento.Path))
        //            {
        //                Directory.CreateDirectory(documento.Path);
        //            }
        //            this.jobExplorer1.Showdocument(documento);

        public Documento Get(string Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Documento> Get(Expression<Func<Documento, bool>> filter = null, Func<IQueryable<Documento>, IOrderedQueryable<Documento>> orderBy = null, string includeProperties = "")
        {
            throw new NotImplementedException();
        }

        public PagedResults<Documento> GetPage(int PageIndex, int PageSize, bool ReCount, Expression<Func<Documento, bool>> filter = null, Func<IQueryable<Documento>, IOrderedQueryable<Documento>> orderBy = null, string includeProperties = "")
        {
            throw new NotImplementedException();
        }

        public PagedResults<Documento> GetPage(int PageIndex, int PageSize, bool ReCount, Query Query, Func<IQueryable<Documento>, IOrderedQueryable<Documento>> orderBy = null, string includeProperties = "")
        {
            throw new NotImplementedException();
        }

        public void RefreshPageCount(string Id)
        {
            throw new NotImplementedException();
        }

        public void Update(Documento t, string Id)
        {
            throw new NotImplementedException();
        }

        public void UpdateDate(string Id, DateTime date)
        {
            throw new NotImplementedException();
        }

        public void UpdatePageCount(string Id, int count)
        {
            throw new NotImplementedException();
        }

        public void UpdatePageStatus(string Id, EstadoTrabajo s)
        {
            throw new NotImplementedException();
        }
    }
}
