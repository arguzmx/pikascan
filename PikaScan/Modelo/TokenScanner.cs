using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PikaScan.Modelo
{
    /// <summary>
    /// DEfine un token de acceso para un dispositivo de digitalziacion.
    /// </summary>
    public class TokenScanner
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
    }
}