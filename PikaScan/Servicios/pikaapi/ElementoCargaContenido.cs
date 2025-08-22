﻿using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace PikaScan.Servicios.pikaapi
{

    public enum PosicionCarga
    {
        al_inicio = 0, al_final = 1, en_posicion = 2
    }

    public class ElementoCargaContenido
    {
        public ElementoCargaContenido()
        {
            Indice = 0;
        }


        /// <summary>
        /// contenido enviado en la forma
        /// </summary>
        [NotMapped]
        public IFormFile file { get; set; }

        /// <summary>
        /// Identificador único de la transacción para un grupo de envío
        /// </summary>
        public string TransaccionId { get; set; }


        /// <summary>
        /// Identificador único del volumen destino de la carga
        /// </summary>
        public string VolumenId { get; set; }

        /// <summary>
        /// Identificador único del elemento de contenido 
        /// </summary>
        public string ElementoId { get; set; }

        /// <summary>
        /// Identificador únido del punto de mentoja al que pertenece la solicitud
        /// </summary>
        public string PuntoMontajeId { get; set; }


        /// <summary>
        /// Version de contenido para el elemento en edición
        /// </summary>
        public string VersionId { get; set; }

        /// <summary>
        ///  Indice para ordenar las adiciones en caso de diferencias 
        ///  en la velocidad de trasnferencia
        /// </summary>
        public int Indice { get; set; }

        /// <summary>
        /// Indica la posición en el documento en la que inicia la carga del contenido
        /// </summary>
        public PosicionCarga Posicion { get; set; }

        /// <summary>
        /// En el caso de carga en una posición de inicio indica en índice de inicio 
        /// </summary>
        public int PosicionInicio { get; set; }
    }
}
