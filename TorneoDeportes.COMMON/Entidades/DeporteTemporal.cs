using System;
using System.Collections.Generic;
using System.Text;

namespace TorneoDeportes.COMMON.Entidades
{
    public class DeporteTemporal
    {
        public string Id { get; set; }
        public string F_aProgramado { get; set; }
        public string Deporte { get; set; }
        public string Equipo1 { get; set; }
        public int Marcador_1 { get; set; }
        public string Equipo2 { get; set; }
        public int Marcador_2 { get; set; }
    }
}
