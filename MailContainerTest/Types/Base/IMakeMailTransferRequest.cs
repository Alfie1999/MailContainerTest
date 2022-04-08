using System;

namespace MailContainerTest.Types
{
  public interface IMakeMailTransferRequest
  {
    string DestinationMailContainerNumber { get; set; }
    MailType MailType { get; set; }
    int NumberOfMailItems { get; set; }
    string SourceMailContainerNumber { get; set; }
    DateTime TransferDate { get; set; }
  }
}