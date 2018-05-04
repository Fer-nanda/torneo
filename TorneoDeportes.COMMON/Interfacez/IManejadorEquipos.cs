using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TorneoDeportes.COMMON.Entidades;

namespace TorneoDeportes.COMMON.Interfacez
{
    public interface IManejadorEquipos : IManejadorGenerico<Equipos>
    {
        
        IEnumerable BuscarEquipos(string palabra);
        int ContadorDeBuscarEquipo(string palabra);

        int Aleatorios(string palabra);
    }
}
