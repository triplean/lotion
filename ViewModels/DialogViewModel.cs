using CommunityToolkit.Mvvm.ComponentModel;

namespace Lotion.ViewModels;

public partial class DialogViewModel : ViewModelBase
{
    [ObservableProperty] private string _title;
    [ObservableProperty] private string _message;

    public DialogViewModel(string title, string message)
    {
        _title = title;
        _message = message;
    }
}