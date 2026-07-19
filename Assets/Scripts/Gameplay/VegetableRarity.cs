
namespace Gameplay
{
    public enum VegetableRarity
    {
        Common,
        Rare,
        Epic,
        Legendary
    }

    public static class VegetableRarityExtensions
    {
        public static float Weight(this VegetableRarity rarity) => rarity switch
        {
            VegetableRarity.Common => 40f,
            VegetableRarity.Rare => 30f,
            VegetableRarity.Epic => 20f,
            VegetableRarity.Legendary => 10f,
            _ => 0f
        };

        public static int Points(this VegetableRarity rarity) => rarity switch
        {
            VegetableRarity.Common => 100,
            VegetableRarity.Rare => 500,
            VegetableRarity.Epic => 1000,
            VegetableRarity.Legendary => 2000,
            _ => 0
        };
    }
}