using PikaScan.Modelo;
using System;

namespace PikaScan.Servicios
{
    public interface ILotesService : IBaseRepository<Lote>
    {
        void UpdateDate(string Id, DateTime date);
        void UpdateStatus(string Id, EstadoTrabajo s);
    }
}
