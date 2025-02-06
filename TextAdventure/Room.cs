namespace TextAdventure;

public enum RoomDirections
{
    north,
    south,
    east,
    west,
}

public class Room
{
    private string _roomName;
    public string description;
    public string enterRoomDescription;
    public Dictionary<RoomDirections, Room> adjacentRooms = new Dictionary<RoomDirections, Room>();

    public Room(string roomName)
    {
        _roomName = roomName;
    }
}
