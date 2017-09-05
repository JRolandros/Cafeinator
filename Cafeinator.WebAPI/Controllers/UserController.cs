using Cafeinator.Infra.Models;
using Cafeinator.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Cafeinator.WebAPI.Controllers
{
  public class UserController : ApiController
  {
    // GET api/<controller>
    public User Get(string bCode)
    {
      using(CafeinatorDBEntities dbCtx=new CafeinatorDBEntities())
      {
        var u = dbCtx.GetUser(bCode);
        return u.Select(x =>
        {
          return new User { BCode = x?.BCode, UsrID = (int)x?.usrID, UsrName = x?.usrName };
        }).FirstOrDefault();
      }
    }


    // POST api/<controller>
    public User Post(User user)
    {
      using(CafeinatorDBEntities dbCtx=new CafeinatorDBEntities())
      {
        return dbCtx.AddNewUser(user.BCode, user.UsrName).Select(x =>
        {
          return new User
          {
            BCode = x?.BCode,
            UsrID = (int)x?.usrID,
            UsrName = x?.usrName
          };
        }).FirstOrDefault();
      }
    }

    public int Delete(int id)
    {
      using (CafeinatorDBEntities dbCtx = new CafeinatorDBEntities())
      {
        return dbCtx.DeleteUser(id);
      }
    }

  }
}