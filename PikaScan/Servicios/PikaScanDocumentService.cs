using PikaScan.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PikaScan.Servicios
{
    public class PikaScanDocumentService : IDocumentService
    {
        public Documento Add(Documento t)
        {
            throw new NotImplementedException();
        }

        public void AddPages(string Id, int count)
        {
            throw new NotImplementedException();
        }

        public void Delete(string Id)
        {
            throw new NotImplementedException();
        }

        public void DelPages(string Id, int count)
        {
            throw new NotImplementedException();
        }

        public Documento Get(string Id)
        {
            return new Documento()
            {
                Id = Id,
                Nombre = "Documento de prueba",
                FechaCreacion = DateTime.Now,
                EstadoTrabajo = EstadoTrabajo.Abierto,
                CantidadPaginas = 0,
                FechaModificacion = DateTime.Now,
                IdLote = "",
                Indice = 0,
                Paginas = new List<Pagina>(),
                Path = "",
                RemoteId = "",
                TipoTrabajo = TipoTrabajo.Local,
                UserId = ""
            };
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
