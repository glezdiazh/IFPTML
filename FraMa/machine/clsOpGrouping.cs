using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FraMa
{
    public class clsOpGrouping
    {
        //public DataTable tabla = new DataTable();
        //public DataTable res = new DataTable();
        
        private DataTable cuenta(DataTable table, int columnaNo)
        {
            var query = from row in table.AsEnumerable()
                        group row by row.Field<string>(table.Columns[columnaNo].ColumnName) into groupings
                        select new
                        {
                            nombre = groupings.Key,
                            cuenta = groupings.Count()
                        };
            return Auxiliares.LINQResultToDataTable(query);
        }
        public double getValorDeTabla(DataTable tablaObjetivo, string buscar)
        {
            double res = -1;
            DataRow dr = tablaObjetivo.Select(string.Format("{0} = {1}", "nombre", "'" + buscar + "'")).FirstOrDefault();
            double.TryParse(dr["cuenta"].ToString(), out res);
            return res;
        }
        //public DataTable LINQResultToDataTable<T>(IEnumerable<T> Linqlist)
        //{
        //    var dt = new DataTable();

        //    PropertyInfo[] columns = null;

        //    if (Linqlist == null) return dt;

        //    foreach (T Record in Linqlist)
        //    {
        //        if (columns == null)
        //        {
        //            columns = ((Type)Record.GetType()).GetProperties();
        //            foreach (PropertyInfo GetProperty in columns)
        //            {
        //                Type colType = GetProperty.PropertyType;

        //                if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition()
        //                == typeof(Nullable<>)))
        //                {
        //                    colType = colType.GetGenericArguments()[0];
        //                }

        //                dt.Columns.Add(new DataColumn(GetProperty.Name, colType));
        //            }
        //        }
        //        DataRow dr = dt.NewRow();

        //        foreach (PropertyInfo pinfo in columns)
        //        {
        //            dr[pinfo.Name] = pinfo.GetValue(Record, null) == null ? DBNull.Value : pinfo.GetValue
        //            (Record, null);
        //        }
        //        dt.Rows.Add(dr);
        //    }
        //    return dt;
        //}

        //0 IDEN  Identity             G   NULL  IDEN - G - NULL        
        public void Identity(ref DataTable tabla, int columna, int colQuery) //int string columnaNombre, int columnaNo)
        {
            Auxiliares.ConvertColumnType(tabla, tabla.Columns[columna].ColumnName, typeof(string));
            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                tabla.Rows[i][columna] = tabla.Rows[i][colQuery];
            }
            #region Borrar
            //DataRow dr;
            //foreach (DataRow item in tabla.Rows)
            //{
            //    dr = res.NewRow();
            //    dr[columnaNombre] = item[columnaNo];
            //    res.Rows.Add(dr);
            //}
            #endregion
        }
        //0 PROB  Probability          G   NULL  PROB - G - NULL        cuenta por level/n
        public void Probabilidad(ref DataTable tabla, int columna, int colQuery)
        {
            DataTable aux = cuenta(tabla, colQuery);
            var totalCols = tabla.Rows.Count;
            
            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                tabla.Rows[i][columna] = getValorDeTabla(aux, tabla.Rows[i][colQuery].ToString()) / totalCols;
            }
            #region MyRegion
            //var tempo = new DataTable();

            //tempo = cuenta(tabla, columnaNombre);
            //DataRow dr;
            //int i = 0;
            //foreach (DataRow item in tabla.Rows)
            //{
            //    //dr = res.NewRow();
            //    //dr[columnaNombre] = getValorDeTabla(tempo, item[columnaNo].ToString()) / totalCols;
            //    //res.Rows.Add(dr);
            //    tabla.Rows[i][columnaNombre] = getValorDeTabla(tempo, item[tabla.Columns[columnaNo]].ToString());
            //    i++;
            //}
            #endregion
            
        }
        //0 SHAN  Shanon               G   NULL  SHAN - G - NULL        entropia = probabilidad*log base 2 de probabilidads
        //public void Shannon(ref DataTable tabla, string columnaNombre, int columnaNo, double baseLog)
        public void Shannon(ref DataTable tabla, int columna, int colQuery, double baseLog)
        {
            var tempo = tabla.Copy();
            Probabilidad(ref tempo, columna, colQuery);
            var i = 0;
            foreach (DataRow item in tempo.Rows)
            {
                tabla.Rows[i][colQuery] = (double)item[0] * Math.Log((double)item[0], baseLog);
                i++;
            }
            #region borrar
            //tempo = res.Copy();
            //res.Clear();

            //DataRow dr;
            //var i = 0;
            //foreach (DataRow item in tempo.Rows)
            //{
            //    //dr = res.NewRow();
            //    //dr[columnaNombre] = (double)item[0]*Math.Log((double)item[0], baseLog);
            //    //res.Rows.Add(dr);

            //    tabla.Rows[i][columnaNombre] = (double)item[0] * Math.Log((double)item[0], baseLog);
            //    i++;
            //}
            #endregion
        }
        //0 COUN  Count                G   NULL  COUN - G - NULL        contar por levels
        public void Contar(ref DataTable tabla, int columna, int colQuery)
        {
            DataTable aux = cuenta(tabla, colQuery);
            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                tabla.Rows[i][columna] = getValorDeTabla(aux, tabla.Rows[i][colQuery].ToString());
            }
            #region MyRegion
            //DataTable tempo = tabla.Copy();
            ////DataColumn Columna;
            ////res.Clear();

            ////Columna = new DataColumn
            ////{
            ////    DataType = System.Type.GetType("System.String"),
            ////    ColumnName = columnaNombre
            ////};
            ////res.Columns.Add(Columna);
            //tempo = cuenta(tempo, columnaNombre);

            ////DataRow dr;
            ////var i = 0;
            //foreach (DataRow item in tabla.Rows)
            //{
            //    //dr = res.NewRow();
            //    //dr[columnaNombre] = getValorDeTabla(tempo, item[columnaNo].ToString());
            //    //res.Rows.Add(dr);
            //    tabla.Rows[i][columnaNombre] = getValorDeTabla(tempo, item[columnaNo].ToString());
            //}
            #endregion
        }
    }
}
