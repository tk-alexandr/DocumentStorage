using System.Collections.Generic;
using System.Linq;

namespace DocumentStorage.WebUI.Models
{
    public class ListFilterInfo
    {
        private string _searchString;
        public string SearchString { get {
            return _searchString ?? "";
        }
            set {
                _searchString = value;
            }
        }

        private string _searchAmoung;
        public string SearchAmoung
        {
            get
            {
                return _searchAmoung ?? SearchAmoungOptions.Keys.First();
            }
            set {
                _searchAmoung = value;
            }
        }

        private Dictionary<string, string> _searchAmoungOptions = new Dictionary<string, string>(){
           {"Everywhere", "Везде"},
            {"ByName", "По Названию"},
            {"ByAuthor", "По Автору"}
        };

        public Dictionary<string, string> SearchAmoungOptions
        {
            get
            {
                return _searchAmoungOptions;
            }
        }

    }
}