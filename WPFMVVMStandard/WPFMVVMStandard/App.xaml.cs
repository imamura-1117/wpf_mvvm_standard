using System.Windows;
using WPFMVVMStandard.ViewModels;
using WPFMVVMStandard.Views;

namespace WPFMVVMStandard
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            // MainView
            var mainView = new MainView();
            mainView.DataContext = new MainViewModel();

            mainView.Show();
        }
    }

}
