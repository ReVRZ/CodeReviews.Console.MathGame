using System.Transactions;

Random rnd = new Random();
int ChallengeValue = new int();
string value = string.Empty;
int correctAnswers = 0;
int number1 = 0;
int number2 = 0;
int userAnswer = 0;
int score = 0;
bool rerun = true;
List<string> answerHistory = new List<string>();

void Menu()
{
    Console.WriteLine("Welcome to the Math Game!\n");
    Console.WriteLine("Choose a difficulty:\n");
    Console.WriteLine("1. Subtraction\n");
    Console.WriteLine("2. Addition\n");
    Console.WriteLine("3. Multiplication\n");
    Console.WriteLine("4. Division\n");
    Console.WriteLine("5. Exit\n");
    Console.WriteLine("6. Show history\n");

    ChallengeValue = Convert.ToInt32(Console.ReadLine());
}
void GetChallengeData(int choice)
{
    switch (choice)
    {
        case 1:
            value = "subtraction";
            break;
        case 2:
            value = "addition";
            break;
        case 3:
            value = "multiplication";
            break;
        case 4:
            value = "division";
            break;
        case 5:
            Console.WriteLine("Exiting the game. Goodbye!");
            rerun = false;
            return;
        case 6:
            DisplayHistory();
            rerun = true;
            return;
        default:
            Console.WriteLine("Invalid choice. Please select a valid option.\n");
            break;
    }
}
void Challenge()
{
    string question = string.Empty;
    if (ChallengeValue < 5 && ChallengeValue > 0)
    {
        Console.WriteLine($"You have selected {value} challenge.");
        string operationSymbol = string.Empty;
        for (int i = 0; i < 5; i++)
        {
        number1 = rnd.Next(1, 101);
        number2 = rnd.Next(1, 101);
        switch (ChallengeValue)
        {
            case 1:
                // Subtraction logic here
                correctAnswers = number1 - number2;
                operationSymbol = "-";
                break;
            case 2:
                // Addition logic here
                correctAnswers = number1 + number2;
                operationSymbol = "+";
                break;
            case 3:
                // Multiplication logic here
                correctAnswers = number1 * number2;
                operationSymbol = "*";
                break;
            case 4:
                // Division logic here
                // Generate numbers until the division is exact
                while (number1 % number2 != 0)
                {
                    number1 = new Random().Next(1, 101);
                    number2 = new Random().Next(1, 101);
                }
                operationSymbol = "/";
                correctAnswers = number1 / number2;
                break;
            default:
                Console.WriteLine("Invalid choice. Please select a valid option.\n");
                break;
        }
        Console.WriteLine($"{i + 1}. What is {number1} {operationSymbol} {number2} ?");
        question = $"{number1} {operationSymbol} {number2} =";
        while (true)
        {
            try
            {
                userAnswer = Convert.ToInt32(Console.ReadLine());
                break;
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
        }
        CheckAnswer(question);
        }
    }
}
void CheckAnswer(string question)
{
    if (userAnswer == correctAnswers)
    {
        Console.WriteLine("Correct!\n");
        score++;
        
        answerHistory.Add($"{question}, userAnswer {userAnswer} ✓\n");
    }
    else
    {
        Console.WriteLine($"Incorrect. The correct answer is {correctAnswers}.\n");
        answerHistory.Add($"{question}, userAnswer {userAnswer} (Correct: {correctAnswers})\n");
    }
}
void DisplayHistory()
{
    if(answerHistory.Count == 0)
    {
        Console.WriteLine("No history available.\n");
        Console.WriteLine($"Your score: {score}\n");
        return;
    }
    else
    {
        Console.WriteLine("Answer History: \n");
        foreach (var entry in answerHistory)
        {
            Console.WriteLine(entry,"\n");
        }
        Console.WriteLine($"Your score: {score}\n");
    }
}
while (rerun)
{
    Menu();
    GetChallengeData(ChallengeValue);
    
    if (ChallengeValue >= 1 && ChallengeValue <= 4)
    {
        Challenge();
    }
}
