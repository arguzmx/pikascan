using PikaScan.Modelo;
using System;

namespace PikaScan.Servicios
{
    public interface  IDocumentService: IBaseRepository<Documento>
    {
        void UpdateDate(string Id,DateTime date);
        void UpdatePageCount(string Id, int count);
        void UpdatePageStatus(string Id, EstadoTrabajo s);

        void AddPages(string Id, int count);

        void DelPages(string Id, int count);


        void RefreshPageCount(string Id);
    }
}
