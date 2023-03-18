using System;
using System.Collections.Generic;
using System.Text;

namespace FraMa
{
    public class columnas
    {
        public enum tipo
        {
            IN_Grouping,
            IN_Continuous,
            OUT_Grouping,
            OUT_Continuous,
            IN_MERGE_Grouping,
            OUT_MERGE_Grouping,
            Original
        }

        public enum operadores
        {
            movingAverage,
            zScore,
            identity,
            distanciaEuclidiana,
            log,
            inversa,
            potencia,
            probabilidad,
            entropyShanon,
            suma,
            promedio,
            count,
            desviacionEstandar,
            coVarianza,
            varianza,
            EuclidDistance
        }

        public int index { get; set; }
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }
        public tipo Tipo { get; set; }
        public List<operadores> operaciones { get; set; }
        public bool generado { get; set; }
        public columnas()
        {
        }

        public columnas(int id, string nombre)
        {
            index = id;
            Nombre = nombre;
            NombreCorto = getNombreCorto(nombre);
            Tipo = tipo.Original;
            operaciones = new List<operadores>();
            operaciones.Add(operadores.promedio);
            generado = false;
        }

        private static string getNombreCorto(string Nombre)
        {
            return Nombre.Substring(0, 2);
        } 
    }
}
