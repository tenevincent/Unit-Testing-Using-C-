using FluentAssertions;
using Loans.Domain.Applications.Values;
using NUnit.Framework;

namespace Loans.Tests
{
    public class LoanAmountShould
    {
        [Test]
        public void StoreCurrencyCode()
        {
            var loanAmount = new LoanAmount("USD", 100_000);
            loanAmount.CurrencyCode.Should().Be("USD");
            loanAmount.CurrencyCode.Should().StartWith("U");
            loanAmount.CurrencyCode.Should().EndWith("D");
            loanAmount.CurrencyCode.Should().BeOneOf("USD","CFA","EUR");

            loanAmount.CurrencyCode.Should().Match("*D");
            loanAmount.CurrencyCode.Should().Match("*S*");

            //Assert.That(sut.CurrencyCode, Is.EqualTo("USD"));
        }
    }
}
