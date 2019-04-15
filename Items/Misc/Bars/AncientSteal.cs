using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenGods.Items.Misc.Bars {
	public class AncientSteal : ModItem {
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Ancient Steal");
		}
		public override void SetDefaults() {
			item.width = 30;
			item.height = 24;
            item.maxStack = 999;
            item.value = 15000;
		}
	}
}