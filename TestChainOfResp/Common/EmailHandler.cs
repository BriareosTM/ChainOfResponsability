using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestChainOfResp.Common
{
    public abstract class EmailHandler : IEmailHandler
    {
        private IEmailHandler _nextHandler;

        public IEmailHandler Next
        {
            set
            {
                _nextHandler = value;
            }
        }

        public virtual void ProcessHandler(string email)
        {
            bool wordFound = false;

            IEnumerable<string> words = MatchingWords();

            if (MatchingWords().Count() == 0)
            {
                wordFound = true;
            }
            else
            {
                string word = MatchingWords().FirstOrDefault(w => email.ToUpper().Contains(w.ToUpper()));

                if (!(word is null))
                    wordFound = true;
            }

            if (wordFound)
                HandleHere(email);
            else
                _nextHandler.ProcessHandler(email);
        }

        protected abstract void HandleHere(string email);
        protected abstract IEnumerable<string> MatchingWords();
    }
}
