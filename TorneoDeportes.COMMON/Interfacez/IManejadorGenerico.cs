using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;
using TorneoDeportes.COMMON.Entidades;

namespace TorneoDeportes.COMMON.Interfacez
{
    public interface IManejadorGenerico<T> where T:Base
    {
        bool Agregar(T entidad);
        List<T> Lista { get; }
        bool Eliminar(ObjectId Id);
        bool Modificar(T entidad);
        T Buscador(ObjectId Id);
    }
}
