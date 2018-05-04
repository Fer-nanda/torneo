using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;
using TorneoDeportes.COMMON.Entidades;
using TorneoDeportes.COMMON.Interfacez;

namespace TorneoDeportes.BIZ
{
    public class ManejadorDeportes : IManejadorDeportes
    {
        IRepositorio<Deportes> deportes;
        public ManejadorDeportes(IRepositorio<Deportes> deportes)
        {
            this.deportes=deportes;
        }

        public List<Deportes> Lista => deportes.Lista;

        public bool Agregar(Deportes entidad)
        {
            return deportes.Crear(entidad);
        }

        

        public Deportes Buscador(ObjectId Id)
        {
            return Lista.Where(e => e.tipo_deporte == Id.ToString()).SingleOrDefault();
        }

       

        public bool Eliminar(ObjectId Id)
        {
            return deportes.Eliminar(Id);
        }

        public bool Modificar(Deportes entidad)
        {
            return deportes.Editar(entidad);
        }
    }
}
