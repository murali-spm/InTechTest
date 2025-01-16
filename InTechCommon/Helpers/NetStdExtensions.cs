using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace InTechCommon.Helpers
{
    public static class NetStdExtensions
    {
        public static TOut? ConvertProperties<TIn, TOut>(this TIn input) where TOut : new()
        {
            if (input == null)
                return default;

            var output = new TOut();

            var inputProperties = typeof(TIn).GetProperties();
            var outputProperties = typeof(TOut).GetProperties();

            foreach(var inputProperty in inputProperties)
            {
                var outputProperty = outputProperties.FirstOrDefault( p => p.Name == inputProperty.Name && p.PropertyType == inputProperty.PropertyType );

                if( outputProperty != null && outputProperty.CanWrite)
                {
                    var value = inputProperty.GetValue(input);
                    outputProperty.SetValue(output, value, null);
                }
            }

            return output;
        }

        public static List<TOut> ConvertProperties<TIn, TOut>(this List<TIn> inputList) where TOut : new()
        {
            var outputList = new List<TOut>();
            foreach(var input in inputList)
            {
                var output = input.ConvertProperties<TIn,TOut>();
                outputList.Add(output);
            }
            return outputList;
        }
    }
}
