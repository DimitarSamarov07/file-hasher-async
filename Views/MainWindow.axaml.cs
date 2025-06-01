using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Styling;


namespace file_hasher_async.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private double ScreenWidth()
    {
        var screen = this.Screens.ScreenFromVisual(this);
        if (screen is not null)
        {
            return screen.WorkingArea.Width;
        }

        return 30.0;
    }

    private void Switch_Toggler(object? sender, RoutedEventArgs e)
    {
        if (sender is not ToggleSwitch toggle)
            return;

        RequestedThemeVariant = toggle.IsChecked == true
            ? ThemeVariant.Dark
            : ThemeVariant.Light;
    }
}