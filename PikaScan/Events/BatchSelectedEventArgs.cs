using PikaScan.Modelo;
using System;

namespace PikaScan.Events
{
    public class BatchSelectedEventArgs: EventArgs
    {
        public Lote batch { get; set; }
    }
}
