using PikaScan.Modelo;
using System;

namespace PikaScan.Events
{
    public class DocumentSelectedEventArgs: EventArgs
    {

        public Documento document { get; set; }
    }
}
