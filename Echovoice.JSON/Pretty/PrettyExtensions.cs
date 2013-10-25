using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Pretty routines are based on work by Mark Rogers twitter.com/MarkRogers0
// http://www.markdavidrogers.com/oxitesample/Blog/json-pretty-printerbeautifier-library-for-net

namespace Echovoice.JSON.Pretty
{
    public static class PrettyExtensions
    {
        public static string PrettyPrintJson(this string unprettyJson)
        {
            return JSONPretty.FormatJson(unprettyJson);
        }

        public static void ForEach<T>(this IEnumerable<T> ie, Action<T> action)
        {
            foreach (var i in ie)
            {
                action(i);
            }
        }
    }
}
