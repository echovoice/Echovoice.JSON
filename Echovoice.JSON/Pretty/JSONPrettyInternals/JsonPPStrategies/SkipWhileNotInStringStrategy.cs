using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Echovoice.JSON.Pretty.JSONPrettyInternals.JsonPPStrategies
{
    public class SkipWhileNotInStringStrategy : ICharacterStrategy
    {
        private readonly char _selectionCharacter;

        public SkipWhileNotInStringStrategy(char selectionCharacter)
        {
            _selectionCharacter = selectionCharacter;
        }

        public void ExecutePrintyPrint(JsonPPStrategyContext context)
        {
            if (context.IsProcessingString)
                context.AppendCurrentChar();
        }

        public char ForWhichCharacter
        {
            get
            {
                return _selectionCharacter;
            }
        }
    }
}
