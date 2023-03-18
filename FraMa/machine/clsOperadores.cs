using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.Statistics;
using System.Diagnostics;


namespace FraMa
{
    public class clsOperadores
    {
        private DataTable max(DataTable tabla, int columnaGrouping, int columnaContinua)
        {
            var query = from row in tabla.AsEnumerable()
                        group row by row.Field<string>(tabla.Columns[columnaGrouping].ColumnName) into groupings
                        select new
                        {
                            nombre = groupings.Key,
                            valor = (double)groupings.Max(p => p.Field<double>(tabla.Columns[columnaContinua].ColumnName))
                        };
            return Auxiliares.LINQResultToDataTable(query);
        }

        private DataTable min(DataTable tabla, int columnaGrouping, int columnaContinua)
        {
            var query = from row in tabla.AsEnumerable()
                        group row by row.Field<string>(tabla.Columns[columnaGrouping].ColumnName) into groupings
                        select new
                        {
                            nombre = groupings.Key,
                            valor = (double)groupings.Max(p => p.Field<double>(tabla.Columns[columnaContinua].ColumnName))
                        };
            return Auxiliares.LINQResultToDataTable(query);
        }

        private DataTable promedio(DataTable tabla, int columnaGrouping, int columnaContinua)
        {
            var query = from row in tabla.AsEnumerable()
                        group row by row.Field<string>(tabla.Columns[columnaGrouping].ColumnName) into groupings
                        select new
                        {
                            nombre = groupings.Key,
                            valor = (double)groupings.Average(p => p.Field<double>(tabla.Columns[columnaContinua].ColumnName))
                        };
            return Auxiliares.LINQResultToDataTable(query);
        }
        private DataTable cuenta(DataTable tabla, string columnaGrouping)
        {
            var query = from row in tabla.AsEnumerable()
                        group row by row.Field<string>(columnaGrouping) into groupings
                        select new
                        {
                            nombre = groupings.Key,
                            valor = (double)groupings.Count()
                        };
            return Auxiliares.LINQResultToDataTable(query);
        }
        private DataTable suma(DataTable tabla, int columnaGrouping, int columnaContinua)
        {
            var query = from row in tabla.AsEnumerable()
                        group row by row.Field<string>(tabla.Columns[columnaGrouping].ColumnName) into groupings
                        select new
                        {
                            nombre = groupings.Key,
                            valor = (double)groupings.Sum(p => p.Field<double>(tabla.Columns[columnaContinua].ColumnName))
                        };
            return Auxiliares.LINQResultToDataTable(query);
        }
        //private DataTable desviacionStandar(string columnaNombre)
        //{
        //    var query = from row in tabla.AsEnumerable()
        //                group row by row.Field<string>(columnaNombre) into groupings
        //                select new
        //                {
        //                    //MathNet.Numerics.Statistics.Statistics.StandardDeviation()
        //                    nombre = groupings.Key,
        //                    valor = (double)groupings. StandardDeviation(p => p.Field<double>(columnaNombre))
        //                };
        //    return LINQResultToDataTable(query);
        //}

        double getValorDeTabla(DataTable tablaObjetivo, string buscar)
        {
            double res = -1;
            DataRow dr;// = tablaObjetivo.Select(string.Format("{0} = {1}", "nombre", buscar)).FirstOrDefault();
            dr = tablaObjetivo.Select(string.Format("{0} = {1}", "nombre", "'"+ buscar + "'")).FirstOrDefault();
            double.TryParse(dr["valor"].ToString(), out res);
            return res;
        }


        double getValorDeTabla(DataTable tablaObjetivo, string colName, string buscar)
        {
            double res = -1;
            DataRow dr;// = tablaObjetivo.Select(string.Format("{0} = {1}", "nombre", buscar)).FirstOrDefault();
            dr = tablaObjetivo.Select(string.Format("{0} = {1}", colName, "'" + buscar + "'")).FirstOrDefault();
            double.TryParse(dr["valor"].ToString(), out res);
            return res;
        }


        //4 ARMG  Armonic Mean Sum     G   C     ARMG - G - C

