using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenGods.Items.Misc.Bars
{
    public class TaintedBar : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Tainted Bar");
        }
        public override void SetDefaults() {
            item.width = 30;
            item.height = 24;
            item.maxStack = 999;
            item.value = 15000;
        }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("TaintedOre"), 3);
            recipe.AddTile(17);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}