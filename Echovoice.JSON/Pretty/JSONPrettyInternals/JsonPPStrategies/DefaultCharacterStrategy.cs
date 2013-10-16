using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Echovoice.JSON.Pretty.JSONPrettyInternals.JsonPPStrategies
{
    public class DefaultCharacterStrategy : ICharacterStrategy
    {
        public void ExecutePrintyPrint(JsonPPStrategyContext context)
        {
            context.AppendCurrentChar();
        }

        public char ForWhichCharacter
        {
            get { throw new InvalidOperationException("Sorry rumpus roo"); }
        }
    }
}
