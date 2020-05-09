using System;
using System.Collections.Generic;
using System.Text;

namespace QRReaderDemo
{
    public class Sitio
    {
        public string direccion { get; set; }
        public string razon { get; set; }
        public string contacto { get; set; }
        public string referencia { get; set; }
        public string area { get; set; }
        public string latitud { get; set; }
        public string longitud { get; set; }
        public string visitas { get; set; }

        public string vigencia { get; set; }
    }

    public class ListaSitios
    {
        public List<Sitio> _sitios { get; set; }

        public ListaSitios()
        {
            _sitios = new List<Sitio>();
            //LoadElements();
        }

    }
}
