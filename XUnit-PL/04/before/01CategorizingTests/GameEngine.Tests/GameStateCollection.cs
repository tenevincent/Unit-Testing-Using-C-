using Xunit;

namespace GameEngine.Tests
{
    [CollectionDefinition(SDConfig.CollectionKey)]
    public class GameStateCollection : ICollectionFixture<GameStateFixture> {}
}
