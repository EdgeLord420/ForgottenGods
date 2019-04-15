using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenGods.Projectiles.Bosses.TheVessel {
    public class ChaosEnergy : ModProjectile {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Chaos Energy");
        }

        public override void SetDefaults() {
            projectile.width = 16;
            projectile.height = 16;
            projectile.alpha = 255;
            projectile.timeLeft = 600;
            projectile.penetrate = -1;
            projectile.hostile = true;
            projectile.magic = true;
            projectile.tileCollide = true;
            projectile.ignoreWater = true;
        }

        public override void AI() {
            if (projectile.localAI[0] == 0f) {
                PlaySound();
                if (projectile.ai[0] < 0f) {
                    projectile.alpha = 0;
                }

                if (projectile.ai[0] < 0f && Main.expertMode) {
                    cooldownSlot = 1;
                }

                projectile.Name = GetName();
                projectile.localAI[0] = 1f;
            }
            CreateDust();
        }

        public virtual void PlaySound() {
            Main.PlaySound(SoundID.Item20, projectile.position);
        }

        public virtual void CreateDust() {
            Color? color = GetColor();
            if (color.HasValue) {
                int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("Flame"), 0f, 0f, 0, color.Value);
                Main.dust[dust].velocity *= 0.4f;
                Main.dust[dust].velocity += projectile.velocity;
            }
        }

        public override void OnHitPlayer(Player target, int damage, bool crit) {
            if ((Main.expertMode || Main.rand.NextBool()) && projectile.ai[0] >= 0f) {
                target.AddBuff((int)projectile.ai[0], (int)projectile.ai[1], true);
            }
        }

        public virtual string GetName() {
            return "Chaos Energy";
        }

        public Color? GetColor() {
            return new Color(80, 10, 150);
        }
    }
}