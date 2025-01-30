using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Distant.Models;

namespace Distant;

public partial class GlavnOkko : Window
{
    Employee Employee1;
    public GlavnOkko()
    {
        InitializeComponent();
        Employee1 = new Employee();
    }
    public GlavnOkko(Employee employee)
    {
        InitializeComponent();
        Employee1 = employee;
    }

    private void Button_Click_Out(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        MainWindow mainWindow = new MainWindow();
        mainWindow.Show();
        Close();
    }
}