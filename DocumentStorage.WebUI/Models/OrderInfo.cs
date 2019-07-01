using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DocumentStorage.WebUI.Models
{
    public class OrderInfo
    {
        private string _sortBy;
        public string SortBy { get {
            return _sortBy ?? SortByOptions.Keys.ToArray()[1];
        }
            set {
                _sortBy = value;
            }
        }
        public bool Descending { get; set; }

        private Dictionary<string, string> _sortByOptions = new Dictionary<string, string>(){
           {"Name", "Названию"},
            {"Date", "Дате"},
            {"Author", "Автору"}
        };

        public Dictionary<string, string> SortByOptions
        {
            get
            {
                return _sortByOptions;
            }
        }

        public bool isDateEnable { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DateFilter { get; set; }
    }
}