using MailContainerTest.Types.Enums;

namespace MailContainerTest.Types
{
  /// <summary>
  /// MailContainer class 
  /// </summary>
  public class MailContainer : IMailContainer
  {
    // check if MailContainerNumber can be a integer
    public string MailContainerNumber { get; set; }
    public int Capacity { get; set; }
    public MailContainerStatus Status { get; set; }
    public virtual AllowedMailType AllowedMailType { get; set; }

  }
}
