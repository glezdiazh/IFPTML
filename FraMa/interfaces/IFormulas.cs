using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FraMa
{
    public interface IFormulas
    {
        string generarPredicado(clsVariable variables, string abreviaturaOperacion);
        void Operar(string formula, params List<clsVariable>[] variables);
    }
}
