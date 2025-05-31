using CommunityToolkit.Mvvm.ComponentModel;

namespace file_hasher_async.Models;

public partial class ObservableFileName : ObservableObject
{
    [ObservableProperty] public string name;

    public ObservableFileName(string name)
    {
        this.name = name;
    }
}

