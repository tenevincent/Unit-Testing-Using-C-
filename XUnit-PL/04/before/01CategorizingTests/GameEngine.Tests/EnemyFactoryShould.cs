using Xunit;
using System;
using Xunit.Abstractions;

namespace GameEngine.Tests
{
    [Trait("Category", "Enemy")]
    public class EnemyFactoryShould : IDisposable
    {
        EnemyFactory sut;
        private readonly ITestOutputHelper _testOutputHelper;

        public EnemyFactoryShould(ITestOutputHelper testOutputHelper)
        {
            sut = new EnemyFactory();
            _testOutputHelper = testOutputHelper;
        }

        [Fact(Skip ="Don´t need to run this!")]
        public void CreateNormalEnemyByDefault()
        {
            

            Enemy enemy = sut.Create("Zombie");

            Assert.IsType<NormalEnemy>(enemy);
        }

        [Fact]
        public void CreateNormalEnemyByDefault_NotTypeExample()
        {
            

            Enemy enemy = sut.Create("Zombie");

            Assert.IsNotType<DateTime>(enemy);
        }

        [Fact]
        public void CreateBossEnemy()
        {
            

            Enemy enemy = sut.Create("Zombie King", true);

            Assert.IsType<BossEnemy>(enemy);
        }

        [Fact]
        public void CreateBossEnemy_CastReturnedTypeExample()
        {
            

            Enemy enemy = sut.Create("Zombie King", true);

            // Assert and get cast result
            BossEnemy boss = Assert.IsType<BossEnemy>(enemy);

            // Additional asserts on typed object
            Assert.Equal("Zombie King", boss.Name);
        }

        [Fact]
        public void CreateBossEnemy_AssertAssignableTypes()
        {
            

            Enemy enemy = sut.Create("Zombie King", true);

            //Assert.IsType<Enemy>(enemy);
            Assert.IsAssignableFrom<Enemy>(enemy);
        }

        [Fact]
        public void CreateSeparateInstances()
        {
            

            Enemy enemy1 = sut.Create("Zombie");
            Enemy enemy2 = sut.Create("Zombie");

            Assert.NotSame(enemy1, enemy2);
        }

        [Fact]
        public void NotAllowNullName()
        {
            

            // Assert.Throws<ArgumentNullException>(() => sut.Create(null));
            Assert.Throws<ArgumentNullException>("name", () => sut.Create(null));
        }

        [Fact]
        public void OnlyAllowKingOrQueenBossEnemies()
        {
            

            EnemyCreationException ex =
                Assert.Throws<EnemyCreationException>(() => sut.Create("Zombie", true));

            Assert.Equal("Zombie", ex.RequestedEnemyName);
        }


        public void Dispose()
        {
            _testOutputHelper.WriteLine("The test is been disposed");
        }

    }
}
