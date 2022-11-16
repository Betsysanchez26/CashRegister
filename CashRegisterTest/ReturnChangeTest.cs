using CashRegister;
using CashRegister.Currencies;
using CashRegister.Model;

namespace CashRegisterTest
{
    public class ReturnChangeTest
    {
        [Fact]
        public void CalculateReturnChange_Succeed()
        {
            Currency c = new USD();
            c.Denominations[0].Count = 8;
            c.Denominations[1].Count = 44;
            c.Denominations[5].Count = 3;
            var result = ReturnChange.CalculateReturnChange(749.75m, c);
            Assert.True(result.Denominations.Count > 0);
        }


        [Fact]
        public void CalculateReturnChange_ReturnsError()
        {
            Currency c = new USD();
            c.Denominations[5].Count = 1;
            var result = ReturnChange.CalculateReturnChange(10.0m, c);
            Assert.True(result.Message == Constants.NotEnoughMoneyMessage);
        }

        [Fact]
        public void CalculateReturnChange_NoChange()
        {
            Currency c = new USD();
            c.Denominations[6].Count = 1;
            var result = ReturnChange.CalculateReturnChange(1.0m, c);
            Assert.True(result.Message == Constants.ExactAmountMessage);
        }

        [Fact]
        public void CalculateReturnChangeMXN_Succeed()
        {
            Currency c = new MXN();
            c.Denominations[0].Count = 8;
            var result = ReturnChange.CalculateReturnChange(749.75m, c);
            Assert.True(result.Denominations.Count>0);
        }
    }
}