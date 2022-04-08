using MailContainerTest.Types.Enums;

namespace MailContainerTest.Types.LargeLetter
{
  public class LargeLetterMailContainer : MailContainer
  {
    public override AllowedMailType AllowedMailType => AllowedMailType.LargeLetter;
  }
}
