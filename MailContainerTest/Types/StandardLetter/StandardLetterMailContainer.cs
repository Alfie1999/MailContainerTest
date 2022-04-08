using MailContainerTest.Types.Enums;

namespace MailContainerTest.Types.SmallParcel
{
  public class StandardLetterMailContainer : MailContainer
  {
    public override AllowedMailType AllowedMailType => AllowedMailType.StandardLetter;
  }
}
