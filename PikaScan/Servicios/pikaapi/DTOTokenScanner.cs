using System;

namespace PikaScan.Servicios.pikaapi
{
    public class DTOTokenScanner
    {
        /// <summary>
        /// Identificador unico del token
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Token de acceso para la digitalizacion.
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Elemento  destino de la digitalizacion.
        /// </summary>
        public string ElementoId { get; set; }

        /// <summary>
        /// Elemento  destino de la digitalizacion.
        /// </summary>
        public string VersionId { get; set; }


        /// <summary>
        /// Fecha de caducidad UTC del token.s
        /// </summary>
        public DateTime Caducidad { get; set; }

        /// <summary>
        /// NOmbr del documento en edicion
        /// </summary>
        public string NombreDocumento { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string VolumenId { get; set; }

        public string PuntoMontajeId { get; set; }

        /// <summary>
        /// Url bas del servivio de digitalización.
        /// </summary>
        public string UrlBase { get; set; }

        /// <summary>
        /// Indica la posición en el documento en la que inicia la carga del contenido
        /// </summary>
        public PosicionCarga Posicion { get; set; }

        /// <summary>
        /// En el caso de carga en una posición de inicio indica en índice de inicio 
        /// </summary>
        public int PosicionInicio { get; set; }

        /// <summary>
        ///     
        /// </summary>
        public int Indice { get; set; } = 1;
    }
}
