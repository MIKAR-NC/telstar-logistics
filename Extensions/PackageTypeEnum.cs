using System.ComponentModel;

namespace TelstarRoutePlanner.Extensions
{
    public enum PackageTypeEnum
    {
        [Description("Standard")]
        Standard=0,
        [Description("Live Animals")]
        LiveAnimals = 1,
        [Description("Dead animals")]
        DeadAnimals = 2,
        [Description("Refrigerated")]
        Refrigerated = 3,
        [Description("Children")]
        Children = 4,
        [Description("Cautious")]
        Cautious = 5,
        [Description("Furniture")]
        Furniture = 6,
        [Description("Weapons")]
        Weapons = 7,
        [Description("Recorded")]
        Recorded = 8,
    }
}
