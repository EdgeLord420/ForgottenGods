using Terraria;
using Terraria.ModLoader;

namespace ForgottenGods.Items.Bosses.TheVessel {
    public class TheVesselBag : ModItem {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Treasure Bag");
            Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
        }

        public override void SetDefaults() {
            item.maxStack = 999;
            item.consumable = true;
            item.width = 24;
            item.height = 24;
            item.rare = 9;
            item.expert = true;
            bossBagNPC = mod.NPCType("TheVessel");
        }

        public override bool CanRightClick() {
            return true;
        }

        public override void OpenBossBag(Player player) {
            player.QuickSpawnItem(mod.ItemType("TaintedOre"), Main.rand.Next(26, 66));
            player.QuickSpawnItem(73, 8);
        }
    }
}