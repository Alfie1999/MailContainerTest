using MailContainerTest.Types.Enums;

namespace MailContainerTest.Types
{
  public interface IMailContainer
  {
    AllowedMailType AllowedMailType { get; set; }
    int Capacity { get; set; }
    string MailContainerNumber { get; set; }
    MailContainerStatus Status { get; set; }
  }
}