using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using TicTacTec.TA.Library;
using Shared.GDO;
using System.ComponentModel;
namespace Shared
{
    public static class Util
    {
        public enum VolType
        {
            ATB,        //Available to Back
            ATL,        //Available to Lay
            TVOLB,      //Traded Volum Back
            TVOLL,      //Traded Volum Back
        };

        public enum DataSeries
        {
            PRICE,
            VOLUME,
        };

        public struct GUIUpdate
        {
            public enum UpdateAction
            {
                Market,
                Message,
                Req_Stop,
            };
            public UpdateAction updateAction;
            public Market market;
            public String msgNr;
            public String[] param;
        };

        public static void SerializeObj(Object obj, string fName)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(fName,
                                     FileMode.Create,
                                     FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, obj);
            stream.Close();
        }

        public static Object DeserializeObj(string fName)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(fName,
                                      FileMode.Open,
                                      FileAccess.Read,
                                      FileShare.Read);
            return formatter.Deserialize(stream);
        }

        //public static TConvert ConvertTo<TConvert>(this object entity) where TConvert : new()
        //{
        //    var convertProperties = TypeDescriptor.GetProperties(typeof(TConvert)).Cast<PropertyDescriptor>();
        //    var entityProperties = TypeDescriptor.GetProperties(entity).Cast<PropertyDescriptor>();

        //    var convert = new TConvert();

        //    foreach (var entityProperty in entityProperties)
        //    {
        //        var property = entityProperty;
        //        var convertProperty = convertProperties.FirstOrDefault(prop => prop.Name == property.Name);
        //        if (convertProperty != null)
        //        {
        //            convertProperty.SetValue(convert, Convert.ChangeType(entityProperty.GetValue(entity), convertProperty.PropertyType));
        //        }
        //    }

        //    return convert;
        //}

        public static void CopyPropertiesTo<T, TU>(this T source, TU dest)
        {

            var sourceProps = typeof(T).GetProperties().Where(x => x.CanRead).ToList();
            var destProps = typeof(TU).GetProperties()
                    .Where(x => x.CanWrite)
                    .ToList();

            foreach (var sourceProp in sourceProps)
            {
                if (destProps.Any(x => x.Name == sourceProp.Name))
                {
                    var p = destProps.First(x => x.Name == sourceProp.Name);
                    p.SetValue(dest, sourceProp.GetValue(source, null), null);
                }

            }

        }

        public static object DeepCopy(object obj)
        {
            if (obj == null)
                return null;
            Type type = obj.GetType();

            if (type.IsValueType || type == typeof(string))
            {
                return obj;
            }
            else if (type.IsArray)
            {
                Type elementType = Type.GetType(
                     type.FullName.Replace("[]", string.Empty));
                var array = obj as Array;
                Array copied = Array.CreateInstance(elementType, array.Length);
                for (int i = 0; i < array.Length; i++)
                {
                    copied.SetValue(DeepCopy(array.GetValue(i)), i);
                }
                return Convert.ChangeType(copied, obj.GetType());
            }
            else if (type.IsClass)
            {

                object toret = Activator.CreateInstance(obj.GetType());
                FieldInfo[] fields = type.GetFields(BindingFlags.Public |
                            BindingFlags.NonPublic | BindingFlags.Instance);
                foreach (FieldInfo field in fields)
                {
                    object fieldValue = field.GetValue(obj);
                    if (fieldValue == null)
                        continue;
                    field.SetValue(toret, DeepCopy(fieldValue));
                }
                return toret;
            }
            else
                throw new ArgumentException("Unknown type");
        }


        public static double getLinearRegAngle(List<double> input, int period)
        {
            int outBegIdx = new int();
            int outNbElement = new int();
            double[] taInput = input.ToArray();
            double[] maOutput = new double[input.Count];
            Core.RetCode retCode;
            if (input.Count < period)
            {
                retCode=Core.LinearRegAngle(0, input.Count - 1, taInput, input.Count, out outBegIdx, out outNbElement, maOutput);
            }
            else
            {
                retCode = Core.LinearRegAngle(input.Count - period, input.Count - 1, taInput, period, out outBegIdx, out outNbElement, maOutput);
            }
            return maOutput[outNbElement == 0 ? 0 : outNbElement - 1];
        }

        // MovingAverage-Start
        public static double getMA(List<double> input, int period, Core.MAType maType)
        {
            int outBegIdx = new int();
            int outNbElement = new int();
            double[] taInput = input.ToArray();
            double[] maOutput = new double[input.Count];
            //Core.MovingAverage
            if (input.Count < period)
            {
                Core.MovingAverage(0, input.Count - 1, taInput, input.Count, maType, out outBegIdx, out outNbElement, maOutput);
            }
            else
            {
                Core.MovingAverage(input.Count - period, input.Count - 1, taInput, period, maType, out outBegIdx, out outNbElement, maOutput);
            }
            return maOutput[outNbElement == 0 ? 0 : outNbElement - 1];
        }


        public static string FormatExc(Exception ex)
        {
            return ex.Source + ex.GetBaseException() + ex.Message + ex.StackTrace;
        }
    }


}