using System;
using System.Collections.Generic;
using System.Text;

namespace QRReaderDemo
{
    public class Grupos
    {
        public string IDag { get; set; }
        public string Tipo { get; set; }
        public string Nombre { get; set; }
    }

    public class ListaGrupos
    {
        public List<Grupos> _grupos { get; set; }

        public ListaGrupos()
        {
            _grupos = new List<Grupos>();
        }

    }
}
