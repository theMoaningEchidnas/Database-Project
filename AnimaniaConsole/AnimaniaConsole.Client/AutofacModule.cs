using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AnimaniaConsole.Data;
using AnimaniaConsole.Services.Contracts;
using AnimaniaConsole.Services.Services;
using Autofac;
using Module = Autofac.Module;
using AutoMapper;

namespace Client
{
    public class AutofacModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<AnimaniaConsoleContext>().As<IAnimaniaConsoleContext>().InstancePerDependency();
            builder.RegisterType<PostService>().As<IPostService>();
        
            builder.Register(x=>Mapper.Instance);
            builder.RegisterType<UserService>().As<IUserService>();


        }
    }
}
