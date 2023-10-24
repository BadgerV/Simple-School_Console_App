namespace OOPConcept.Helper
{
    public static class Utility
    {
        public static string GenerateId(string prefix, int id, string text)
        {
            var subText = text[..3];

            return $"{prefix}-{id:D5}-{subText.ToUpper()}";
        }

        public static int AgeCalculator(DateOnly dateOnly)
        {
            return DateTime.Now.Year - dateOnly.Year;
        }

        public static void PrintSuccessMessage(string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        public static void PrintErrorMessage(string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        public static void PrintInfoMessage(string text)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}