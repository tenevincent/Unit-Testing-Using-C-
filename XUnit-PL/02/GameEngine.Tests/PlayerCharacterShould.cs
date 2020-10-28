using System;
using Xunit;
using GameEngine;


namespace GameEngine.Tests
{
    public class PlayerCharacterShould
    {
        [Fact]
        public void BeInexperienceWhenNew()
        {
            PlayerCharacter sut = new PlayerCharacter();
            Assert.True(sut.IsNoob);
        }

        [Fact]
        public void CalculateFullName()
        {
            PlayerCharacter sut = new PlayerCharacter();
            sut.FirstName = "Vincent";
            sut.LastName = "Tene";
            
            Assert.Equal("Vincent Tene", sut.FullName);
        }

        [Fact]
        public void CalculateFullNameStartWithFirstName()
        {
            PlayerCharacter sut = new PlayerCharacter();
            sut.FirstName = "Vincent";
            sut.LastName = "Tene";

            Assert.StartsWith("Vincent", sut.FullName);
        }

        [Fact]
        public void CalculateFullNameEndWithFirstName()
        {
            PlayerCharacter sut = new PlayerCharacter();
            sut.FirstName = "Vincent";
            sut.LastName = "Tene";

            Assert.EndsWith("Tene", sut.FullName);
        }


        [Fact]
        public void CalculateFullName_IgnoreCase()
        {
            PlayerCharacter sut = new PlayerCharacter();
            sut.FirstName = "Vincent";
            sut.LastName = "Tene";

            Assert.Equal("Vincent TENE", sut.FullName, ignoreCase:true);
        }

        [Fact]
        public void CalculateFullName_Contains()
        {
            PlayerCharacter sut = new PlayerCharacter();
            sut.FirstName = "Vincent";
            sut.LastName = "Tene";

            Assert.Contains("cent", sut.FullName);
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
            Assert.InRange<int>(sut.Health, 101, 200);
        }

        [Fact]
        public void NotHaveNickNameByDefault()
        {
            PlayerCharacter sut = new PlayerCharacter();

            Assert.Null(sut.Nickname);
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

            Assert.DoesNotContain("Vincent", sut.Weapons);
        }


        [Fact]
        public void HaveAtLeastOneKindOfSword()
        {
            PlayerCharacter sut = new PlayerCharacter();

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

            Assert.Equal(expectedWeapons, sut.Weapons);
        }

        [Fact]
        public void HaveNoEmptyDefaultWeapons()
        {
            PlayerCharacter sut = new PlayerCharacter();

            Assert.All(sut.Weapons, weapon => Assert.False(string.IsNullOrWhiteSpace(weapon)));
        }

    }
}
