using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FraMa
{
    public class clsMotor 
    {
        public enum Tipos
        {
            parametros,
            grouping,
            continuas,
            operadores
        }

        public List<clsVariable> Entradas { get; set; }
        public List<clsVariable> Salidas { get; set; }
        public List<clsVariable> Temporales { get; set; }
        public clsOperacion.operadores Operador { get; set; }
        public Tipos Tipo { get; set; } 

        public DataTable tablaExcel { get; set; }
        
        public clsMotor(List<clsVariable> entradas, List<clsVariable> salidas, List<clsVariable> temporales, clsOperacion.operadores operador, Tipos tipo)
        {
            Entradas = entradas;
            Salidas = salidas;
            Temporales = temporales;
            Operador = operador;
            Tipo = tipo;
        }

        public List<double> sumaCaso1(DataTable tabla, params clsVariable[] input)
        {
            var res = new List<double>();
            foreach (var item in input)
            {
                var valor = tabla.Compute("SUM([" + tabla.Columns[item.ColumnaNo].ColumnName + "])", "");
                res.Add(Convert.ToDouble(valor));
            }
            return res;
        }

        public static string getTipoListado(params List<clsVariable>[] listado)
        {
            string res = string.Empty;
            foreach (var item in listado)
            {
                if (item.Count != 0)
                {
                    res += "1";
                }
                else
                {
                    res += "0";
                }
            }
            return res;
        }
    }
}