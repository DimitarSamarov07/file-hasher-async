using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Interactivity;
using Avalonia.Platform.Storage;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using file_hasher_async.Models;

namespace file_hasher_async.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public string Greeting { get; } = "Welcome to file-hasher-async!";

    public string WorkInProgress { get; } =
        "Please stand back while we are working on doing something. Come back next week :)";

    public ObservableFileName firstFileName { get; set; }
    public ObservableFileName secondFileName { get; set; }

    private IStorageFile firstFile;
    private IStorageFile secondFile;


    public MainWindowViewModel()
    {
        firstFileName = new ObservableFileName("Select the first file");
        secondFileName = new ObservableFileName("Select the second file");
    }

    public async Task OpenFile(FileOrder order)
    {
        var file = await OpenFilePickerAsync();
        if (file is null) return;

        switch (order)
        {
            case FileOrder.First:
                firstFile = file;
                firstFileName.Name = file.Name;
                break;
            case FileOrder.Second:
                secondFile = file;
                secondFileName.Name = file.Name;
                break;
        }
    }

    private async Task<IStorageFile?> OpenFilePickerAsync()
    {
        // Magic definition of the storage provider
        if (Application.Current?.ApplicationLifetime is not IClassicDesktopStyleApplicationLifetime desktop ||
            desktop.MainWindow?.StorageProvider is not { } provider)
        {
            throw new NullReferenceException("Missing StorageProvider instance.");
        }

        // Open the file picker and return the file selected
        var file = await provider.OpenFilePickerAsync(new FilePickerOpenOptions
        {
            Title = "Open Text File",
            AllowMultiple = false
        });

        return file?.Count >= 1 ? file[0] : null;
    }
}

public enum FileOrder
{
    First,
    Second
}