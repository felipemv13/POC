using System.Text.RegularExpressions;

namespace Strings
{
    public class TestesRegex
    {
        public static bool ResolverSexo(string sexo1, string sexo2)
        {
            var a = Regex.Match(sexo1, @"[A-Za-z]+");
            var b = Regex.Match(sexo2, @"[A-Za-z]+");

            var regex = @"[A-Za-z]+";

            if (!Regex.Match(sexo1, regex).Success || !Regex.Match(sexo2, regex).Success)
                return true;

            switch (sexo1.Trim().ToLower())
            {
                case "feminino":
                case "f":
                case "fem":
                    sexo1 = "f";
                    break;
                case "masculino":
                case "m":
                case "masc":
                    sexo1 = "m";
                    break;
                default:
                    break;
            }

            switch (sexo2.Trim().ToLower())
            {
                case "feminino":
                case "f":
                case "fem":
                    sexo2 = "f";
                    break;
                case "masculino":
                case "m":
                case "masc":
                    sexo1 = "m";
                    break;
                default:
                    break;
            }
            return !(sexo1 == sexo2);
        }
    }
}
