using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.World.Generation;

namespace ForgottenGods {
    public class FGWorld : ModWorld {
        public static int biomeTiles = 0;

        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight) {
            int ChaosIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Chaos Infestation"));
            if (ChaosIndex != -1) {
                tasks.Insert(ChaosIndex + 1, new PassLegacy("Chaos Infestation", delegate (GenerationProgress progress) {
                    progress.Message = "Generating the Chaos Infestation";
                    for (int i = 0; i < 4; i++) {
                        WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)WorldGen.worldSurfaceLow, Main.maxTilesY - 200), (double)WorldGen.genRand.Next(100, 200), WorldGen.genRand.Next(50, 150), mod.TileType("ChaosGrass"), true, 0f, 0f, false, true);
                    }
                }));
            }
        }

        public override void TileCountsAvailable(int[] tileCounts) {
            biomeTiles = tileCounts[mod.TileType("ChaosGrass")];
        }

        public override void ResetNearbyTileEffects() {
            biomeTiles = 0;
        }
    }
}