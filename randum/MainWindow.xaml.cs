using System;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace randum
{
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            this.ExtendsContentIntoTitleBar = true;

            var appWindowsPresenter = this.AppWindow.Presenter as OverlappedPresenter;
            if (appWindowsPresenter != null)
            {
                appWindowsPresenter.IsResizable = false;
                appWindowsPresenter.IsMaximizable = false;
            }

            AppWindow.Resize(new Windows.Graphics.SizeInt32(300, 300));
        }

        private void ValidateInput(TextBox sender, TextBoxBeforeTextChangingEventArgs args)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(args.NewText, "^[0-9]*$"))
            {
                args.Cancel = true;
            }
        }

        private void GenerateRandomNumber(object sender, RoutedEventArgs e)
        {
            Random random = new Random();

            if (int.TryParse(MinInput.Text, out int min) && int.TryParse(MaxInput.Text, out int max)) 
            {
                if (min < max)
                {
                    int randomNumber = random.Next(min, max + 1);
                    ResultDisplay.Text = randomNumber.ToString();
                }
            }
        }
    }
}
