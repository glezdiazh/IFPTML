using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;
using System.Linq;


using Accord.Math;
using Accord.IO;
using System.IO;
using System.ComponentModel;

namespace FraMa
{
    //Paralell
    public static class datos
    {
        #region PasosoIniciales
        /// <summary>
        /// Obtiene una lista de string con los nombres de las columnas de la tabla de excel.
        /// 1. Cargar el archivo de excel
        /// 2. Limpiar la data
        /// 3. Obtener el listado de nombres de columnas
        /// </summary>
        /// <param name="datosExcel">Tabla Original de excel</param>
        /// <returns>array string con los nombres de las tablas</returns>
        public static string[] getVarsGenerales(DataTable datosExcel)
        {
            var listado = new List<string>();
            clsVariable c;

            foreach (DataColumn col in datosExcel.Columns)
            {
                c = new clsVariable(col.Ordinal, col.ColumnName);
                listado.Add(c.Nombre);
            }
            return listado.ToArray();
        }

        public static List<clsVariable> getVariablesGenerales(DataTable datosExcel)
        {
            return getVarsFormExcel(datosExcel);
        }

        private static List<clsVariable> getVarsFormExcel(DataTable datosExcel)
        {
            var listado = new List<clsVariable>();
            clsVariable c;

            foreach (DataColumn col in datosExcel.Columns)
            {
                c = new clsVariable(col.Ordinal, col.ColumnName);
                listado.Add(c);
            }

            //var listado = new List<columnas>();
            //columnas c;

            //foreach (DataColumn col in datosExcel.Columns)
            //{
            //    c = new columnas(col.Ordinal, col.ColumnName);
            //    listado.Add(c);
            //}

            return listado;
        }
        #endregion

        #region Missing Values: Promediar Eliminar MD
        /// <summary>
        /// Cambia missing values por el promedio de los datos de la columna
        /// </summary>
        /// <param name="tablaExcel">Datos originales de excel</param>
        /// <param name="index">indice de la columna a desarrollar</param>
        public static void missingValuesPromedio(ref DataTable tablaExcel, int index)
        {
            object[] prevalores = columnaToObjectArray(tablaExcel, index);
            double cuentaNoNulos = prevalores.Count(x => !string.IsNullOrEmpty(x.ToString()));
            double suma = prevalores.Where(x => !string.IsNullOrWhiteSpace(x.ToString())).Cast<double>().Sum();

            double? promedio = suma / cuentaNoNulos;

            foreach (DataRow dr in tablaExcel.Rows)
            {
                if (string.IsNullOrEmpty(dr[index].ToString()))
                {
                    dr[index] = promedio;
                }
            }
        }
        /// <summary>
        /// Elimina los datos nulos o vacios de la columna
        /// </summary>
        /// <param name="tablaExcel">Datos originales de excel</param>
        /// <param name="index">indice de la columna a desarrollar</param>
        public static void missingValuesRemove(ref DataTable tablaExcel, int index)
        {
            Debug.WriteLine("Antes: " + tablaExcel.Rows.Count.ToString());
            DataTable temp = tablaExcel.Copy();

            foreach (DataRow dr in tablaExcel.Rows)
            {
                if (string.IsNullOrEmpty(dr[index].ToString()))
                {
                    dr.Delete();
                }
            }
            temp.AcceptChanges();
            Debug.WriteLine("Se han eliminado: " + tablaExcel.Rows.Count.ToString());
        }
        /// <summary>
        /// Cambia missing values por el MD de los datos de la columna
        /// </summary>
        /// <param name="tablaExcel">Datos originales de excel</param>
        /// <param name="index">indice de la columna a desarrollar</param>
        public static void missingValuesMD(ref DataTable tablaExcel, int index)
        {
            Debug.WriteLine("init: " + DateTime.Now.ToString());
            string missingValue = "MD_";

            DataTable dtCloned = tablaExcel.Clone();
            dtCloned.Columns[index].DataType = typeof(String);
            foreach (DataRow row in tablaExcel.Rows)
            {
                dtCloned.ImportRow(row);
            }

            tablaExcel = dtCloned;

            foreach (DataRow dr in tablaExcel.Rows)
            {
                if (string.IsNullOrEmpty(dr[index].ToString()))
                {
                    dr[index] = missingValue + index.ToString();
                }
            }
            Debug.WriteLine("finish: " + DateTime.Now.ToString());
        }
        #endregion

