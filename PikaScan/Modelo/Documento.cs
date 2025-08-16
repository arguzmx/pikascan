using System;
using System.Collections.Generic;

namespace PikaScan.Modelo
{

    public enum TipoTrabajo {
        Local, Red
    }


    public enum EstadoTrabajo {
        Abierto, Cerrado
    }

        public class Documento
    {
        public Documento() {
            Id = System.Guid.NewGuid().ToString();
          // Paginas = new List<Pagina>();
        }

        public string Id { get; set; }

        public string IdLote { get; set; }

        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }

        public EstadoTrabajo EstadoTrabajo { get; set; }

        public TipoTrabajo TipoTrabajo { get; set; }

        public string Nombre { get; set; }

        public int Indice { get; set; }
        public int CantidadPaginas { get; set; }

        public string UserId { get; set; }

        public string Path { get; set; }

        public string RemoteId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public List<Pagina> Paginas { get; set; }
    }
}
