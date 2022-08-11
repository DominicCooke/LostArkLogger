using ParsedLogParser.Models;
using System.Globalization;
using System.Text;
using System.Text.Json;

LoadAllJsonFiles();

void LoadAllJsonFiles()
{
    var parsedLogs = new List<ParsedLog>();

    foreach (string fileName in Directory.GetFiles(@"C:\Users\Dominic\Documents\Lost Ark Logs\parsed", "*.json"))
    {
        try
        {
            ParsedLog parsedLog = LoadData<ParsedLog>(fileName);

            if (parsedLog?.MostDamageTakenEntity?.Name?.Contains("Resurrected Sylmael Devourer Maneth") ?? false)
            {
                parsedLog.Date = GetFileName(fileName);
                parsedLog.FileName = $"{parsedLog.Date:dd-MM-yyyy}-{Guid.NewGuid()}";
                parsedLogs.Add(parsedLog);
            }
        }
        catch { }
    }

    parsedLogs = parsedLogs.DistinctBy(pl => pl.Entities.First(e => e.Key == "Freakeh" || e.Key == "You").Value.DamageDealt).ToList();

    foreach (var parsedLog in parsedLogs)
    {
        CreateCsvFile(parsedLog);
    }
}

static DateTime GetFileName(string filePath)
{
    var lastIndexOfSlash = filePath.LastIndexOf("\\");
    string date = filePath.Substring(lastIndexOfSlash + 9, 10);
    return DateTime.Parse(date);
}

static List<string> GetWhitelistedNames()
{
    var a = new List<string>()
    {
        "Aedra"  ,
"Ayrndril"    ,
"Ayywhat"    ,
"Bigbalthasar"    ,
"Bosse"    ,
"Brÿnolf"    ,
"Bvi"    ,
"Craykoko"    ,
"Daikiigg"    ,
"Dangs"    ,
"Dennisz"    ,
"Dige"    ,
"Einarsson"    ,
"Emandoog"    ,
"Flashey"    ,
"Freakeh"    ,
"Gjormy"    ,
"Haiau"    ,
"Imabard"    ,
"Irinicha"    ,
"Itspredator"    ,
"Jaymarry"    ,
"Joormungand"    ,
"Koppacatmag"    ,
"Langriis"    ,
"Lbr"    ,
"Lunox"    ,
"Lynerbeirdd"    ,
"Lytica"    ,
"Maeshtro"    ,
"Musique"    ,
"Mycheatisweed"    ,
"Nyrwina"    ,
"Odium"    ,
"Pokeransu"    ,
"Prola"    ,
"Rejoiner"    ,
"Ryulixdemonic"    ,
"Sarrtek"    ,
"Sheeny"    ,
"Shunyo"    ,
"Silbererde"    ,
"Sukinoi"    ,
"Synsblaster"    ,
"Tevi"    ,
"Tormentar"    ,
"Vigoslance"    ,
"Wahnie"    ,
"Xandrine"    ,
"Yukxia"    ,
"Ascenn",
"Crecialina",
"Gelitus",
"Gubonggun",
"Gunsinger",
"Hasty",
"lily",
"Loststark",
"Nearsight",
"Pineharc",
"Reijix",
"Senlin",
"Tallaxlcbardin",
"Tandir",
"Tanonymous",
"Tormentarc",
"Zafkey",
"Îcôn"
    };

    a.Sort();

    return a;
}

void CreateCsvFile(ParsedLog parsedLog)
{
    var csv = new StringBuilder();

    List<string> members = GetWhitelistedNames();

    foreach (var member in members)
    {
        var searchingKey = member;

        var isThere = parsedLog.Entities.Any(e => e.Key == member);

        if (member == "Freakeh" && !isThere)
        {
            isThere = parsedLog.Entities.Any(e => e.Key == "You");
            searchingKey = "You";
        }

        if (isThere)
        {
            var entity = parsedLog.Entities.First(e => e.Key == searchingKey);

            if (entity.Value.DamageDealt > 0 || GetWhitelistedNames().Contains(entity.Key))
            {
                var name = entity.Key;

                if (name == "You")
                {
                    name = "Freakeh";
                }

                NumberFormatInfo nfi = new NumberFormatInfo();
                nfi.NumberDecimalSeparator = ".";
                var damageDealt = (decimal.Parse(entity.Value?.DamageDealt.ToString()) / 1000000).ToString(nfi);

                //var maximumDamage = 0;
                //var maximumDamageSkillName = string.Empty;
                //
                //if (entity.Value?.Skills.Count > 0)
                //{
                //    maximumDamage = (int)entity.Value.Skills.Max(s => s.Value?.MaxDamage);
                //    maximumDamageSkillName = entity.Value.Skills.MaxBy(s => s.Value?.MaxDamage).Key;
                //}

                //var newLine = string.Format("{0},{1},{2},{3}", name, damageDealt, maximumDamageSkillName, maximumDamage);
                csv.AppendLine(string.Format("{0},{1}", name, damageDealt));
            }
        }
        else
        {
            csv.AppendLine(string.Format("{0},{1}", member, "0"));
        }
    }

    SaveData(csv.ToString(), parsedLog.FileName);
}

void SaveData(string data, string fileName)
{
    File.WriteAllText($@"C:\Users\Dominic\Desktop\Temp\{fileName}.csv", data);
}

void SaveJsonData(object data, string fileName)
{
    string json = JsonSerializer.Serialize(data, new JsonSerializerOptions() { IncludeFields = true });
    File.WriteAllText($@"C:\Users\Dominic\Desktop\Temp\{fileName}.json", json);
}

T LoadData<T>(string filePath)
{
    string json = File.ReadAllText(filePath);
    if (string.IsNullOrEmpty(json))
    {
        return default;
    }
    else
    {
        return JsonSerializer.Deserialize<T>(json);
    }
}