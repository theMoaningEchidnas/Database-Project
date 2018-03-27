using AnimaniaConsole.Core.Contracts;
using Autofac;
using Client;
using System.Reflection;

namespace AnimaniaConsole.Client
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            AutoMapperConfig.Initialize();

            var builder = new ContainerBuilder();
            builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());

            var container = builder.Build();

            var engine = container.Resolve<IEngine>();
            engine.Run();
        }
    }
}
