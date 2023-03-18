using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FraMa
{
    public class clsOpForContinuousVar 
    {
        //2 DIFV  DiferenceV1V2        C   C     DIFV - C - C
        public void DifV1V2(ref DataTable tabla, int colNumero, int colIn1, int colIn2)
        {
            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                tabla.Rows[i][colNumero] = (double)tabla.Rows[i][colIn1] - (double)tabla.Rows[i][colIn2];
            }
        }
        //2 DIVV  DivisionV1V2         C   C     DIVV - C - C
        public void DivV1V2(ref DataTable tabla, int colNumero, int colIn1, int colIn2)
        {
            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                if ((double)tabla.Rows[i][colIn2] > 0)
                {
                    tabla.Rows[i][colNumero] = (double)tabla.Rows[i][colIn1] / (double)tabla.Rows[i][colIn2];
                }
            }
        }
        //2 PROV  ProdVIV2             C   C     PROV - C - C
        public void ProdV1V2(ref DataTable tabla, int colNumero, int colIn1, int colIn2)
        {
            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                tabla.Rows[i][colNumero] = (double)tabla.Rows[i][colIn1] * (double)tabla.Rows[i][colIn2]; ;
            }
        }
        //2 SUMV  SumV1V2              C   C     SUMV - C - C
        public void SumV1V2(ref DataTable tabla, int colNumero, int colIn1, int colIn2)
        {
            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                tabla.Rows[i][colNumero] = (double)tabla.Rows[i][colIn1] + (double)tabla.Rows[i][colIn2];
            }
        }
        #region borrar
        //public void DifV1V2(string columnaNombre, int columnaA, int columnaB)
        //{
        //    DataColumn Columna;
        //    res.Clear();
        //    Columna = new DataColumn
        //    {
        //        DataType = System.Type.GetType("System.Decimal"),
        //        ColumnName = columnaNombre
        //    };
        //    res.Columns.Add(Columna);

        //    DataRow dr;
        //    foreach (DataRow item in tabla.Rows)
        //    {
        //        dr = res.NewRow();
        //        dr[columnaNombre] = (double)item[columnaA] - (double)item[columnaB];
        //        res.Rows.Add(dr);
        //    }
        //}
        //2 DIVV  DivisionV1V2         C   C     DIVV - C - C
        //public void DivV1V2(string columnaNombre, int columnaA, int columnaB)
        //{
        //    DataColumn Columna;
        //    res.Clear();
        //    Columna = new DataColumn
        //    {
        //        DataType = System.Type.GetType("System.Decimal"),
        //        ColumnName = columnaNombre
        //    };
        //    res.Columns.Add(Columna);

        //    DataRow dr;
        //    foreach (DataRow item in tabla.Rows)
        //    {
        //        dr = res.NewRow();
        //        if (columnaB == 0)
        //        {
        //            continue;
        //        }
        //        else
        //        {
        //            dr[columnaNombre] = (double)item[columnaA] / (double)item[columnaB];
        //        }
        //        res.Rows.Add(dr);
        //    }
        //}
        ////2 PROV  ProdVIV2             C   C     PROV - C - C
        //public void ProdV1V2(string columnaNombre, int columnaA, int columnaB)
        //{
        //    DataColumn Columna;
        //    res.Clear();
        //    Columna = new DataColumn
        //    {
        //        DataType = System.Type.GetType("System.Decimal"),
        //        ColumnName = columnaNombre
        //    };
        //    res.Columns.Add(Columna);

        //    DataRow dr;
        //    foreach (DataRow item in tabla.Rows)
        //    {
        //        dr = res.NewRow();
        //        dr[columnaNombre] = (double)item[columnaA] * (double)item[columnaB];
        //        res.Rows.Add(dr);
        //    }
        //}
        ////2 SUMV  SumV1V2              C   C     SUMV - C - C
        //public void SumV1V2(string columnaNombre, int columnaA, int columnaB)
        //{
        //    DataColumn Columna;
        //    res.Clear();
        //    Columna = new DataColumn
        //    {
        //        DataType = System.Type.GetType("System.Decimal"),
        //        ColumnName = columnaNombre
        //    };
        //    res.Columns.Add(Columna);

        //    DataRow dr;
        //    foreach (DataRow item in tabla.Rows)
        //    {
        //        dr = res.NewRow();
        //        dr[columnaNombre] = (double)item[columnaA] + (double)item[columnaB];
        //        res.Rows.Add(dr);
        //    }
        //}
        #endregion
    }
}
