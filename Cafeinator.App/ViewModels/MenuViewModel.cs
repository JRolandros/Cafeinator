using Cafeinator.App.Helpers.Commands;
using Cafeinator.App.Helpers.Navigation;
using Cafeinator.App.Models;
using Cafeinator.DataAccess.DataServices;
using Cafeinator.Infra.Models;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Cafeinator.App.ViewModels
{
  public class MenuViewModel : BaseViewModel
  {

    private DrinkModel selectedDrink;

    public DrinkModel SelectedDrink
    {
      get { return selectedDrink; }
      set { selectedDrink = value; OnPropertyChanged(); }
    }

    private int sugarQty;

    public int SugarQty
    {
      get { return sugarQty; }
      set { sugarQty = value; OnPropertyChanged(); }
    }

    private bool isGoodByeVisible;

    public bool IsGoodByeVisible
    {
      get { return isGoodByeVisible; }
      set { isGoodByeVisible = value; OnPropertyChanged(); }
    }


    private List<DrinkModel> drinks;
    public ObservableCollection<DrinkModel> Drinks
    {
      get
      {
        return new ObservableCollection<DrinkModel>(drinks);
      }

    }

    

    private ICommand checkedCommand;

    public ICommand CheckedCommand
    {
      get
      {
        return checkedCommand ?? (checkedCommand = new RelayCommand(o =>
      {
        drinks = drinks.Where(d => d.DrkID != ((DrinkModel)o).DrkID).Select(x => { x.IsDrinkSelected = false; return x; }).ToList();
        drinks.Add((DrinkModel)o);
        SelectedDrink = (DrinkModel)o;
      }));
      }
    }

    private ICommand unCheckedCommand;

    public ICommand UnCheckedCommand
    {
      get
      {
        return unCheckedCommand ?? (unCheckedCommand = new RelayCommand(o =>
        {
          SelectedDrink = null;
        }));
      }
    }
    private ICommand addSugarCommand;

    public ICommand AddSugarCommand
    {
      get
      {
        return addSugarCommand ?? (addSugarCommand = new RelayCommand(o =>
        {
          if (SelectedDrink != null && SugarQty < 5)
            SugarQty++;
        }));
      }
    }

    private ICommand removeSugarCommand;

    public ICommand RemoveSugarCommand
    {
      get
      {
        return removeSugarCommand ?? (removeSugarCommand = new RelayCommand(o =>
        {
          if (SelectedDrink != null && SugarQty > 0)
            SugarQty--;
        }));
      }
    }

    private ICommand serveCoffeeCommand;

    public ICommand ServeCoffeeCommand
    {
      get
      {
        return serveCoffeeCommand ?? (serveCoffeeCommand = new RelayCommand(o =>
        {
          if (SelectedDrink != null)
          {
            serveCoffe();
          }
        }));
      }
    }

    private async void serveCoffe()
    {
      SelectedDrink.SugarQty = SugarQty;
      Drink drink = SelectedDrink.GetDrinkFromModel();
      await this.dataService.SaveLastUserDrinkAsync(drink, CurrentUser.UsrID);
      IsGoodByeVisible = true;
      await Task.Delay(10000);
      IsGoodByeVisible = false;
      navService.NavigateTo(ViewModelLocator.LOGIN_VIEW);
      
    }

    public override async Task InitProperties()
    {

      if (CurrentUser!=null)
      {
        var drink = await dataService.GetUserLastChoiceAsync(CurrentUser);
        if (drink != null)
        {
          SelectedDrink = drinks.Where(x => x.DrkID == drink.DrkID).Select(x => { x.IsDrinkSelected = true; return x; }).FirstOrDefault();
          Drinks.Remove(Drinks.Where(x => x.DrkID == drink.DrkID).FirstOrDefault());
          Drinks.Add(SelectedDrink);
          SugarQty = drink.SugarQty;
        }
      }
    }
    IDataService dataService;
    private ICafeinatorNavigationService navService;
    public MenuViewModel(IDataService _DataService, ICafeinatorNavigationService _navService)
    {
      this.dataService = _DataService;
      this.navService = _navService;
      IsGoodByeVisible = false;

      drinks = new List<DrinkModel>
      {
        new DrinkModel {DrkID=1,DrkLabel=" Cafe",SugarQty=0},
        new DrinkModel {DrkID=2,DrkLabel=" The",SugarQty=0 },
        new DrinkModel {DrkID=3,DrkLabel=" Chocolat",SugarQty=0 }
      };
    }

  }
}
