using AnnoMapEditor.DataArchives.Assets.Deserialization;
using AnnoMapEditor.DataArchives.Assets.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using AnnoMapEditor.Utilities;

namespace AnnoMapEditor.DataArchives.Assets.Models
{
    /**
     * Class for 117 Regions
     */
    [AssetTemplate(TEMPLATE_NAME)]
    public class RegionAsset : StandardAsset
    {
        public static readonly Logger<RegionAsset> _logger = new();
        
        public const string TEMPLATE_NAME = "Region";

        public const long REGION_ROMAN_GUID = 3225;
        public const long REGION_CELTIC_GUID = 6626;

        public const string REGION_ROMAN_REGIONID = "Roman";


        [StaticAsset(REGION_ROMAN_GUID)]
        public static RegionAsset Roman { get; private set; }

        [StaticAsset(REGION_CELTIC_GUID)]
        public static RegionAsset Celtic { get; private set; }

        public static IEnumerable<RegionAsset> SupportedRegions => new[] { Roman, Celtic };


        /// <summary>
        /// Each region has its own AmbientName, which is needed when creating the .a7t. These
        /// values are missing in assets.xml. The values seen here were reverse engineered from
        /// existing a7t files within the game.
        /// 
        /// Note: Region assets do contain an attribute "Ambiente". However its value is always
        /// "Region_map_global" and does not match the expected value for a7ts.
        /// </summary>
        // TODO: Similar thing in 117? 
        // private static readonly Dictionary<long, string> REGION_AMBIENTE_HARDCODED = new Dictionary<long, string>()
        // {
        //     [REGION_MODERATE_GUID] = "Moderate_01_day_night",
        //     [REGION_SOUTHAMERICA_GUID] = "south_america_caribic_01",
        //     [REGION_ARCTIC_GUID] = "DLC03_01",
        //     [REGION_AFRICA_GUID] = "Colony_02"
        // };


        public string DisplayName { get; init; }

        public string? Ambiente { get; init; }

        public string RegionID { get; init; }

        public IEnumerable<long> AllowedFertilityGuids { get; init; }

        [GuidReference(nameof(AllowedFertilityGuids))]
        public ICollection<FertilityAsset> AllowedFertilities { get; init; }


        public RegionAsset(XElement valuesXml)
            : base(valuesXml)
        {
            // TODO: 117 does something different regarding localization...
            DisplayName = valuesXml.Element("Standard")?
                .Element("Name")?
                .Value ?? "Unknown Region Name";
            // DisplayName = valuesXml.Element("Text")!
            //     .Element("LocaText")?
            //     .Element("English")!
            //     .Element("Text")!
            //     .Value!
            //     ?? "Meta";

            XElement regionElement = valuesXml.Element(TEMPLATE_NAME)!;

            // if (REGION_AMBIENTE_HARDCODED.ContainsKey(GUID))
            //     Ambiente = REGION_AMBIENTE_HARDCODED[GUID];

            // The region Moderate does not have a RegionID specified in assets.xml. All other
            // regions have them.
            RegionID = regionElement.Element("RegionID")?.Value ?? REGION_ROMAN_REGIONID;

            AllowedFertilityGuids = regionElement.Element("AllowedFertilities")?
                .Elements("Item")?
                .Select(x => long.Parse(x.Value))
                .ToArray()
                ?? Array.Empty<long>();
            
            if (RegionID == "Roman") Roman = this;
            else if (RegionID == "Celtic") Celtic = this;
        }


        public static RegionAsset DetectFromPath(string filePath)
        {
            // if (filePath.Contains("colony01") || filePath.Contains("ggj") || filePath.Contains("scenario03"))
            //     return SouthAmerica;
            // else if (filePath.Contains("dlc03") || filePath.Contains("colony_03"))
            //     return Arctic;
            // else if (filePath.Contains("dlc06") || filePath.Contains("colony02") || filePath.Contains("scenario02"))
            //     return Africa;
            // else
            //     return Moderate;
            
            if (filePath.Contains("celtic"))
                return Celtic;
            else 
                return Roman;
        }


