using health_calc_pack_dotnet.Interfaces;
using health_calc_pack_dotnet.Models;

namespace health_calc_pack_dotnet.Strategy
{
    public class BulkingActiveStrategy : IMacronutrientStrategy
    {
        const int PROTEIN = 2;
        const int FAT_BULKING = 2;
        const int CARBOHYDRATE = 7;

        public MacronutrientModel Calc(double Weight)
        {
            var Result = new MacronutrientModel()
            {
                Protein = PROTEIN * (int)Weight,
                Carbohydrates = CARBOHYDRATE * (int)Weight,
                Fat = FAT_BULKING * (int)Weight
            };

            return Result;

        }
    }
}
