using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;
using TorneoDeportes.COMMON.Entidades;

namespace TorneoDeportes.COMMON.Interfacez
{
    public interface IRepositorio<T> where T :Base
    {
        bool Crear(T entidad);
        bool Editar(T entidadModificada);
        bool Eliminar(ObjectId Id);
        List<T> Lista { get; }
    }
}
