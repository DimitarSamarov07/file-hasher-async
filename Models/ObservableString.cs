using CommunityToolkit.Mvvm.ComponentModel;

namespace file_hasher_async.Models;

public partial class ObservableString : ObservableObject
{
    [ObservableProperty] public string stringValue;
}