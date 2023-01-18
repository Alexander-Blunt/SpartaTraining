using RestSharp;
using Newtonsoft.Json;

namespace DnD5eSpellfinderApp;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine(GetSpellFromName("fireball"));
    }

    public static SpellResult GetSpellFromName(string spellName)
    {
        var client = new RestClient("https://api.open5e.com/spells");
        var request = new RestRequest($"/?{spellName}");
        request.Timeout = -1;
        request.AddHeader("Content-Type", "application/json");
        RestResponse response = client.Execute(request);
        return JsonConvert.DeserializeObject<SpellResult>(response.Content);
    }
}