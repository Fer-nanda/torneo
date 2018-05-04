using System;
using System.Collections.Generic;
using System.Text;

namespace TorneoDeportes.COMMON.Entidades
{
    public class Persona:Base
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        
        public string Domicilio { get; set; }
    }
}
