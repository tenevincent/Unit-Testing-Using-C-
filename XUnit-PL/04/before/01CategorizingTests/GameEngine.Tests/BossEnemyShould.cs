using System;
using Xunit;
using Xunit.Abstractions;

namespace GameEngine.Tests
{
    public class BossEnemyShould : IDisposable
    { 
        private readonly ITestOutputHelper _testOutputHelper;
        private BossEnemy sut;
        public BossEnemyShould(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            sut = new BossEnemy();
        }

        [Fact]
        [Trait("Category","Enemy WriteOuput")]
        public void HaveCorrectPower()
        {

            _testOutputHelper.WriteLine("Creating Boss Enemy");

            

            Assert.Equal(166.667, sut.SpecialAttackPower, 3);
        }

        public void Dispose()
        {


        }

    }
}
