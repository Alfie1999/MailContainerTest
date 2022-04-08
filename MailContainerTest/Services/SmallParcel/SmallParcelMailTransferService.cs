using MailContainerTest.Data;

namespace MailContainerTest.Services.LargeLetter
{
  public class SmallParcelMailTransferService : MailTransferService
  {
    public SmallParcelMailTransferService(IMailContainerDataStore sourceMailContainerDataStore,
                               IMailContainerDataStore targetMailContainerDataStore)
      : base(sourceMailContainerDataStore, targetMailContainerDataStore)
    {

    }
  }
}