        #region Levels 

        public static DataTable getLevels(List<clsVariable> InputContinuous, DataTable datosExcel, ref List<clsVariable> groupingVars)
        {
            DataTable res = new DataTable();
            DataTable temp = new DataTable();
            foreach (clsVariable grouping in groupingVars)
            {
                //if (!grouping.generado)
                {
                    temp = getLevelPorGrouping(InputContinuous, datosExcel, grouping.ColumnaNo);
                    res.Merge(temp);
                    //grouping.generado = true;
                }
            }
            return res;
        }

        public static DataTable getLevelPorGrouping(List<clsVariable> InputContinuas, DataTable datosExcel, int grouping )
        {
            DataTable datosLevels = new DataTable();
            List<DataTable> tablas = new List<DataTable>();
            DataView dv = new DataView(datosExcel);
            string nombreColumnaNueva = string.Empty;


            
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////CAMBIADO POR IMPLEMENTACION
            //foreach (clsVariable continuas in InputContinuas)
            //{
            //    datosLevels = dv.ToTable(false, datosExcel.Columns[grouping].ColumnName, datosExcel.Columns[continuas.index].ColumnName);
            //    //string[] operadores = continuas.operaciones.Select(a => a.ToString()).ToArray();
            //    var operadores = continuas.operaciones.Select(a => a.ToString()).ToArray();

            //    DataTable tabla = new DataTable();
            //    foreach (string operacion in operadores)
            //    {
            //        //Debug.WriteLine(continuas.Nombre + " " + operacion);
            //        switch (operacion)
            //        {
            //            case "promedio":
            //                nombreColumnaNueva = "<" + datosExcel.Columns[continuas.index].ColumnName + ">";
            //                tabla = Formulas.promedio(datosLevels, nombreColumnaNueva);
            //                break;
            //            case "suma":
            //                nombreColumnaNueva = "sum_" + datosExcel.Columns[continuas.index].ColumnName;
            //                tabla = Formulas.suma(datosLevels, nombreColumnaNueva);
            //                break;
            //        }
            //        tablas.Add(tabla);
            //    }
            //}
            nombreColumnaNueva = "nij";
            //DataTable tabla1 = Formulas.count(datosLevels, nombreColumnaNueva);
            //tablas.Add(tabla1);
            
            
            DataTable resultado = datos.FullOuterJoinDataTables(tablas.ToArray());
            resultado.Columns.Add("grouping", typeof(int)).SetOrdinal(0);


            foreach (DataRow dr in resultado.Rows)
            {
                dr["grouping"] = grouping;
            }
            
            //resultado.Columns["grouping"].DefaultValue = grouping;

            //DataColumn Col = resultado.Columns.Add("grouping", System.Type.GetType("System.int"));
            //Col.SetOrdinal(0);// to put the column in position 0;
            



            return resultado;

            

        }
        public static DataTable FullOuterJoinDataTables(params DataTable[] datatables) // supports as many datatables as you need.
        {
            DataTable result = datatables.First().Clone();

            var commonColumns = result.Columns.OfType<DataColumn>();

            foreach (var dt in datatables.Skip(1))
            {
                commonColumns = commonColumns.Intersect(dt.Columns.OfType<DataColumn>(), new DataColumnComparer());
            }

            result.PrimaryKey = commonColumns.ToArray();

            foreach (var dt in datatables)
            {
                result.Merge(dt, false, MissingSchemaAction.AddWithKey);
            }

            return result;
        }
        public class DataColumnComparer : IEqualityComparer<DataColumn>
        {
            public bool Equals(DataColumn x, DataColumn y) => x.Caption == y.Caption;

