using System;
using System.Collections.Generic;
using System.Text;

namespace QRReaderDemo
{
    public class Elemento
    {
        public string dato { get; set; }
        public string fecha { get; set; }
        public string turno { get; set; }
        public string area { get; set; }
        public string unidad { get; set; }
        public string nombre { get; set; }
        public string empleado { get; set; }
        public string razon { get; set; }
        public string direccion { get; set; }
    }

    public class ListaElementos
    {
        public List<Elemento> _elementos { get; set; }

        public ListaElementos()
        {
            _elementos = new List<Elemento>();
            //LoadElements();
        }

    }
}
