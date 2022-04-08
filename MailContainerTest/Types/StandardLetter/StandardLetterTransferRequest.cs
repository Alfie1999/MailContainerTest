namespace MailContainerTest.Types.SmallParcel
{

  public class StandardLetterTransferRequest : MakeMailTransferRequest, IMakeMailTransferRequest
  {
    public override MailType MailType => MailType.StandardLetter;

  }
}
