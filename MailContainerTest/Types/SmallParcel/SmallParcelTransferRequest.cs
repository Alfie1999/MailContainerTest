namespace MailContainerTest.Types.SmallParcel
{
  public class SmallParcelTransferRequest : MakeMailTransferRequest, IMakeMailTransferRequest
  {
    public override MailType MailType => MailType.SmallParcel;

  }
}
