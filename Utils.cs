using System.Security.Cryptography;
using System.Text;

namespace DZ_Players;

public class Utils
{
    public static string SteamIDToUID(string steamId) => Convert.ToBase64String(SHA256.HashData(Encoding.ASCII.GetBytes(steamId))).Replace('/', '_').Replace('+', '-');
}
