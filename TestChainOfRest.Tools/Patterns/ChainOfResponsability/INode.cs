using System;
using System.Collections.Generic;
using System.Text;

namespace TestChainOfRest.Tools.Patterns.ChainOfResponsability
{
    public interface INode<TContext>
    {
        INode<TContext> Next { set; }
        void Process(TContext context);
    }
}
