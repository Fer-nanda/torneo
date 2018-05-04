using System;
using System.Collections.Generic;
using System.Text;

namespace TorneoDeportes.COMMON.Entidades
{
    public class Torneos:Base
    {
        public string F_Programado { get; set; }
        public string Deporte { get; set; }
        public string Equipo1 { get; set; }
        public int Marcador1 { get; set; }
        public string Equipo2 { get; set; }
        public int Marcador2 { get; set; }
    }
}
