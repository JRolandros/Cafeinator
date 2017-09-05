using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafeinator.Config.config
{
  [ConfigurationCollection(typeof(OfflineUserDataConfigElement))]
  public class OfflineUserDataConfigCollection : ConfigurationElementCollection
  {
    internal const string PropertyName = "OfflineUserDataConfigElement";
    public override ConfigurationElementCollectionType CollectionType
    {
      get
      {
        return ConfigurationElementCollectionType.BasicMapAlternate;
      }
    }

    protected override string ElementName
    {
      get { return PropertyName; }
    }

    protected override bool IsElementName(string elementName)
    {
      return elementName.Equals(PropertyName, StringComparison.InvariantCultureIgnoreCase);
    }

    public override bool IsReadOnly()
    {
      return base.IsReadOnly();
    }

    protected override ConfigurationElement CreateNewElement()
    {
      return new OfflineUserDataConfigElement();
    }

    protected override object GetElementKey(ConfigurationElement element)
    {
      return ((OfflineUserDataConfigElement)element).UsrID;
    }

    public OfflineUserDataConfigElement this[int idx]
    {
      get
      {
        return (OfflineUserDataConfigElement)BaseGet(idx);
      }
    }

    public OfflineUserDataConfigElement GetByKey(string key)
    {
        return (OfflineUserDataConfigElement)BaseGet(key);
    }
  }
}
