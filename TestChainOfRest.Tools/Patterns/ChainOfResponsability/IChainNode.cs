using System;
using System.Collections.Generic;
using System.Text;

namespace TestChainOfRest.Tools.Patterns.ChainOfResponsability
{
    public interface IChainNode<TContext>
    {
        IChainNode<TContext> Next { set; }
        void Process(TContext context);
    }
}