            public int GetHashCode(DataColumn obj) => obj.Caption.GetHashCode();
        }

        #endregion

        private static bool existColumna(DataTable tabla, string column)
        {
            return tabla.Columns.Contains(column) ? true : false;
        }

        public static void addColumn(ref DataTable tabla, string NewColumnName)
        {
            if (!existColumna(tabla, NewColumnName))
            {
                tabla.Columns.Add(NewColumnName);
            }
        }

        //TODO: importante al cargar el archivo de excel
        public static List<clsVariable> CrearColumnas(string[] cols)
        {
            List<clsVariable> listado = new List<clsVariable>();
            int i = 0;
            clsVariable c;
            foreach (string col in cols)
            {
                c = new clsVariable(i, col);
                listado.Add(c);
                i++;
            }
            return listado;
        }

        public static List<clsVariable> CrearColumnas(DataTable datosExcel)
        {
            List<clsVariable> listado = new List<clsVariable>();
            int i = 0;
            clsVariable c;

            foreach (DataColumn col in datosExcel.Columns)
            {
                c = new clsVariable(i, col.ColumnName);
                listado.Add(c);
                i++;
            }
            return listado;
        }

        

        public static void addColumnaToList(ref List<clsVariable> listado, string colNombre)
        {
            clsVariable newCol = new clsVariable(listado.Count, colNombre);
            listado.Add(newCol);
        }

        public static List<string> getNombresCortosPorIndices(List<clsVariable> listadoGeneral, int[] indicesColumnas)
        {
            List<string> nombresCortos = new List<string>();
            clsVariable c = new clsVariable();

            foreach (int indice in indicesColumnas)
            {
                c = listadoGeneral.Find(x => x.ColumnaNo == indice);
                nombresCortos.Add(c.NombreCorto);
            }
            return nombresCortos;
        }

        public static string getNombresCortosFromListado(List<string> listado)
        {
            return string.Join("_", listado.ToArray());
        }

        public static void merginCols(ref List<clsVariable> listadoGeneral, ref DataTable tabla, int[] indicesColumnas)
        {
            string colNueva = ""; //= getColNombreFromIndices(int[] indices);
            clsVariable c = new clsVariable(listadoGeneral.Count, colNueva);
            addColumnaToList(ref listadoGeneral, colNueva);

        }


        private static DataTable getDataFiltradaColumna(string columnaFiltro, DataTable excelData)
        {
            DataTable table = new DataTable();

            if (!string.IsNullOrEmpty(columnaFiltro))
            {
                DataView view = new DataView(excelData);
                table = view.ToTable(true, "["+columnaFiltro+"]");
                view.Dispose();
            }
            return table;
        }

        //private static DataTable getDataFiltradaColumna(int colIndex, DataTable excelData)
        //{
        //    DataTable table = new DataTable();
        //    string columnaFiltro = string.Empty; //getColName for index
        //    if (!string.IsNullOrEmpty(columnaFiltro))
        //    {
        //        DataView view = new DataView(excelData);
        //        table = view.ToTable(true, columnaFiltro);
        //        view.Dispose();
        //    }
        //    return table;
        //}

        
        #region Levels

        private static string[] columnaToStringArray(DataTable tabla, int indice)
        {
            return tabla.Columns[indice].ToArray<string>();
        }
        private static object[] columnaToObjectArray(DataTable tabla, int indice)
        {
            return tabla.Columns[indice].ToArray<object>();
        }


