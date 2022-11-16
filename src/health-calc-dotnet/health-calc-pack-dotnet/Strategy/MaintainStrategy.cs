using health_calc_pack_dotnet.Interfaces;
using health_calc_pack_dotnet.Models;

namespace health_calc_pack_dotnet.Strategy
{
    public class MaintainStrategy : IMacronutrientStrategy
    {
        const int PROTEIN = 2;
        const int FAT = 1;
        const int CARBOHYDRATE = 5;

        public MacronutrientModel Calc(double Weight)
        {
            var Result = new MacronutrientModel()
            {
                Protein = PROTEIN * (int)Weight,
                Carbohydrates = CARBOHYDRATE * (int)Weight,
                Fat = FAT * (int)Weight
            };

            return Result;

        }
    }
}
