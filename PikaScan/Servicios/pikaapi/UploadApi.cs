using Ninject.Activation;
using PikaScan.Modelo;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PikaScan.Servicios.pikaapi
{
    public class UploadApi
    {
        private string _baseURL = "http://localhost:5000/api/v1.0/upload";
        public async Task EnviarPaginas(List<PaginaPika> paginas, DTOTokenScanner dto)
        {
            var httpClient = new HttpClient
            {
                Timeout = Timeout.InfiniteTimeSpan
            };

            string transactionId = Guid.NewGuid().ToString();

            foreach (var pagina in paginas)
            {
                if (!File.Exists(pagina.Ruta))
                    continue;

                MultipartFormDataContent payload = null;
                FileStream stream = null;

                try
                {
                    dto.Indice++;
                    payload = ConvertirAPayload(pagina, dto, transactionId, out stream);

                    using (payload)
                    using (var request = new HttpRequestMessage(HttpMethod.Post, $"{_baseURL}/scanner/pagina"))
                    {
                        request.Content = payload;
                        request.Headers.Add("x-scanner-token", dto.Token);

                        using (var response = await httpClient.SendAsync(
                request, HttpCompletionOption.ResponseHeadersRead))
                        {
                            response.EnsureSuccessStatusCode();
                        }
                    }
                }
                finally
                {
                    if(stream != null)
                        stream.Dispose();
                }

                using (var completeRequest = new HttpRequestMessage(HttpMethod.Post, $"{_baseURL}/scanner/completar/{transactionId}"))
                {
                    completeRequest.Headers.Add("x-scanner-token", dto.Token);

                    using (var completeResponse = await httpClient.SendAsync(
                completeRequest, HttpCompletionOption.ResponseHeadersRead))
                    {
                        completeResponse.EnsureSuccessStatusCode();
                    }
                }

            }
        }

        private MultipartFormDataContent ConvertirAPayload(PaginaPika pag, DTOTokenScanner dto, string transaccionId, out FileStream stream)
        {
            var form = new MultipartFormDataContent();

            stream = File.OpenRead(pag.Ruta);
            var streamContent = new StreamContent(stream);
            streamContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            form.Add(streamContent, "file", Path.GetFileName(pag.Ruta));

            form.Add(new StringContent(transaccionId), "TransaccionId");
            form.Add(new StringContent(dto.VolumenId  ?? ""), "VolumenId");
            form.Add(new StringContent(dto.ElementoId ?? ""), "ElementoId");
            form.Add(new StringContent(dto.PuntoMontajeId ?? ""), "PuntoMontajeId");
            form.Add(new StringContent(dto.VersionId ?? ""), "VersionId");
            form.Add(new StringContent(dto.Indice.ToString() ?? ""), "Indice");
            form.Add(new StringContent(PosicionCarga.al_final.ToString()), "Posicion");
            form.Add(new StringContent("0"), "PosicionInicio");

            return form;
        }

    }
}
