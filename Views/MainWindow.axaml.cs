using Avalonia.Animation;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace file_hasher_async.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    // private void ClickHandler(object? sender, RoutedEventArgs e)
    // {
    //     Message.Text = "Hashing....(some day)";
    //     var animation = (Animation)this.Resources["EmojiMagic"];
    //     animation?.RunAsync(Emoji);
    // }

    private double ScreenWidth()
    {
        var screen = this.Screens.ScreenFromVisual(this);
        if (screen is not null)
        {
            return screen.WorkingArea.Width;
        }
        return 30.0;
    }
}