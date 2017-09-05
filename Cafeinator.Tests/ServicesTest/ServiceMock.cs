using Cafeinator.DataAccess.DataServices;
using Cafeinator.Infra.Models;
using Cafeinator.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafeinator.Tests.ServicesTest
{
  public class ServiceMock
  {
    IDataService Service;
    public ServiceMock(IDataService _service)
    {
      this.Service = _service;
    }
    public async Task<User> MockUser()
    {     
        var u = new User
        {
          BCode = "555",
          UsrName = "TestUser"
        };
      u=await Service.CreateUserAsync(u);

      return u;
    }

    public async Task<int> DeleteMockUser(int usrID)
    {
        return await Service.DeleteUserAsync(usrID);
    }

    public async Task<int> DeleteMockMenu(int usrID)
    {
      return await Service.DeleteMenuAsync(usrID);
    }

  }

  
}