        //4 AVEG  Average Mean         G   C     AVEG - G - C
        public void averagePorLevel(ref DataTable tabla, int colNumero, int colGrouping, int colContinua)
        {
            //var tablaTemp = tabla1.Copy();
            var temp = promedio(tabla, colGrouping, colContinua);

            var i = 0;
            foreach (DataRow item in tabla.Rows)
            {
                tabla.Rows[i][colNumero] = (double)getValorDeTabla(temp, item[colGrouping].ToString());
                i++;
            }
        }

        //4 ECDG  Euclidean Dist       G   C     ECDG - G - C
        //4 GEMG  Geometric Mean       G   C     GEMG - G - C
        //4 MHDG  Manhatan Dist        G   C     MHDG - G - C
        //4 MMPG  Min Max Probability  G   C     MMPG - G - C
        public void MinMaxProb(ref DataTable tabla, int colNumero, int colGrouping, int colContinua)
        {
            var maximo = max(tabla, colGrouping, colContinua);
            var minimo = min(tabla, colGrouping, colContinua);

            var i = 0;
            foreach (DataRow item in tabla.Rows)
            {
                double valMin = getValorDeTabla(minimo, item[colGrouping].ToString());
                double valMax = getValorDeTabla(maximo, item[colGrouping].ToString());
                tabla.Rows[i][colNumero] = ((double)item[colContinua] - valMin)/valMax - valMin; 
                i++;
            }
        }
        //4 MVAG  Moving Average       G   C     MVAG - G - C
        public void MovingAverage(ref DataTable tabla1, int colNumero, int colGrouping, int colContinua)
        {
            var temp = promedio(tabla1, colGrouping, colContinua);

            var i = 0;
            foreach (DataRow item in tabla1.Rows)
            {
                tabla1.Rows[i][colNumero] = (double)item[colContinua] - getValorDeTabla(temp, item[colGrouping].ToString());
                i++;
            }
        }

        //4 STDG  StandarDeviation     G   C     STDG - G - C
        public void StandarDeviation(ref DataTable tabla1, int colNumero, int colGrouping, int colContinua)
        {
            var prom = promedio(tabla1, colGrouping, colContinua);
            var cont = cuenta(tabla1, tabla1.Columns[colGrouping].ColumnName);

            Debug.WriteLine("entra:" + tabla1.Columns.Count);
            var i = 0;
            foreach (DataRow item in tabla1.Rows)
            {
                tabla1.Rows[i][colNumero] = ((double)item[colContinua] - getValorDeTabla(prom, tabla1.Rows[i][colGrouping].ToString()))/ (getValorDeTabla(cont, tabla1.Rows[i][colGrouping].ToString()) - 1);
                i++;
            }
        }
        //4 SUMG  Sum for grouping     G   C     SUMG - G - C
        public void sumaPorLevel(ref DataTable tabla, int colNumero, int colGrouping, int colContinua)
        {
            var temp = suma(tabla, colGrouping, colContinua);

            var i = 0;
            foreach (DataRow item in tabla.Rows)
            {
                tabla.Rows[i][colNumero] = (double)getValorDeTabla(temp, item[colGrouping].ToString());
                i++;
            }
        }
        //4 ZSCG  ZScore               G   C     ZSCG - G - C
        public void zScore(ref DataTable tabla, int colNumero, int colGrouping, int colContinua)
        {
            var prom = promedio(tabla, colGrouping, colContinua);
            var std = tabla.Copy();
            int nuevaCol = 0;

            DataColumn Columna;
            Columna = new DataColumn
            {
                DataType = System.Type.GetType("System.Double"),
                ColumnName = "temp",
                DefaultValue = 0
            };
            std.Columns.Add(Columna);
            nuevaCol = std.Columns.Count - 1;

            StandarDeviation(ref std, nuevaCol, colGrouping, colContinua);

            DataView dv = new DataView(std);
            var tablas = dv.ToTable(false, std.Columns[0].ColumnName, std.Columns[nuevaCol].ColumnName); //se obtienen las dos columnas
            tablas.Columns[0].ColumnName = "nombre";
            tablas.Columns[1].ColumnName = "valor";

            var i = 0;
            foreach (DataRow item in tabla.Rows)
            {
                Debug.WriteLine(getValorDeTabla(prom, item[colGrouping].ToString()));
                tabla.Rows[i][colNumero] = ((double)item[colContinua] - getValorDeTabla(prom, item[colGrouping].ToString()))/getValorDeTabla(tablas, item[colGrouping].ToString());
                i++;
            }
        }
        #region No Usados
        //TODO: Grouping Continua
        //enum calculos
        //{
        //    sumGruoupin,
        //    armonicMeanSum,
        //    zScore,
        //    standarDev,
        //    manhatanDist,
        //    euclidianDist,
        //    averageMean,
        //    movingAverage,
        //    geometricMean
        //}

