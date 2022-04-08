using MailContainerTest.Data;
using MailContainerTest.Types;
using System;

namespace MailContainerTest.Services
{
  public abstract class MailTransferService
  {
    private readonly IMailContainerDataStore _sourceMailContainerDataStore;
    private readonly IMailContainerDataStore _destinationMailContainerDataStore;
    private readonly MakeMailTransferResult _makeMailTransferResult;
    public MailTransferService(IMailContainerDataStore sourceMailContainerDataStore,
                               IMailContainerDataStore destinationMailContainerDataStore)
    {
      _sourceMailContainerDataStore = sourceMailContainerDataStore;
      _destinationMailContainerDataStore = destinationMailContainerDataStore;
      _makeMailTransferResult = new MakeMailTransferResult();
    }

    /// <summary>
    /// *Cannot change the signature of this method 
    /// Transfers the the items between the containers
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public MakeMailTransferResult MakeMailTransfer(MakeMailTransferRequest request)
    {
      _ = request ?? throw new ArgumentNullException(nameof(request));


      _makeMailTransferResult.Success = true;

      var sourceMailContainer =
      _sourceMailContainerDataStore.GetMailContainer(request.SourceMailContainerNumber);

      var destinationMailContainer =
     _destinationMailContainerDataStore.GetMailContainer(request.DestinationMailContainerNumber);

      if (!ValidateContainers(sourceMailContainer, request.NumberOfMailItems))
      {
        _makeMailTransferResult.Success = false;
      }
      else if (!ValidateContainers(destinationMailContainer, request.NumberOfMailItems))
      {
        _makeMailTransferResult.Success = false;
      }
      else
      {
        sourceMailContainer.Capacity -= request.NumberOfMailItems;
        _sourceMailContainerDataStore.UpdateMailContainer(sourceMailContainer);
        _makeMailTransferResult.sourceContainerCapacity = sourceMailContainer.Capacity;

        destinationMailContainer.Capacity += request.NumberOfMailItems;
        _destinationMailContainerDataStore.UpdateMailContainer(destinationMailContainer);
        _makeMailTransferResult.destinationContainerCapacity = destinationMailContainer.Capacity;
      }
      return _makeMailTransferResult;
    }
    /// <summary>
    /// Validation helper method 
    /// </summary>
    /// <param name="mailContainerToValidate"></param>
    /// <param name="numberOfItems"></param>
    /// <returns></returns>
    private bool ValidateContainers(IMailContainer mailContainerToValidate, int numberOfItems)
    {
      if (mailContainerToValidate == null)
      {
        return false;
      }
      else if (mailContainerToValidate.Capacity < numberOfItems)
      {
        return false;
      }
      else if (mailContainerToValidate.Status != MailContainerStatus.Operational)
      {
        return false;
      }
      return true;
    }
  }
}
