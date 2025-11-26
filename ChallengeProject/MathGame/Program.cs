using System.Transactions;

int ChallengeValue = new int();
string value = string.Empty;
int correctAnswers = 0;
int number1 = 0;
int number2 = 0;
int userAnswer = 0;
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
void getChallengeData(int choice)
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
            displayHistory();
            rerun = true;
            return;
        default:
            Console.WriteLine("Invalid choice. Please select a valid option.\n");
            break;
    }
}
void challenge()
{
    string question = string.Empty;
    if (ChallengeValue < 5 && ChallengeValue > 0)
    {
        Console.WriteLine($"You have selected {value} challenge.");
        string operationSymbol = string.Empty;
        number1 = new Random().Next(1, 101);
        number2 = new Random().Next(1, 101);
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
        Console.WriteLine($"What is {number1} {operationSymbol} {number2} ?");
        question += $"{number1} {operationSymbol} {number2} =";
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
        checkAnswer(question);
    }
}
void checkAnswer(string question)
{
    if (userAnswer == correctAnswers)
    {
        Console.WriteLine("Correct!\n");
        answerHistory.Add($"{question} {userAnswer}\n");
    }
    else
    {
        Console.WriteLine($"Incorrect. The correct answer is {correctAnswers}.\n");
    }
}
void displayHistory()
{
    Console.WriteLine("Answer History: \n");
    foreach (var entry in answerHistory)
    {
        Console.WriteLine(entry,"\n");
    }
}
while (rerun)
{
    Menu();
    getChallengeData(ChallengeValue);
    
    if (ChallengeValue >= 1 && ChallengeValue <= 4)
    {
        challenge();
    }
}