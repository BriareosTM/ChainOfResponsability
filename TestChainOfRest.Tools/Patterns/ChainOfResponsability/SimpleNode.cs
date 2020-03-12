using System;
using System.Collections.Generic;
using System.Text;

namespace TestChainOfRest.Tools.Patterns.ChainOfResponsability
{
    public class SimpleNode<TContext> : Node<TContext>
        where TContext : class
    {
        public SimpleNode(Action<TContext> handler, Action<TContext, Exception> exceptionHandler = null)
            : base(handler, null, exceptionHandler)
        {
        }

        public override void Process(TContext context)
        {
            try
            {
                Handler(context);
                Next?.Process(context);
            }
            catch (Exception ex)
            {
                HandleException(context, ex);
            }
        }
    }
}
