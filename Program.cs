class Program
{
    public static void Main()
    {

        HandleAnswers handleAnswers = new HandleAnswers();
        bool isRunning = true;

        Quiz quiz = new Quiz();

        System.Console.WriteLine("Välkommen till mitt quiz");
        System.Console.WriteLine("------------------------");

        while(isRunning)
        {
            System.Console.WriteLine("Gör ett av följande val: ");
            System.Console.WriteLine("1. Gör quiz");
            System.Console.WriteLine("2. Se dina poäng");
            System.Console.WriteLine("3. Se vilka frågor du svarade fel på");
            System.Console.WriteLine("4. Avsluta program");
            string input = Console.ReadLine();

            switch(input)
            {
                case "1":
                System.Console.WriteLine("Gör quiz");
                Quiz.StällFrågor(handleAnswers);
                break;

                case "2":
                System.Console.WriteLine($"Du har nu {handleAnswers.ShowPoints()} poäng!");
                break;

                case "3":
                System.Console.WriteLine("Se fel svar");
                handleAnswers.ShowWrongAnswers();
                break;

                case "4":
                System.Console.WriteLine("avsluta program");
                isRunning = false;
                break;

                default:
                System.Console.WriteLine("Felaktig inmatning. Försök igen. ");
                break;
            }           


        }

    }
}

