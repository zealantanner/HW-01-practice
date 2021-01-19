using System; 
using System.Diagnostics.CodeAnalysis;

namespace CS1405_Lab
{
    public class Employee
    {
        public Employee(string name)
        {
            Name = name?? throw new ArgumentNullException(nameof(name));                         
        }

        public string Name { get; }                                                              

        private string? _Name;

        static bool TryGetDigitAsText(
            char number, [NotNullWhen(true)]out string? text) =>
                (text = number switch
                {
                    '1' => "one",
                    '2' => "two",
                    '3' => "three",
                    '4' => "four",
                    '5' => "five",
                    '6' => "six",
                    '7' => "seven",
                    '8' => "eight",
                    '9' => "nine",
                    _ => null
                }) is string;

        [return: NotNullIfNotNull("text")]
        static public string? TryGetDigitsAsText(string? text)
        {
            if (text is null) return null;

            string result = "";
            foreach (char character in text)
            {
                if (TryGetDigitAsText(character, out string? digitText))
                {
                    if (result != "") result += '-';
                    result += digitText.ToLower();
                }
            }
            return result;
        }
    }
    class Program
    {
        static void Main()
        {
            Employee first = new Employee("billy");
            Console.WriteLine(first);
            first.TryGetDigitsAsText('1',"billy");
            Console.WriteLine(first);

        }
    }
}

