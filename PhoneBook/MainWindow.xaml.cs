using System;

using System.Windows;

using System.Windows.Input;

using System.Diagnostics;
using PhoneBook.MVVM.View;
using System.Windows.Controls.Primitives;

namespace PhoneBook
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SearchTextBox.Focus();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void ButtonMinimize_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private void WindowStateButton_Click(object sender, RoutedEventArgs e)
        {
            if (Application.Current.MainWindow.WindowState != WindowState.Maximized)
            {
                Application.Current.MainWindow.WindowState = WindowState.Maximized;
                Application.Current.MainWindow.BorderThickness = new Thickness(7);
            } else
            {
                Application.Current.MainWindow.BorderThickness = new Thickness(0);
                Application.Current.MainWindow.WindowState = WindowState.Normal;
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void SendMailButton_Click(object sender, RoutedEventArgs e)
        {
                // Открываем Outlook и создаем новое письмо
                Process.Start(new ProcessStartInfo
                {
                    FileName = $"mailto:{MailTextBox.Text}",
                    UseShellExecute = true,
                }); 

        }

        private void Border_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            SearchTextBox.Text = CurrentUserName.Text;
            if (ListUser.Items.Count > 0)
            {
                ListUser.SelectedItem = ListUser.Items[0];
            }
        }

        private void OpenWindowButton_Click(object sender, RoutedEventArgs e)
        {
            var messageWindow = new CurrentUserInfoView();
            messageWindow.PlacementTarget = this;
            messageWindow.HorizontalOffset = 8;
            messageWindow.VerticalOffset = this.ActualHeight - 60;
            messageWindow.IsOpen = true;
        }

    }
}
