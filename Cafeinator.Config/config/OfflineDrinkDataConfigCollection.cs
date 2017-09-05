using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafeinator.Config.config
{
  [ConfigurationCollection(typeof(OfflineDrinkDataConfigElement))]
  public class OfflineDrinkDataConfigCollection : ConfigurationElementCollection
  {
    internal const string PropertyName = "OfflineDrinkDataConfigElement";
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
      return new OfflineDrinkDataConfigElement();
    }

    protected override object GetElementKey(ConfigurationElement element)
    {
      return ((OfflineDrinkDataConfigElement)element).DrkID;
    }

    public OfflineDrinkDataConfigElement this[int idx]
    {
      get
      {
        return (OfflineDrinkDataConfigElement)BaseGet(idx);
      }
    }

    public OfflineDrinkDataConfigElement GetByKey(string key)
    {
        return (OfflineDrinkDataConfigElement)BaseGet(key);
    }
  }
}
