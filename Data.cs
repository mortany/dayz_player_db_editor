using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DZ_Players
{
    public class DZ_PlayersDB
    {
        public List<DZ_Char> Players = new List<DZ_Char>();

        public void WipePlayer(string UID)
        {
            if (UID.Length == 17)
                UID = SteamIDToUID(UID);

            Players.RemoveAt(Players.FindIndex(p => p.UID == UID));
        }

        public DZ_PlayersDB(string db_path)
        {
            using (var connection = new SqliteConnection("Data Source=" + db_path))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = "SELECT Count(*) FROM Players";
                object? value = command.ExecuteScalar();

                long CountCell = 0;

                if (value != null) CountCell = (long)value;


                for (int ID = 1; ID <= CountCell; ID++)
                {
                    command.CommandText = "SELECT UID FROM Players WHERE Id = '" + ID + "'";

                    var result = command.ExecuteScalar();

                    if (result != null)
                    {
                        string player_uid = result.ToString();
                        command.CommandText = "SELECT Data FROM Players WHERE Id = '" + ID + "'";
                        var player_data = command.ExecuteScalar() as byte[];
                        command.CommandText = "SELECT Alive FROM Players WHERE Id = '" + ID + "'";
                        var alive = command.ExecuteScalar();

                        Players.Add(new DZ_Char(ID, player_uid, Convert.ToBoolean(alive), player_data));
                    }
                }
            }
        }
        public string SteamIDToUID(string steam_id)
        {
            return System.Convert.ToBase64String(new SHA256CryptoServiceProvider().ComputeHash(Encoding.ASCII.GetBytes(steam_id))).Replace('/', '_').Replace('+', '-');
        }
    }
    public class DZ_Char
    {
        public DZ_Char(int id, string uid, bool alive, byte[]? data)
        {
            ID = id;
            Alive = alive;
            UID = uid;

            if (data != null)
            {
                using (var memoryStream = new MemoryStream(data))
                using (var binaryStream = new BinaryReader(memoryStream))
                {
                    Alive = alive;
                    Header_data = binaryStream.ReadBytes(16);
                    int char_name_len = binaryStream.ReadByte();
                    Character_name = new string(binaryStream.ReadChars(char_name_len));

                    ushort data_len = binaryStream.ReadUInt16();

                    Stats_data = binaryStream.ReadBytes(data_len);

                    ushort ver = binaryStream.ReadUInt16();

                    uint items_count = binaryStream.ReadUInt32();

                    Items = new List<DZ_Item>();

                    for (int i = 0; i < items_count; i++)
                    {
                        Items.Add(new DZ_Item(uid, binaryStream));
                    }
                }
            }
        }
        public int ID { get; set; }
        public ushort Ver { get; set; }
        public string UID { get; set; }
        public byte[]? Header_data { get; set; }
        public string? Character_name { get; set; }
        public byte[]? Stats_data { get; set; }

        public bool Alive { get; set; }

        public bool IsWiped { get; set; }
        public bool DataIsChanged { get; set; }

        public List<DZ_Item>? Items { get; set; }

    }
    public class DZ_Item
    {
        public DZ_Item(string UID, BinaryReader reader, DZ_Item? parent = null)
        {
            Parent = UID;
            uint data_count = reader.ReadUInt32();
            int item_name_len = reader.ReadByte();
            Classname = new string(reader.ReadChars(item_name_len));
            Skip = reader.ReadBytes(6);
            int slot_len = reader.ReadByte();
            Slot = new string(reader.ReadChars(slot_len));
            int custom_data_len = reader.ReadInt32();

            Network_ID = new int[4];

            Network_ID[0] = reader.ReadInt32();
            Network_ID[1] = reader.ReadInt32();
            Network_ID[2] = reader.ReadInt32();
            Network_ID[3] = reader.ReadInt32();

            Data = reader.ReadBytes(custom_data_len - 16);

            uint childs_count = reader.ReadUInt32();

            for (int i = 0; i < childs_count; i++)
            {
                AddChild(new DZ_Item(UID, reader, this));
            }

            if (parent != null) Parent_Item = parent;
        }
        public string Classname { get; set; }
        public string Slot { get; set; }
        public byte[] Skip { get; set; }
        public byte[] Data { get; set; }
        public string GetID() { return "[ ID: " + Network_ID[0] + ":" + Network_ID[1] + ":" + Network_ID[2] + ":" + Network_ID[3] + "]"; }
        public string GetN_ID() { return Network_ID[0] + "," + Network_ID[1] + "," + Network_ID[2] + "," + Network_ID[3]; }
        public int[] Network_ID { get; set; }
        public string Parent { get; set; }

        public DZ_Item Parent_Item { get; set; }

        public List<DZ_Item> Childs { get; set; }

        public void AddChild(DZ_Item item)
        {
            if (Childs == null)
                Childs = new List<DZ_Item>();

            Childs.Add(item);
        }

    }
}
