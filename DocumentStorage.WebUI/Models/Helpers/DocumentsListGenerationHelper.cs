using DocumentStorage.Domain.Abstract;
using DocumentStorage.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DocumentStorage.WebUI.Models.Helpers
{
    public class DocumentsListGeneratorHelper
    {
        public static IEnumerable<Document> GetDocumentsList(DocumentsListViewModel model, IDocumentsRepository repository)
        {

            string sortString = model.OrderInfo.SortBy;
            if (model.OrderInfo.Descending) sortString += " desc";

            IQueryable<Document> documents;
            switch (sortString)
            {
                case ("Name"):
                    documents = repository.Documents.OrderBy(d => d.Name);
                    break;
                case ("Name desc"):
                    documents = repository.Documents.OrderByDescending(d => d.Name);
                    break;
                case ("Date"):
                    documents = repository.Documents.OrderBy(d => d.Date);
                    break;
                case ("Date desc"):
                    documents = repository.Documents.OrderByDescending(d => d.Date);
                    break;
                case ("Author"):
                    documents = repository.Documents.OrderBy(d => d.Author.Name);
                    break;
                case ("Author desc"):
                    documents = repository.Documents.OrderByDescending(d => d.Author.Name);
                    break;
                default:
                    documents = repository.Documents.OrderBy(d => d.Name);
                    break;

            }

            if (!String.IsNullOrEmpty(model.FilterInfo.SearchString))
            {

                string searchString = model.FilterInfo.SearchString.ToUpper();

                switch (model.FilterInfo.SearchAmoung)
                {
                    case("ByName"):
                        documents = documents.Where(d => d.Name.ToUpper().Contains(searchString));
                        break;
                    case("ByAuthor"):
                        documents = documents.Where(d => d.Author.Name.ToUpper().Contains(searchString));
                        break;
                    case("Everywhere"):
                        documents = documents.Where(d => d.Name.ToUpper().Contains(searchString)
                            || d.Author.Name.ToUpper().Contains(searchString));
                        break;
                }
            }

            if (model.OrderInfo.isDateEnable && model.OrderInfo.DateFilter != null)
            {
                documents = documents.Where(d => d.Date.Date == model.OrderInfo.DateFilter);
            }
            
             return documents;
        }
    }
}