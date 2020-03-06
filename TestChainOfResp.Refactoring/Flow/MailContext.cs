namespace TestChainOfResp.Refactoring.Flow
{
    internal class MailContext
    {
        internal string MailContent { get; private set; }
        public MailContext(string mailContent)
        {
            MailContent = mailContent;
        }
    }
}