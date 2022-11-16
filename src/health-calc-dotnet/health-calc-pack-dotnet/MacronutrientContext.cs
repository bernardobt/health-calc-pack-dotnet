using health_calc_pack_dotnet.Interfaces;
using health_calc_pack_dotnet.Models;

namespace health_calc_pack_dotnet
{
    public class MacronutrientContext
    {
        private IMacronutrientStrategy MacronutrientStrategy;

        public MacronutrientContext(IMacronutrientStrategy Strategy)
        {
            MacronutrientStrategy = Strategy;
        }

        public void SetStrategy(IMacronutrientStrategy Strategy)
        {
            MacronutrientStrategy = Strategy;
        }

        public MacronutrientModel Execute(double Weight)
        {
            return MacronutrientStrategy.Calc(Weight);
        }

    }
}
