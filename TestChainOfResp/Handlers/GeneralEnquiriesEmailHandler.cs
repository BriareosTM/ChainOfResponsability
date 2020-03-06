using System;
using System.Collections.Generic;
using System.Text;

using TestChainOfResp.Common;

namespace TestChainOfResp.Handlers
{
    public class GeneralEnquiriesEmailHandler : EmailHandler
    {
        protected override void HandleHere(string email)
        {
            Console.WriteLine("Email handled by general enquiries");
        }

        protected override IEnumerable<string> MatchingWords()
        {
            return new string[0];
        }
    }
}
