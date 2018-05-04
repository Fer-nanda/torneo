using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TorneoDeportes.COMMON.Entidades;

namespace TorneoDeportes.COMMON.Interfacez
{
    public interface IManejadorTorneo : IManejadorGenerico<Torneos>
    {
        int VerificarSiEsNumero(string text);
    }
}
