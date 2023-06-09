using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace PhoneBook.MVVM.View
{
    /// <summary>
    /// Логика взаимодействия для CurrentUserInfoView.xaml
    /// </summary>
    public partial class CurrentUserInfoView : Popup
    {
        public CurrentUserInfoView()
        {
            InitializeComponent();
            Messsage.Focus();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string emailSubject = "Изменение данных о пользователе (справочник)";
            string emailBody = Messsage.Text; // Получение текста из TextBox

            string mailtoUri = $"mailto:hd@aluminstroy.ru?subject={Uri.EscapeDataString(emailSubject)}&body={Uri.EscapeDataString(emailBody)}";

            Process.Start(new ProcessStartInfo
            {
                FileName = mailtoUri,
                UseShellExecute = true
            });

        }

        private void Window_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            
        }
    }
}
