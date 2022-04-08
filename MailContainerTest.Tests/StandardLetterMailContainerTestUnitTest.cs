using Autofac.Extras.Moq;
using FluentAssertions;
using MailContainerTest.Data;
using MailContainerTest.Services.LargeLetter;
using MailContainerTest.Types;
using MailContainerTest.Types.Enums;
using MailContainerTest.Types.SmallParcel;
using Moq;
using System;
using Xunit;

namespace MailContainerTest.Tests
{
  /// <summary>
  /// Tests for StandardetterMailContainerTestUnitTest.
  /// </summary>
  public class StandardetterMailContainerTestUnitTest
  {

    [Theory]
    [ClassData(typeof(MakeMailTransferRequestTestData))]
    public void Success_StandardLetter_Backup_Container(string destinationMailContainerNumber,
      int NumberOfMailItems, string sourceMailContainerNumber, DateTime transferDate,
      int sourceContinerCapacity, int desinationContinerCapacity)
    {
      //Arrange
      var request = new MakeMailTransferRequest
      {
        DestinationMailContainerNumber = destinationMailContainerNumber,
        NumberOfMailItems = NumberOfMailItems,
        SourceMailContainerNumber = sourceMailContainerNumber,
        TransferDate = transferDate
      };

      var StandardLetterContainer = new StandardLetterMailContainer
      {
        Capacity = desinationContinerCapacity,
        MailContainerNumber = "2",
        Status = MailContainerStatus.Operational
      };
      using var mockBackUpContainer = AutoMock.GetLoose();

      mockBackUpContainer.Mock<IMailContainerDataStore>()
       .SetupSequence(x => x.GetMailContainer(It.IsAny<string>()))
          .Returns(
        new StandardLetterMailContainer
        {
          Capacity = sourceContinerCapacity,
          MailContainerNumber = "1",
          Status = MailContainerStatus.Operational
        })
        .Returns(StandardLetterContainer);

      var mailTransferService = mockBackUpContainer.Create<StandardLetterBackupMailTransferService>();


      //Act
      var response = mailTransferService.MakeMailTransfer(request);
      //Assert
      StandardLetterContainer.AllowedMailType.Should().Be(AllowedMailType.StandardLetter);
      StandardLetterContainer.AllowedMailType.Should().NotBe(AllowedMailType.LargeLetter);
      StandardLetterContainer.AllowedMailType.Should().NotBe(AllowedMailType.SmallParcel);

      response.Should().NotBeNull();

      response.Success.Should().NotBe(false);
      response.Success.Should().BeTrue("it's set to true");
      response.Success.Should().Be(response.Success);

      response.sourceContainerCapacity.Should().BeOfType(typeof(int),
        "because a {0} is set", typeof(int));
      response.sourceContainerCapacity.Should().Be(sourceContinerCapacity - NumberOfMailItems);

      response.destinationContainerCapacity.Should().BeOfType(typeof(int),
        "because a {0} is set", typeof(int));
      response.destinationContainerCapacity.Should().Be(desinationContinerCapacity + NumberOfMailItems);
    }

    [Theory]
    [ClassData(typeof(MakeMailTransferRequestTestData))]
    public void Success_StandardLetter_Container(string destinationMailContainerNumber,
    int NumberOfMailItems, string sourceMailContainerNumber, DateTime transferDate,
    int sourceContinerCapacity, int desinationContinerCapacity)
    {
      //Arrange
      var request = new MakeMailTransferRequest
      {
        DestinationMailContainerNumber = destinationMailContainerNumber,
        NumberOfMailItems = NumberOfMailItems,
        SourceMailContainerNumber = sourceMailContainerNumber,
        TransferDate = transferDate
      };

      using var mockBackUpContainer = AutoMock.GetLoose();

      mockBackUpContainer.Mock<IMailContainerDataStore>()
       .SetupSequence(x => x.GetMailContainer(It.IsAny<string>()))
          .Returns(
        new StandardLetterMailContainer
        {
          Capacity = sourceContinerCapacity,
          MailContainerNumber = "1",
          Status = MailContainerStatus.Operational
        })
        .Returns(
        new StandardLetterMailContainer
        {
          Capacity = desinationContinerCapacity,
          MailContainerNumber = "2",
          Status = MailContainerStatus.Operational
        });

      var mailTransferService = mockBackUpContainer.Create<StandardLetterMailTransferService>();


      //Act
      var response = mailTransferService.MakeMailTransfer(request);
      //Assert
      response.Should().NotBeNull();

      response.Success.Should().NotBe(false);
      response.Success.Should().BeTrue("it's set to true");
      response.Success.Should().Be(response.Success);

      response.sourceContainerCapacity.Should().BeOfType(typeof(int),
        "because a {0} is set", typeof(int));
      response.sourceContainerCapacity.Should().Be(sourceContinerCapacity - NumberOfMailItems);

      response.destinationContainerCapacity.Should().BeOfType(typeof(int),
        "because a {0} is set", typeof(int));
      response.destinationContainerCapacity.Should().Be(desinationContinerCapacity + NumberOfMailItems);
    }



    [Fact]
    public void Fail_MailContainer_Status_OutOfService_StandardLetter()
    {
      //Arrange
      var request = new MakeMailTransferRequest
      {
        DestinationMailContainerNumber = "1",
        NumberOfMailItems = 2,
        SourceMailContainerNumber = "2",
        TransferDate = DateTime.Now
      };

      using var mock = AutoMock.GetLoose();
      mock.Mock<IMailContainerDataStore>()
       .SetupSequence(x => x.GetMailContainer(It.IsAny<string>()))
          .Returns(
        new StandardLetterMailContainer
        {
          Capacity = 200,
          MailContainerNumber = "15",
          Status = MailContainerStatus.OutOfService
        }).Returns(
        new StandardLetterMailContainer
        {
          Capacity = 20,
          MailContainerNumber = "10",
          Status = MailContainerStatus.Operational
        });

      var mailTransferService = mock.Create<StandardLetterBackupMailTransferService>();

      //Act
      var response = mailTransferService.MakeMailTransfer(request);
      //Assert
      response.Success.Should()
        .BeFalse("it's set to false due to  Status = MailContainerStatus.OutOfService");
      response.Success.Should().Be(false);
    }

    [Fact]
    public void Fail_ArgumentNullException_StandardLetter()
    {
      //Arrange
      using var mock = AutoMock.GetLoose();
      var mailTransferService = mock.Create<StandardLetterBackupMailTransferService>();
      //Act
      Action response = () => mailTransferService.MakeMailTransfer(null);
      //Assert
      response.Should().ThrowExactly<ArgumentNullException>();
    }

  }
}
