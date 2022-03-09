using Autofac;
using DecoratorPatternWithAutofac;

var container = Bootstrapper.Bootstrap();

using var scope =  container.BeginLifetimeScope();

var playerRepository = scope.Resolve<IPlayerRepository>();

playerRepository.GetById(1);

playerRepository.GetById(3);