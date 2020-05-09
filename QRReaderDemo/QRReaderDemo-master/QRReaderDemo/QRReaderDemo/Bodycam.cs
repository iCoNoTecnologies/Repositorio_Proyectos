using System;
using System.Collections.Generic;
using System.Text;

namespace QRReaderDemo
{
    public class Bodycam
    {
        public string Id { get; set; }
        public string Descripcion { get; set; }
    }

    public class ListaBodycam
    {
        public List<Bodycam> _bodycam { get; set; }

        public ListaBodycam()
        {
            _bodycam = new List<Bodycam>();
        }

    }
}
