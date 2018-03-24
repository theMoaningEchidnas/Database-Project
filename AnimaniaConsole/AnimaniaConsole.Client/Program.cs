using AnimaniaConsole.Core.Contracts;
using AnimaniaConsole.Services.Contracts;
using Autofac;
using Client;
using System.Reflection;

namespace AnimaniaConsole.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            AutoMapperConfig.Initialize();

            var builder = new ContainerBuilder();
            builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());

            var container = builder.Build();
            var postService = container.Resolve<IPostService>();

            var engine = container.Resolve<IEngine>();
            engine.Run();

            

        }
    }
}
