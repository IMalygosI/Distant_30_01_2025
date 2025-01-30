using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Distant;

public partial class Error : Window
{
    public Error(string Warning)
    {
        InitializeComponent();

        if (Warning == "")
        {
            warning.Text = Warning;
        }
        else if (Warning == "")
        {
            warning.Text = Warning;
        }

    }
    public Error()
    {
        InitializeComponent();
    }

    private void Button_Click_Out(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        Close();
    }
}