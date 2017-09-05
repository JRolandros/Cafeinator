using Cafeinator.App.Helpers.Navigation;
using Cafeinator.App.Views;
using Cafeinator.DataAccess.DataServices;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafeinator.App.ViewModels
{
  public class ViewModelLocator
  {
    public const string LOGIN_VIEW = "LOGIN";
    public const string MENU_VIEW = "MENU";
    public const string ADD_USER_VIEW = "ADDUSER";
    public ViewModelLocator()
    {
      ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

      SimpleIoc.Default.Register<IDataService, DataService>();
      
      SimpleIoc.Default.Register<ICafeinatorNavigationService>(() =>
      {
        var navService = new CafeinatorNavigationService();
        navService.RegisterPage(LOGIN_VIEW, typeof(LoginView));
        navService.RegisterPage(MENU_VIEW, typeof(MenuView));
        return navService;
      });

      SimpleIoc.Default.Register<LoginViewModel>();
      SimpleIoc.Default.Register<MenuViewModel>();
      SimpleIoc.Default.Register<BaseViewModel>();
    }

    public LoginViewModel LoginVM
    {
      get { return SimpleIoc.Default.GetInstance<LoginViewModel>(); }
    }

    public MenuViewModel MenuVM
    {
      get { return SimpleIoc.Default.GetInstance<MenuViewModel>(); }
    }

    public BaseViewModel BaseVM
    {
      get { return SimpleIoc.Default.GetInstance<BaseViewModel>(); }
    }

    public static void Cleanup()
    {
      // TODO Clear the ViewModels
    }
  }
}
