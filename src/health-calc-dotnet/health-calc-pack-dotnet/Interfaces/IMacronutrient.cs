using health_calc_pack_dotnet.Enums;
using health_calc_pack_dotnet.Models;

namespace health_calc_pack_dotnet.Interfaces
{
    public interface IMacronutrient
    {
        MacronutrientModel Calc(
            SexEnum Sex,
            ActivityLevelEnum ActivityLevel,
            GoalEnum Goal,
            double Height,
            double Weight
            );

        bool IsValidData(double Weigth);
    }
}
