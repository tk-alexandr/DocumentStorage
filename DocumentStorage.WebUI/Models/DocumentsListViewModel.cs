using DocumentStorage.Domain.Entities;
using System.Collections.Generic;

namespace DocumentStorage.WebUI.Models
{
    public class DocumentsListViewModel
    {
        public IEnumerable<Document> Documents { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public OrderInfo OrderInfo { get; set; }
        public ListFilterInfo FilterInfo { get; set; }
    }
}