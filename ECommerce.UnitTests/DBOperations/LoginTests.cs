using ECommerce.DBOperations;
using NUnit.Framework;

namespace ECommerce.UnitTests.DBOperations
{
  [TestFixture]
  public class LoginTests
  {
    [TestCase("Ashok", true)]
    [TestCase("asdfghjkl", false)]
    [TestCase(null, false)]
    public void CheckIsUsernameExist(string username, bool expectedValue)
    {
      Login login = new Login();
      var result = login.IsUsernameExist(username);

      Assert.AreEqual(result, expectedValue);
    }

    [Test]
    public void CheckGettingUserDetails()
    {
      Login login = new Login();

      var result = login.GetUserDetails("Ashok");
      Assert.AreEqual(result.FirstName, "Ashok");

      result = login.GetUserDetails("asdfghjkl");
      Assert.IsNull(result);

      result = login.GetUserDetails(null);
      Assert.IsNull(result);
    }

    [TestCase("Ashok","password", true)]
    [TestCase("Ashok","asdfghjkl", false)]
    [TestCase("asdfghjkl", "asdfghjkl", false)]
    [TestCase(null,null, false)]
    public void CheckForValidCredentials(string username,string password, bool expectedValue)
    {
      Login login = new Login();
      var result = login.CheckForValidCredentials(username,password);

      Assert.AreEqual(result, expectedValue);
    }

    [TestCase("redmoon.ashok@gmail.com", true)]
    [TestCase("asdfghjkl@gmail.com", false)]
    [TestCase(null, false)]
    public void CheckIsEmailExist(string emailID, bool expectedValue)
    {
      Login login = new Login();
      var result = login.IsEmailExist(emailID);

      Assert.AreEqual(result, expectedValue);
    }

    [TestCase(9710948799, true)]
    [TestCase(123456789, false)]
    public void CheckIsPhoneNumberExist(long number, bool expectedValue)
    {
      Login login = new Login();
      var result = login.IsPhoneNumberExist(number);

      Assert.AreEqual(result, expectedValue);
    }
  }
}
