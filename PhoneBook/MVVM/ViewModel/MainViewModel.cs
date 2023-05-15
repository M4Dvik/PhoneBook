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
        public ObservableCollection<DataModel> Dates { get; set; }
        private DataModel _selectedCard;

        public DataModel SelectedCard
        {
            get { return _selectedCard; }
            set { _selectedCard = value;
                OnPropertyChanged();
            }
        }

        /* Commands */








        public MainViewModel() {
            Dates = new ObservableCollection<DataModel>();

             



            
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
                });
            }




        }




    }
}
