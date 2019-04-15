using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenGods.Projectiles.Bosses.TheVessel {
    public class ChaosRing : ModProjectile {
        private int timer;
        private float remove = 500f + (float)Main.rand.Next(500);

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Chaos Ring");
        }

        public override void SetDefaults() {
            projectile.width = 16;
            projectile.height = 16;
            projectile.penetrate = -1;
            projectile.magic = true;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            projectile.netImportant = true;
        }

        public override void SendExtraAI(BinaryWriter writer) {
            writer.Write(projectile.localAI[0]);
            writer.Write(projectile.localAI[1]);
        }

        public override void ReceiveExtraAI(BinaryReader reader) {
            projectile.localAI[0] = reader.ReadSingle();
            projectile.localAI[1] = reader.ReadSingle();
        }

        public override void AI() {
            remove -= 1f;
            NPC center = Main.npc[(int)projectile.ai[0]];
            if (!center.active || center.type != mod.NPCType("TheVessel")) {
                projectile.Kill();
            }

            if (remove < 0f) {
                if (Main.rand.Next(180 + (int)remove) == 1) {
                    projectile.Kill();
                }
            }

            if (timer < 120) {
                projectile.alpha = (120 - timer) * 255 / 120;
                timer++;
            }

            else {
                projectile.alpha = 0;
                projectile.hostile = true;
            }

            projectile.timeLeft = 2;
            projectile.ai[1] += 2f * (float)Math.PI / 600f * projectile.localAI[1];
            projectile.ai[1] %= 2f * (float)Math.PI;
            projectile.rotation -= 2f * (float)Math.PI / 120f * projectile.localAI[1];
            projectile.Center = center.Center + projectile.localAI[0] * new Vector2((float)Math.Cos(projectile.ai[1]), (float)Math.Sin(projectile.ai[1]));
        }

        public override void OnHitPlayer(Player target, int damage, bool crit) {
            for (int k = 0; k < Player.maxBuffs; k++) {
                if (target.buffType[k] > 0 && target.buffTime[k] > 0 && BuffLoader.CanBeCleared(target.buffType[k]) && Main.rand.NextBool()) {
                    target.DelBuff(k);
                    k--;
                }
            }
        }

        public Color? GetColor() {
            return new Color(80, 10, 150);
        }
    }
}