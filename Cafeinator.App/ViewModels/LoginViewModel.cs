using Cafeinator.App.Helpers.Commands;
using Cafeinator.App.Helpers.Navigation;
using Cafeinator.DataAccess.DataServices;
using Cafeinator.Infra.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Cafeinator.App.ViewModels
{
  public class LoginViewModel : BaseViewModel
  {
    private IDataService DataService;
    private ICafeinatorNavigationService navService;
    public LoginViewModel(IDataService _dataService, ICafeinatorNavigationService _navService)
    {
      CanBadgeAgain = true;
      this.DataService = _dataService;
      this.navService = _navService;
    }

    private bool canBadgeAgain;

    public bool CanBadgeAgain
    {
      get { return canBadgeAgain; }
      set { canBadgeAgain = value; OnPropertyChanged(); }
    }

    
    private string login;
    /// <summary>
    /// Badge code is your login
    /// </summary>
    public string Login
    {
      get { return login; }
      set { login = value; OnPropertyChanged(); }
    }

    private ICommand authenticationCommand;
    public ICommand AuthenticationCommand
    {
      get
      {
        return authenticationCommand ?? (authenticationCommand = new RelayCommand(
            o =>
          {          
            authenticate();
            
          }
          ));
      }
    }

    private ICommand addNewUserCommand;


    public ICommand AddNewUserCommand
    {
      get
      {
        return addNewUserCommand ?? (addNewUserCommand = new RelayCommand(
          o =>
          {
            goToAddUserViewModel();
          }));
      }
    }
    private async void authenticate()
    {
      CanBadgeAgain = false;
      ErrorMessage = "";
      User user = await this.DataService.LoginAsync(this.Login);
      
      if (user != null)
      {
        CurrentUser = user;
        navService.NavigateTo(ViewModelLocator.MENU_VIEW);
        ErrorMessage = "";
      }
      else
      {
        ErrorMessage = "badge non reconnu ! Demander à un collègue de vous ajouter";
      }
      CanBadgeAgain = true;
    }

    private void goToAddUserViewModel()
    {

    }
  }
}
