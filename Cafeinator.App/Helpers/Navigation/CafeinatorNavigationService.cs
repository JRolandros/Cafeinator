using Cafeinator.App.ViewModels;
using Cafeinator.App.Views;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;

namespace Cafeinator.App.Helpers.Navigation
{
  public class CafeinatorNavigationService : ICafeinatorNavigationService
  {
    private readonly Dictionary<String, UserControl> _framesDictionary = new Dictionary<string, UserControl>();
    private readonly Dictionary<String, Type> _framesTypeDictionary = new Dictionary<string, Type>();
    public object CurrentData { get; set; }

    private Frame Mainframe;
    public CafeinatorNavigationService()
    {
    }

    public void Initialize(MainWindow mainWindow, string startKey, object data = null)
    {
      this.Mainframe = mainWindow.GetMainFrame();
      Mainframe.NavigationUIVisibility = NavigationUIVisibility.Hidden;
      NavigateTo(startKey, data);
    }


    public void RegisterPage(string key, Type type)
    {
      _framesTypeDictionary.Add(key, type);
    }

    public void NavigateTo(string key)
    {
      this.NavigateTo(key, null);
    }

    public void NavigateTo(string key, object data)
    {
      UserControl nextFrame = null;
      Type nextFrameType = null;
      _framesDictionary.TryGetValue(key, out nextFrame);
      _framesTypeDictionary.TryGetValue(key, out nextFrameType);
      if (Mainframe != null)
      {
        if (nextFrameType == null)
          return;

        if (nextFrame == null)
        {
          nextFrame = (UserControl)Activator.CreateInstance(nextFrameType);

          _framesDictionary.Add(key, nextFrame);
        }

        var frameContext = (BaseViewModel)nextFrame.DataContext;
        if (nextFrameType != typeof(LoginView))
          frameContext.InitProperties().ConfigureAwait(false);//Don't collect this current context state, just go with another thread and terminate your self.

        Mainframe.Navigate(nextFrame, data);
      }
    }

    private bool CanGoBack()
    {
      return Mainframe != null && Mainframe.CanGoBack;
    }

    public void GoBack()
    {
      if (!CanGoBack())
        return;
      Mainframe.GoBack();
    }

    public void Dispose()
    {
    }
  }
}
