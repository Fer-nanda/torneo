using System;
using System.Collections.Generic;
using System.Text;

namespace TorneoDeportes.COMMON.Entidades
{
    public class Usuarios:Persona
    {
        
        public string Nom_Usuario { get; set; }
        public string Contraseña { get; set; }
        
        public override string ToString()
        {
            return Nom_Usuario;
        }
    }
}
