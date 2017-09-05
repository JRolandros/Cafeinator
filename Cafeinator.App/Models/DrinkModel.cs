using Cafeinator.Infra.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Cafeinator.App.Models
{
  public class DrinkModel : INotifyPropertyChanged
  {
    public DrinkModel(Drink drink)
    {
      this.DrkID = drink.DrkID;
      this.DrkLabel = drink.DrkLabel;
      this.SugarQty = drink.SugarQty;
    }
    public DrinkModel()
    {

    }
    private bool isDrinkSelected;

    public bool IsDrinkSelected
    {
      get { return isDrinkSelected; }
      set { isDrinkSelected = value; OnPropertyChanged(); }
    }

    private int drkID;

    public int DrkID
    {
      get { return drkID; }
      set { drkID = value; OnPropertyChanged(); }
    }

    private string drkLable;

    public string DrkLabel
    {
      get { return drkLable; }
      set { drkLable = value; OnPropertyChanged(); }
    }

    private int sugarQty;

    public int SugarQty
    {
      get { return sugarQty; }
      set { sugarQty = value; OnPropertyChanged(); }
    }


    public Drink GetDrinkFromModel()
    {
      return new Drink() { DrkID = this.DrkID, DrkLabel = this.DrkLabel, SugarQty = this.SugarQty };
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] String propertyName = "")
    {
      var handler = PropertyChanged;
      if (handler != null)
      {
        handler(this, new PropertyChangedEventArgs(propertyName));
      }
    }
  }
}
