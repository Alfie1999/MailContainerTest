using System;
using System.Collections;
using System.Collections.Generic;

namespace MailContainerTest.Tests
{
  public class MakeMailTransferRequestTestData : IEnumerable<object[]>
  {
    public IEnumerator<object[]> GetEnumerator()
    {
      yield return new object[] { "1", 2, "1", DateTime.Now, 10, 5 };
      yield return new object[] { "2", 2, "2", DateTime.Now.AddDays(2), 20, 15 };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
  }
}
