using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenGods.Tiles.Ore {
    public class TaintedOre : ModTile {
        public override void SetDefaults() {
            TileID.Sets.Ore[Type] = true;
            Main.tileSpelunker[Type] = true;
            Main.tileValue[Type] = 340;
            Main.tileShine2[Type] = true;
            Main.tileShine[Type] = 1000;
            Main.tileMergeDirt[Type] = true;
            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = true;
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("TaintedOre");
            AddMapEntry(new Color(152, 171, 198), name);
            dustType = 84;
            drop = mod.ItemType("TaintedOre");
            soundType = 21;
            soundStyle = 1;
            mineResist = 2f;
            minPick = 65;
        }
    }
}