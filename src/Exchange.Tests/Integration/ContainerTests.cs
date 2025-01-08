using Exchange.Engine;
using Exchange.Engine.Abstractions;
using IoC;

namespace Exchange.Tests.Integration;

public class ContainerTests
{
    [Fact]
    public void ContainerCanResolveEngineUsingProvidedConfiguration()
    {
        using var container = Container
            .Create().Using<EngineConfiguration>();

        var engine = container.Resolve<IExchangeEngine>();

        Assert.NotNull(engine);
    }
}