using System;
using System.Collections.Generic;
using System.Text;

namespace QRReaderDemo
{
    public class Kit
    {
        public string Id { get; set; }
        public string Descripcion { get; set; }
    }

    public class ListaKit
    {
        public List<Kit> _kits { get; set; }

        public ListaKit()
        {
            _kits = new List<Kit>();
        }

    }
}
