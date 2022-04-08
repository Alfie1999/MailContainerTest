using MailContainerTest.Data;

namespace MailContainerTest.Services.LargeLetter
{
  public class StandardLetterMailTransferService : MailTransferService
  {
    public StandardLetterMailTransferService(IMailContainerDataStore sourceMailContainerDataStore,
                               IMailContainerDataStore targetMailContainerDataStore)
      : base(sourceMailContainerDataStore, targetMailContainerDataStore)
    {

    }
  }
}
