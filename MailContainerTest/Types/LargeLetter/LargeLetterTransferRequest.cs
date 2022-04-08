namespace MailContainerTest.Types.LargeLetter
{
  public class LargeLetterTransferRequest : MakeMailTransferRequest, IMakeMailTransferRequest
  {
    public override MailType MailType => MailType.LargeLetter;

  }
}
