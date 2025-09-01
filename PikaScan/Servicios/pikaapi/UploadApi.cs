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

            var httpClient = new HttpClient
            {
                Timeout = Timeout.InfiniteTimeSpan
            };

            string transactionId = Guid.NewGuid().ToString();

            Form1.Instance.UpdateProgress(0, paginas.Count + 1);
            int index = 0;
            foreach (var pagina in paginas)
            {
                index++;
                Form1.Instance.UpdateProgress(index, paginas.Count + 1);

                await Task.Delay(2000);

                if (!File.Exists(pagina.Ruta))
                    continue;

                MultipartFormDataContent payload = null;
                FileStream stream = null;

                try
                {
                    dto.Indice++;
                    payload = ConvertirAPayload(pagina, dto, transactionId, out stream);

                    string url = "";
                    if (index == 1)
                    {
                        url = $"{_baseURL}/scanner/pagina?restart=true";
                    }
                    else
                    {
                        url = $"{_baseURL}/scanner/pagina?restart=false";
                    }

                        using (payload)
                        using (var request = new HttpRequestMessage(HttpMethod.Post, url))
                        {
                            request.Content = payload;
                            request.Headers.Add("x-scanner-token", dto.Token);

                            var response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
                            if (response.IsSuccessStatusCode)
                            {

                            }
                            else
                            {
                                uploadCompleto = false;
                            }

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
                    using (var completeRequest = new HttpRequestMessage(HttpMethod.Post, $"{_baseURL}/scanner/completar/{transactionId}"))
                    {
                        completeRequest.Headers.Add("x-scanner-token", dto.Token);
                        var completeResponse = await httpClient.SendAsync(completeRequest, HttpCompletionOption.ResponseHeadersRead);
                        if (completeResponse.IsSuccessStatusCode)
                        {

                        }
                        else
                        {
                            uploadCompleto = false;
                        }
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
            form.Add(new StringContent(PosicionCarga.al_final.ToString()), "Posicion");
            form.Add(new StringContent("0"), "PosicionInicio");

            return form;
        }

    }
}
