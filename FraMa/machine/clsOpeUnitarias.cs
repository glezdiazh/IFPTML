using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.Statistics;

namespace FraMa
{
    public class clsOpeUnitarias //: IFormulas, IDisposable
    {
        #region borrar
        ////////////enum calculos
        ////////////{
        ////////////    Sum,
        ////////////    Min, 
        ////////////    Max,
        ////////////    Avg,
        ////////////    StDev
        ////////////}

        ////////////public DataTable tabla = new DataTable();
        ////////////public DataTable res = new DataTable();
        ////////////public double valor = 0d;

        ////////////public clsOpeUnitarias()
        ////////////{
        ////////////}
        /////////////// <summary>
        /////////////// Obtiene el "valor" de la operacion unitaria sobre item(s) seleccionado(s) de una columna
        /////////////// </summary>
        /////////////// <param name="tabla"></param>
        /////////////// <param name="formula"></param>
        /////////////// <param name="variables"></param>
        ////////////public void Operar(string formula, params List<clsVariable>[] variables)
        ////////////{
        ////////////    var toOperate = variables[0]; //Selecciono una sola columna
        ////////////    foreach (var item in toOperate) //selecciono todos los items para sumar
        ////////////    {
        ////////////        var oper = string.Empty;
        ////////////        switch (formula)
        ////////////        {
        ////////////            case "singleSuma":
        ////////////                oper = calculos.Sum.ToString();
        ////////////                break;
        ////////////            case "singleMax":
        ////////////                oper = calculos.Max.ToString();
        ////////////                break;
        ////////////            case "singleMin":
        ////////////                oper = calculos.Min.ToString();
        ////////////                break;
        ////////////            case "singleAverage":
        ////////////                oper = calculos.Avg.ToString();
        ////////////                break;
        ////////////            case "singleStandarDev":
        ////////////                oper = calculos.StDev.ToString();
        ////////////                break;
        ////////////        }
        ////////////        valor += getResultado((clsVariable)item, oper);//oper contiene SUM AVG MIN MAX
        ////////////    }
        ////////////}      
        /////////////// <summary>
        /////////////// Genera el string que va como argumento de la funcion Compute de la DataTable
        /////////////// </summary>
        /////////////// <param name="variable">la variable debe contener el nombre de la columna</param>
        /////////////// <param name="abreviaturaOperacion">SUM, MIN, MAX, AVG</param>
        /////////////// <param name="variables">todo: describe variables parameter on generarPredicado</param>
        /////////////// <returns>argumento del Compute Datatable</returns>
        ////////////public string generarPredicado(clsVariable variables, string abreviaturaOperacion)
        ////////////{
        ////////////    //return  string.Format("\"" + abreviaturaOperacion + "\"" + "([" + tabla.Columns[variable.ColumnaNo].ColumnName + "])", "");
        ////////////    return string.Format("\"" + abreviaturaOperacion + "\"" + "([ tabla.Columns[variables.ColumnaNo].ColumnName ])");
        ////////////}

        ////////////private double getResultado(clsVariable variable, string abreviaturaOperacion)
        ////////////{
        ////////////    return Convert.ToDouble(tabla.Compute(generarPredicado(variable, abreviaturaOperacion), ""));
        ////////////}

        ////////////public void Dispose()
        ////////////{
        ////////////    tabla.Dispose();
        ////////////    GC.SuppressFinalize(this);
        ////////////}
        #endregion

        //https://stackoverflow.com/questions/2442525/how-to-select-min-and-max-values-of-a-column-in-a-datatable
        //3 AVEP  Average              C   NULL  AVER - C - NULL
        public void Average(ref DataTable tabla, int columna, int colQuery)
        {
            var temp = tabla.Copy();
            var valores = tabla.AsEnumerable().Select(al => al.Field<double>(temp.Columns[colQuery].ColumnName)).ToList();
            var valor = valores.Average();

            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                tabla.Rows[i][columna] = valor;
            }
        }

        public static double Average(DataTable tabla, int columna, int colQuery)
        {
            var temp = tabla.Copy();
            var valores = tabla.AsEnumerable().Select(al => al.Field<double>(temp.Columns[colQuery].ColumnName)).ToList();
            return valores.Average();
        }

        //3 Cons  Constant             NULLNULL  NULL - NULL - NULL
        public void Constante(ref DataTable tabla, int columna, int colQuery, double constante)
        {
            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                tabla.Rows[i][columna] = (double)tabla.Rows[i][colQuery] * constante;
            }
        }
        //3 MAXP  Max                  C   NULL  MAX  - C - NULL
        public void Max(ref DataTable tabla, int columna, int colQuery)
        {
            var temp = tabla.Copy();
            var valores = tabla.AsEnumerable().Select(al => al.Field<double>(temp.Columns[colQuery].ColumnName)).ToList();
            var valor = valores.Max();

            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                tabla.Rows[i][columna] = valor;
            }
        }
        //3 MINP  Min                  C   NULL  MIN  - C - NULL
        public void Min(ref DataTable tabla, int columna, int colQuery)
        {
            var temp = tabla.Copy();
            var valores = tabla.AsEnumerable().Select(al => al.Field<double>(temp.Columns[colQuery].ColumnName)).ToList();
            var valor = valores.Min();

            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                tabla.Rows[i][columna] = valor;
            }
        }
        //3 STDP  StandarDeviation     C   NULL  STDV - C - NULL
        public void DesviacionEstandar(ref DataTable tabla, int columna, int colQuery)
        {
            var temp = tabla.Copy();
            var valores = tabla.AsEnumerable().Select(al => al.Field<double>(temp.Columns[colQuery].ColumnName)).ToList();
            var valor = valores.StandardDeviation();

            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                tabla.Rows[i][columna] = valor;
            }
        }

        public static double DesviacionEstandar(DataTable tabla, int columna, int colQuery)
        {
            var temp = tabla.Copy();
            var valores = tabla.AsEnumerable().Select(al => al.Field<double>(temp.Columns[colQuery].ColumnName)).ToList();
            var valor = valores.StandardDeviation();
            return valor;
        }

        //3 SUMP  Sum                  C   NULL  SUM  - C - NULL
        public void Suma(ref DataTable tabla, int columna, int colQuery)
        {
            var temp = tabla.Copy();
            var valores = tabla.AsEnumerable().Select(al => al.Field<double>(temp.Columns[colQuery].ColumnName)).ToList();
            var valor = valores.Sum();

            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                tabla.Rows[i][columna] = valor;
            }
        }
        #region borrar
        //public void sumaPorLevel(ref DataTable tabla1, int colNumero, int colGrouping, int colContinua)
        //{
        //    var temp = new DataTable();
        //    temp = suma(colGrouping, colContinua);

        //    var i = 0;
        //    foreach (DataRow item in tabla1.Rows)
        //    {
        //        tabla1.Rows[i][colNumero] = (double)getValorDeTabla(temp, item[colGrouping].ToString());
        //        i++;
        //    }
        //}
        #endregion       
    }
}
