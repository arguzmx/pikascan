using Ninject.Activation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace PikaScan.Servicios.pikaapi
{
    public class UploadApi
    {
        private string _baseURL = string.Empty;
        public async Task EnviarPaginas(List<PaginaPika> paginas, DTOTokenScanner dto)
        {
            bool uploadCompleto = true;

            _baseURL = string.IsNullOrEmpty(dto.UrlBase?.TrimEnd('/')) ? "http://localhost:5000/api/v1.0/upload" : dto.UrlBase?.TrimEnd('/');

            string transactionId = dto.VersionId.ToString();

            int index = 0;

            Form1.Instance.UpdateProgress(index, paginas.Count);
            foreach (var pagina in paginas)
            {
                await Task.Delay(2000);

                if (!File.Exists(pagina.Ruta))
                    continue;

                MultipartFormDataContent payload = null;
                MultipartFormDataContent payloadVerificacion = null;
                FileStream stream = null;

                try
                {

                    dto.Indice++;

                    string url = "";
                    string urlVerificacion = "";

                    if (index == 1)
                    {
                        url = $"{_baseURL}/scanner/pagina?restart=false";
                        urlVerificacion = $"{_baseURL}/scanner/pagina/verificacion?restart=false";
                    }
                    else
                    {
                        url = $"{_baseURL}/scanner/pagina?restart=false";
                        urlVerificacion = $"{_baseURL}/scanner/pagina/verificacion?restart=false";
                    }

                    payloadVerificacion = ConvertirAPayloadVerificacion(pagina, dto, transactionId);
                    var respuestaVerificacion = await EnviarPeticion(HttpMethod.Post, urlVerificacion, dto.Token, payloadVerificacion);
                    if (!respuestaVerificacion.IsSuccessStatusCode)
                        continue;

                    payload = ConvertirAPayload(pagina, dto, transactionId, out stream);
                    var respuesta = await EnviarPeticion(HttpMethod.Post, url, dto.Token, payload);
                    if (respuesta.IsSuccessStatusCode)
                    {
                        index++;
                        Form1.Instance.UpdateProgress(index, paginas.Count);
                    }
                    else
                    {
                        uploadCompleto = false;
                    }
                }
                catch (Exception ex)
                {
                    Form1.Instance.UpdateProgress(1, 1);
                    uploadCompleto =false;
                    Form1.Instance.ShowNotification($"Error enviando página {index}: {ex.Message}", System.Windows.Forms.ToolTipIcon.Error);
                    break;
                }   
                finally
                {
                    if(stream != null)
                        stream.Dispose();
                }
            }

            if(uploadCompleto)
            {
                try
                {
                    var completeResponse = await EnviarPeticion(HttpMethod.Post, $"{_baseURL}/scanner/completar/{transactionId}", dto.Token, null);
                    if (completeResponse.IsSuccessStatusCode)
                    {
                        Form1.Instance.tsProgressSend.Visible = false;
                        Form1.Instance.tsLAbel.Text = "Envío finalizado";
                    }
                    else
                    {
                        uploadCompleto = false;
                    }
                }
                catch (Exception ex)
                {
                    Form1.Instance.UpdateProgress(1, 1);
                    Form1.Instance.ShowNotification($"Error al finalizar la transacción de carga: {ex.Message}", System.Windows.Forms.ToolTipIcon.Error);
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
            form.Add(new StringContent(dto.Posicion.ToString() ?? ""), "Posicion");
            form.Add(new StringContent(dto.PosicionInicio.ToString() ?? ""), "PosicionInicio");

            return form;
        }

        private MultipartFormDataContent ConvertirAPayloadVerificacion(PaginaPika pag, DTOTokenScanner dto, string transaccionId)
        {
            var form = new MultipartFormDataContent();
            form.Add(new StringContent(Path.GetFileName(pag.Ruta)), "NombreOriginal");
            form.Add(new StringContent(transaccionId), "TransaccionId");
            form.Add(new StringContent(dto.VolumenId ?? ""), "VolumenId");
            form.Add(new StringContent(dto.ElementoId ?? ""), "ElementoId");
            form.Add(new StringContent(dto.PuntoMontajeId ?? ""), "PuntoMontajeId");
            form.Add(new StringContent(dto.VersionId ?? ""), "VersionId");

            return form;
        }

        private async Task<HttpResponseMessage> EnviarPeticion(HttpMethod method, string url, string token, HttpContent payload = null)
        {
            HttpClient httpClient = new HttpClient
            {
                Timeout = Timeout.InfiniteTimeSpan
            };

            using (var request = new HttpRequestMessage(method, url))
            {
                if (payload != null)
                {
                    request.Content = payload;
                }
                request.Headers.Add("x-scanner-token", token);
                return await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
            }
        }


    }
}
