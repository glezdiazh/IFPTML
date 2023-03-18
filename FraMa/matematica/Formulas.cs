using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

//Programar la obtencion del nombre de la columna de acuerdo al int[] index 
//Guardar las operaciones continuas como columna
//Guardar las operaciones continuas en la tabla
namespace FraMa
{
    public static class Formulas
    {
        public static double paramSum(DataTable tabla, int col) {
            var suma = tabla.AsEnumerable()
                .Sum(x => x.Field<double>(tabla.Columns[col].ColumnName))
                .ToString();

            return double.Parse(suma);
        }


        public static void movingAverage(ref DataTable tabla) { }
        public static void zScore(ref DataTable tabla) { }
        public static void identity(ref DataTable tabla) { }
        public static void distanciaEuclidiana(ref DataTable tabla) { }
        public static void log(ref DataTable tabla, int col) { }
        public static void inversa(ref DataTable tabla) { }
        public static void potencia(ref DataTable tabla) { }
        public static void probabilidad(ref DataTable tabla) { }
        public static void entropyShanon(ref DataTable tabla) { }
        public static DataTable suma(DataTable datosLevels, string colNuevaNombre) {
            var result = from row in datosLevels.AsEnumerable()
                         group row by row.Field<string>(datosLevels.Columns[0].ColumnName) into grp //order by grp.key
                         select new
                         {
                             id = grp.Key,
                             Operacion = grp.Sum(r => double.Parse(r[datosLevels.Columns[1].ColumnName].ToString()))
                         };

            DataTable resultado = new DataTable();
            resultado.Columns.Add("Valores");
            resultado.Columns.Add(colNuevaNombre);

            foreach (var item in result)
            {
                resultado.Rows.Add(item.id, item.Operacion);
            }
            return resultado;
        }
        public static DataTable promedio(DataTable datosLevels, string colNuevaNombre)
        {
            var result = from row in datosLevels.AsEnumerable()
                         group row by row.Field<string>(datosLevels.Columns[0].ColumnName) into grp //order by grp.key
                         select new
                         {
                             id = grp.Key,
                             Operacion = grp.Average(r => double.Parse(r[datosLevels.Columns[1].ColumnName].ToString()))
                         };

            DataTable resultado = new DataTable();
            resultado.Columns.Add("Valores");
            resultado.Columns.Add(colNuevaNombre);

            foreach (var item in result)
            {
                resultado.Rows.Add(item.id, item.Operacion);
            }
            return resultado;
        }
        public static DataTable count(DataTable datosLevels, string colNuevaNombre)
        {
            var result = from row in datosLevels.AsEnumerable()
                         group row by row.Field<string>(datosLevels.Columns[0].ColumnName) into grp //order by grp.key
                         select new
                         {
                             id = grp.Key,
                             Operacion = grp.Count()
                         };

            DataTable resultado = new DataTable();
            resultado.Columns.Add("Valores");
            resultado.Columns.Add(colNuevaNombre);

            foreach (var item in result)
            {
                resultado.Rows.Add(item.id, item.Operacion);
            }
            return resultado;
        }
        public static void desviacionEstandar(ref DataTable tabla) { }
        public static void coVarianza(ref DataTable tabla) { }
        public static void varianza(ref DataTable tabla) { }

