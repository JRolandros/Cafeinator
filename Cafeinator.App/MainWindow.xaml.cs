using Cafeinator.App.Helpers.Navigation;
using Cafeinator.App.ViewModels;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Cafeinator.App
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
      
    }

    protected override void OnContentRendered(EventArgs e)
    {
      base.OnActivated(e);
      ServiceLocator.Current.GetInstance<ICafeinatorNavigationService>().Initialize(this, ViewModelLocator.LOGIN_VIEW);
    }

    public Frame GetMainFrame()
    {
      return MainFrame;
    }
  }
}
