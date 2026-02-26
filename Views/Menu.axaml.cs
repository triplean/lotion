using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace Lotion.Views;

public partial class Menu : Window
{
    public Menu()
    {
        InitializeComponent();
    }

    private void BootstrapperButtonClick(object? sender, RoutedEventArgs e)
    {
        Window bootstrapper = new Bootstrapper();
        bootstrapper.Show();
        Close();
    }
}