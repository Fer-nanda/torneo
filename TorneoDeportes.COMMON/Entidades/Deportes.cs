using System;
using System.Collections.Generic;
using System.Text;

namespace TorneoDeportes.COMMON.Entidades
{
    public class Deportes:Base
    {
        public string tipo_deporte { get; set; }
        public override string ToString()
        {
            return tipo_deporte;
        }
    }
}
