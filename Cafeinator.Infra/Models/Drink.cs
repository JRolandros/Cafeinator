using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafeinator.Infra.Models
{
  public class Drink
  {
    private int drkID;

    public int DrkID
    {
      get { return drkID; }
      set { drkID = value; }
    }

    private string drkLable;

    public string DrkLabel
    {
      get { return drkLable; }
      set { drkLable = value; }
    }

    private int sugarQty;

    public int SugarQty
    {
      get { return sugarQty; }
      set { sugarQty = value; }
    }

  }
}
