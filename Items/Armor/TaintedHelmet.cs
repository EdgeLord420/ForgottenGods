using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ForgottenGods.Items.Armor {
    [AutoloadEquip(EquipType.Head)]
    public class TaintedHelmet : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Chaos Slave's Helmet");
            Tooltip.SetDefault("The stains are everywhere..."
                + "\n+3 max minions");
        }

        public override void SetDefaults() {
            item.width = 18;
            item.height = 18;
            item.value = 500000;
            item.rare = 3;
            item.defense = 10;
        }

        public override void UpdateEquip(Player player) {
            player.maxMinions += 3;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs) {
            return body.type == mod.ItemType("TaintedBreastplate") && legs.type == mod.ItemType("TaintedLeggings");
        }

        public override void UpdateArmorSet(Player player) {
            player.setBonus = "defense increased by 5 and 10% increased damage";
            player.rangedDamage += 0.10f;
            player.magicDamage += 0.10f;
            player.meleeDamage += 0.10f;
            player.minionDamage += 0.10f;
            player.thrownDamage += 0.10f;
            player.statDefense += 5;
        }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("TaintedBar"), 15);
            recipe.AddIngredient(mod.ItemType("AncientSteal"), 10);
            recipe.AddIngredient(86, 40);
            recipe.AddTile(16);
            recipe.SetResult(this);
            recipe.AddRecipe();

            ModRecipe recipe2 = new ModRecipe(mod);
            recipe2.AddIngredient(mod.ItemType("TaintedBar"), 15);
            recipe2.AddIngredient(mod.ItemType("AncientSteal"), 10);
            recipe2.AddIngredient(1329, 40);
            recipe2.AddTile(16);
            recipe2.SetResult(this);
            recipe2.AddRecipe();
        }
    }
}