using health_calc_pack_dotnet;
using health_calc_pack_dotnet.Enums;
using health_calc_pack_dotnet.Models;

namespace health_calc_test_xunit
{
    public class MacronutrientTest
    {
        [Theory]
        [InlineData(SexEnum.Male, 170, 170, 85)]
        [InlineData(SexEnum.Female, 136, 136, 68)]
        public void When_RequestMacronutrientCalcWithValidDataForCutting_ThenReturnResult(SexEnum Sex, int Carbohydrates, int Protein, int Fat)
        {
            //Arrange
            var MacronutrientGoal = new Macronutrient();
            var ActivityLevel = ActivityLevelEnum.Sedentary;
            var Goal = GoalEnum.Cutting;
            var Height = 168;
            var Weight = 85;

            var Expected = new MacronutrientModel()
            {
                Carbohydrates = Carbohydrates,
                Protein = Protein,
                Fat = Fat
            };


            //Act
            var Result = MacronutrientGoal.Calc(
                Sex,
                ActivityLevel,
                Goal,
                Height,
                Weight
                );

            //Assert
            Assert.Equal(Expected.Carbohydrates, Result.Carbohydrates);
            Assert.Equal(Expected.Protein, Result.Protein);
            Assert.Equal(Expected.Fat, Result.Fat);
        }


        [Theory]
        [InlineData(SexEnum.Male, ActivityLevelEnum.Sedentary, 340, 170, 170)]
        [InlineData(SexEnum.Female, ActivityLevelEnum.Sedentary, 272, 136, 136)]
        [InlineData(SexEnum.Male, ActivityLevelEnum.Moderate, 340, 170, 170)]
        [InlineData(SexEnum.Female, ActivityLevelEnum.Moderate, 272, 136, 136)]
        [InlineData(SexEnum.Male, ActivityLevelEnum.Active, 595, 170, 170)]
        [InlineData(SexEnum.Female, ActivityLevelEnum.Active, 476, 136, 136)]
        [InlineData(SexEnum.Male, ActivityLevelEnum.VeryActive, 595, 170, 170)]
        [InlineData(SexEnum.Female, ActivityLevelEnum.VeryActive, 476, 136, 136)]
        public void When_RequestMacronutrientCalcWithValidDataForBulking_ThenReturnResult(SexEnum Sex , ActivityLevelEnum ActivityLevel, int Carbohydrates, int Protein, int Fat)
        {
            //Arrange
            var MacronutrientGoal = new Macronutrient();
            var Goal = GoalEnum.Bulking;
            var Height = 168;
            var Weight = 85;

            var Expected = new MacronutrientModel()
            {
                Carbohydrates = Carbohydrates,
                Protein = Protein,
                Fat = Fat
            };


            //Act
            var Result = MacronutrientGoal.Calc(
                Sex,
                ActivityLevel,
                Goal,
                Height,
                Weight
                );

            //Assert
            Assert.Equal(Expected.Carbohydrates, Result.Carbohydrates);
            Assert.Equal(Expected.Protein, Result.Protein);
            Assert.Equal(Expected.Fat, Result.Fat);
        }


        [Theory]
        [InlineData(SexEnum.Male, 425, 170, 85)]
        [InlineData(SexEnum.Female, 340, 136, 68)]
        public void When_RequestMacronutrientCalcWithValidDataForMaintain_ThenReturnResult(SexEnum Sex, int Carbohydrates, int Protein, int Fat)
        {
            //Arrange
            var MacronutrientGoal = new Macronutrient();
            var ActivityLevel = ActivityLevelEnum.Sedentary;
            var Goal = GoalEnum.Maintain;
            var Height = 168;
            var Weight = 85;

            var Expected = new MacronutrientModel()
            {
                Carbohydrates = Carbohydrates,
                Protein = Protein,
                Fat = Fat
            };


            //Act
            var Result = MacronutrientGoal.Calc(
                Sex,
                ActivityLevel,
                Goal,
                Height,
                Weight
                );

            //Assert
            Assert.Equal(Expected.Carbohydrates, Result.Carbohydrates);
            Assert.Equal(Expected.Protein, Result.Protein);
            Assert.Equal(Expected.Fat, Result.Fat);
        }

        [Fact]
        public void When_RequestMacronutrientCalcWithIValidData_ThenThrowException()
        {
            //Arrange
            var MacronutrientGoal = new Macronutrient();
            var Sex = SexEnum.Male;
            var ActivityLevel = ActivityLevelEnum.Sedentary;
            var Goal = GoalEnum.Cutting;
            var Height = 168;
            var Weight = 34;


            //Act and Assert
            Assert.Throws<Exception>(
                () => MacronutrientGoal.Calc(
                Sex,
                ActivityLevel,
                Goal,
                Height,
                Weight
                ));
        }

    }
}
