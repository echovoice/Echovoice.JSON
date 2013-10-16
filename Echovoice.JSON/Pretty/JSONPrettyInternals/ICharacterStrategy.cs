using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Echovoice.JSON.Pretty.JSONPrettyInternals
{
    public interface ICharacterStrategy
    {
        void ExecutePrintyPrint(JsonPPStrategyContext context);
        char ForWhichCharacter { get; }
    }
}
