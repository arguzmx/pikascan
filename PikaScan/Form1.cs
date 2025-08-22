using PikaScan.Servicios.pikaapi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PikaScan
{
    public partial class Form1 : Form
    {
        private DTOTokenScanner scanner;
        public Form1(string deeplink)
        {
            InitializeComponent();

            if (deeplink != null)
                scanner = ObtenerDatosDeeplink(deeplink);

            MessageBox.Show("Deeplink recibido: " + deeplink);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.twainCapture1.StartModule();
        }

        private DTOTokenScanner ObtenerDatosDeeplink(string deeplink = null)
        {
            var uri = new Uri(deeplink);
            var consulta = uri.Query.TrimStart('?');
            var datos = new DTOTokenScanner();

            foreach ( var param in consulta.Split('&'))
            {
                var claveValor = param.Split(new[] { '=' }, 2);

                if (claveValor.Length != 2)
                    continue;

                string clave = Uri.UnescapeDataString(claveValor[0]);
                string valor = Uri.UnescapeDataString(claveValor[1]);

                switch (clave)
                {
                    case "token":
                        datos.Token = valor.Contains("=") ? valor.Split('=').Last() : valor;
                        break;
                    case "elementoId":
                        datos.ElementoId = valor; break;
                    case "versionId":
                        datos.VersionId = valor; break;
                    case "volumenId":
                        datos.VolumenId = valor; break;
                    case "puntoMontajeId":
                        datos.PuntoMontajeId = valor; break;
                    case "caducidad":
                        if (DateTime.TryParse(valor, out DateTime fechaConvertida))
                            datos.Caducidad = fechaConvertida;
                        break;
                }
            }

            return datos;
        }

        private void twainCapture1_Load(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            //Desde el front llamar click al icono del escaner para crear el tokenscanner y darle click al boton prueba.
            //Remplazar la ruta con archivos para la prueba

            var paginas = new List<PaginaPika>
            {
                new PaginaPika { Ruta = @"C:\Users\desarrollo\Pictures\IMG\dino.jpg" },
                new PaginaPika { Ruta = @"C:\Users\desarrollo\Pictures\IMG\cars.jpg" },
            };

            var servicio = new UploadApi();

            await servicio.EnviarPaginas(paginas, scanner);


        }
    }
}
