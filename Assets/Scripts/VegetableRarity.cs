
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
            VegetableRarity.Common => 50f,
            VegetableRarity.Rare => 30f,
            VegetableRarity.Epic => 15f,
            VegetableRarity.Legendary => 5f,
            _ => 0f
        };
        
        public static float Points(this VegetableRarity rarity) => rarity switch
        {
            VegetableRarity.Common => 10,
            VegetableRarity.Rare => 50,
            VegetableRarity.Epic => 100,
            VegetableRarity.Legendary => 200,
            _ => 0
        };
    }
