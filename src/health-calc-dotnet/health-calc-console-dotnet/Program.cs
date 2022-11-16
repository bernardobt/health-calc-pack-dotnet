using health_calc_pack_dotnet;

Console.WriteLine("Cálculo do IMC:");

Console.WriteLine("Peso em kg:");
var Weight = Console.ReadLine();

Console.WriteLine("Altura em cm:");
var Height = Console.ReadLine();

BMI objBMI = new BMI();

double ResultBMI = objBMI.Calc(double.Parse(Height), double.Parse(Weight));
string Category = objBMI.GetBMIClass(ResultBMI);



Console.WriteLine("Cálculo dos Macronutirientes:");

Console.WriteLine("Indique o sexo: \n f - Feminino\n m - Masculino");
var Sex = Console.ReadLine();
var SexEnum = (Sex == "f") ? health_calc_pack_dotnet.Enums.SexEnum.Female : health_calc_pack_dotnet.Enums.SexEnum.Male;

Console.WriteLine("Indique o nivel de atividade: \n s - Sedentário\n m - Moderado\n a - Ativo\n e - Extremamente Ativo");
var ActivityLevel = Console.ReadLine();
var ActivityLevelEnum = health_calc_pack_dotnet.Enums.ActivityLevelEnum.Sedentary;

switch (ActivityLevel)
{
    case "m":
        ActivityLevelEnum = health_calc_pack_dotnet.Enums.ActivityLevelEnum.Moderate;
        break;
    case "a":
        ActivityLevelEnum = health_calc_pack_dotnet.Enums.ActivityLevelEnum.Active;
        break;
    case "e":
        ActivityLevelEnum = health_calc_pack_dotnet.Enums.ActivityLevelEnum.VeryActive;
        break;
    default:
        ActivityLevelEnum = health_calc_pack_dotnet.Enums.ActivityLevelEnum.Sedentary;
        break;
}


Console.WriteLine("Indique o objetivo: \n b - Bulking\n c - Cutting\n m - Manter o Peso");
var Goal = Console.ReadLine();
var GoalEnum = health_calc_pack_dotnet.Enums.GoalEnum.Maintain;

switch (Goal)
{
    case "b":
        GoalEnum = health_calc_pack_dotnet.Enums.GoalEnum.Bulking;
        break;
    case "c":
        GoalEnum = health_calc_pack_dotnet.Enums.GoalEnum.Cutting;
        break;
    default:
        GoalEnum = health_calc_pack_dotnet.Enums.GoalEnum.Maintain;
        break;
}

Macronutrient objMacronutrient = new Macronutrient();

var ResultMacronutrient = objMacronutrient.Calc(
    SexEnum,
    ActivityLevelEnum,
    GoalEnum,
    double.Parse(Height),
    double.Parse(Weight)    
    );


Console.WriteLine("Resultado do IMC: \n" + Category);
Console.WriteLine($"Para o objetivo {GoalEnum}, o seu consumo de macronutrientes diário deve ser:\n Carbohidratos: {ResultMacronutrient.Carbohydrates}g\n Gordura: {ResultMacronutrient.Fat}g\n Proteínas: {ResultMacronutrient.Protein}g" );


//Macronutriente objMacronutriente = new Macronutriente();


Console.ReadKey();