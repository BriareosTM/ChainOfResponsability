using System;
using System.Collections.Generic;
using System.Text;

namespace TestChainOfRest.Tools.Patterns.ChainOfResponsability
{
    public class Node<TContext> : INode<TContext>
        where TContext : class
    {
        protected Action<TContext> InitAction { get; private set; }
        protected Action<TContext> Handler { get; private set; }
        protected Predicate<TContext> Predicate { get; private set; }
        protected Action<TContext, Exception> ExceptionHandler { get; private set; }

        public INode<TContext> Next { protected get; set; }

        public Node(Action<TContext> handler, Predicate<TContext> predicate = null, Action<TContext, Exception> exceptionHandler = null)
        {
            if (handler == null)
                throw new ArgumentNullException(nameof(handler));

            Handler = handler;
            Predicate = predicate;
            ExceptionHandler = exceptionHandler;
        }

        public Node(Action<TContext> initAction, Action<TContext> handler, Predicate<TContext> predicate = null, Action<TContext, Exception> exceptionHandler = null)
            : this(handler, predicate, exceptionHandler)
        {
            if (initAction == null)
                throw new ArgumentNullException(nameof(initAction));

            InitAction = initAction;
            Predicate = predicate;
            ExceptionHandler = exceptionHandler;
        }

        public virtual void Process(TContext context)
        {
            try
            {
                if (InitAction != null)
                    InitAction(context);

                if ((Predicate != null && Predicate(context)) || Predicate == null)
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
                HandleException(context, ex);
            }
        }

        protected virtual void HandleException(TContext context, Exception ex)
        {
            if (ExceptionHandler == null)
                Console.WriteLine(ex.Message);
            else
                ExceptionHandler(context, ex);
            
        }
    }
}
