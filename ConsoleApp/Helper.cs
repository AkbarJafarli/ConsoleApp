namespace ConsoleApp
{
    public static class Helper
    {
        public static bool isValidName(this string name)
        {
            return char.IsUpper(name[0]) && name.Length >= 3 && !name.Contains(" ") && !string.IsNullOrEmpty(name);
        }
        public static bool isValidSurname(this string surname)
        {
            return char.IsUpper(surname[0]) && surname.Length > 3 && !surname.Contains(" ") && !string.IsNullOrEmpty(surname);
        }
        public static bool checkClassname(this string className)
        {
            return char.IsUpper(className[0]) && char.IsUpper(className[1]) && char.IsDigit(className[2]) && char.IsDigit(className[3]) && char.IsDigit(className[4]) && className.Length == 5 && !string.IsNullOrEmpty(className);
        }
    }
}
;