using AnnoMapEditor.DataArchives.Assets.Deserialization;
using System.Xml.Linq;

namespace AnnoMapEditor.DataArchives.Assets.Models
{
    [AssetTemplate(TEMPLATE_NAME)]
    public class FertilityAsset : StandardAsset
    {
        public const string TEMPLATE_NAME = "Fertility";


        public string DisplayName { get; init; }


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
        }
    }
}
