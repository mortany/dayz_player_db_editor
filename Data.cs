using Microsoft.Data.Sqlite;

namespace DZ_Players;

public class DzPlayersDb
{
    public readonly List<DzChar> Players = new();
        
    public DzPlayersDb(string dbPath)
    {
        using var connection = new SqliteConnection($"Data Source={dbPath}");
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM Players";
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            var id = reader.GetInt32(0);
            var playerUid = reader.GetString(2);
            var playerData = reader["Data"] as byte[];
            var alive = Convert.ToBoolean(reader["Alive"]);
            Players.Add(new DzChar(id, playerUid, alive, playerData));
        }
    }
        
    public void WipePlayer(string UID)
    {
        if (UID.Length == 17)
            UID = Utils.SteamIDToUID(UID);

        Players.RemoveAt(Players.FindIndex(p => p.UID == UID));
    }
}
public class DzChar
{
    public int ID { get; set; }
    public ushort Ver { get; set; }
    public string UID { get; set; }
    public byte[]? HeaderData { get; set; }
    public string? CharacterName { get; set; }
    public byte[]? StatsData { get; set; }
    public bool Alive { get; set; }
    public bool IsWiped { get; set; }
    public bool DataIsChanged { get; set; }
    public List<DzItem>? Items { get; set; }
        
    public DzChar(int id, string uid, bool alive, byte[]? data)
    {
        ID = id;
        Alive = alive;
        UID = uid;

        if (data == null)
            return;
            
        using var memoryStream = new MemoryStream(data);
        using var binaryStream = new BinaryReader(memoryStream);
        Alive = alive;
        HeaderData = binaryStream.ReadBytes(16);
        int charNameLen = binaryStream.ReadByte();
        CharacterName = new string(binaryStream.ReadChars(charNameLen));
        var dataLen = binaryStream.ReadUInt16();
        StatsData = binaryStream.ReadBytes(dataLen);
        var ver = binaryStream.ReadUInt16();
        var itemsCount = binaryStream.ReadUInt32();
        Items = new List<DzItem>();
        for (var i = 0; i < itemsCount; i++) 
            Items.Add(new DzItem(uid, binaryStream));
    }
}
public class DzItem
{
    public string Classname { get; set; }
    public string Slot { get; set; }
    public byte[] Skip { get; set; }
    public byte[] Data { get; set; }
    public string PersistentGuid { get; set; }
    public string Parent { get; set; }
    public DzItem? ParentItem { get; set; }
    public List<DzItem>? Childs { get; set; }
        
    public DzItem(string UID, BinaryReader reader, DzItem? parent = null)
    {
        Parent = UID;
        var dataCount = reader.ReadUInt32();
        var itemNameLen = reader.ReadByte();
        Classname = new string(reader.ReadChars(itemNameLen));
        Skip = reader.ReadBytes(6);
        var slotLen = reader.ReadByte();
        Slot = new string(reader.ReadChars(slotLen));
        var customDataLen = reader.ReadInt32();
        PersistentGuid = new Guid(reader.ReadBytes(16)).ToString().ToUpper();
        Data = reader.ReadBytes(customDataLen - 16);
            
        if (parent != null)
            ParentItem = parent;
        var childsCount = reader.ReadUInt32();
        for (var i = 0; i < childsCount; i++)
            AddChild(new DzItem(UID, reader, this));
    }

    private void AddChild(DzItem item)
    {
        Childs ??= new List<DzItem>();
        Childs.Add(item);
    }

}
