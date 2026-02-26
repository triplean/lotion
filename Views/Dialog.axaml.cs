using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Lotion.ViewModels;

namespace Lotion.Views;

public partial class Dialog : Window
{
    public Dialog(string title, string message)
    {
        InitializeComponent();
        DataContext = new DialogViewModel(title, message);
    }

    private void AcceptDialog(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}