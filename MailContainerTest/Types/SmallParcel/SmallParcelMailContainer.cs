using MailContainerTest.Types.Enums;

namespace MailContainerTest.Types.SmallParcel
{

  public class SmallParcelMailContainer : MailContainer
  {
    public override AllowedMailType AllowedMailType => AllowedMailType.SmallParcel;
  }
}
