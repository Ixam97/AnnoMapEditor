using System.Collections.Generic;
using System.Linq;
using AnnoMapEditor.DataArchives.Assets.Deserialization;
using System.Xml.Linq;
using AnnoMapEditor.Utilities;

namespace AnnoMapEditor.DataArchives.Assets.Models
{
    [AssetTemplate(TEMPLATE_NAME)]
    public class FertilityAsset : StandardAsset
    {
        private static readonly Logger<FertilityAsset> _logger = new();
        public const string TEMPLATE_NAME = "Fertility";


        public string DisplayName { get; init; }

        public IEnumerable<long> AllowedRegionGUIDs { get; init; }


        public FertilityAsset(XElement valuesXml)
            : base(valuesXml)
        {
            // TODO: 117 Localization
            DisplayName = valuesXml.Element("Standard")?
                .Element("Name")?
                .Value ?? "UnknownFertilityAsset";
            // DisplayName = valuesXml.Element("Text")!
            //     .Element("LocaText")!
            //     .Element("English")!
            //     .Element("Text")!
            //     .Value!;

            if (DisplayName.Contains("Celtic")) AllowedRegionGUIDs = new[] { RegionAsset.REGION_CELTIC_GUID };
            else if (DisplayName.Contains("Roman")) AllowedRegionGUIDs = new[] { RegionAsset.REGION_ROMAN_GUID };
            else AllowedRegionGUIDs = new[] { RegionAsset.REGION_CELTIC_GUID, RegionAsset.REGION_ROMAN_GUID };
        }
    }
}
