using MailContainerTest.Data;

namespace MailContainerTest.Services.LargeLetter
{
  public class StandardLetterBackupMailTransferService : MailTransferService
  {
    public StandardLetterBackupMailTransferService(IMailContainerDataStore sourceMailContainerDataStore,
                               IMailContainerDataStore targetMailContainerDataStore)
      : base(sourceMailContainerDataStore, targetMailContainerDataStore)
    {

    }
  }
}
