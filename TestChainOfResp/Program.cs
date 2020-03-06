using System;
using TestChainOfResp.Common;
using TestChainOfResp.Handlers;

namespace TestChainOfResp
{
    class Program
    {
        static void Main(string[] args)
        {
            Handle("Viagra to sale!!!");
            Handle("I need my car repaired.");
            Handle("My car is broken, it's a bad news.");
            Handle("Where can i buy a car.");
            Handle("So what next.");
        }

        static void Handle(string email)
        {
            IEmailHandler spam = new SpamEmailHandler();
            IEmailHandler sales = new SalesEmailHandler();
            IEmailHandler service = new ServiceEmailHandler();
            IEmailHandler manager = new ManagerHandler();
            IEmailHandler general = new GeneralEnquiriesEmailHandler();

            spam.Next = sales;
            sales.Next = service;
            service.Next = manager;
            manager.Next = general;

            spam.ProcessHandler(email);
        }
    }
}
