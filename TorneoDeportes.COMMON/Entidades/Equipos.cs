using System;
using System.Collections.Generic;
using System.Text;

namespace TorneoDeportes.COMMON.Entidades
{
    public class Equipos:Base
    {
        public string Nombre { get; set; }
        public string Tipo_Deporte { get; set; }
        public override string ToString()
        {
            return Nombre;
        }

    }
}
