using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace Forberedande_kurs
{
    class Program
    {
        static void Main(string[] args)
        {
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu();
            }
        }

        // Huvudmeny
        private static bool MainMenu()
        {
            Console.Clear();
            Console.WriteLine("...Förberedande kurs Lexicon...\n");
            Console.WriteLine("0) Avsluta");
            Console.WriteLine("1) Hello World");
            Console.WriteLine("2) Lämna personuppgifter");
            Console.WriteLine("3) Ändra textfärg");
            Console.WriteLine("4) Visa dagens datum");
            Console.WriteLine("5) Visa största numret");
            Console.WriteLine("6) Gissa talet");
            Console.WriteLine("7) Spara text till en fil");
            Console.WriteLine("8) Läs innehåll från textfil");
            Console.WriteLine("9) Räkna decimalmatte");
            Console.WriteLine("10) Multiplikationstabell 1-10");
            Console.WriteLine("11) Skapa arrays");
            Console.WriteLine("12) Testa om ordet är ett palindrom");
            Console.WriteLine("13) Skriv ut alla värden mellan två tal");
            Console.WriteLine("14) Sortera komma separerade värden");
            Console.WriteLine("15) Addera komma separerade värden");
            Console.WriteLine("16) Skapa en karaktär");
            Console.Write("\r\nVälj funktion: ");

            switch (Console.ReadLine())
            {
                case "0":
                    return false;
                case "1":
                    HelloWorld();
                    return true;
                case "2":
                    User();
                    return true;
                case "3":
                    ChangeColor();
                    return true;
                case "4":
                    TodaysDate();
                    return true;
                case "5":
                    CompareNumbers();
                    return true;
                case "6":
                    guessNumber();
                    return true;
                case "7":
                    WriteToFile();
                    return true;
                case "8":
                    ReadFromFile();
                    return true;
                case "9":
                    DecimalMath();
                    return true;
                case "10":
                    Multiplication();
                    return true;
                case "11":
                    MakeArrays();
                    return true;
                case "12":
                    CheckPalindrom();
                    return true;
                case "13":
                    PrintValues();
                    return true;
                case "14":
                    SortCommaValues();
                    return true;
                case "15":
                    AddCommaValues();
                    return true;
                case "16":
                    BuildCharacter();
                    return true;
                default:
                    return true;
            }
        }
        // Funktion 1, skriver ut Hello World till consol
        private static void HelloWorld()
        {
            Console.Clear();
            Console.WriteLine("\nHello World!");
            Console.WriteLine("\nTryck på enter för att avsluta");
            System.Console.ReadKey();
        }

        // Funktion 2, Tar användaruppgifter och skriver ut de angivna uppgifterna till consol
        private static void User()
        {
            Console.Clear();
            Console.WriteLine("\nAnge ditt förnamn och tryck enter");
            string firstName = Console.ReadLine();
            Console.WriteLine("Ange ditt efternamn och tryck enter");
            string lastName = Console.ReadLine();
            Console.WriteLine("Ange din ålder och tryck enter");
            string age = Console.ReadLine();
            Console.WriteLine($"\nUppgifterna du har angivit är: \nFörnamn: {firstName} \nEfternamn: {lastName} \nÅlder: {age} ");
            Console.WriteLine("\nTryck på enter för att avsluta");
            System.Console.ReadKey();
        }

        // Funktion 3, Byter textfärg till en slumpmässig färg, om färgen redan är ändrad från standardfärgen byts den tillbaka
        private static void ChangeColor()
        {
            Console.Clear();
            // Hämtar aktuell textfärg
            ConsoleColor currentForeground = Console.ForegroundColor;
            ConsoleColor defaultForeground = ConsoleColor.White;
            if (currentForeground == defaultForeground)
            {
                Console.ForegroundColor = GetRandomConsoleColor();
                Console.WriteLine("\nTextfärgen är ändrad");
                Console.WriteLine("\nTryck på enter för att återgå till huvudmenyn");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nOriginal färgen återställd");
                Console.WriteLine("\nTryck på enter för att återgå till huvudmenyn");
            }
            System.Console.ReadKey();
        }
        // Metod som returnerar en slumpmässig textfärg
        public static Random _random = new Random();
        private static ConsoleColor GetRandomConsoleColor()
        {
            var consoleColors = Enum.GetValues(typeof(ConsoleColor));
            return (ConsoleColor)consoleColors.GetValue(_random.Next(consoleColors.Length));
        }

        // Funktion 4, Metod för att skriva ut dagens datum till consol efter angivet format
        private static void TodaysDate()
        {
            Console.Clear();
            DateTime today = DateTime.Today;
            string strDate = today.ToString("yyyy-MM-dd");
            Console.WriteLine("Dagens datum är: " + strDate);
            Console.WriteLine("Tryck på enter för att återgå till huvudmenyn");
            System.Console.ReadKey();
        }

        // Funktion 5, Konverterar användarinput från string till int och skriver ut högsta värdet till consol
        private static void CompareNumbers()
        {
            Console.Clear();
            Console.WriteLine("Ange två tal för att hitta det största talet.");
            Console.WriteLine("Knappa in det första talet och tryck enter");
            int firstNum = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ange det andra talet och tryck enter");
            int secondNum = Convert.ToInt32(Console.ReadLine());
            int result = Math.Max(firstNum, secondNum);
            Console.WriteLine("Det största talet är " + result);
            Console.WriteLine("Tryck på enter för att återgå till huvudmenyn");
            System.Console.ReadKey();
        }

        // Funktion 6, Tar input och testar om det är ett tal mellan 1-100, genererar sedan ett slupmässigt tal och jämför om det är samma 
        public static int counter = 0;

        private static void guessNumber()
        {
            Console.Clear();
            Console.WriteLine("Gissa ett tal mellan 1-100 och tryck enter");
            string userInput = Console.ReadLine();
            int value;
            bool success = int.TryParse(userInput, out value);
            if (success && value < 101)
            {
                NumGen(value);
            }
            else
            {
                Console.WriteLine("Ange endast siffror mellan 1-100");
                Retry();
            }
        }

        public static int randomNumber;
        private static void NumGen(int guess)
        {

            if (counter == 0)
            {
                randomNumber = GetRandomNumber();
            }
            if (guess == randomNumber)
            {
                Console.WriteLine("Du gissade korrekt! Imponerande :) Det tog endast " + counter + " försök ");
                counter = 0;
                Retry();
            }
            else
            {
                if (guess > randomNumber)
                {
                    Console.WriteLine("Du gissade tyvärr för högt, det korrekta talet är lägre ");
                    counter++;
                    Console.WriteLine("Totalt " + counter + " försök ");
                    Retry();
                }
                else
                {
                    Console.WriteLine("Du gissade tyvärr för lågt, det korrekta talet är högre ");
                    counter++;
                    Console.WriteLine("Totalt " + counter + " försök ");
                    Retry();
                }

            }
        }
        // Metod för att generera ett slupmässigt nummer mellan 1-100
        public static int GetRandomNumber()
        {
            Random rand = new Random();
            int x = rand.Next(1, 100);
            int randomNum = x;
            return randomNum;
        }
        public static void Retry()
        {
            Console.WriteLine("Vill du spela igen? y/n");
            string tryAgain = Console.ReadLine();
            if (tryAgain == "y")
            {
                guessNumber();
            }
            else
            {
                MainMenu();
            }
        }

        // Funktion 7, Tar string input och sparar till fil
        public static void WriteToFile()
        {
            Console.Clear();
            Console.WriteLine("Vänligen ange texten du önskar spara");
            string txtToSave = Console.ReadLine();
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "sparadText.txt")))
            {
                outputFile.WriteLine(txtToSave);
            }
            Console.WriteLine("Sparat!");
            Console.WriteLine("Tryck på valfri tangent för att återgå till huvudmenyn");
            System.Console.ReadKey();
        }

        // Funktion 8 Skriver ut innehållet av sparade filen från funktion 7, använder: using System.IO;
        public static void ReadFromFile()
        {
            string appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string filePath = Path.Combine(appDataFolder, "sparadText.txt");
            using (var reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
            Console.WriteLine("Tryck på valfri tangent för att återgå till huvudmenyn");
            System.Console.ReadKey();
        }

        // Funktion 9, Tar string som input och testar om det är ett decimaltal via CheckForDecimal(); som sedan skriver ut matematiska operationer till consol 
        public static void DecimalMath()
        {
            Console.Clear();
            Console.WriteLine("\nAnge valfritt decimaltal och tryck på enter");
            string userInput = Console.ReadLine();
            CheckForDecimal(userInput);

        }
        public static void CheckForDecimal(string decNum)
        {
            decimal value;
            bool success = Decimal.TryParse(decNum, out value);
            if (success)
            {
                decimal root = (decimal)Math.Sqrt((double)value);
                decimal square = (decimal)Math.Pow((double)value, 2);
                decimal pow10 = (decimal)Math.Pow((double)value, 10);
                Console.WriteLine("\nRoten ur " + value + " är " + root);
                Console.WriteLine(value + " i kvadrat är " + square);
                Console.WriteLine(value + " upphöjt till 10 är " + pow10);
            }
            else
            {
                Console.WriteLine("Du angav: " + decNum + " Ange endast decimaltal");
                TryAgain();
            }
            Console.WriteLine("Tryck på enter för att återgå till huvudmenyn");
            System.Console.ReadKey();
        }

        public static void TryAgain()
        {
            Console.WriteLine("\nVill du försöka igen? y/n");
            string tryAgain = Console.ReadLine();
            if (tryAgain == "y")
            {
                DecimalMath();
            }
            else
            {
                MainMenu();
            }
        }

        // Funktion 10, Skriver ut multiplikationstabellen från 1-10 till consol med en tab imellan
        public static void Multiplication()
        {
            Console.Clear();
            Console.WriteLine("\nMultiplikationstabell från 1 till 10\n");
            for (int i = 1; i <= 10; i++)
            {
                for (int j = 1; j <= 10; j++)
                {
                    Console.Write(i * j + "\t");
                }
                Console.Write("\n");
            }
            Console.WriteLine("\nTryck på enter för att återgå till huvudmenyn");
            Console.ReadLine();
        }

        // Funktion 11, Skapar array med slumpmässiga nummer och skriver sedan ut den sorterad i stigande ordning till consol
        public static void MakeArrays()
        {
            Console.Clear();
            Console.WriteLine("\nSkapar array med slumpmässiga nummer");
            int size = 10;
            Random random = new Random();
            int[] array1 = new int[size];

            for (int i = 0; i < size; i++)
            {
                array1[i] = random.Next(0, 99);
                Console.Write(array1[i] + " ");
            }
            int[] array2 = new int[size];
            int temp;
            array1.CopyTo(array2, 0);
            for (int i = 0; i < array2.Length; i++)
            {
                for (int j = 1 + i; j < array2.Length; j++)
                {
                    if (array2[i] > array2[j])
                    {
                        temp = array2[i];
                        array2[i] = array2[j];
                        array2[j] = temp;
                    }
                }
            }

            Console.Write("\n\nArray sorterad i stigande ordning:\n");
            for (int i = 0; i < array2.Length; i++)
            {
                Console.Write(array2[i] + " ");
            }
            Console.WriteLine("\n\nTryck på enter för att återgå till huvudmenyn");
            Console.ReadLine();
        }

        // Funktion 12, Testar om input är ett palindrom
        static void CheckPalindrom()
        {
            Console.Clear();
            Console.WriteLine("\nSkriv in valfritt ord och se om det är ett palindrom");
            string usrInput = Console.ReadLine();
            bool result = IsPalindrome(usrInput);
            if (result)
            {
                Console.WriteLine(usrInput + " är ett palindrom");
            }
            else
            {
                Console.WriteLine(usrInput + " är inte ett palindrom");
            }
            Console.WriteLine("\nTryck på enter för att återgå till huvudmenyn");
            Console.ReadLine();
        }
        // Metod för att vända på input string, är den samma returneras true
        static bool IsPalindrome(string str)
        {
            return str.SequenceEqual(str.Reverse());
        }

        // Funktion 13, Konverterar 2 input till int och skriver ut alla tal mellan dessa till consol
        static void PrintValues()
        {
            Console.Clear();
            Console.WriteLine("Ange två tal för att skriva ut alla nummer imellan");
            Console.WriteLine("\nAnge det första talet och tryck enter");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\nAnge det andra talet och tryck enter");
            int num2 = Convert.ToInt32(Console.ReadLine());
            int max = Math.Max(num1, num2);
            int min = Math.Min(num1, num2);
            Console.WriteLine("\nDu har angivit lägsta talet som " + min + " och högsta som " + max);
            int x = min + 1;
            for (int i = x; i < max; i++)
            {
                Console.WriteLine(x);
                x++;
            }
            Console.WriteLine("\n\nTryck på enter för att återgå till huvudmenyn");
            Console.ReadLine();
        }

        // Funktion 14, Splittar csv input till array som sorteras, skapar sedan två listor och printar ut dem var för sig till consol
        static void SortCommaValues()
        {
            Console.Clear();
            Console.WriteLine("Skriv in valfritt antal värden och separera med komma, exempelvis, 100, 200 osv... och tryck enter");
            string input = Console.ReadLine();
            string[] values = input.Split(',').Select(sValue => sValue.Trim()).ToArray();
            double[] numbers = Array.ConvertAll(values, converter: s => double.Parse(s));
            Array.Sort(numbers);
            List<double> odd = new List<double>();
            List<double> even = new List<double>();
            // Testar array numbers mot modulus, ger division med 2 ingen rest är talet jämnt, annars är det udda, och sparar sedan till lista
            foreach (var item in numbers)
            {
                if (item % 2 == 0)
                {
                    even.Add(item);
                }
                else
                {
                    odd.Add(item);
                }
            }
            Console.WriteLine("De udda talen är: ");
            odd.ForEach(Console.WriteLine);
            Console.WriteLine("Och de jämna talen är: ");
            even.ForEach(Console.WriteLine);
            Console.WriteLine("\n\nTryck på enter för att återgå till huvudmenyn");
            Console.ReadLine();
        }

        // Funktion 15, Adderar alla värden från csv input och printar ut resultat till consol
        static void AddCommaValues()
        {
            Console.Clear();
            Console.WriteLine("\nSkriv in valfritt antal värden och separera med komma, exempelvis, 10,20 osv... och tryck enter");
            string input = Console.ReadLine();
            string[] values = input.Split(',').Select(sValue => sValue.Trim()).ToArray();
            double[] numbers = Array.ConvertAll(values, converter: s => double.Parse(s));
            double sum = 0;
            foreach (var num in numbers)
            {
                sum = sum + num;
            }
            Console.WriteLine("\nSumman av additionerna är: " + sum);
            Console.WriteLine("\n\nTryck på enter för att återgå till huvudmenyn");
            Console.ReadKey();
        }

        // Funktion 16, Tar två string inputs för namn från användaren och skapar slumpmässiga värden för spelkaraktärer 
        static void BuildCharacter()
        {
            Console.Clear();
            Features player = new Features();
            Features opponent = new Features();
            player.Health = GetRandomNumber();
            player.Strength = GetRandomNumber();
            player.Luck = GetRandomNumber();
            opponent.Health = GetRandomNumber();
            opponent.Strength = GetRandomNumber();
            opponent.Luck = GetRandomNumber();
            Console.WriteLine("\nSkriv in namnet på din karaktär och tryck enter");
            string namePlayer = Console.ReadLine(); ;
            Console.WriteLine("Skriv in namnet på din motståndare och tryck enter");
            string nameOpp = Console.ReadLine();
            Console.WriteLine($"\nDin karaktär heter {namePlayer} och har följande värden:\nHälsa = {player.Health} \nStyrka = {player.Strength} \nTur =  {player.Luck} ");
            Console.WriteLine($"\nDin motståndare heter {nameOpp} och har följande värden: \nHälsa = {opponent.Health} \nStyrka = {opponent.Strength} \nTur =  {opponent.Luck} ");
            Console.WriteLine("\n\nTryck på enter för att återgå till huvudmenyn");
            Console.ReadKey();
        }

    }
}// Namespace Forberedande_kurs slutar 

// Class för att lagra värden för egenskaperna styrka, hälsa och tur
public class Features
{
    public int Health { get; set; }
    public int Strength { get; set; }
    public int Luck { get; set; }

}
