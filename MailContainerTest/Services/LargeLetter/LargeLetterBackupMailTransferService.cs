using MailContainerTest.Data;

namespace MailContainerTest.Services.LargeLetter
{
  public class LargeLetterBackupMailTransferService : MailTransferService
  {
    public LargeLetterBackupMailTransferService(IMailContainerDataStore sourceMailContainerDataStore,
                               IMailContainerDataStore targetMailContainerDataStore)
      : base(sourceMailContainerDataStore, targetMailContainerDataStore)
    {

    }
  }
}
