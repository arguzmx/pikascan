using PikaScan.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PikaScan.Servicios.pikaapi
{
    public class UploadApi
    {

        public async Task EnviarPaginas(List<PaginaPika> paginas, string token)
        {
            // Generar un nuvo GUID string a utilizar como TransactionId
            // llamar a UploadController 
            // [HttpPost("scanner/pagina")] 
            // Con cada una de las páginas convetidas a  ElementoCargaContenido
            // Y al finalizzar llamra [HttpPost("scanner/completar/{TransaccionId}")]

        }

    }
}
