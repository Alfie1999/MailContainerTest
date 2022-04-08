using MailContainerTest.Data;

namespace MailContainerTest.Services.LargeLetter
{
  public class SmallParcelBackupMailTransferService : MailTransferService
  {
    public SmallParcelBackupMailTransferService(IMailContainerDataStore sourceMailContainerDataStore,
                               IMailContainerDataStore targetMailContainerDataStore)
      : base(sourceMailContainerDataStore, targetMailContainerDataStore)
    {

    }
  }
}
