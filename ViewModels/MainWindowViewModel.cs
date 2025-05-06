using Avalonia.Interactivity;

namespace file_hasher_async.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public string Greeting { get; } = "Welcome to file-hasher-async!";
    public string WorkInProgress{ get; } = "Please stand back while we are working on doing something. Come back next week :)";
    
}