using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FraMa
{
    public class clsOperacion
    {        
        //public enum tipo
        //{
        //    IN_Grouping,
        //    IN_Continuous,
        //    OUT_Grouping,
        //    OUT_Continuous,
        //    IN_MERGE_Grouping,
        //    OUT_MERGE_Grouping,
        //    Original
        //}
        public enum operadores
        {
            //Parameter
            paramSum,
            paramConst,
            paramMax,
            paramMin,
            paramAverage,
            //Grouping
            groupingIdentity,
            groupingMerge,
            groupingProbability,
            groupingShanon,
            groupingCount,
            //Continuous
            continuousIdentity,
            continuousStandarDeviation,
            continuousZscore,
            continuousNumericalPower,
            continuousLogarithm,
            continuousExponential,
            continuousSumForGrouping,
            continuousAbsolute,
            //Operators
            operatorsSum,
            operatorsStandarDev,
            operatorsProduct,
            operatorsDivision,
            operatorsNumericalPower,
            operatorsMin,
            operatorsMax,
            operatorsProbability,
            operatorsManhatanDis,
            operatorsEuclideanDis,
            operatorsDiference,
            operatorsAverageMean,
            operatorsGeometricMean,
            operatorsArmonicMeanSum,
            operatorsMovingAverage,
            //default
            none
        }

        public string Nombre { get; set; }
        public string NombreCorto { get; set; }
        public int Id { get; set; }
        public clsVariable Inputs { get; set; }
        public clsVariable Outputs { get; set; }
        public operadores operacion { get; set; }
        
        public clsOperacion()
        {
            Inputs = new clsVariable();
            Outputs = new clsVariable();
        }

        public clsOperacion(int id, operadores operacion, clsVariable entrada, clsVariable salida)
        {
            Inputs = new clsVariable();
            Outputs = new clsVariable();

            Id = id;
            this.operacion = operacion;
            Inputs = entrada;
            Outputs = salida;
            Nombre = GetParteNombre(operacion, entrada, salida);
        }

        public static string GetParteNombre(operadores operador, clsVariable input, clsVariable output)
        {
            var resultado = "None";
            switch (operador)
            {
                case operadores.paramSum:
                    resultado = "Sum_" + input.NombreCorto;
                    break;
                case operadores.paramConst:
                    resultado = "Const_" + input.NombreCorto;
                    break;
                case operadores.paramMax:
                    resultado = "Max_" + input.NombreCorto;
                    break;
                case operadores.paramMin:
                    resultado = "Min_" + input.NombreCorto;
                    break;
                case operadores.paramAverage:
                    resultado = "<" + input.NombreCorto + "+" + output.NombreCorto;
                    break;
                case operadores.groupingIdentity:
                    resultado = "GI_" + input.NombreCorto;
                    break;
                case operadores.groupingMerge:
                    resultado = "Merge_" +input.NombreCorto + "_" + output.NombreCorto;
                    break;
                case operadores.groupingProbability:
                    break;
                case operadores.groupingShanon:
                    break;
                case operadores.groupingCount:
                    break;
                case operadores.continuousIdentity:
                    break;
                case operadores.continuousStandarDeviation:
                    break;
                case operadores.continuousZscore:
                    break;
                case operadores.continuousNumericalPower:
                    break;
                case operadores.continuousLogarithm:
                    break;
                case operadores.continuousExponential:
                    break;
                case operadores.continuousSumForGrouping:
                    break;
                case operadores.continuousAbsolute:
                    break;
                case operadores.operatorsSum:
                    break;
                case operadores.operatorsStandarDev:
                    break;
                case operadores.operatorsProduct:
                    break;
                case operadores.operatorsDivision:
                    break;
                case operadores.operatorsNumericalPower:
                    break;
                case operadores.operatorsMin:
                    break;
                case operadores.operatorsMax:
                    break;
                case operadores.operatorsProbability:
                    break;
                case operadores.operatorsManhatanDis:
                    break;
                case operadores.operatorsEuclideanDis:
                    break;
                case operadores.operatorsDiference:
                    break;
                case operadores.operatorsAverageMean:
                    break;
                case operadores.operatorsGeometricMean:
                    break;
                case operadores.operatorsArmonicMeanSum:
                    break;
                case operadores.operatorsMovingAverage:
                    break;
                default:
                    break;
            }
            return resultado;
        }
        public static operadores getOperador(RadioButton radioButton)
        {
            var operar = operadores.none;
            switch (radioButton.Name)
            {
                case "rbParamSum":
                    operar = operadores.paramSum;
                    break;
                case "rbParamConstant":
                    operar = operadores.paramConst;
                    break;
                case "rbParamMax":
                    operar = operadores.paramMax;
                    break;
                case "rbParamMin":
                    operar = operadores.paramMin;
                    break;
                case "rbParamAverage":
                    operar = operadores.paramAverage;
                    break;
            }
            return operar;
        }
    }
}
