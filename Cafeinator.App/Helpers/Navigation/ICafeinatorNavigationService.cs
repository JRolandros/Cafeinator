using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Cafeinator.App.Helpers.Navigation
{
  public interface ICafeinatorNavigationService
  {
    void Initialize(MainWindow MainWindow, string startKey, object data = null);
    void RegisterPage(string key, Type type);
    void NavigateTo(string key);
    void NavigateTo(string key, object data);
    void GoBack();
    void Dispose();
  }
}
