 
using System;
using System.Reflection;
using Xunit;

namespace GameEngine.Tests
{
    public class PlayerCharacterShould
    {
        [Fact]
        public void BeInExperiencedWhenNew()
        {
            // Arrange
            PlayerCharacter sut = new PlayerCharacter();

            //  

            // Assert
            Assert.True(sut.IsNoob); 
        }

        [Fact]
        public void CalculateFullName()
        {
            // Arrange
            PlayerCharacter sut = new PlayerCharacter();

            // 
            sut.FirstName = "Vincent";
            sut.LastName = "Tene";

            // Assert
            Assert.Equal("Vincent Tene", sut.FullName);

            Assert.StartsWith("Vincent", sut.FullName);
            Assert.EndsWith("Tene", sut.FullName);
            Assert.Contains("Tene", sut.FullName);

        }



        [Fact]
        public void CalculateFullName_IgnoreCase()
        {
            // Arrange
            PlayerCharacter sut = new PlayerCharacter();

            // 
            sut.FirstName = "VINCENT";
            sut.LastName = "TENE";

            // Assert
            Assert.Equal("Vincent Tene", sut.FullName, ignoreCase:true);

            Assert.StartsWith("Vincent", sut.FullName, StringComparison.OrdinalIgnoreCase);
            Assert.EndsWith("Tene", sut.FullName, StringComparison.OrdinalIgnoreCase);
            Assert.Contains("Tene", sut.FullName, StringComparison.OrdinalIgnoreCase);
        }



        [Fact]
        public void CalculateFullNameWithTitleCase()
        {
            PlayerCharacter sut = new PlayerCharacter();

            sut.FirstName = "Sarah";
            sut.LastName = "Smith";

            Assert.Matches("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", sut.FullName);
        }



        [Fact]
        public void StartWithDefaultHealth()
        {
            PlayerCharacter sut = new PlayerCharacter();

            Assert.Equal(100, sut.Health);
        }

        [Fact]
        public void StartWithDefaultHealth_NotEqualExample()
        {
            PlayerCharacter sut = new PlayerCharacter();

            Assert.NotEqual(0, sut.Health);
        }

        [Fact]
        public void IncreaseHealthAfterSleeping()
        {
            PlayerCharacter sut = new PlayerCharacter();

            sut.Sleep(); // Expect increase between 1 to 100 inclusive

            //Assert.True(sut.Health >= 101 && sut.Health <= 200);
            Assert.InRange(sut.Health, 101, 200);
        }


        [Fact]
        public void HaveALongBow()
        {
            PlayerCharacter sut = new PlayerCharacter();

            Assert.Contains("Long Bow", sut.Weapons);
        }

        [Fact]
        public void NotHaveAStaffOfWonder()
        {
            PlayerCharacter sut = new PlayerCharacter();

            Assert.DoesNotContain("Staff Of Wonder", sut.Weapons);

        }

        [Fact]
        public void HaveAtLeastOneKindOfSword()
        {
            PlayerCharacter sut = new PlayerCharacter();
            Assert.Contains(sut.Weapons, weapons => !weapons.Contains("n"));
            Assert.Contains(sut.Weapons, weapons => !weapons.Contains("Vincent")) ;
            Assert.Contains(sut.Weapons, weapon => weapon.Contains("Sword"));
        }

        [Fact]
        public void HaveAllExpectedWeapons()
        {
            PlayerCharacter sut = new PlayerCharacter();

            var expectedWeapons = new[]
            {
                "Long Bow",
                "Short Bow",
                "Short Sword"
            };

            Assert.Equal(expectedWeapons, sut.Weapons );
        }

        [Fact]
        public void HaveNoEmptyDefaultWeapons()
        {
            PlayerCharacter sut = new PlayerCharacter();

            Assert.All(sut.Weapons, weapon => Assert.False(string.IsNullOrWhiteSpace(weapon)));
        }




        [Fact]
        public void CanTest_CalculateHealthIncrease_Private()
        {

            PlayerCharacter sut = new PlayerCharacter();
            MethodInfo methodInfo = typeof(PlayerCharacter).GetMethod("CalculateHealthIncrease", BindingFlags.NonPublic | BindingFlags.Instance);

           int result = (int)methodInfo.Invoke(sut,null);

            Assert.InRange(result, 1, 101);
        }


 

        [Fact]
        public void RaiseSleptEvent()
        {
            PlayerCharacter sut = new PlayerCharacter();

            Assert.Raises<EventArgs>(
                handler => sut.PlayerSlept += handler,
                handler => sut.PlayerSlept -= handler,
                () => sut.Sleep());
        }


        [Fact]
        public void RaisePropertyChangedEvent()
        {
            PlayerCharacter sut = new PlayerCharacter();

            Assert.PropertyChanged(sut, "Health", () => sut.TakeDamage(10));
            Assert.PropertyChanged(sut, "Health", () => sut.TakeDamage(2));
        }


    }
}
