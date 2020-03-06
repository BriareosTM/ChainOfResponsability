using System;
using System.Collections.Generic;
using System.Text;

using TestChainOfResp.Common;

namespace TestChainOfResp.Handlers
{
    public class ManagerHandler : EmailHandler
    {
        protected override void HandleHere(string email)
        {
            Console.WriteLine("Email handled by manager");
        }

        protected override IEnumerable<string> MatchingWords()
        {
            yield return "complain";
            yield return "bad";
        }
    }
}
