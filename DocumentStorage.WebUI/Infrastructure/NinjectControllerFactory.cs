using System;
using Ninject;
using System.Web.Mvc;
using System.Web.Routing;
using DocumentStorage.Domain.Abstract;
using DocumentStorage.Domain.Concrete;
using DocumentStorage.WebUI.Infrastructure.Abstract;
using DocumentStorage.WebUI.Infrastructure.Concrete;

namespace DocumentStorage.WebUI.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;
        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null
                ? null
                : (IController)ninjectKernel.Get(controllerType);
        }

        private void AddBindings()
        {

            ninjectKernel.Bind<IDocumentsRepository>().To<NHibernateDocumentRepository>();
            ninjectKernel.Bind<IAuthProvider>().To<FormsAuthProvider>();
            
        }
    }
}