using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DnD5eSpellfinderApp;


public class SpellResult
{
    [JsonProperty("count")]
    public int Count { get; set; }
    public string next { get; set; }
    public object previous { get; set; }
    public Spell[] results { get; set; }
    public override string ToString()
    {
        string outputString = "";
        foreach (var spell in results)
        {
            outputString += spell.name + "\r\n";
        }
        return outputString;
    }
}

public class Spell
{
    public string slug { get; set; }
    public string name { get; set; }
    public string desc { get; set; }
    public string higher_level { get; set; }
    public string page { get; set; }
    public string range { get; set; }
    public string components { get; set; }
    public string material { get; set; }
    public string ritual { get; set; }
    public string duration { get; set; }
    public string concentration { get; set; }
    public string casting_time { get; set; }
    public string level { get; set; }
    public int level_int { get; set; }
    public string school { get; set; }
    public string dnd_class { get; set; }
    public string archetype { get; set; }
    public string circles { get; set; }
    public string document__slug { get; set; }
    public string document__title { get; set; }
    public string document__license_url { get; set; }
}
