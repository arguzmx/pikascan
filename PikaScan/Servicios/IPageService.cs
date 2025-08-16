using PikaScan.Modelo;
using System.Collections.Generic;

namespace PikaScan.Servicios
{
    public interface IPageService : IBaseRepository<Pagina>
    {

        void Delete(string DocId, List<int> idx);

        void Delete(string DocId, List<string> names);
        void Delete(string DocId, int idx);
        int GetNextPageIndex(string DocId);

        void AddAtIndex(List<Pagina> paginas, string DocId, int Index);

        Pagina Get(string DocId, int idx);
    }
}
