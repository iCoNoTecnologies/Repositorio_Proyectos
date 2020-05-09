using System;
using System.Collections.Generic;
using System.Text;

namespace QRReaderDemo
{
    public class Tablets
    {
        public string Id { get; set; }
        public string Descripcion { get; set; }
    }

    public class ListaTablets
    {
        public List<Tablets> _tablets { get; set; }

        public ListaTablets()
        {
            _tablets = new List<Tablets>();
        }

    }
}