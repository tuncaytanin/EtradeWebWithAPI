using Autofac;
using Business.Concrete;
using Core.Utilities.Security.Token.JWT;
using DataAccess.Concrete.EntityFrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Core.Utilities.Security.Token;
using DataAccess.Abstract;
using Core.CrossCuttingConcers.Caching.Microsoft;
using Core.CrossCuttingConcers.Caching;

namespace Business.DependectResolvers
{
    public class AutofacModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EfAppUserDal>().As<IAppUserDal>();
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<JwtTokenService>().As<ITokenService>();
            builder.RegisterType<AuthService>().As<IAuthService>();
            builder.RegisterType<MemoryCachceService>().As<ICacheService>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterseptorSelector()
                }).SingleInstance();
        }
    }
}
