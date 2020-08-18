using BasicTDDCalc;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BeerAPIUnitTestMoq
{
    public class CalcTest
    {
        [Fact]
        public void Testing_Result_of_Sum_of_Two_Numbers()
        {
            // Arrange
            Calc _calculator = new Calc();            
            //Act
            int c = _calculator.SumTwoNum(2,2);
            //Assert            
            Assert.Equal(c, 4);
        }
    }
}
