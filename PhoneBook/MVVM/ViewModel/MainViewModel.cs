using PhoneBook.Core;
using PhoneBook.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace PhoneBook.MVVM.ViewModel
{
    internal class MainViewModel:ObservableObject
    {
        public ObservableCollection<DataModel> Dates { get; set; }
        public ICollectionView DatesView { get; set; }


        private DataModel _selectedCard;

        public DataModel SelectedCard
        {
            get { return _selectedCard; }
            set { _selectedCard = value;
                OnPropertyChanged();
            }
        }

        private string _searchText1;

        public string SearchText1
        {
            get { return _searchText1; }
            set 
            { 
                _searchText1 = value;
                ApplyFilter();
                
            }
        }       
        
        private string _searchText2;

        public string SearchText2
        {
            get { return _searchText2; }
            set 
            { 
                _searchText2 = value;
                ApplyFilter();

            }
        }

        private string _searchText3;

        public string SearchText3
        {
            get { return _searchText3; }
            set 
            { 
                _searchText3 = value;
                ApplyFilter();

            }
        }
        
        private string _searchText4;

        public string SearchText4
        {
            get { return _searchText4; }
            set 
            { 
                _searchText4 = value;
                ApplyFilter();

            }
        }



        /* Commands */

        private void ApplyFilter()
        {
            DatesView.Filter = o =>
            {
                if (o is DataModel data)
                {
                    bool matchesSearchText1 = string.IsNullOrEmpty(SearchText1) || data.Username.ToLower().Contains(SearchText1.ToLower());
                    bool matchesSearchText2 = string.IsNullOrEmpty(SearchText2) || data.Post.ToLower().Contains(SearchText2.ToLower());
                    bool matchesSearchText3 = string.IsNullOrEmpty(SearchText3) || data.LocalNumber.ToLower().Contains(SearchText3.ToLower());
                    bool matchesSearchText4 = string.IsNullOrEmpty(SearchText4) || data.CompanyDep.ToLower().Contains(SearchText4.ToLower());

                    // Применяем логический оператор для комбинирования условий
                    return matchesSearchText1 && matchesSearchText2 && matchesSearchText3 && matchesSearchText4;
                }

                return false;
            };

            DatesView.Refresh();
        }



        public MainViewModel() {
            Dates = new ObservableCollection<DataModel>();
            BindingOperations.EnableCollectionSynchronization(Dates, new object());
            DatesView = CollectionViewSource.GetDefaultView(Dates);

            




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
                    CompanyDep = $"Отдел IT{i}",
                });
            }
            for (int i = 0; i < 3; i++)
            {
                Dates.Add(new DataModel
                {
                    Username = $"Марья Иванновна{i}",
                    LocalNumber = $"{i}150",
                    PhoneNumber = "1234567890",
                    Email = "1234567890",
                    Post = "Помощник системного администратора",
                    CompanyName = "Алюминстрой",
                    CompanyDep = $"Отдел IT{i}",
                });
            }
            for (int i = 0; i < 4; i++)
            {
                Dates.Add(new DataModel
                {
                    Username = $"Вася Пупкин{i}",
                    LocalNumber = $"150",
                    PhoneNumber = "1234567890",
                    Email = "1234567890",
                    Post = "Помощник системного ",
                    CompanyName = "Алюминстрой",
                    CompanyDep = $"Отдел IT{i}",
                });
            }




        }





    }
}
