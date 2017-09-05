using Cafeinator.DataAccess.DataServices;
using Cafeinator.Infra.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Cafeinator.Tests.ServicesTest
{
  [TestClass]
  public class BaseUnitTest
  {
    public User mockUser { get; private set; }
    protected static ServiceMock serviceMock;
    protected IDataService service;

    [TestInitialize()]
    public void TestInitialize()
    {
      //TODO: create real transaction initializer strategic here

      //since we don't have better strategy made up, let just create data and then delete it.
      service = new DataService();
      serviceMock = new ServiceMock(service);
      serviceMock.MockUser().ContinueWith(x =>
      {
        mockUser = x.Result;
      }).Wait();
      
    }

    [TestCleanup()]
    public void TestCleanup()
    {
      //TODO: get the current real transaction object and roll it back

      //delete menu first to avoid reltionship violation
      serviceMock.DeleteMockMenu(mockUser.UsrID).Wait();
      //then delete user
      serviceMock.DeleteMockUser(mockUser.UsrID).Wait();
    }

    //[AssemblyCleanup()]
    //public static void TestCleanup()
    //{
    //  //TODO: get the current real transaction object and roll it back

    //  serviceMock.DeleteMockUser(mockUser.UsrID).Wait();
    //}

  }
}
