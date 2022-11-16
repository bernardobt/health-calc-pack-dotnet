using health_calc_pack_dotnet.Enums;
using health_calc_pack_dotnet.Interfaces;
using health_calc_pack_dotnet.Models;
using health_calc_pack_dotnet.Strategy;

namespace health_calc_pack_dotnet
{


    public class Macronutrient : IMacronutrient
    {
        const int MIN_WEIGHT = 35;

        public MacronutrientModel Calc(
            SexEnum Sex,
            ActivityLevelEnum ActivityLevel,
            GoalEnum Goal,
            double Height,
            double Weight)

        {

            if (!IsValidData(Weight))
                throw new Exception("Invalid parameters");

            IMacronutrientStrategy MacronutrientStrategy = new MaintainStrategy();

            if (Goal == GoalEnum.Cutting)
                MacronutrientStrategy = new CuttingStrategy();
            else if (Goal == GoalEnum.Bulking)
            {
                if (ActivityLevel == ActivityLevelEnum.Sedentary || ActivityLevel == ActivityLevelEnum.Moderate)
                    MacronutrientStrategy = new BulkingStrategy();
                else
                    MacronutrientStrategy = new BulkingActiveStrategy();
            }
            else if (Goal == GoalEnum.Maintain)
                MacronutrientStrategy = new MaintainStrategy();



            var Context = new MacronutrientContext(MacronutrientStrategy);

            var Result = Context.Execute(Weight);


            double CorrectionFactorForSex = 1;
            if (Sex == SexEnum.Female)
                CorrectionFactorForSex = 0.8;


            Result.Fat *= CorrectionFactorForSex;
            Result.Carbohydrates *= CorrectionFactorForSex;
            Result.Protein *= CorrectionFactorForSex;

            return Result;
        }


        public bool IsValidData(double Weigth)
        {
            if (Weigth < MIN_WEIGHT)
                return false;

            return true;
        }
    }
}
