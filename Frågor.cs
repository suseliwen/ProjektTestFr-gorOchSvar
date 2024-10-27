class Question
{
    public string Quest {get; set;}
    public string Answer {get; set;}
    public int Points {get; set;}

    public Question(string quest, string answer, int points)
    {
        Quest = quest;
        Answer = answer;
        Points = points;
    }
}

class Quiz
{
    public static void StällFrågor(HandleAnswers handleAnswers)
    {
        List<Question> questions = new List<Question>();

        {
            questions.Add(new Question("Hur långt är ett snöre?", "Jättelångt", 5));
            questions.Add(new Question("Vad är 2 + 2?", "4", 1));
            questions.Add(new Question("Vad är huvudstaden i Sverige?", "Stockholm", 3));
            questions.Add(new Question("Vilket år landade månen?", "1969", 4));
            questions.Add(new Question("Vad är havets djupaste punkt?", "Marianergraven", 5));
            questions.Add(new Question("Vad är pi?", "3.14", 2));
            questions.Add(new Question("Vilket ämne har kemisk beteckning O?", "Syre", 3));
            questions.Add(new Question("Vad är det största djuret på jorden?", "Blåval", 5));
            questions.Add(new Question("Vilken planet är känd som den röda planeten?", "Mars", 4));
            questions.Add(new Question("Vad heter Sveriges kung?", "Carl XVI Gustaf", 5));
            questions.Add(new Question("Vilket ämne har kemisk beteckning Fe?", "Järn", 5));
            questions.Add(new Question("Vad kallas den process där växter omvandlar ljus till energi?", "Fotosyntes", 4));
            questions.Add(new Question("Vilken kontinent ligger Australien på?", "Oceanien", 5));
            questions.Add(new Question("Vilket år startade andra världskriget?", "1939", 5));
            questions.Add(new Question("Vilken är den största arten av landlevande däggdjur?", "Elefant", 1));
            questions.Add(new Question("Vad är enheten för elektrisk ström?", "Ampere", 4));
            questions.Add(new Question("Vad heter den mest befolkade staden i världen?", "Tokyo", 5));
            questions.Add(new Question("Vilken typ av energi lagras i mat?", "Kemisk", 5));


            /*for (var i = 0; i < questions.Count; i++ )
            {
                System.Console.WriteLine($"Fråga: {questions[i].Quest}, Svar: {questions[i].Answer}, Poäng: {questions[i].Points}");          
                System.Console.WriteLine();          

            }*/

            Random rnd = new Random();
            int numOfQuest = questions.Count;
            
            for (int i = 0; i < numOfQuest; i++)
            {
                int j = rnd.Next(i, numOfQuest);
                var temp = questions[i];
                questions[i] = questions[j];
                questions[j] = temp;
            }

            for (int i = 0; i < 5; i++)
            {
                Question question = questions[i];
                System.Console.WriteLine($"{question.Quest}");
                string answer = Console.ReadLine();

                if(answer.Trim () == question.Answer)
                {
                    System.Console.WriteLine("Grattis! Du svarade rätt!");
                    handleAnswers.AddCorrectAnswer(question.Quest, question.Points);      
                }

                else
                {
                    System.Console.WriteLine($"Du svarade tyvärr fel. Rätt svar var {question.Answer}");
                    handleAnswers.AddWrongAnswer(question);
                }
            }
        }
    }
}

class HandleAnswers
{
    private List<string> correctAnswers = new List<string>();
    private List<Question> wrongAnswer = new List<Question>();    
    private List <int> points = new List<int>();

    public void AddCorrectAnswer(string answer, int point)
    {
        correctAnswers.Add(answer);
        points.Add(point);
        
    }

    public void AddWrongAnswer(Question question)
    {
        wrongAnswer.Add(question);
    }

       public void ShowWrongAnswers()
    {
        System.Console.WriteLine("Du svarade fel på följande frågor: ");
        foreach(var answer in wrongAnswer)
        {
            System.Console.WriteLine(answer);
        }
    }

    public void Practice()
    {
        foreach(var question in wrongAnswer)
        {
            System.Console.WriteLine($"{question.Quest}");
            string answer = Console.ReadLine();

            if(answer.Trim() == question.Answer)
            {
                System.Console.WriteLine("Grattis! Den här gången svarade du rätt!");

            }
            else
            {
                System.Console.WriteLine($"Du svarade fel även denna gång. Rätt svar var {question.Answer}. Försök igen!");
            }
        }
    }

    public int ShowPoints()
    {
        return points.Sum();
        

    }

}