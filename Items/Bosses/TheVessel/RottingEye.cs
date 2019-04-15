using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenGods.Items.Bosses.TheVessel {
    public class RottingEye : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Rotting Eyeball");
            Tooltip.SetDefault("It seems to be covered in some sort of mold...");
        }

        public override void SetDefaults() {
            item.width = 54;
            item.height = 46;
            item.maxStack = 20;
            item.rare = 1;
            item.useAnimation = 45;
            item.useTime = 45;
            item.useStyle = 4;
            item.UseSound = SoundID.Item44;
            item.consumable = true;
        }

        public override bool CanUseItem(Player player) {
            return !NPC.AnyNPCs(mod.NPCType("TheVessel")) && !Main.dayTime;
        }

        public override bool UseItem(Player player) {
            NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("TheVessel"));
            Main.PlaySound(SoundID.Roar, player.position, 0);
            return true;
        }
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(520, 4);
            recipe.AddIngredient(521, 4);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}