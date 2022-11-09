using health_calc_pack_dotnet.Interfaces;

namespace health_calc_pack_dotnet
{
    public class BMI : IBMI
    {
        public double Calc(double Height, double Weight)
        {
            if (!IsValidData(Height, Weight))
                throw new Exception("Invalid parameters");

            return Math.Round(Weight * 10000 / (Math.Pow(Height, 2)), 2);
        }

        public string GetBMIClass(double BMI)
        {
            var Result = string.Empty;
            if (BMI < 18.5)
                Result = "Underweight";
            else if (18.5 <= BMI && BMI < 25)
                Result = "Helthy weight";
            else if (25 <= BMI && BMI < 30)
                Result = "Overweight";
            else if (30 <= BMI && BMI < 35)
                Result = "Class 1 obesity";
            else if (35 <= BMI && BMI < 40)
                Result = "Class 2 obesity";
            else if (40 <= BMI)
                Result = "Class 3 obesity";

            return Result;
        }

        public bool IsValidData(double Height, double Weigth)
        {
            if (Height <= 0 || Weigth <= 0)
                return false;

            return true;
        }
    }
}