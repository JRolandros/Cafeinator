using Cafeinator.Infra.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Cafeinator.App.ViewModels
{
  public class BaseViewModel : INotifyPropertyChanged
  {
    private UserControl currentView;
    public UserControl CurrentView
    {
      get
      {
        return currentView;
      }
      set
      {
        currentView = value;
        OnPropertyChanged();
      }
    }

    private string errorMessage;
    public string ErrorMessage
    {
      get
      {
        return errorMessage;
      }
      set
      {
        errorMessage = value; OnPropertyChanged();
      }
    }

    private static User currentUser;

    public static User CurrentUser
    {
      get { return currentUser; }
      set { currentUser = value; }
    }

    public virtual Task InitProperties()
    {
      return null;
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
