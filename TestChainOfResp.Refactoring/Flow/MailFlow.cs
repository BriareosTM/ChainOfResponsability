using System;
using System.Collections.Generic;
using System.Linq;
using TestChainOfRest.Tools.Patterns.ChainOfResponsability;

namespace TestChainOfResp.Refactoring.Flow
{
    public class MailFlow
    {
        private IChainNode<MailContext> _main;

        public MailFlow()
        {
            _main = new ChainNode<MailContext>(SpamHandler, SpamPredicate)
            {
                Next = new ChainNode<MailContext>(SalesHandler, SalesPredicate)
                {
                    Next = new ChainNode<MailContext>(ServiceHandler, ServicePredicate)
                    {
                        Next = new ChainNode<MailContext>(ManagerHandler, ManagerPredicate)
                        {
                            Next = new ChainNode<MailContext>(GeneralHandler, GeneralPredicate)
                        }
                    }
                }
            };
        }

        private bool SpamPredicate(MailContext context)
        {
            return WordPredicate(context, new string[] { "viagra", "pills", "medecines" });
        }

        private void SpamHandler(MailContext context)
        {
            Console.WriteLine("this is a spam mail!!");
        }

        private bool SalesPredicate(MailContext context)
        {
            return WordPredicate(context, new string[] { "buy", "purchase" });
        }

        private void SalesHandler(MailContext context)
        {
            Console.WriteLine("Email handled by sales department");
        }

        private bool ManagerPredicate(MailContext context)
        {
            return WordPredicate(context, new string[] { "complain", "bad" });
        }

        private void ManagerHandler(MailContext context)
        {
            Console.WriteLine("Email handled by manager");
        }

        private bool ServicePredicate(MailContext context)
        {
            return WordPredicate(context, new string[] { "service", "repair" });
        }

        private void ServiceHandler(MailContext context)
        {
            Console.WriteLine("Email handled by service department");
        }

        private bool GeneralPredicate(MailContext context)
        {
            return WordPredicate(context, new string[0]);
        }

        private void GeneralHandler(MailContext context)
        {
            Console.WriteLine("Email handled by general enquiries");
        }

        private bool WordPredicate(MailContext context, IEnumerable<string> matchingWords)
        {
            return matchingWords.Count() == 0
                || !(matchingWords.FirstOrDefault(w => context.MailContent.ToUpper().Contains(w.ToUpper())) is null);
        }

        internal void Start(MailContext mailContext)
        {
            _main.Process(mailContext);
        }
    }
}
