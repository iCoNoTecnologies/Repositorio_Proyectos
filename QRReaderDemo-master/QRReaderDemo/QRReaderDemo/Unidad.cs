﻿using System;
using System.Collections.Generic;
using System.Text;

namespace QRReaderDemo
{
    public class Unidad
    {
        public string unidad { get; set; }
    }

    public class ListaUnidades
    {
        public List<Unidad> _unidades { get; set; }

        public ListaUnidades()
        {
            _unidades = new List<Unidad>();
            //LoadElements();
        }

    }
}
