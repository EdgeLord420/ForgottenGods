using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ForgottenGods.Items.Armor {
    [AutoloadEquip(EquipType.Legs)]
    public class TaintedLeggings : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Chaos Slave's Leggings");
            Tooltip.SetDefault("Good for running away..."
                + "\n10% increased movement speed"
                + "\n5% increased damage");
        }

        public override void SetDefaults() {
            item.width = 18;
            item.height = 18;
            item.value = 550000;
            item.rare = 3;
            item.defense = 8;
        }

        public override void UpdateEquip(Player player) {
            player.rangedDamage += 0.05f;
            player.magicDamage += 0.05f;
            player.meleeDamage += 0.05f;
            player.minionDamage += 0.05f;
            player.thrownDamage += 0.05f;
            player.moveSpeed += 0.10f;
        }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("TaintedBar"), 20);
            recipe.AddIngredient(mod.ItemType("AncientSteal"), 15);
            recipe.AddIngredient(86, 30);
            recipe.AddTile(16);
            recipe.SetResult(this);
            recipe.AddRecipe();

            ModRecipe recipe2 = new ModRecipe(mod);
            recipe2.AddIngredient(mod.ItemType("TaintedBar"), 20);
            recipe2.AddIngredient(mod.ItemType("AncientSteal"), 15);
            recipe2.AddIngredient(1329, 30);
            recipe2.AddTile(16);
            recipe2.SetResult(this);
            recipe2.AddRecipe();
        }
    }
}