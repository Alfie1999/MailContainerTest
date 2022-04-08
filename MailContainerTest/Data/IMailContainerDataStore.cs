using MailContainerTest.Types;

namespace MailContainerTest.Data
{
  public interface IMailContainerDataStore
  {
    IMailContainer GetMailContainer(string mailContainerNumber);
    void UpdateMailContainer(IMailContainer mailContainer);
  }
}