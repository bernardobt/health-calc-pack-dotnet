using health_calc_pack_dotnet.Enums;
using health_calc_pack_dotnet.Interfaces;
using health_calc_pack_dotnet.Models;

namespace health_calc_pack_dotnet.Strategy
{
    public class CuttingStrategy : IMacronutrientStrategy
    {
        const int PROTEIN = 2;
        const int FAT = 1;
        const int CARBOHYDRATE = 2;

        public MacronutrientModel Calc(double Weight)
        {
            var Result = new MacronutrientModel()
            {
                Protein = PROTEIN * Weight,
                Carbohydrates = CARBOHYDRATE * Weight,
                Fat = FAT * Weight
            };

            return Result;

        }
    }
}
