using System;
using System.Collections.Generic;
using System.Text;

namespace TestChainOfResp.Common
{
    public interface IEmailHandler
    {
        IEmailHandler Next { set; }

        void ProcessHandler(string email);
    }
}
