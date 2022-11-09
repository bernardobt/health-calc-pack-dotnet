namespace health_calc_pack_dotnet.Interfaces
{
    public interface IBMI
    {
        double Calc(double Height, double Weigth);

        string GetBMIClass(double BMI);

        bool IsValidData(double Height, double Weigth);


    }
}
