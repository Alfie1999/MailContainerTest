using System;

namespace MailContainerTest.Types
{
  public class MakeMailTransferRequest : IMakeMailTransferRequest
  {
    // Can SourceMailContainerNumber be an integer?
    public string SourceMailContainerNumber { get; set; }
    // Can DestinationMailContainerNumber be an integer?
    public string DestinationMailContainerNumber { get; set; }
    public int NumberOfMailItems { get; set; }
    public DateTime TransferDate { get; set; }
    public virtual MailType MailType { get; set; }
  }
}
