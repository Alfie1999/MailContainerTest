### Mail Container Test 

The code for this exercise has been developed to manage the transfer of mail items from one container to another for processing.

#### Process for transferring mail

- Lookup the container the mail is being transferred from.
- Check the containers are in a valid state for the transfer to take place.
- Reduce the container capacity on the source container and increase the destination container capacity by the same amount.

#### Restrictions

- A container can only hold one type of mail.


#### Assumptions

- For the sake of simplicity, we can assume the containers have an unlimited capacity.

### The exercise brief

The exercise is to take the code in the solution and refactor it into a more suitable approach with the following things in mind:

- Testability
- Readability
- SOLID principles
- Architectural design of the code

You should not change the method signature of the MakeMailTransfer method.

You should add suitable tests into the MailContainerTest.Test project.

There are no additional constraints, use the packages and approach you feel appropriate, aim to spend no more than 2 hours. Please update the readme with specific comments on any areas that are unfinished and what you would cover given more time.


### Thoughts/comments

# TODO:

Further tests are needed to give more coverage 
I think I've covered the main areas with tests

# TODO:

In the interest of time I've left out function and property comments
on most

# Check List

class MailContainer 

    // check if MailContainerNumber can be a integer
    public string MailContainerNumber { get; set; }

class MakeMailTransferRequest : IMakeMailTransferRequest
  // check if SourceMailContainerNumber and DestinationMailContainerNumber can be a integer
    public string SourceMailContainerNumber { get; set; }
    public string DestinationMailContainerNumber { get; set; }