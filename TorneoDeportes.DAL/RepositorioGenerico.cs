using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using TorneoDeportes.COMMON.Entidades;
using TorneoDeportes.COMMON.Interfacez;

namespace TorneoDeportes.DAL
{
    public class RepositorioGenerico<T> : IRepositorio<T> where T : Base
    {
        private MongoClient client;
        private IMongoDatabase db;

        public RepositorioGenerico()
        {
            client = new MongoClient(new MongoUrl("mongodb://torneos19:fernanda1908@ds161041.mlab.com:61041/fernanda18"));
            db = client.GetDatabase("fernanda18");//nombre de mi base de datos
        }

        private IMongoCollection<T> Collection()
        {
            return db.GetCollection<T>(typeof(T).Name);
        }

        public List<T> Lista => Collection().AsQueryable().ToList();

        public bool Crear(T entidad)
        {
            try
            {
                Collection().InsertOne(entidad);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Editar(T entidadModificada)
        {
            try
            {
                return Collection().ReplaceOne(p => p.Id == entidadModificada.Id, entidadModificada).ModifiedCount == 1;
            }
            catch (Exception)
            {
                return false;
            }
        }

      

        public bool Eliminar(ObjectId Id)
        {
            try
            {
                return Collection().DeleteOne(p => p.Id == Id).DeletedCount == 1;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
