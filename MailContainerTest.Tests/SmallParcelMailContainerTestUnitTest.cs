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
  /// Tests for SmallParcelMailContainerTestUnitTest.
  /// </summary>
  public class SmallParcelMailContainerTestUnitTest
  {

    [Theory]
    [ClassData(typeof(MakeMailTransferRequestTestData))]
    public void Success_SmallParcel_Backup_Container(string destinationMailContainerNumber,
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
        new SmallParcelMailContainer
        {
          Capacity = sourceContinerCapacity,
          MailContainerNumber = "1",
          Status = MailContainerStatus.Operational
        })
        .Returns(
        new SmallParcelMailContainer
        {
          Capacity = desinationContinerCapacity,
          MailContainerNumber = "2",
          Status = MailContainerStatus.Operational
        });

      var mailTransferService = mockBackUpContainer.Create<SmallParcelBackupMailTransferService>();


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

    [Theory]
    [ClassData(typeof(MakeMailTransferRequestTestData))]
    public void Success_SmallParcel_Container(string destinationMailContainerNumber,
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

      var smallParcelMailContainer = new SmallParcelMailContainer
      {
        Capacity = desinationContinerCapacity,
        MailContainerNumber = "2",
        Status = MailContainerStatus.Operational
      };
      using var mockBackUpContainer = AutoMock.GetLoose();

      mockBackUpContainer.Mock<IMailContainerDataStore>()
       .SetupSequence(x => x.GetMailContainer(It.IsAny<string>()))
          .Returns(
        new SmallParcelMailContainer
        {
          Capacity = sourceContinerCapacity,
          MailContainerNumber = "1",
          Status = MailContainerStatus.Operational
        })
        .Returns(smallParcelMailContainer);

      var mailTransferService = mockBackUpContainer.Create<SmallParcelMailTransferService>();


      //Act
      var response = mailTransferService.MakeMailTransfer(request);
      //Assert
      smallParcelMailContainer.AllowedMailType.Should().Be(AllowedMailType.SmallParcel);
      smallParcelMailContainer.AllowedMailType.Should().NotBe(AllowedMailType.LargeLetter);
      smallParcelMailContainer.AllowedMailType.Should().NotBe(AllowedMailType.StandardLetter);

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
    public void Fail_MailContainer_Status_OutOfService_SmallParcel()
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
        new SmallParcelMailContainer
        {
          Capacity = 200,
          MailContainerNumber = "15",
          Status = MailContainerStatus.OutOfService
        }).Returns(
        new SmallParcelMailContainer
        {
          Capacity = 20,
          MailContainerNumber = "10",
          Status = MailContainerStatus.Operational
        });

      var mailTransferService = mock.Create<SmallParcelBackupMailTransferService>();

      //Act
      var response = mailTransferService.MakeMailTransfer(request);
      //Assert
      response.Success.Should()
       .BeFalse("it's set to false due to  Status = MailContainerStatus.OutOfService");
      response.Success.Should().Be(false);
    }

    [Fact]
    public void Fail_ArgumentNullException_SmallParcel()
    {
      //Arrange
      using var mock = AutoMock.GetLoose();
      var mailTransferService = mock.Create<SmallParcelBackupMailTransferService>();
      //Act
      Action response = () => mailTransferService.MakeMailTransfer(null);
      //Assert
      response.Should().ThrowExactly<ArgumentNullException>();
    }

  }
}
