using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TorneoDeportes.COMMON.Entidades;
using TorneoDeportes.COMMON.Interfacez;

namespace TorneoDeportes.BIZ
{
    public class ManejadorUsuarios : IManejadorUsuarios
    {
        IRepositorio<Usuarios> usuario;
        public ManejadorUsuarios(IRepositorio<Usuarios> usuario)
        {
            this.usuario = usuario;
        }

        public List<Usuarios> Lista => usuario.Lista;

        public bool Agregar(Usuarios entidad)
        {
            return usuario.Crear(entidad);
        }

        public Usuarios Buscador(ObjectId Id)
        {
            return Lista.Where(e => e.Id == Id).SingleOrDefault();
        }

        public bool Eliminar(ObjectId Id)
        {
            return usuario.Eliminar(Id);
        }

        public bool Modificar(Usuarios entidad)
        {
            return usuario.Editar(entidad);
        }
    }
}
