using CommunityToolkit.Mvvm.ComponentModel;

namespace Lotion.ViewModels;

public partial class BootstrapperViewModel : ViewModelBase
{
    [ObservableProperty]
    private int progress;
    [ObservableProperty]
    private string progressDescription;
}