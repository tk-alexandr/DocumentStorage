using System;

namespace DocumentStorage.WebUI.Models
{
    public class PagingInfo
    {
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        private int? _numerator;

        public int TotalPages
        {
            get
            {
                return (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage);
            }
        }

        public int? ItemNumerator
        {
            get
            {
                _numerator = _numerator ?? (CurrentPage - 1) * ItemsPerPage;
                return ++_numerator;
            }
        }
    }
}