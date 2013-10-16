using Echovoice.JSON.Pretty.JSONPrettyInternals;
using Echovoice.JSON.Pretty.JSONPrettyInternals.JsonPPStrategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Pretty routines are based on work by Mark Rogers twitter.com/MarkRogers0
// http://www.markdavidrogers.com/oxitesample/Blog/json-pretty-printerbeautifier-library-for-net

namespace Echovoice.JSON.Pretty
{
    public class JSONPretty
    {
        private readonly JsonPPStrategyContext _context;

        public JSONPretty(JsonPPStrategyContext context)
        {
            _context = context;

            _context.ClearStrategies();
            _context.AddCharacterStrategy(new OpenBracketStrategy());
            _context.AddCharacterStrategy(new CloseBracketStrategy());
            _context.AddCharacterStrategy(new OpenSquareBracketStrategy());
            _context.AddCharacterStrategy(new CloseSquareBracketStrategy());
            _context.AddCharacterStrategy(new SingleQuoteStrategy());
            _context.AddCharacterStrategy(new DoubleQuoteStrategy());
            _context.AddCharacterStrategy(new CommaStrategy());
            _context.AddCharacterStrategy(new ColonCharacterStrategy());
            _context.AddCharacterStrategy(new SkipWhileNotInStringStrategy('\n'));
            _context.AddCharacterStrategy(new SkipWhileNotInStringStrategy('\r'));
            _context.AddCharacterStrategy(new SkipWhileNotInStringStrategy('\t'));
            _context.AddCharacterStrategy(new SkipWhileNotInStringStrategy(' '));
        }

        public string PrettyPrint(string inputString)
        {
            if (inputString.Trim() == String.Empty)
                return "";

            var input = new StringBuilder(inputString);
            var output = new StringBuilder();

            PrettyPrintCharacter(input, output);

            return output.ToString();
        }

        private void PrettyPrintCharacter(StringBuilder input, StringBuilder output)
        {
            for (var i = 0; i < input.Length; i++)
                _context.PrettyPrintCharacter(input[i], output);
        }
    }
}