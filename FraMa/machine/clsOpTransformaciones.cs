using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FraMa
{
    public class clsOpTransformaciones 
    {
        #region Borrar
        //enum calculos
        //{
        //    absoluteValue,
        //    numericalPower,
        //    exponential,
        //    logaritm
        //}

        //public DataTable tabla { get; set; }

        //public DataTable tabla = new DataTable();
        //public DataTable res = new DataTable();
        //public double exponente = 0d;
        //public double baseLogth = 0d;

        //public string generarPredicado(clsVariable variables, string abreviaturaOperacion)
        //{

        //    throw new NotImplementedException();
        //}

        //public void Operar(string formula, params List<clsVariable>[] variables)
        //{
        //    //var continuas = variables[0];
        //    //var temporales = variables[1];

        //    //switch (formula)
        //    //{
        //    //    case "absoluteValue":
        //    //        AbsoluteValue();
        //    //        break;
        //    //    case "numericalPower":
        //    //        NumericalPower();
        //    //        break;
        //    //    case "logaritmo":
        //    //        Logaritmo();
        //    //        break;
        //    //    case "exponencial":
        //    //        Exponencial();
        //    //        break;
        //    //    default:
        //    //        break;
        //    //}
        //}

        //private void AbsoluteValue(params List<clsVariable>[] listaVariables)
        //{
        //    foreach (var listas in listaVariables)
        //    {
        //        if (!listas.Any())
        //        {
        //            DataColumn Columna;
        //            foreach (clsVariable variable in listas)
        //            {
        //                var nombreCol = string.Format("Abs|{0}|" + variable.NombreCorto);
        //                Columna = new DataColumn
        //                {
        //                    DataType = System.Type.GetType("System.Decimal"),
        //                    ColumnName = nombreCol
        //                };
        //                res.Columns.Add(Columna);

        //                DataRow dr;
        //                foreach (DataRow item in tabla.Rows)
        //                {
        //                    dr = res.NewRow();
        //                    //dr[1] = item[tabla.Columns[index].ColumnName;
        //                    //item[numeroCol] = 4;
        //                    dr[nombreCol] = Math.Abs((double)item[variable.ColumnaNo]);
        //                    res.Rows.Add(dr);
        //                }
        //                //TODO: Numerar la base de datos para poder unir las tablas !!!importante
        //            }
        //        }
        //    }
        //}
        //private void NumericalPower(params List<clsVariable>[] listaVariables)
        //{
        //    foreach (var listas in listaVariables)
        //    {
        //        if (!listas.Any())
        //        {
        //            DataColumn Columna;
        //            foreach (clsVariable variable in listas)
        //            {
        //                var nombreCol = string.Format("NumPow({0})" + variable.NombreCorto);
        //                Columna = new DataColumn
        //                {
        //                    DataType = System.Type.GetType("System.Decimal"),
        //                    ColumnName = nombreCol
        //                };
        //                res.Columns.Add(Columna);

        //                DataRow dr;
        //                foreach (DataRow item in tabla.Rows)
        //                {
        //                    dr = res.NewRow();
        //                    //dr[1] = item[tabla.Columns[index].ColumnName;
        //                    //item[numeroCol] = 4;
        //                    dr[nombreCol] = Math.Pow((double)item[variable.ColumnaNo],exponente);
        //                    res.Rows.Add(dr);
        //                }
        //                //TODO: Numerar la base de datos para poder unir las tablas !!!importante
        //            }
        //        }
        //    }
        //}
        //private void Logaritmo(params List<clsVariable>[] listaVariables)
        //{
        //    foreach (var listas in listaVariables)
        //    {
        //        if (!listas.Any())
        //        {
        //            DataColumn Columna;
        //            foreach (clsVariable variable in listas)
        //            {
        //                var nombreCol = string.Format("Logth({0})" + variable.NombreCorto);
        //                Columna = new DataColumn
        //                {
        //                    DataType = System.Type.GetType("System.Decimal"),
        //                    ColumnName = nombreCol
        //                };
        //                res.Columns.Add(Columna);

        //                DataRow dr;
        //                foreach (DataRow item in tabla.Rows)
        //                {
        //                    dr = res.NewRow();
        //                    //dr[1] = item[tabla.Columns[index].ColumnName;
        //                    //item[numeroCol] = 4;
        //                    dr[nombreCol] = Math.Log((double)item[variable.ColumnaNo], baseLogth);
        //                    res.Rows.Add(dr);
        //                }
        //                //TODO: Numerar la base de datos para poder unir las tablas !!!importante
        //            }
        //        }
        //    }
        //}
        ////TODO: Preguntar
        //private void Exponencial(params List<clsVariable>[] listaVariables)
        //{
        //    foreach (var listas in listaVariables)
        //    {
        //        if (!listas.Any())
        //        {
        //            DataColumn Columna;
        //            foreach (clsVariable variable in listas)
        //            {
        //                var nombreCol = string.Format("Exp({0})" + variable.NombreCorto);
        //                Columna = new DataColumn
        //                {
        //                    DataType = System.Type.GetType("System.Decimal"),
        //                    ColumnName = nombreCol
        //                };
        //                res.Columns.Add(Columna);

        //                DataRow dr;
        //                foreach (DataRow item in tabla.Rows)
        //                {
        //                    dr = res.NewRow();
        //                    //dr[1] = item[tabla.Columns[index].ColumnName;
        //                    //item[numeroCol] = 4;
        //                    dr[nombreCol] = Math.Exp((double)item[variable.ColumnaNo]);
        //                    res.Rows.Add(dr);
        //                }
        //                //TODO: Numerar la base de datos para poder unir las tablas !!!importante
        //            }
        //        }
        //    }
        //}

        //public void Dispose()
        //{
        //    tabla.Dispose();
        //    res.Dispose();
        //    GC.SuppressFinalize(this);
        //}
        #endregion
        //1 ABVA  Absolute Value       C   NULL  ABVA - C - NULL
        public void AbsoluteValue(ref DataTable tabla, int colNumero, int colQuery)
        {
            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                tabla.Rows[i][colNumero] = Math.Abs((double)tabla.Rows[i][colQuery]);
            }
            #region Borrar
            //var i = 0;
            //foreach (DataRow item in tabla.Rows)
            //{
            //    //dr = res.NewRow();
            //    ////dr[1] = item[tabla.Columns[index].ColumnName;
            //    ////item[numeroCol] = 4;
            //    //dr[nombreCol] = Math.Abs((double)item[variable.ColumnaNo]);
            //    //dr[columnaNombre] = Math.Abs((double)item[columnaNo]);
            //    //res.Rows.Add(dr);
            //    tabla.Rows[i][colNumero] = Math.Abs((double)item[columnaNo]);
            //    i++;
            //}
            #endregion
        }
        //1 EXPO  Exponential          C   NULL  EXPO - C - NULL
        public void ExponencialEuler(ref DataTable tabla, int colNumero, int colQuery)
        {
            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                tabla.Rows[i][colNumero] = Math.Exp((double)tabla.Rows[i][colQuery]);
            }
            #region borrar
            //var i = 0;
            //foreach (DataRow item in tabla.Rows)
            //{
            //    tabla.Rows[i][colNumero] = Math.Exp((double)item[columnaNo]);
            //    i++;
            //}
            #endregion
        }
        //1 EXPO  Exponential          C   NULL  EXPO - C - NULL
        public void Exponencial(ref DataTable tabla, int colNumero, int colQuery, double exponente)
        {
            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                tabla.Rows[i][colNumero] = Math.Pow((double)tabla.Rows[i][colQuery], exponente);
            }
        }
        //1 LOGH  Logharitm            C   NULL  LOGH - C - NULL
        public void Logaritmo(ref DataTable tabla, int colNumero, int colQuery, double baseLog)
        {
            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                tabla.Rows[i][colNumero] = Math.Log((double)tabla.Rows[i][colQuery], baseLog);
            }
        }
        //1 MMPR  Min-Max Probability  C   NULL  MMPR - C - NULL
        public void MinMaxProbability(ref DataTable tabla, int colNumero, int colQuery)
        {
            var temp = tabla.Copy();
            var levels = tabla.AsEnumerable().Select(al => al.Field<double>(temp.Columns[colQuery].ColumnName)).Distinct().ToList();

            var min = levels.Min();
            var max = levels.Max();
            var divisor = levels.Max() - levels.Min();

            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                tabla.Rows[i][colNumero] = ((double)(double)tabla.Rows[i][colQuery] - min) / divisor;
            }
        }
        //1 NUPO  Numerical Power      C   NULL  NUPO - C - NULL
        public void NumericalPower(ref DataTable tabla, int colNumero, int colQuery, double exp)
        {
            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                tabla.Rows[i][colNumero] = Math.Pow((double)tabla.Rows[i][colQuery], exp);
            }
        }
       
        //1 IDET  Identity             C   NULL  IDET - C - NULL
        public void Identity(ref DataTable tabla, int colNumero, int colQuery)
        {
            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                tabla.Rows[i][colNumero] = tabla.Rows[i][colQuery];
            }
        }

        //1 ZSCT  zScore               C   C     ZSCT - C - C
        public void ZScore(ref DataTable tabla, int colNumero, int colQuery)
        {
            double promedio = clsOpeUnitarias.Average(tabla, colNumero, colQuery);
            double desviacionS = clsOpeUnitarias.DesviacionEstandar(tabla, colNumero, colQuery);

            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                tabla.Rows[i][colNumero] = ((double)tabla.Rows[i][colQuery] - promedio)/desviacionS;
            }
        }
        //valor - promedio / desviacion estandar muestral 
        #region borrar


        //public void NumericalPower(string columnaNombre, int columnaNo, double exp)
        //{
        //    DataColumn Columna;
        //    res.Clear();
        //    //var nombreCol = string.Format("NumPow({0})" + variable.NombreCorto);
        //    Columna = new DataColumn
        //    {
        //        DataType = System.Type.GetType("System.Decimal"),
        //        //ColumnName = nombreCol
        //        ColumnName = columnaNombre
        //    };
        //    res.Columns.Add(Columna);

        //    DataRow dr;
        //    foreach (DataRow item in tabla.Rows)
        //    {
        //        dr = res.NewRow();
        //        //dr[1] = item[tabla.Columns[index].ColumnName;
        //        //item[numeroCol] = 4;
        //        //dr[nombreCol] = Math.Pow((double)item[variable.ColumnaNo], exponente);
        //        dr[columnaNombre] = Math.Pow((double)item[columnaNo], exp);
        //        res.Rows.Add(dr);
        //    }
        //    //TODO: Numerar la base de datos para poder unir las tablas !!!importante
        //}

        //public void MinMaxProbability(string columnaNombre, int columnaNo)
        //{
        //    DataColumn Columna;
        //    res.Clear();

        //    //https://stackoverflow.com/questions/2442525/how-to-select-min-and-max-values-of-a-column-in-a-datatable
        //    var levels = tabla.AsEnumerable().Select(al => al.Field<double>(columnaNombre)).Distinct().ToList();
        //    var min = levels.Min();
        //    //var prueba = levels.StandardDeviation();
        //    //double max = levels.Max();
        //    var divisor = levels.Max() - levels.Min();

        //    Columna = new DataColumn
        //    {
        //        DataType = System.Type.GetType("System.Double"),
        //        ColumnName = columnaNombre
        //    };
        //    res.Columns.Add(Columna);
        //    DataRow dr;
        //    foreach (DataRow item in tabla.Rows)
        //    {
        //        dr = res.NewRow();
        //        dr[columnaNombre] = ((double)item[columnaNo] - min) / divisor;
        //        res.Rows.Add();
        //    }
        //}

        //public void Logaritmo(string columnaNombre, int columnaNo, double baseLog)
        //{
        //    DataColumn Columna;
        //    res.Clear();

        //    //var nombreCol = string.Format("Logth({0})" + variable.NombreCorto);
        //    Columna = new DataColumn
        //    {
        //        DataType = System.Type.GetType("System.Double"),
        //        //ColumnName = nombreCol
        //        ColumnName = columnaNombre
        //    };
        //    res.Columns.Add(Columna);

        //    DataRow dr;
        //    foreach (DataRow item in tabla.Rows)
        //    {
        //        dr = res.NewRow();
        //        //dr[1] = item[tabla.Columns[index].ColumnName;
        //        //item[numeroCol] = 4;
        //        //dr[nombreCol] = Math.Log((double)item[variable.ColumnaNo], baseLogth);
        //        dr[columnaNombre] = Math.Log((double)item[columnaNo], baseLog);
        //        res.Rows.Add(dr);
        //    }
        //    //TODO: Numerar la base de datos para poder unir las tablas !!!importante
        //}

        //public void ExponencialEuler(string columnaNombre, int columnaNo)
        //{
        //    DataColumn Columna;
        //    res.Clear();
        //    //var nombreCol = string.Format("NumPow({0})" + variable.NombreCorto);
        //    Columna = new DataColumn
        //    {
        //        DataType = System.Type.GetType("System.Decimal"),
        //        //ColumnName = nombreCol
        //        ColumnName = columnaNombre
        //    };
        //    res.Columns.Add(Columna);

        //    DataRow dr;
        //    foreach (DataRow item in tabla.Rows)
        //    {
        //        dr = res.NewRow();
        //        //dr[1] = item[tabla.Columns[index].ColumnName;
        //        //item[numeroCol] = 4;
        //        //dr[nombreCol] = Math.Pow((double)item[variable.ColumnaNo], exponente);
        //        dr[columnaNombre] = Math.Exp((double)item[columnaNo]);
        //        res.Rows.Add(dr);
        //    }
        //    //TODO: Numerar la base de datos para poder unir las tablas !!!importante
        //}
        //public void AbsoluteValue(string columnaNombre, int columnaNo)
        //{
        //    DataColumn Columna;
        //    res.Clear();
        //    //var nombreCol = string.Format("Abs|{0}|" + variable.NombreCorto);
        //    Columna = new DataColumn
        //    {
        //        DataType = System.Type.GetType("System.Decimal"),
        //        //ColumnName = nombreCol
        //        ColumnName = columnaNombre
        //    };
        //    res.Columns.Add(Columna);

        //    DataRow dr;
        //    foreach (DataRow item in tabla.Rows)
        //    {
        //        dr = res.NewRow();
        //        ////dr[1] = item[tabla.Columns[index].ColumnName;
        //        ////item[numeroCol] = 4;
        //        //dr[nombreCol] = Math.Abs((double)item[variable.ColumnaNo]);
        //        dr[columnaNombre] = Math.Abs((double)item[columnaNo]);
        //        res.Rows.Add(dr);
        //    }//TODO: Numerar la base de datos para poder unir las tablas !!!importante
        //}
        //1 EXPO  Exponential          C   NULL  EXPO - C - NULL
        //public void ExponencialEuler(string columnaNombre, int columnaNo)
        //{
        //    DataColumn Columna;
        //    res.Clear();
        //    //var nombreCol = string.Format("NumPow({0})" + variable.NombreCorto);
        //    Columna = new DataColumn
        //    {
        //        DataType = System.Type.GetType("System.Decimal"),
        //        //ColumnName = nombreCol
        //        ColumnName = columnaNombre
        //    };
        //    res.Columns.Add(Columna);

        //    DataRow dr;
        //    foreach (DataRow item in tabla.Rows)
        //    {
        //        dr = res.NewRow();
        //        //dr[1] = item[tabla.Columns[index].ColumnName;
        //        //item[numeroCol] = 4;
        //        //dr[nombreCol] = Math.Pow((double)item[variable.ColumnaNo], exponente);
        //        dr[columnaNombre] = Math.Exp((double)item[columnaNo]);
        //        res.Rows.Add(dr);
        //    }
        //    //TODO: Numerar la base de datos para poder unir las tablas !!!importante
        //}
        #endregion
    }
}