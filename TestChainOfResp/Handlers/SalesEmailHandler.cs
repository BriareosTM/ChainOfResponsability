using System;
using System.Collections.Generic;
using System.Text;

using TestChainOfResp.Common;

namespace TestChainOfResp.Handlers
{
    public class SalesEmailHandler : EmailHandler
    {
        protected override void HandleHere(string email)
        {
            Console.WriteLine("Email handled by sales department");
        }

        protected override IEnumerable<string> MatchingWords()
        {
            yield return "buy";
            yield return "purchase";
        }
    }
}
