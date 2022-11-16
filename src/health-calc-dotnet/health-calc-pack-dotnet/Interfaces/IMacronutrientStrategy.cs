using health_calc_pack_dotnet.Enums;
using health_calc_pack_dotnet.Models;

namespace health_calc_pack_dotnet.Interfaces
{
    public interface IMacronutrientStrategy
    {
        MacronutrientModel Calc(double Weight);
    }
}
