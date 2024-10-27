using System.IO;

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

    public static List<Question> LoadQuestions(string filePath)
    {
        List<Question> questions = new List<Question>();

        foreach(var line in File.ReadLines(filePath))
        {
            var parts = line.Split('|');
            if(parts.Length == 3)
            {
                string quest = parts[0];
                string answer = parts[1];
                int points = int.Parse(parts[2]);
                questions.Add(new Question(quest, answer, points));
            }
        }
        return questions;
    }


    public static void StällFrågor(HandleAnswers handleAnswers)
    {
        List<Question> questions = LoadQuestions("questions.txt");
        {
            
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