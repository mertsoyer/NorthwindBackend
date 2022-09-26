using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule:Module
    {
        /// <summary>
        /// Dependency Injection Autofac ile kurgulanması
        /// </summary>
        /// <param name="builder"></param>
        protected override void Load(ContainerBuilder builder)
        {
            //Product
            builder.RegisterType<ProductService>().As<IProductService>();
            builder.RegisterType<EfProductDal>().As<IProductDal>();

            //Category
            builder.RegisterType<CategoryService>().As<ICategoryService>();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>();
            
            //User
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            
        }

    }
}
