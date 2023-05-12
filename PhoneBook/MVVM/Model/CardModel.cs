using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.MVVM.Model
{
    internal class CardModel
    {
        public string Username { get; set; }
        public string Post { get; set; }
        public ObservableCollection<DataModel> Dates { get; set; }
        public string UserPost => Dates.Last().Post;
        public string DUsername => Dates.Last().Username;
    }
}
