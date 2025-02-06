namespace TextAdventure;

public class TextGame
{
    private Room _currentRoom;
    private bool _isGameRunning = true;

    public void InitializeGame()
    {
        Console.WriteLine("Welcome to a text adventure");
        Room mainHallway = new Room("Main Hallway");
        mainHallway.description = "You are in a large hallway with " +
                                  "the front door closed behind you. EAST of you is the kitchen.";
        mainHallway.enterRoomDescription = "You enter an elegant grand hallway.";
        
        _currentRoom = mainHallway;

        Room kitchen = new Room("Kitchen");
        kitchen.enterRoomDescription = "You enter a kitchen, the smell of moldy cheese fills the air.";
        kitchen.description = "Smoke still smolders in the wooden grill, someone was here recently. " +
                              "WEST of you is the main hallway";
        
        mainHallway.adjacentRooms.Add(RoomDirections.east, kitchen);
        kitchen.adjacentRooms.Add(RoomDirections.west, mainHallway);
        
        Console.WriteLine(_currentRoom.enterRoomDescription);
    }

    public void ProcessUserInput(string command)
    {
        if (command == "investigate")
        {
            Console.WriteLine(_currentRoom.description);
        }
        else
        {
            Console.WriteLine("I don't understand that command.");
        }
    }

    public void ProcessUserInput(string command, string subject)
    {
        if (command == "go")
        {
            MovePlayer(subject);
        }
        else
        {
            Console.WriteLine("I don't understand that command.");
        }
    }

    void MovePlayer(string subject)
    {
        if (Enum.TryParse(subject, out RoomDirections direction))
        {
            if (_currentRoom.adjacentRooms.ContainsKey(direction))
            {
                _currentRoom = _currentRoom.adjacentRooms[direction];
                Console.WriteLine(_currentRoom.enterRoomDescription);
            }
            else
            {
                Console.WriteLine("You look around but cannot go that way.");
            }
        }
        else
        {
            Console.WriteLine("I cannot go that way!");
        }
    }
    
    public bool GameIsRunning()
    {
        return _isGameRunning;
    }
}