using System;
using TestChainOfResp.Refactoring.Flow;
using TestChainOfRest.Tools.Patterns.ChainOfResponsability;

namespace TestChainOfResp.Refactoring
{
    class Program
    {
        static void Main(string[] args)
        {
            MailFlow mailFlow = new MailFlow();
            mailFlow.Start(new MailContext("Viagra to sale!!!"));
            mailFlow.Start(new MailContext("I need my car repaired."));
            mailFlow.Start(new MailContext("My car is broken, it's a bad news."));
            mailFlow.Start(new MailContext("Where can i buy a car."));
            mailFlow.Start(new MailContext("So what next."));
        }

        static void Handle(string email)
        {
            //spam.Process(email);
        }
    }
}
