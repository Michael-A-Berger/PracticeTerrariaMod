using Terraria.ID;
using Terraria.ModLoader;

namespace PracticeTerrariaMod.Items
{
    public class BasicConsumable: ModItem
    {
        // SetStaticDefaults()
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("A basic (modded) consumable item. Try it out!");
        }

        // SetDefaults()
        public override void SetDefaults()
        {
            // Basic item properties
            item.width = 32;                    // The item's in-game hitbox width (in "pixels")
            item.height = 32;                   // The item's in-game hitbox height (in "pixels")
            item.maxStack = 99;                 // How many of the item can be stacked
            item.value = 1000;                  // Sell value (Pl-Gl-Sl-Cp)
            item.rare = 1;                      // The item's "Rarity" (item name hover text color)
            item.scale = 1f;                    // How big the item becomes when used by the player
            item.UseSound = SoundID.Item1;      // What sound the item plays when it's used
            item.useStyle = 2;                  // Using pose resembles drinking potion
            item.useTime = 25;                  // The time it takes for the item to be used (in ticks)
            item.useAnimation = 25;             // The time it takes for the item's animation to play (in ticks)

            // Potion-Specific Defaults
            item.potion = true;                 // "Potion Sickness" debuff is applied on use
            item.consumable = true;             // The item is consumed after use
            item.buffType = BuffID.Panic;       // "Panic" buff is applied on use
            item.buffTime = 60 * 15;            // Selected buff (see above) lasts for 900 ticks (15 seconds)

            // Defining what the item is NOT
            item.noMelee = true;                // Not a melee weapon (practically, it disables the item from dealing damage)
            item.accessory = false;             // (Default) Not an accessory
            item.defense = 0;                   // (Default) No armor points are given when equipped
            item.crit = 0;                      // (Default) No option to "Crit" while using the item
            item.useAmmo = AmmoID.None;         // (Default) No ammo is used when using this item
            item.mana = 0;                      // (Default) No mana consumption on use
            item.expert = false;                // (Default) Usage is NOT limited to Expert mode
            item.questItem = false;             // (Default) Not a quest item, AKA quest tooltip doesn't show up
            item.mech = false;                  // (Default) Wires are NOT show when holding the item
        }

        // AddRecipe()
        public override void AddRecipes()
        {
            // Creating the Recipe container
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DirtBlock, 5);
            recipe.AddIngredient(ItemID.Mushroom, 1);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

    }
}
