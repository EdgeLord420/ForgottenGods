using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework.Graphics;

namespace ForgottenGods {
    public class FGPlayer : ModPlayer {
        public bool zoneChaosBiome = false;

        public override void UpdateBiomes() {
            zoneChaosBiome = (FGWorld.biomeTiles > 99);
        }

        public override void SendCustomBiomes(BinaryWriter writer) {
            BitsByte flags = new BitsByte();
            flags[0] = zoneChaosBiome;
            writer.Write(flags);
        }

        public override void ReceiveCustomBiomes(BinaryReader reader) {
            BitsByte flags = reader.ReadByte();
            zoneChaosBiome = flags[0];
        }

        public override void UpdateBiomeVisuals() {

        }

        public override Texture2D GetMapBackgroundImage() {
            return null;
        }
    }
}