using PhoneBook.Core;
using PhoneBook.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.MVVM.ViewModel
{
    internal class MainViewModel:ObservableObject
    {
        public ObservableCollection<CardModel> Cards { get; set; }
        public ObservableCollection<DataModel> Dates { get; set; }

            /* Commands */

        public RelayCommand SendCommand { get; set; }
        public CardModel SelectedCard { get; set; }

        private string _LocalNumber;
        public string LocalNumber
        {
            get { return _LocalNumber; }
            set
            {
                _LocalNumber = value;
                OnPropertyChanged();
            }
        }



        public MainViewModel() {
            Cards = new ObservableCollection<CardModel>();
            Dates = new ObservableCollection<DataModel>();

            SendCommand = new RelayCommand(o =>
            {
                Dates.Add(new DataModel
                {
                    LocalNumber = LocalNumber,

                });

                LocalNumber = "";
            });

            
            for (int i = 0; i < 3; i++)
            {
                Dates.Add(new DataModel
                {
                    Username = $"Илья Евсеев{i}",
                    LocalNumber = "150",
                    PhoneNumber = "1234567890",
                    Email = "1234567890",
                    Post = "Помощник  администратора",
                    CompanyName = "Алюминстрой",
                    CompanyDep = "Отдел IT",
                    IsNativeOrigin = false,
                });
            }
            for (int i = 0; i < 4; i++)
            {
                Dates.Add(new DataModel
                {
                    Username = $"Вася Пупкин{i}",
                    LocalNumber = "150",
                    PhoneNumber = "1234567890",
                    Email = "1234567890",
                    Post = "Помощник системного ",
                    CompanyName = "Алюминстрой",
                    CompanyDep = "Отдел IT",
                    IsNativeOrigin = true,
                });
            }

            foreach (DataModel user in Dates)
            {
                if (user != null)
                {
                    Cards.Add(new CardModel
                    {
                        Username = user.Username,
                        Post = user.Post,
                    }); 
                }
            }


        }




    }
}
