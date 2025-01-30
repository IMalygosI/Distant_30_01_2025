using System;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Controls;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Distant
{
    public partial class MainWindow : Window
    {
        bool war = true;

        public MainWindow()
        {
            InitializeComponent();
        }
        private async Task isvisible()
        {
            await Task.Delay(10000);
            Entrance.IsVisible = true;
        }
        private string GenerateString(int length)
        {
            string chars = "QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm0123456789";
            Random random = new Random();
            char[] result = new char[length];
            for (int i = 0; i < length; i++)
            {
                int index = random.Next(chars.Length);
                result[i] = chars[index];
            }
            return new string(result);
        }
        private void UpdateCaptcha()
        {
            string randomText = GenerateString(4);
            CapchaTextBlock.Text = randomText;
        }
        private void Button_Click_Entrance(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            var User = Helper.Base.Employees.FirstOrDefault(z => z.Password == password.Text & z.Login == login.Text);

            if (war != true)
            {
                if (User != null)
                {
                    if (CapchaTextBlock.Text != null && CapchaTextBox.Text != null && CapchaTextBlock.Text == CapchaTextBox.Text)
                    {
                        GlavnOkko glavnOkko = new GlavnOkko(User);
                        glavnOkko.Show();
                        Close();
                        CapchaTextBlock.IsVisible = false;
                        CapchaTextBox.IsVisible = false;
                    }
                    else
                    {
                        string Errors = "Невенрый Ввод капчи";
                        Error error = new Error(Errors);
                        error.ShowDialog(this);

                        Entrance.IsVisible = false;

                        isvisible();
                        UpdateCaptcha();
                    }
                }
                else
                {
                    string Errors = "Логин или Пароль введены не верно!";
                    Error error = new Error(Errors);
                    error.ShowDialog(this);
                }
            }
            else
            {
                if (User != null)
                {
                    GlavnOkko glavnOkko = new GlavnOkko(User);
                    glavnOkko.Show();
                    Close();
                }
                else
                {
                    string Errors = "Логин или Пароль введены не верно!";
                    war = false;
                    Error error = new Error(Errors);
                    error.ShowDialog(this);

                    CapchaTextBlock.IsVisible = true;
                    CapchaTextBox.IsVisible = true;
                    UpdateCaptcha();
                }
            }
        }

        private void togglePassword(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            if (password != null)
            {
                password.PasswordChar = password.PasswordChar == '*' ? '\0' : '*';
            }
        }
    }
}