using PikaScan.Modelo;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PikaScan.Controles
{
    public partial class DocumentViewer : UserControl
    {

        public DocumentViewer()
        {
            InitializeComponent();
            this.SizeChanged += DocumentViewer_SizeChanged;
            this.DisplayCount = 1;
            this.paginas = new List<Pagina>();
            this.documento = null;

        }

        private Color color;
        public Color BgColor
        {
            get { return this.color; }
            set
            {
                this.color = value;
                foreach (var c in this.Controls)
                {
                    ((ImageEditor)c).BgColor = value;
                }
            }
        }


        public void ShowImage(string path, int port)
        {
            foreach (var c in this.Controls)
            {
                ImageEditor editor = (ImageEditor)c;
                int vpid = int.Parse((string)editor.Tag);
                if (vpid == port)
                {
                    editor.SetImage(path, port);
                    break;
                }
            }
        }
        private void DocumentViewer_SizeChanged(object sender, EventArgs e)
        {
            RedrawView();
        }

        private int _DisplayCount;

        public int DisplayCount
        {
            get { return _DisplayCount; }
            set { _DisplayCount = value; RedrawView(); }
        }




        private List<Pagina> paginas { get; set; }
        public Documento documento { get; set; }
        public void ShowPages(Documento documento, List<Pagina> paginas)
        {
            this.paginas = paginas;
            this.documento = documento;
            ShowPages();
        }


        public void ShowPages(List<string> rutas)
        {
            ClearPorts();
            for (int i = 1; i <= rutas.Count; i++)
            {
                foreach (var c in this.Controls)
                {
                    ImageEditor editor = (ImageEditor)c;
                    int vpid = int.Parse((string)editor.Tag);
                    if (vpid == i)
                    {
                        editor.SetImage(rutas[i - 1], i - 1);
                        break;
                    }
                }
            }

        }

        public void ClearPorts()
        {
            foreach (var c in this.Controls)
            {
                ((ImageEditor)c).ClearImage();
            }
        }


        private void DocumentViewer_Load(object sender, EventArgs e)
        {
            RedrawView();


        }



        private void ShowPages()
        {


            for (int i = 1; i <= UISession.availableDisplays; i++)
            {
                int nextitem = 0;
                if (nextitem < paginas.Count)
                {
                    string p = Path.Combine(documento.Path, paginas[nextitem].Name);
                    foreach (var c in this.Controls)
                    {
                        if (int.Parse((string)((ImageEditor)c).Tag) == i)
                        {
                            Debug.Print($"{i} {p} {nextitem}");
                            ((ImageEditor)c).SetImage(p, nextitem);
                            break;
                        }
                    }

                }
            }
        }

        public void RedrawView()
        {
            int w = this.Width;
            int h = this.Height;
            int panelgap = 10;

            foreach (var c in this.Controls)
            {
                ((ImageEditor)c).ClearImage();
                ((ImageEditor)c).Visible = false;
            }




            switch (_DisplayCount)
            {
                case 1:
                    ImEditor01.Width = w;
                    ImEditor01.Height = h;
                    ImEditor01.Top = 0;
                    ImEditor01.Left = 0;
                    break;

                case 2:
                    w = (w - panelgap) / 2;

                    foreach (var c in this.Controls)
                    {
                        ((ImageEditor)c).Width = w;
                        ((ImageEditor)c).Height = h;
                    }


                    ImEditor01.Top = 0;
                    ImEditor01.Left = 0;

                    ImEditor02.Top = 0;
                    ImEditor02.Left = w + panelgap;
                    break;

                case 4:
                    w = (w - panelgap) / 2;
                    h = (h - panelgap) / 2;

                    foreach (var c in this.Controls)
                    {
                        ((ImageEditor)c).Width = w;
                        ((ImageEditor)c).Height = h;
                    }



                    ImEditor01.Top = 0;
                    ImEditor01.Left = 0;
                    ImEditor02.Top = 0;
                    ImEditor02.Left = w + panelgap;

                    ImEditor03.Top = h + panelgap;
                    ImEditor03.Left = 0;
                    ImEditor04.Top = h + panelgap;
                    ImEditor04.Left = w + panelgap;

                    break;

                case 8:
                    w = (w - panelgap) / 4;
                    h = (h - panelgap) / 2;

                    foreach (var c in this.Controls)
                    {
                        ((ImageEditor)c).Width = w;
                        ((ImageEditor)c).Height = h;
                    }

                    ImEditor01.Top = 0;
                    ImEditor01.Left = 0;
                    ImEditor02.Top = 0;
                    ImEditor02.Left = w + panelgap;

                    ImEditor03.Top = 0;
                    ImEditor03.Left = 2 * (w + panelgap);
                    ImEditor04.Top = 0;
                    ImEditor04.Left = 3 * (w + panelgap);



                    ImEditor05.Top = h + panelgap;
                    ImEditor05.Left = 0;
                    ImEditor06.Top = h + panelgap;
                    ImEditor06.Left = w + panelgap;

                    ImEditor07.Top = h + panelgap;
                    ImEditor07.Left = 2 * (w + panelgap);
                    ImEditor08.Top = h + panelgap;
                    ImEditor08.Left = 3 * (w + panelgap);

                    break;

            }


            foreach (var c in this.Controls)
            {
                if (int.Parse((string)((ImageEditor)c).Tag) <= _DisplayCount.GetHashCode())
                {
                    ((ImageEditor)c).Visible = true;
                }
            }

            ShowPages();

        }

    }
}
