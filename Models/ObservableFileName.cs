using CommunityToolkit.Mvvm.ComponentModel;

namespace file_hasher_async.Models;

public partial class ObservableFileName : ObservableObject
{
    [ObservableProperty] public string name;
    [ObservableProperty] public bool hasDefaultChanged = false;

    public ObservableFileName(string name)
    {
        this.name = name;
    }

    partial void OnNameChanged(string? oldValue, string? newValue)
    {
        HasDefaultChanged = true;
    }

}

