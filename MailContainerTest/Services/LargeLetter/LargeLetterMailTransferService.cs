using MailContainerTest.Data;

namespace MailContainerTest.Services.LargeLetter
{
  public class LargeLetterMailTransferService : MailTransferService
  {
    public LargeLetterMailTransferService(IMailContainerDataStore sourceMailContainerDataStore,
                               IMailContainerDataStore targetMailContainerDataStore)
      : base(sourceMailContainerDataStore, targetMailContainerDataStore)
    {

    }
  }
}
