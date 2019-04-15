using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenGods.Tiles.Grass {
    public class ChaosGrass : ModTile {
        public override void SetDefaults() {
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Chaos Infested Grass");
            AddMapEntry(new Color(100, 26, 150), name);
            dustType = 58;
            soundType = 6;
            soundStyle = 1;
        }

        public override void RandomUpdate(int i, int j) {
            if (Main.tile[i + 1, j].type == 2) {
                WorldGen.SpreadGrass(i, j, TileID.Dirt, mod.TileType("ChaosGrass"), false, 0);
            }
        }

        public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem) {
            WorldGen.KillTile(i, j);
            WorldGen.PlaceTile(i, j, TileID.Dirt);
        }
    }
}