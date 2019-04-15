using Microsoft.Xna.Framework;
using System;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenGods.Items.Weapons.Melee {
    public class TaintedSword : ModItem {
        public int RandomNumber(int min, int max) {
            Random random = new Random();
            return random.Next(min, max);
        }

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Twisted Blade");
            Tooltip.SetDefault("The blood stains won't wash off...");
        }

        public override void SetDefaults() {
            item.damage = 34;
            item.melee = true;
            item.width = 40;
            item.height = 40;
            item.useTime = 25;
            item.useAnimation = 25;
            item.useStyle = 1;
            item.knockBack = 5;
            item.value = 2000000;
            item.rare = 3;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("TaintedBar"), 50);
            recipe.AddIngredient(mod.ItemType("AncientSteal"), 30);
            recipe.AddTile(16);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void MeleeEffects(Player player, Rectangle hitbox) {
            if (Main.rand.NextBool(3)) {
                Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 5, 1f, -5f, 0, default(Color), 1f);
            }
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit) {
            int rand = RandomNumber(1, 4);
            if (rand == 1) {
                target.AddBuff(30, 300);
            } else if(rand == 2) {
                target.AddBuff(24, 300);
            } else if(rand == 3) {
                target.AddBuff(31, 150);
            } else if(rand == 4) {
                target.AddBuff(36, 150);
            }
        }
    }
}