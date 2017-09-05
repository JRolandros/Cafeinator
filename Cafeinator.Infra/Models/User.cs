using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafeinator.Infra.Models
{
  public class User
  {
    private int usrID;
    /// <summary>
    /// User ID. technical Id
    /// </summary>
    public int UsrID
    {
      get { return usrID; }
      set { usrID = value; }
    }

    private string usrName;
    /// <summary>
    /// User name
    /// </summary>
    public string UsrName
    {
      get { return usrName; }
      set { usrName = value; }
    }

    private string bCode;
    /// <summary>
    /// Badge code
    /// </summary>
    public string BCode
    {
      get { return bCode; }
      set { bCode = value; }
    }

  }
}
