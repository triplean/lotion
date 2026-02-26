using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Lotion.ViewModels;

namespace Lotion.Views;

public partial class Bootstrapper : Window
{
    public Bootstrapper()
    {
        InitializeComponent();
    }

    protected override void OnInitialized()
    {
        base.OnInitialized();
        Task.Run(() =>
        {
            var vm = new BootstrapperViewModel();
            Avalonia.Threading.Dispatcher.UIThread.InvokeAsync(() =>
            {
                return DataContext = vm;
            });

            Avalonia.Threading.Dispatcher.UIThread.InvokeAsync(() =>
            {
                vm.Progress = 25;
                vm.ProgressDescription = "Installing Roblox...";
            });
            
            if (!Backend.Bootstrapper.SoberInstalled()) Backend.Bootstrapper.InstallSober();

            Avalonia.Threading.Dispatcher.UIThread.InvokeAsync(() =>
            {
                vm.Progress = 50;
                vm.ProgressDescription = "Updating Roblox...";
            });
            Backend.Bootstrapper.UpdateSober();

            if (Backend.Utils.IsSoberRunning())
            {
                Avalonia.Threading.Dispatcher.UIThread.InvokeAsync(() =>
                {
                    var menu = new Menu();
                    menu.Show();
                    Close();
                });
            }

            Avalonia.Threading.Dispatcher.UIThread.InvokeAsync(() =>
            {
                vm.Progress = 100;
                vm.ProgressDescription = "Starting Roblox...";
            });
            
            Backend.Bootstrapper.StartSober();
            Avalonia.Threading.Dispatcher.UIThread.InvokeAsync(() => Close());
        });
    }

    private void OnCancel(object sender, RoutedEventArgs e)
    {
        Close();
    }
}