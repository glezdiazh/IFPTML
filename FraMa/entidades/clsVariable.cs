using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FraMa
{
    public class clsVariable
    {
        public string Nombre { get; set; }
        public string NombreCorto { get; set; }
        public string NombreColumna { get; set; }
        public int ColumnaNo { get; set; }
        
        public clsVariable()
        {
        }

        public clsVariable(string nombre)
        {
            Nombre = nombre;
            NombreCorto = getNombreCorto(nombre);
            ColumnaNo = -1;
        }

        public clsVariable(int columnaNo, string nombre) : this(nombre)
        {
            ColumnaNo = columnaNo;
            Nombre = nombre;
            NombreCorto = getNombreCorto(nombre);
        }

        private static string getNombreCorto(string Nombre)
        {
            string temporal = Nombre.Substring(0, 2);
            return temporal.Trim();
            //return Nombre.Substring(0, 3);
        }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
