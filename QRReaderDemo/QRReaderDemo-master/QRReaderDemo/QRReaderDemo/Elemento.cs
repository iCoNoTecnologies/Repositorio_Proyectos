using System;
using System.Collections.Generic;
using System.Text;

namespace QRReaderDemo
{
    public class Elemento
    {
        public string Nombre { get; set; }
        public string Paterno { get; set; }
        public string Materno { get; set; }
        public string NoEmpleado { get; set; }
        public string Sexo { get; set; }
        public string fecha { get; set; }
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
