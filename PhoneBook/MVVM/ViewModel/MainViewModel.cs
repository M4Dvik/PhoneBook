using PhoneBook.Core;
using PhoneBook.MVVM.Model;
using PhoneBook.MVVM.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;


namespace PhoneBook.MVVM.ViewModel
{
    internal class MainViewModel:ObservableObject
    {
        public ObservableCollection<DataModel> Dates { get; set; }
        public ICollectionView DatesView { get; set; }


        private DataModel? _selectedCard;
        public DataModel SelectedCard
        {
            get { return _selectedCard; }
            set { _selectedCard = value;
                OnPropertyChanged();
                if (value != null)
                {

                    Application.Current.MainWindow.Width = 600;

                } else
                {
                    
                    Application.Current.MainWindow.Width = 300;

                }
            }
        }

        private string? _searchText;
        public string SearchText
        {
            get { return _searchText; }
            set 
            { 
                _searchText = value;
                ApplyFilter();
                
            }
        }

        private string? _currentUserName;
        public string? CurrentUserName
        {
            get { return _currentUserName; }
            set
            {
                _currentUserName = value;
                OnPropertyChanged(); // Вызов события OnPropertyChanged для обновления привязки
            }
        }

        private string? _CurrentUserDepartment;
        public string? CurrentUserDepartment
        {
            get { return _CurrentUserDepartment; }
            set { _CurrentUserDepartment = value;
                OnPropertyChanged();
            }
        }

        private string _connectionIcon;
        public string ConnectionIcon
        {
            get { return _connectionIcon; }
            set { _connectionIcon = value; }
        }








        public MainViewModel() {
            Dates = new ObservableCollection<DataModel>();
            BindingOperations.EnableCollectionSynchronization(Dates, new object());
            DatesView = CollectionViewSource.GetDefaultView(Dates);

            try
            {
                CurrentUserName = ActiveDirectory.CurrentUserName;
            }
            catch (Exception)
            {
                CurrentUserName = "Default";
            } // Current User Name OR No Connection

            try
            {
                CurrentUserDepartment = ActiveDirectory.CurrentUserDepartment;
            }
            catch (Exception)
            {
                CurrentUserDepartment = "DefaultDefaultDefaultDefaultDefaultDefaultDefault";
            } // Current User Post OR No Connection

            try
            {
                foreach (SearchResult searchResult in ActiveDirectory.Users)
                {
                    string? username = searchResult.Properties.Contains("name") ? searchResult.Properties["name"][0].ToString() : null;
                    string? localNumber = searchResult.Properties.Contains("telephoneNumber") ? searchResult.Properties["telephoneNumber"][0].ToString() : null;
                    string? phoneNumber = searchResult.Properties.Contains("mobile") ? searchResult.Properties["mobile"][0].ToString() : null;
                    string? email = searchResult.Properties.Contains("mail") ? searchResult.Properties["mail"][0].ToString() : null;
                    string? post = searchResult.Properties.Contains("title") ? searchResult.Properties["title"][0].ToString() : null;
                    string? companyName = searchResult.Properties.Contains("company") ? searchResult.Properties["company"][0].ToString() : null;
                    string? companyDep = searchResult.Properties.Contains("department") ? searchResult.Properties["department"][0].ToString() : null;
                    string? companyType = searchResult.Properties.Contains("l") ? searchResult.Properties["l"][0].ToString() : null;
                    string? fatherName = searchResult.Properties.Contains("extensionAttribute2") ? searchResult.Properties["extensionAttribute2"][0].ToString() : null;

                    Dates.Add(new DataModel
                    {
                        Username = username,
                        LocalNumber = localNumber,
                        PhoneNumber = phoneNumber,
                        Email = email,
                        Post = post,
                        CompanyName = companyName,
                        CompanyDep = companyDep,
                        CompanyType = companyType,
                        Fathername = fatherName,
                        Fullname = $"{username} {fatherName}",
                    });
                }
                ConnectionIcon = "/Images/connection_on.png";
            }
            catch (Exception ex) 
            {
                
                for (int i = 0; i < 4; i++)
                {
                    Dates.Add(new DataModel
                    {
                        Username = $"Вася Петров{i}",
                        Fathername = "Александрович",
                        Fullname = $"Вася Петров{i} Александрович",
                        LocalNumber = $"404",
                        PhoneNumber = "1234567890",
                        Email = "@mail.ru",
                        Post = "РазнорабочийРазнорабочийРазнорабочийРазнорабочийРазнорабочийРазнорабочий",
                        CompanyName = "Компания",
                        CompanyDep = $"Отдел{i}",
                    });
                    Dates.Add(new DataModel
                    {
                        Username = $"Петя Васечкин{i}",
                        Fathername = "Александрович",
                        Fullname = $"Петя Васечкин{i} Александрович",
                        Email = "@mail.ru",
                        Post = "Курьер",
                        CompanyName = "Компания",
                        CompanyDep = $"Отдел{i}",
                    });
                }
                ConnectionIcon = "/Images/connection_off.png";
            } // User List OR No Connection

            DatesView.SortDescriptions.Add(new SortDescription("Username", ListSortDirection.Ascending));



        }

        private void ApplyFilter()
        {
            DatesView.Filter = o =>
            {
                if (o is DataModel data)
                {
                    bool matchesSearchText = string.IsNullOrEmpty(SearchText)
                || (data.Fullname != null && data.Fullname.ToLower().Contains(SearchText.ToLower()))
                || (data.Post != null && data.Post.ToLower().Contains(SearchText.ToLower()))
                || (data.LocalNumber != null && data.LocalNumber.ToLower().Contains(SearchText.ToLower()))
                || (data.Email != null && data.Email.ToLower().Contains(SearchText.ToLower()))
                || (data.PhoneNumber != null && data.PhoneNumber.ToLower().Contains(SearchText.ToLower()))
                || (data.CompanyName != null && data.CompanyName.ToLower().Contains(SearchText.ToLower()))
                || (data.CompanyDep != null && data.CompanyDep.ToLower().Contains(SearchText.ToLower()));

                    // Применяем логический оператор для комбинирования условий
                    return matchesSearchText;
                }

                return false;
            };

            DatesView.Refresh();
        }




    }
}