        public static List<string> getLevels(ref DataTable tablaNueva, DataTable tablaExcel, int[] varGrouping, List<clsVariable> listadoGeneral)
        {
            List<string> levels = new List<string>();

            //DataTable temp;
            


            tablaNueva.Columns.Add("DataValues");
            foreach (int indice in varGrouping)
            {
                string[] filasPorColumnaExcel = columnaToStringArray(tablaExcel, indice);
                filasPorColumnaExcel = filasPorColumnaExcel.Distinct();
                foreach (string fila in filasPorColumnaExcel)
                {
                    tablaNueva.Rows.Add(fila);
                    levels.Add(fila);
                }
                
                //Function obsoleta
                //nombresColumnasExcel = nombresColumnasExcel.Distinct().ToArray();


                //nombresColumnasExcel = listadoGeneral.Find(x => x.index == indice).Nombre; //getColName for indice
                //Console.WriteLine("\nFind: Part where name contains \"seat\": {0}", parts.Find(x => x.PartName.Contains("seat")));

                //nombresColumnasExcel = nombresColumnasExcel.Distinct();

                //temp = new DataTable();
                //foreach (string col in nombresColumnasExcel)
                //{
                    //temp = getDataFiltradaColumna(col, tablaExcel);
                    //Debug.WriteLine(col + ":" + temp.Rows.Count);
                //}

                //addcolumna a la tabla
                //foreach (DataRow dr in temp.Rows)
                //{
                //    tablaNueva.Rows.Add(dr);
                //}
            }
            return levels;
        }
        #endregion
        public static class variables
        {
            public static string checkMDValues(DataTable tablaExcel, params clsVariable[] variables)
            {

                var resultado = string.Empty;
                var builder = new StringBuilder();
                builder.Append(resultado);


                foreach (var variable in variables)
                {
                    var contador = 0;

                    foreach (DataRow dr in tablaExcel.Rows)
                    {
                        if (string.IsNullOrEmpty(dr[variable.ColumnaNo].ToString()))
                        {
                            contador++; ;
                        }
                    }
                    if (contador > 0)
                    {
                        builder.Append(String.Format("The item {0} contains {1} values of Missing Data", variable.Nombre, contador) + Environment.NewLine);
                    }
                }
                resultado = builder.ToString();

                return resultado;
            }
        }

        public static void ToCSV(this DataTable dtDataTable, string strFilePath)
        {
            StreamWriter sw = new StreamWriter(strFilePath, false);
            //headers  
            for (int i = 0; i < dtDataTable.Columns.Count; i++)
            {
                sw.Write(dtDataTable.Columns[i]);
                if (i < dtDataTable.Columns.Count - 1)
                {
                    sw.Write(";");
                }
            }
            sw.Write(sw.NewLine);
            foreach (DataRow dr in dtDataTable.Rows)
            {
                for (int i = 0; i < dtDataTable.Columns.Count; i++)
                {
                    if (!Convert.IsDBNull(dr[i]))
                    {
                        string value = dr[i].ToString();
                        if (value.Contains(';'))
                        {
                            value = String.Format("\"{0}\"", value);
                            sw.Write(value);
                        }
                        else
                        {
                            sw.Write(dr[i].ToString());
                        }
                    }
                    if (i < dtDataTable.Columns.Count - 1)
                    {
                        sw.Write(";");
                    }
                }
                sw.Write(sw.NewLine);
            }
            sw.Close();
        }

        public static void WriteTsv<T>(IEnumerable<T> data, TextWriter output)
        {
            var props = TypeDescriptor.GetProperties(typeof(T));
            foreach (PropertyDescriptor prop in props)
            {
                output.Write(prop.DisplayName); // header
                output.Write("\t");
            }
            output.WriteLine();
            foreach (T item in data)
            {
                foreach (PropertyDescriptor prop in props)
                {
                    output.Write(prop.Converter.ConvertToString(
                         prop.GetValue(item)));
                    output.Write("\t");
                }
                output.WriteLine();
            }
        }
    }
}
