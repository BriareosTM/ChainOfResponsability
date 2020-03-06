using System;
using System.Collections.Generic;
using System.Text;

namespace TestChainOfRest.Tools.Patterns.ChainOfResponsability
{
    public class ChainNode<TContext> : IChainNode<TContext>
        where TContext : class
    {
        protected Action<TContext> Handler { get; private set; }
        protected Predicate<TContext> Predicate { get; private set; }
        protected Action<TContext, Exception> ExceptionHandler { get; private set; }

        public IChainNode<TContext> Next { private get; set; }

        public ChainNode(Action<TContext> handler, Predicate<TContext> predicate = null, Action<TContext, Exception> exceptionHandler = null)
        {
            Handler = handler ?? throw new ArgumentNullException(nameof(handler));
            Predicate = predicate;
            ExceptionHandler = exceptionHandler;
        }

        public virtual void Process(TContext context)
        {
            try
            {
                if ((!(Predicate is null) && Predicate(context)) || Predicate is null)
                {
                    Handler(context);
                }
                else
                {
                    Next?.Process(context);
                }
            }
            catch (Exception ex)
            {
                if (ExceptionHandler is null)
                    HandleException(context, ex);
                else
                    ExceptionHandler(context, ex);
            }
        }

        protected virtual void HandleException(TContext context, Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
