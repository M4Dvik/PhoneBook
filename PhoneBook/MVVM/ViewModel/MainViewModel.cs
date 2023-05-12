using PhoneBook.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.MVVM.ViewModel
{
    internal class MainViewModel
    {
        public ObservableCollection<CardModel> Cards { get; set; }
        public ObservableCollection<DataModel> Dates { get; set; }



        public MainViewModel() {
            Cards = new ObservableCollection<CardModel>();
            Dates = new ObservableCollection<DataModel>();
            
            Dates.Add(new DataModel
            {
                Username = "Илья Евсеев",
                LocalNumber = "150",
                PhoneNumber = "1234567890",
                Email = "1234567890",
                Post = "Помощник системного администратора",
                CompanyName = "Алюминстрой",
                CompanyDep = "Отдел IT",
                IsNativeOrigin = false,
            });

            for (int i = 0; i < 3; i++)
            {
                Dates.Add(new DataModel
                {
                    Username = "Илья Евсеев",
                    LocalNumber = "150",
                    PhoneNumber = "1234567890",
                    Email = "1234567890",
                    Post = "Помощник системного администратора",
                    CompanyName = "Алюминстрой",
                    CompanyDep = "Отдел IT",
                    IsNativeOrigin = false,
                });
            }
            for (int i = 0; i < 4; i++)
            {
                Dates.Add(new DataModel
                {
                    Username = "Вася Пупкин",
                    LocalNumber = "150",
                    PhoneNumber = "1234567890",
                    Email = "1234567890",
                    Post = "Помощник системного администратора",
                    CompanyName = "Алюминстрой",
                    CompanyDep = "Отдел IT",
                    IsNativeOrigin = true,
                });
            }
            Dates.Add(new DataModel
            {
                Username = "Вася Пупкин",
                LocalNumber = "150",
                PhoneNumber = "1234567890",
                Email = "1234567890",
                Post = "Помощник системного администратора",
                CompanyName = "Алюминстрой",
                CompanyDep = "Отдел IT",
                IsNativeOrigin = true,
            });
            for (int i = 0; i < 5; i++)
            {
                Cards.Add(new CardModel
                {
                    Username = $"Илья {i}",
                    Dates = Dates,

                });
            }


        }




    }
}
