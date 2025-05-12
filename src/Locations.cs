using System.Collections.Generic;
using System.Linq;

namespace PPDSAP;

public static class Locations
{
    public static Dictionary<string, int> LocationNameToId = new()
    {
        ["Base Duck"] = 1,
        ["Dragon Duck"] = 2,
        ["Wood Duck"] = 3,
        ["Plaid Duck"] = 4,
        ["Stone Duck"] = 5,
        ["Marble Duck"] = 6,
        ["Submarine Duck"] = 7,
        ["Propeller Hat Duck"] = 8,
        ["Fireman Duck"] = 9,
        ["Lord Duck"] = 10,
        ["Cow Duck"] = 11,
        ["Metallic Pink Duck"] = 12,
        ["Calavera Duck"] = 13,
        ["Flower Duck"] = 14,
        ["Glow Duck"] = 15,
        ["Gold Duck"] = 16,
        ["KISS Duck"] = 17,
        ["Leopard Duck"] = 18,
        ["Manga Duck"] = 19,
        ["Military Duck"] = 20,
        ["Pink Duck"] = 21,
        ["Psychedelic Duck"] = 22,
        ["Imposter Duck"] = 23,
        ["Tiger Duck"] = 24,
        ["Black Duck"] = 25,
        ["Cartoon Duck"] = 26,
        ["Pink Lightning Duck"] = 27,
        ["Fractured Duck"] = 28,
        ["Graffiti Duck"] = 29,
        ["Green Duck"] = 30,
        ["Lava Duck"] = 31,
        ["Lightning Duck"] = 32,
        ["Moss Duck"] = 33,
        ["Red Duck"] = 34,
        ["Zebra Duck"] = 35,
        ["Panda Duck"] = 36,
        ["Sci-Fi Duck"] = 37,
        ["Skeleton Duck"] = 38,
        ["MLG Duck"] = 39,
        ["Knife Duck"] = 40,
        ["Wireframe Duck"] = 41,
        ["Polka Dot Duck"] = 42,
        ["Sakura Duck"] = 43,
        ["Cactus Duck"] = 44,
        ["8-Ball Duck"] = 45,
        ["Alien Duck"] = 46,
        ["Gay Duck"] = 47,
        ["QR Duck"] = 48,
        ["Computer Duck"] = 49,
        ["Computer Mouse Duck"] = 50,
        ["Gamer Duck"] = 51,
    };
    
    public static Dictionary<int, string> IdToLocationName =
        LocationNameToId.ToDictionary(kv => kv.Value, kv => kv.Key);
    
    public static Dictionary<string, string> DuckIdToLocationName = new()
    {
        ["Duck1Base"] = "Base Duck",
        ["Duck2Dragon"] = "Dragon Duck",
        ["Duck3Wood"] = "Wood Duck",
        ["Duck4Fabric"] = "Plaid Duck",
        ["Duck5Stone"] = "Stone Duck",
        ["Duck6Marble"] = "Marble Duck",
        ["Duck7Propeller"] = "Submarine Duck",
        ["Duck8HatProp"] = "Propeller Hat Duck",
        ["Duck9Fireman"] = "Fireman Duck",
        ["Duck10Lord"] = "Lord Duck",
        ["Duck11Cow"] = "Cow Duck",
        ["Duck12Aluminium"] = "Metallic Pink Duck",
        ["Duck13Calavera"] = "Calavera Duck",
        ["Duck14Flower"] = "Flower Duck",
        ["Duck15Glow"] = "Glow Duck",
        ["Duck16Gold"] = "Gold Duck",
        ["Duck17Kiss"] = "KISS Duck",
        ["Duck18Leopard"] = "Leopard Duck",
        ["Duck19Manga"] = "Manga Duck",
        ["Duck20Militare"] = "Military Duck",
        ["Duck21Pink"] = "Pink Duck",
        ["Duck22Psichedelic"] = "Psychedelic Duck",
        ["Duck23Spy"] = "Imposter Duck",
        ["Duck24Tiger"] = "Tiger Duck",
        ["Duck25Black"] = "Black Duck",
        ["Duck26BW"] = "Cartoon Duck",
        ["Duck27Flash"] = "Pink Lightning Duck",
        ["Duck28Fracture"] = "Fractured Duck",
        ["Duck29Graffiti"] = "Graffiti Duck",
        ["Duck30Green"] = "Green Duck",
        ["Duck31Lava"] = "Lava Duck",
        ["Duck32Lightnight"] = "Lightning Duck",
        ["Duck33Moss"] = "Moss Duck",
        ["Duck35Red"] = "Red Duck",
        ["Dick36Spiral"] = "Zebra Duck", // the PPDS dev misspelled `Duck` smh 
        ["Duck37Panda"] = "Panda Duck",
        ["Duck38Scifi"] = "Sci-Fi Duck",
        ["Duck39Skeleton"] = "Skeleton Duck",
        ["Duck40Pixel"] = "MLG Duck",
        ["Duck41Knife"] = "Knife Duck",
        ["Duck42Wireframe"] = "Wireframe Duck",
        ["Duck43Pois"] = "Polka Dot Duck",
        ["Duck43Sakura"] = "Sakura Duck",
        ["Duck44Cactus"] = "Cactus Duck",
        ["Duck45N8"] = "8-Ball Duck",
        ["Duck46Alien"] = "Alien Duck",
        ["Duck47Gay"] = "Gay Duck",
        ["ICDuck4QR"] = "QR Duck",
        ["ICDuck3PC"] = "Computer Duck",
        ["ICDuck2Mouse"] = "Computer Mouse Duck",
        ["ICDuck1Asus"] = "Gamer Duck"
    };

    public static Dictionary<string, string> LocationNameToDuckId =
        DuckIdToLocationName.ToDictionary(kv => kv.Value, kv => kv.Key);

    public static string[][] Columns =
    [
        ["Base Duck", "Skeleton Duck", "Military Duck", "Green Duck", "MLG Duck"],
        [/*"Alien Duck",*/ "Zebra Duck", "Pink Duck", "Submarine Duck", "Sakura Duck"],
        ["Moss Duck", "Metallic Pink Duck", "Gay Duck", "Glow Duck", "Wireframe Duck"],
        ["Wood Duck", "Panda Duck", "Imposter Duck", "Dragon Duck", "Knife Duck"],
        ["Plaid Duck", "Flower Duck", "Tiger Duck", "Fireman Duck", "Gold Duck"],
        ["Stone Duck", "Lightning Duck", "Black Duck", "Lava Duck", "Graffiti Duck"],
        ["Marble Duck", "Cactus Duck", "Sci-Fi Duck", "Cow Duck", "Psychedelic Duck"],
        ["Red Duck", "KISS Duck", "Pink Lightning Duck", "Calavera Duck"],
        ["Propeller Hat Duck", "Leopard Duck", "Fractured Duck", "Cartoon Duck"],
        ["Polka Dot Duck", "Manga Duck", "8-Ball Duck", "Lord Duck"]
    ];
}