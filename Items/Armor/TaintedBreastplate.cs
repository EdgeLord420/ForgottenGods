using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenGods.Items.Armor {
    [AutoloadEquip(EquipType.Body)]
    public class TaintedBreastplate : ModItem {
        public override void SetStaticDefaults() {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Chaos Slave's Breastplate");
            Tooltip.SetDefault("Protects you from the wip..."
                + "\nImmunity to 'On Fire!'"
                + "\n5% increased damage"
                + "\n+20 max mana and +5% movement speed");
        }

        public override void SetDefaults() {
            item.width = 18;
            item.height = 18;
            item.value = 600000;
            item.rare = 3;
            item.defense = 12;
        }

        public override void UpdateEquip(Player player) {
            player.buffImmune[BuffID.OnFire] = true;
            player.rangedDamage += 0.05f;
            player.magicDamage += 0.05f;
            player.meleeDamage += 0.05f;
            player.minionDamage += 0.05f;
            player.thrownDamage += 0.05f;
            player.statManaMax2 += 20;
            player.moveSpeed += 0.05f;
        }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("TaintedBar"), 25);
            recipe.AddIngredient(mod.ItemType("AncientSteal"), 20);
            recipe.AddIngredient(86, 40);
            recipe.AddTile(16);
            recipe.SetResult(this);
            recipe.AddRecipe();

            ModRecipe recipe2 = new ModRecipe(mod);
            recipe2.AddIngredient(mod.ItemType("TaintedBar"), 25);
            recipe2.AddIngredient(mod.ItemType("AncientSteal"), 20);
            recipe2.AddIngredient(1329, 40);
            recipe2.AddTile(16);
            recipe2.SetResult(this);
            recipe2.AddRecipe();
        }
    }
}