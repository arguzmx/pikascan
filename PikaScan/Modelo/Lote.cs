using System;
using System.Collections.Generic;

namespace PikaScan.Modelo
{
    public class Lote
    {
        public Lote() {
            Id = System.Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }

        public EstadoTrabajo EstadoTrabajo { get; set; }

        public TipoTrabajo TipoTrabajo { get; set; }

        public string Nombre { get; set; }

        public string UserId { get; set; }
        public string Path { get; set; }
        public string RemoteId { get; set; }
        public string RemoteState { get; set; }
        public List<Documento> Documentos { get; set; }

    }
}
