using MongoDB.Bson;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TorneoDeportes.COMMON.Entidades;
using TorneoDeportes.COMMON.Interfacez;

namespace TorneoDeportes.BIZ
{
    public class ManejadorEquipos : IManejadorEquipos
    {
        IRepositorio<Equipos> equi;
        public ManejadorEquipos(IRepositorio<Equipos> usuario)
        {
            this.equi = usuario;
        }

        public List<Equipos> Lista => equi.Lista.OrderBy(p => p.Nombre).OrderBy(e => e.Tipo_Deporte).ToList();

        public bool Agregar(Equipos entidad)
        {
            return equi.Crear(entidad);
        }

        public int Aleatorios(string palabra)
        {
            int valor = ContadorDeBuscarEquipo(palabra);
            Random a = new Random();
            int v = 0;
            return v = a.Next(1, valor);
        }

        public Equipos Buscador(ObjectId Id)
        {
            return Lista.Where(e => e.Tipo_Deporte == Id.ToString()).SingleOrDefault();
        }

        public IEnumerable BuscarEquipos(string palabra)
        {
            return Lista.Where(e => e.Tipo_Deporte == palabra).ToList();
        }

        public int ContadorDeBuscarEquipo(string palabra)
        {
            return Lista.Where(e => e.Tipo_Deporte == palabra).ToList().Count();
        }

        

        public bool Eliminar(ObjectId Id)
        {
            return equi.Eliminar(Id);
        }

        public bool Modificar(Equipos entidad)
        {
            return equi.Editar(entidad);
        }
    }
}
