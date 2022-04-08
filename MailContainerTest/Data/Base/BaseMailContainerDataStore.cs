using MailContainerTest.Types;
using MailContainerTest.Types.SmallParcel;

namespace MailContainerTest.Data
{
  public class BaseMailContainerDataStore : IMailContainerDataStore
  {
    public IMailContainer GetMailContainer(string mailContainerNumber)
    {
      return new MailContainer();
    }

    public void UpdateMailContainer(IMailContainer mailContainer)
    {
      // Update mail container in the database. Implementation not required for this exercise.
    }
  }
}
