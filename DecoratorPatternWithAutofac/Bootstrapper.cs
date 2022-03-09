using Autofac;

namespace DecoratorPatternWithAutofac
{
    internal class Bootstrapper
    {
        public static IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();

            builder
                .RegisterType<DatabasePlayerRepository>()
                .Named<IPlayerRepository>("PlayerRepository");

            builder
                .RegisterType<MemoryCachePlayerRepository>()
                .WithParameter(
                    (p, c) => p.ParameterType == typeof(IPlayerRepository),
                    (p, c) => c.ResolveNamed<IPlayerRepository>("PlayerRepository"))
                .AsImplementedInterfaces();

            return builder.Build();
        }
    }
}
