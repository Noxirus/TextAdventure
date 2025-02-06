using TextAdventure;

TextGame currentGame = new TextGame();
currentGame.InitializeGame();

while (currentGame.GameIsRunning())
{
    Console.WriteLine("What would you like to do?");
    string usersInput = Console.ReadLine();
    
    Console.Clear();
    usersInput = usersInput.ToLower();
    usersInput = usersInput.Trim();
    
    string[] userInputArray = usersInput.Split(' ');

    if (userInputArray.Length == 1)
    {
        currentGame.ProcessUserInput(userInputArray[0]);
    }
    else if (userInputArray.Length == 2)
    {
        currentGame.ProcessUserInput(userInputArray[0], userInputArray[1]);
    }
}