        #region Operaciones sobre variables continuas
        public static void mergeColumnas(ref DataTable tabla, ref List<clsVariable> listadoGeneral, int[] colsToCalc)
        {
            string colName = ""; //getColName

            int j = 1;
            foreach (DataRow fila in tabla.Rows)
            {
                string valor = string.Empty;
                foreach (int index in colsToCalc)
                {
                    valor += fila[index] + "-";
                }
                fila[colName] = valor; //agregar el valor en la tabla y en la lista de columnas outs
                //backgroundWorker1.ReportProgress(j++ * 100 / tabla.Rows.Count);
            }
        }
        public static void productoColumnas(ref DataTable tabla, ref List<clsVariable> listadoGeneral, int[] colsToCalc)
        {
            string colName = ""; //getColName

            int j = 1;
            foreach (DataRow fila in tabla.Rows)
            {
                double valor = 1;
                foreach (int index in colsToCalc)
                {
                    valor *= double.Parse(fila[index].ToString());
                }
                fila[colName] = valor; //agregar el valor en la tabla y en la lista de columnas outs
                //backgroundWorker1.ReportProgress(j++ * 100 / tabla.Rows.Count);
            }
        }
        public static void diferenciaColumnas(ref DataTable tabla, ref List<clsVariable> listadoGeneral, int[] colsToCalc)
        {
            string colName = ""; //getColName

            int j = 1;
            foreach (DataRow fila in tabla.Rows)
            {
                int control = 0;
                double valor = 0;
                foreach (int index in colsToCalc)
                {
                    if (control == 0)
                    {
                        valor = double.Parse(fila[index].ToString());
                    }
                    else
                    {
                        valor -= double.Parse(fila[index].ToString());
                    }
                    control++;
                }
                fila[colName] = valor; //agregar el valor en la tabla y en la lista de columnas outs
                //backgroundWorker1.ReportProgress(j++ * 100 / tabla.Rows.Count);
            }
        }
        public static void manhatanColumnas(ref DataTable tabla, ref List<clsVariable> listadoGeneral, int[] colsToCalc)
        {
            string colName = ""; //getColName

            int j = 1;
            foreach (DataRow fila in tabla.Rows)
            {
                int control = 0;
                double valor = 0;
                foreach (int index in colsToCalc)
                {
                    if (control == 0)
                    {
                        valor = double.Parse(fila[index].ToString());
                    }
                    else
                    {
                        valor -= double.Parse(fila[index].ToString());
                    }
                    control++;
                }
                fila[colName] = Math.Abs(valor); //agregar el valor en la tabla y en la lista de columnas outs
                //backgroundWorker1.ReportProgress(j++ * 100 / tabla.Rows.Count);
            }
        }
        public static void averageColumnas(ref DataTable tabla, ref List<clsVariable> listadoGeneral, int[] colsToCalc)
        {
            string colName = ""; //getColName

            int j = 1;
            foreach (DataRow fila in tabla.Rows)
            {
                double valor = 0;
                foreach (int index in colsToCalc)
                {
                    valor += double.Parse(fila[index].ToString());
                }
                fila[colName] = valor / colsToCalc.Length; //agregar el valor en la tabla y en la lista de columnas outs
                //backgroundWorker1.ReportProgress(j++ * 100 / tabla.Rows.Count);
            }
        }
        public static void geometricMeanColumnas(ref DataTable tabla, ref List<clsVariable> listadoGeneral, int[] colsToCalc)
        {
            string colName = ""; //getColName

            int j = 1;
            foreach (DataRow fila in tabla.Rows)
            {
                double valor = 1;
                foreach (int index in colsToCalc)
                {
                    valor *= double.Parse(fila[index].ToString());
                }
                fila[colName] = Math.Pow(valor, 1/colsToCalc.Length); //agregar el valor en la tabla y en la lista de columnas outs
                //backgroundWorker1.ReportProgress(j++ * 100 / tabla.Rows.Count);
            }
        }
        //public static void EuclidDistanceColumnas(ref DataTable tabla, ref List<columnas> listadoGeneral, int[] colsToCalc)
        //{
        //    double valor = 1;
        //    string colName = ""; //getColName

        //    int j = 1;
        //    /*foreach (DataRow fila in tabla.Rows)
        //    {
        //        foreach (int index in colsToCalc)
        //        {
        //            valor *= double.Parse(fila[index].ToString());
        //        }
        //        fila[colName] = Math.Pow(valor, 1 / colsToCalc.Length; //agregar el valor en la tabla y en la lista de columnas outs
        //        //backgroundWorker1.ReportProgress(j++ * 100 / tabla.Rows.Count);
        //    }*/
        //}
        #endregion
    }
}
