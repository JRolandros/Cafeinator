using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafeinator.Config.config
{
  public class OfflineUserDataConfigElement : ConfigurationElement
  {
    [ConfigurationProperty("UsrID", DefaultValue = "", IsKey = true, IsRequired = true)]
    public string UsrID
    {
      get { return (string)this["UsrID"]; }
      set { this["UsrID"] = value; }
    }

    [ConfigurationProperty("BCode", DefaultValue = "", IsKey = false, IsRequired = true)]
    public string BCode
    {
      get { return (string)this["BCode"]; }
      set { this["BCode"] = value; }
    }

    [ConfigurationProperty("UsrName", DefaultValue = "", IsKey = false, IsRequired = true)]
    public string UsrName
    {
      get { return (string)this["UsrName"]; }
      set { this["UsrName"] = value; }
    }

  }
}
