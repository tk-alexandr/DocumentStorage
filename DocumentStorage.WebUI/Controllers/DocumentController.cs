using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DocumentStorage.Domain.Abstract;
using DocumentStorage.Domain.Entities;
using DocumentStorage.WebUI.Models;
using DocumentStorage.WebUI.Models.Helpers;
using System.Web.Security;
using System.Collections.Generic;

namespace DocumentStorage.WebUI.Controllers
{
    [Authorize]
    public class DocumentController : Controller
    {
        private IDocumentsRepository repository;
        public int PageSize = 5;
        private string UserName { get {
            string cookieName = FormsAuthentication.FormsCookieName;
            HttpCookie authCookie = HttpContext.Request.Cookies[cookieName];
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
            string User = ticket.Name;

            return User;
        } }

        public DocumentController(IDocumentsRepository documentsRepository)
        {
            this.repository = documentsRepository;
        }

        

        public ViewResult List(DocumentsListViewModel model, NavMenuViewModel menu, int? SubmitOrder, int? SubmitFilter, int page = 1)
        {
            if (SubmitOrder == null && Session["OrderInfo"] == null)
            {
                model.OrderInfo = new OrderInfo();
            }
            else if (SubmitOrder == null && Session["OrderInfo"] != null)
            {
                model.OrderInfo = (OrderInfo)Session["OrderInfo"];
            }
            else
            {
                Session["OrderInfo"] = model.OrderInfo;
            }

            if (SubmitFilter != null)
                Session["FilterInfo"] = menu.ListFilterInfo;

            model.FilterInfo = (ListFilterInfo)Session["FilterInfo"] ?? new ListFilterInfo();

            model.PagingInfo = new PagingInfo
            {
                CurrentPage = page,
                ItemsPerPage = PageSize
            };
            
            IEnumerable<Document> documents = DocumentsListGeneratorHelper.GetDocumentsList(model, repository);
            model.PagingInfo.TotalItems = documents.Count();
            model.Documents = documents
                .Skip((model.PagingInfo.CurrentPage - 1) * model.PagingInfo.ItemsPerPage)
                .Take(model.PagingInfo.ItemsPerPage);


            return View(model);
        }

        
        public ViewResult Create()
        {
            return View();
        }


        [HttpPost]
        public ViewResult Create(DocumentCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string fileFullName = model.Name + ".docx";
                string relativePath = DirectoryPathHelper.GetRelativePath(fileFullName, Server.MapPath);
                string absolutePath = Server.MapPath(relativePath);

                CreateDocumentHelper.Create(absolutePath, model.Content);

                 DocxToPdfHelper.Convert(absolutePath);
                

                Author author = repository.Authors.Single(a => a.Login == UserName);
                Document doc = new Document() { Author = author, Date = DateTime.Now, Name = model.Name, Url = relativePath };
                repository.AddDocument(doc);

                return View("Message", doc);
            }
            else
            {
                return View();
            }
            
        }


        public ViewResult Upload()
        {
            return View();
        }

        [HttpPost]
        public ViewResult Upload(DocumentUploadViewModel model)
        {
            
            if (ModelState.IsValid)
            {

                string fileFullName = System.IO.Path.GetFileName(model.uploadFile.FileName);
                string relativePath = DirectoryPathHelper.GetRelativePath(fileFullName, Server.MapPath);
                string absolutePath = Server.MapPath(relativePath);

                model.uploadFile.SaveAs(absolutePath);

                DocxToPdfHelper.Convert(absolutePath);

                Author author = repository.Authors.Single(a => a.Login == UserName);
                Document doc = new Document() { Author = author, Date = DateTime.Now, Name = model.Name, Url = relativePath };
                repository.AddDocument(doc);

                return View("Message", doc);
            }
            else
            {
                return View();
            }
            
        }



        public ActionResult Open(int documentID)
        {
            Document doc = repository.Documents.Single(d => d.DocumentID == documentID);

            return File(Server.MapPath(doc.Url + ".pdf"), "application/pdf");
        }


        public ActionResult Download(int documentID)
        {
            Document doc = repository.Documents.Single(d => d.DocumentID == documentID);

            string fileExtention = doc.Url.Substring(doc.Url.LastIndexOf('.')).ToLower();
            string mimeType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
            
            return File(Server.MapPath(doc.Url),  mimeType, doc.Name + fileExtention);
        }

        public ViewResult Message(Document doc)
        {
            return View(doc);
        }


    }
}
