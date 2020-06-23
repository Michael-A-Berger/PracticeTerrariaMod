using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PracticeTerrariaMod.Items
{
    class CarrotBomb: ModItem
    {
        // SetStaticDefaults()
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Bounces 3 times before exploding.\n\"Warning: Not suitable for consumption.\"");
        }

        // SetDefaults()
        public override void SetDefaults()
        {
            // Generic item properties
            item.width = 24;
            item.height = 23;
            item.maxStack = 999;
            item.value = Item.sellPrice(0, 0, 5, 0);
            item.useStyle = 1;                  // "1" = Swinging
            item.useAnimation = 15;             // "useAnimation" and "useTime" should be the same in 99% of
            item.useTime = 15;                  // circumstances.
            item.UseSound = SoundID.Item1;
            item.rare = ItemRarityID.Green;
            item.noUseGraphic = true;           // Implication is that bomb is being thrown, not stuck to player's arm

            // Bomb-Specific Properties
            item.consumable = true;
            // item.ranged = true;              // These are disabled because projectile items
            // item.damage = 50;                // don't usually have a "Damage" set on them
            item.shoot = mod.ProjectileType("CarrotBomb");
            item.shootSpeed = 4f;
            item.noMelee = true;

        }

        // AddRecipes()
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.AddIngredient(ItemID.Bomb);
            recipe.AddIngredient(ItemID.DirtBlock, 5);
            recipe.AddIngredient(ItemID.Gel, 5);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
