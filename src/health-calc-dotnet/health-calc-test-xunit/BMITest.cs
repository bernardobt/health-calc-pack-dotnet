using health_calc_pack_dotnet;
using Xunit;

namespace health_calc_test_xunit
{
    public class BMITest
    {
        [Fact]
        public void When_RequestBMICalcWithValidData_ThenReturnBMIIndex()
        {
            //Arrange
            var Bmi = new BMI();
            var Height = 168;
            var Weight = 85;
            var Expected = 30.12;


            //Act
            var Result = Bmi.Calc(Height, Weight);

            //Assert
            Assert.Equal(Expected, Result);
        }

        [Fact]
        public void When_RequestBMICalcWithValidData_ThenReturnBMIIndexWithinRange()
        {
            //Arrange
            var Bmi = new BMI();
            var Height = 168;
            var Weight = 85;
            var ExpectedMin = 30.10;
            var ExpectedMax = 30.14;


            //Act
            var Result = Bmi.Calc(Height, Weight);

            //Assert
            Assert.InRange(Result, ExpectedMin, ExpectedMax);
        }

        // Application changed behaviour so this test is no longer adequate
        // It is being left here as a comment for study purpose
        //[Fact]
        //public void When_RequestBMICalcWithInvalidDataZeroDividedByZero_ThenReturnNaN()
        //{
        //    //Arrange
        //    var Bmi = new BMI();
        //    var Height = 0.0;
        //    var Weight = 0.0;
        //    var Expected = double.NaN;


        //    //Act
        //    var Result = Bmi.Calc(Height, Weight);

        //    //Assert
        //    Assert.Equal(Expected, Result);
        //}
        [Fact]
        public void When_RequestBMICalcWithInvalidDataZeroDividedByZero_ThenThrowException()
        {
            //Arrange
            var Bmi = new BMI();
            var Height = 0.0;
            var Weight = 0.0;

            //Act and Assert
            Assert.Throws<Exception>(() => Bmi.Calc(Height, Weight));
        }



        // Application changed behaviour so this test is no longer adequate
        // It is being left here as a comment for study purpose

        //[Fact]
        //public void When_RequestBMICalcWithInvalidDataDivisionByZero_ThenReturnInfinity()
        //{
        //    //Arrange
        //    var Bmi = new BMI();
        //    var Height = 0.0;
        //    var Weight = 85.00;
        //    var Expected = double.PositiveInfinity;

        //    //Act
        //    var Result = Bmi.Calc(Height, Weight);

        //    //Assert
        //    Assert.Equal(Expected, Result);
        //}
        [Fact]
        public void When_RequestBMICalcWithInvalidDataDivisionByZero_ThenThrowException()
        {
            //Arrange
            var Bmi = new BMI();
            var Height = 0.0;
            var Weight = 85.0;


            //Act and Assert
            Assert.Throws<Exception>(() => Bmi.Calc(Height, Weight));

        }




        [Theory]
        [InlineData(17.5, "Underweight")]
        [InlineData(18.49, "Underweight")]
        [InlineData(18.5, "Helthy weight")]
        [InlineData(24.99, "Helthy weight")]
        [InlineData(25, "Overweight")]
        [InlineData(29.99, "Overweight")]
        [InlineData(30, "Class 1 obesity")]
        [InlineData(34.99, "Class 1 obesity")]
        [InlineData(35, "Class 2 obesity")]
        [InlineData(39.99, "Class 2 obesity")]
        [InlineData(40, "Class 3 obesity")]
        [InlineData(45, "Class 3 obesity")]
        public void When_RequestBMIClass_ThenReturnClass(double BMI, string ExpectedResult)
        {
            //Arrange
            var Bmi = new BMI();

            //Act
            var Result = Bmi.GetBMIClass(BMI);

            //Assert
            Assert.Equal(ExpectedResult, Result);
        }

        [Theory]
        [InlineData(0, 168)]
        [InlineData(85, 0)]
        [InlineData(0, 0)]
        public void When_InvalidData_ThenReturnValidationResultFalse(double HeightInput, double WeightInput)
        {
            //Arrange
            var Bmi = new BMI();
            var Height =HeightInput;
            var Weight = WeightInput;

            //Act
            var Result = Bmi.IsValidData(Height, Weight);

            //Assert
            Assert.False(Result);
        }
    }
}