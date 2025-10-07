using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Pretty routines are based on work by Mark Rogers twitter.com/MarkRogers0
// http://www.markdavidrogers.com/oxitesample/Blog/json-pretty-printerbeautifier-library-for-net

namespace Echovoice.JSON.Pretty
{
    /// <summary>
    /// Extension methods for JSON pretty printing.
    /// </summary>
    public static class PrettyExtensions
    {
        /// <summary>
        /// Pretty prints a JSON string with proper indentation.
        /// </summary>
        /// <param name="unprettyJson">The JSON string to format</param>
        /// <returns>A formatted JSON string with proper indentation</returns>
        public static string PrettyPrintJson(this string unprettyJson)
        {
            return JSONPretty.FormatJson(unprettyJson);
        }

        /// <summary>
        /// Executes an action for each element in a sequence.
        /// </summary>
        /// <typeparam name="T">The type of elements in the sequence</typeparam>
        /// <param name="ie">The sequence of elements</param>
        /// <param name="action">The action to execute for each element</param>
        public static void ForEach<T>(this IEnumerable<T> ie, Action<T> action)
        {
            foreach (var i in ie)
            {
                action(i);
            }
        }
    }
}