        public override string ToString() => DisplayName;
    }
    
    /**
     * Class for 1800 Regions
     */
    [AssetTemplate(TEMPLATE_NAME)]
    public class RegionAsset1800 : StandardAsset
    {
        public const string TEMPLATE_NAME = "Region";

        public const long REGION_MODERATE_GUID = 5000000;
        public const long REGION_SOUTHAMERICA_GUID = 5000001;
        public const long REGION_ARCTIC_GUID = 160001;
        public const long REGION_AFRICA_GUID = 114327;

        public const string REGION_MODERATE_REGIONID = "Moderate";


        [StaticAsset(REGION_MODERATE_GUID)]
        public static RegionAsset Moderate { get; private set; }

        [StaticAsset(REGION_SOUTHAMERICA_GUID)]
        public static RegionAsset SouthAmerica { get; private set; }

        [StaticAsset(REGION_ARCTIC_GUID)]
        public static RegionAsset Arctic { get; private set; }

        [StaticAsset(REGION_AFRICA_GUID)]
        public static RegionAsset Africa { get; private set; }

        public static IEnumerable<RegionAsset> SupportedRegions => new[] { Moderate, SouthAmerica, Arctic, Africa };


        /// <summary>
        /// Each region has its own AmbientName, which is needed when creating the .a7t. These
        /// values are missing in assets.xml. The values seen here were reverse engineered from
        /// existing a7t files within the game.
        /// 
        /// Note: Region assets do contain an attribute "Ambiente". However its value is always
        /// "Region_map_global" and does not match the expected value for a7ts.
        /// </summary>
        private static readonly Dictionary<long, string> REGION_AMBIENTE_HARDCODED = new Dictionary<long, string>()
        {
            [REGION_MODERATE_GUID] = "Moderate_01_day_night",
            [REGION_SOUTHAMERICA_GUID] = "south_america_caribic_01",
            [REGION_ARCTIC_GUID] = "DLC03_01",
            [REGION_AFRICA_GUID] = "Colony_02"
        };


        public string DisplayName { get; init; }

        public string? Ambiente { get; init; }

        public string RegionID { get; init; }

        public IEnumerable<long> AllowedFertilityGuids { get; init; }

        [GuidReference(nameof(AllowedFertilityGuids))]
        public ICollection<FertilityAsset> AllowedFertilities { get; init; }


        public RegionAsset1800(XElement valuesXml)
            : base(valuesXml)
        {
            DisplayName = valuesXml.Element("Text")!
                .Element("LocaText")?
                .Element("English")!
                .Element("Text")!
                .Value!
                ?? "Meta";

            XElement regionElement = valuesXml.Element(TEMPLATE_NAME)!;

            if (REGION_AMBIENTE_HARDCODED.ContainsKey(GUID))
                Ambiente = REGION_AMBIENTE_HARDCODED[GUID];

            // The region Moderate does not have a RegionID specified in assets.xml. All other
            // regions have them.
            RegionID = regionElement.Element("RegionID")?.Value ?? REGION_MODERATE_REGIONID;

            AllowedFertilityGuids = regionElement.Element("AllowedFertilities")?
                .Elements("Item")?
                .Select(x => long.Parse(x.Value))
                .ToArray()
                ?? Array.Empty<long>();
        }


        public static RegionAsset DetectFromPath(string filePath)
        {
            if (filePath.Contains("colony01") || filePath.Contains("ggj") || filePath.Contains("scenario03"))
                return SouthAmerica;
            else if (filePath.Contains("dlc03") || filePath.Contains("colony_03"))
                return Arctic;
            else if (filePath.Contains("dlc06") || filePath.Contains("colony02") || filePath.Contains("scenario02"))
                return Africa;
            else
                return Moderate;
        }


        public override string ToString() => DisplayName;
    }
}
