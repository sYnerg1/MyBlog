using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SyncaBlog.Core.Interfaces;
using SyncaBlog.Core.Repositories;


namespace SyncaBlog.Ninject1
{
    public class NinjectRegistration : NinjectModule
    {
        private string EFDbContext;
        //2 rivneva
        public NinjectRegistration(string EFDbContext)
        {
            this.EFDbContext = EFDbContext;
        }

        public override void Load()
        {
            //lkz 2 hsdytdj]
            Bind<IUnitOfWork>().To<EFUnitOfWork>().WithConstructorArgument(EFDbContext);

           // Bind<IService>().To<MyService>();
        }
    }
}