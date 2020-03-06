using System;
using System.Collections.Generic;
using System.Text;

using TestChainOfResp.Common;

namespace TestChainOfResp.Handlers
{
    public class SpamEmailHandler : EmailHandler
    {
        protected override void HandleHere(string email)
        {
            Console.WriteLine("this is a spam mail!!");
        }

        protected override IEnumerable<string> MatchingWords()
        {
            yield return "viagra";
            yield return "pills";
            yield return "medecines";
        }
    }
}
