﻿using System;
using System.Collections.Generic;
using System.Text;

using TestChainOfResp.Common;

namespace TestChainOfResp.Handlers
{
    public class ServiceEmailHandler : EmailHandler
    {
        protected override void HandleHere(string email)
        {
            Console.WriteLine("Email handled by service department");
        }

        protected override IEnumerable<string> MatchingWords()
        {
            yield return "service";
            yield return "repair";
        }
    }
}