        //public DataTable tabla = new DataTable();
        //public DataTable res = new DataTable();

        //DataTable tablapromedios = new DataTable();

        //private DataTable promedio(int columnaGrouping, int columnaContinua)
        //{
        //    var query = from row in tabla.AsEnumerable()
        //                group row by row.Field<string>(tabla.Columns[columnaGrouping].ColumnName) into groupings
        //                select new
        //                {
        //                    nombre = groupings.Key,
        //                    valor = (double)groupings.Average(p => p.Field<double>(tabla.Columns[columnaContinua].ColumnName))
        //                };
        //    return Auxiliares.LINQResultToDataTable(query);
        //}


        //public void Operar(string formula, params List<clsVariable>[] variables)
        //{
        //    //var listaGrouping = variables[0];
        //    //var listaContinua = variables[1];

        //    //switch (formula)
        //    //{
        //    //    case "sumGruoupin":
        //    //        res = SumGruoupin(null, null);
        //    //        break;
        //    //    //case "armonicMeanSum":
        //    //    //    ArmonicMeanSum();
        //    //    //    break;
        //    //    //case "zScore":
        //    //    //    ZScore();
        //    //    //    break;
        //    //    //case "standarDev":
        //    //    //    StandarDev();
        //    //    //    break;
        //    //    //case "manhatanDist":
        //    //    //    ManhatanDist();
        //    //    //    break;
        //    //    //case "euclidianDist":
        //    //    //    EuclidianDist();
        //    //    //    break;
        //    //    case "averageMean":
        //    //        res = AverageMean(null, null);
        //    //        break;
        //    //    case "movingAverage":
        //    //        res = MovingAverage(null, null);
        //    //        break;
        //    //    //case "geometricMean":
        //    //    //    GeometricMean();
        //    //    //    break;
        //    //}
        //}

        //private DataTable MovingAverage(clsVariable grouping, clsVariable continua)
        //{
        //    var TablaPromedios = new DataTable();

        //    var query = from tablaExcel in tabla.AsEnumerable()
        //                join tablaPromedios in TablaPromedios.AsEnumerable()
        //                        on (string)tablaExcel[grouping.NombreColumna] equals (string)tablaPromedios[grouping.NombreColumna]
        //                select new
        //                {
        //                    id = tablaExcel[grouping.NombreColumna],
        //                    promedio = ((double)tablaExcel[continua.NombreCorto] - (double)tablaPromedios[continua.NombreCorto]),
        //                };
        //    return Auxiliares.LINQResultToDataTable(query);
        //}
        //private DataTable SumGruoupin(clsVariable grouping, clsVariable continua)
        //{
        //    var query = (from fila in tabla.AsEnumerable()
        //                 group fila by
        //                     fila.Field<string>(grouping.NombreColumna)
        //                 into g
        //                 select new
        //                 {
        //                     id = g.Key,
        //                     valor = (double?)g.Sum(p => p.Field<double>(continua.NombreColumna))
        //                 });

        //    return Auxiliares.LINQResultToDataTable(query);
        //}
        //private DataTable AverageMean(clsVariable grouping, clsVariable continua)
        //{
        //    var query = (from fila in tabla.AsEnumerable()
        //                 group fila by
        //                     fila.Field<string>(grouping.NombreColumna)
        //                 into g
        //                 select new
        //                 {
        //                     id = g.Key,
        //                     valor = (double?)g.Average(p => p.Field<double>(continua.NombreColumna))

        //                 });

        //    return Auxiliares.LINQResultToDataTable(query);
        //}

        #endregion
    }
}