using System;
using System.Collections.Generic;
using System.Text;

namespace TorneoDeportes.COMMON.Entidades
{
    public class Generadora
    {
        public Generadora()
        {
            Puntos = new List<Grafica>();
        }

        public List<Grafica> Puntos { get; set; }

        public List<Grafica> GeneradorDatos(List<TorneoLista> listatorneo, double limiteInferior, double limiteSuperior, double incremento)
        {
            Puntos = new List<Grafica>();
            double contador = 1;
            foreach (var item in listatorneo)
            {
                Puntos.Add(new Grafica(contador++, item.Puntaje));
            }
            return Puntos;
        }
    }
}
