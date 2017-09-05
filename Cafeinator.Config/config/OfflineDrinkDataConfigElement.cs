using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafeinator.Config.config
{
  public class OfflineDrinkDataConfigElement : ConfigurationElement
  {
    [ConfigurationProperty("DrkID", DefaultValue = "", IsKey = true, IsRequired = true)]
    public string DrkID
    {
      get { return (string)this["DrkID"]; }
      set { this["DrkID"] = value; }
    }

    [ConfigurationProperty("DrkLabel", DefaultValue = "", IsKey = false, IsRequired = true)]
    public string BCode
    {
      get { return (string)this["DrkLabel"]; }
      set { this["DrkLabel"] = value; }
    }

  }
}
