using Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

using Accord.IO;
using OfficeOpenXml;

namespace FraMa
{
    public static class archivos
    {
        public static DataSet GetDataFormExcel { get; set; }
        public static List<string> lstColumns { get; set; }
        //public string[] lstLevels { get; set; }
        public static int noRows { get; set; }
        public static int noCols { get; set; }
        public static string status { get; set; }
        public static Dictionary<int, string> columnas { get; set; }


        public static DataTable getDataFromExcel(string pathFile)
        {
            FileStream stream = File.Open(pathFile, FileMode.Open, FileAccess.Read);

            IExcelDataReader excelReader = null;

            excelReader = pathFile.Contains(".xlsx")
                ? ExcelReaderFactory.CreateOpenXmlReader(stream)
                : ExcelReaderFactory.CreateBinaryReader(stream);

            excelReader.IsFirstRowAsColumnNames = true;

            DataSet result = excelReader.AsDataSet();
            DataTable dt = result.Tables[0];

            if (dt != null)
            {
                noRows = dt.Rows.Count;
                noCols = dt.Columns.Count;
                if ((noRows > 0) && (noCols > 0))
                {
                    dt = cleanDatosFromExcel(dt);
                    lstColumns = getColumns(dt);
                    status = "Succesfully Load";
                }
                else
                {
                    status = pathFile + " No found data";
                }
            }
            else
            {
                status = "File without data for process";
            }
            return dt;
        }

        private static DataTable cleanDatosFromExcel(DataTable dt)
        {
            DataTable table = new DataTable();
            dt = dt.Rows
                    .Cast<DataRow>()
                    .Where(row => !row.ItemArray.All(field => field is DBNull ||
                                     string.IsNullOrWhiteSpace(field as string)))
                                     .CopyToDataTable();
            return dt;
        }

        public static List<string> getColumns(DataTable dt)
        {
            List<string> cols = new List<string>();
            foreach (DataColumn item in dt.Columns)
            {
                cols.Add(item.ColumnName);
            }
            return cols;
        }

        public static Dictionary<int, string> getColumnas(DataTable dt)
        {
            Dictionary<int, string> columnas = new Dictionary<int, string>();

            foreach (DataColumn item in dt.Columns)
            {
                columnas.Add(item.Ordinal, item.ColumnName);
            }
            return columnas;
        }

        public static string[] getColumnas(Dictionary<int, string> DicionarioColumnas)
        {
            return DicionarioColumnas.Values.ToArray();
        }

    }
}
