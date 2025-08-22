using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PikaScan.Servicios.pikaapi
{
    public class DTOTokenScanner
    {
        public string Token { get; set; }

        public string ElementoId { get; set; }

        public string VersionId { get; set; }

        public DateTime Caducidad { get; set; }
        public string VolumenId { get; set; }
        public string PuntoMontajeId { get; set; }
        public int Indice { get; set; } = 1;
    }
}
