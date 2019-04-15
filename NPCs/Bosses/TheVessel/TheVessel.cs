using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ForgottenGods.NPCs.Bosses.TheVessel {
    public class TheVessel : ModNPC {
        public float attackCool = -1;
        public Boolean rings;
        public static readonly int arenaWidth = (int)(1.3f * NPC.sWidth);
        private int RandomNumber(int min, int max) {
            Random random = new Random();
            return random.Next(min, max);
        }

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("The Vessel");
        }

        public override void SetDefaults() {
            npc.aiStyle = -1;
            npc.lifeMax = 3500;
            npc.damage = 80;
            npc.defense = 15;
            npc.knockBackResist = 0f;
            npc.width = 104;
            npc.height = 110;
            npc.npcSlots = 1f;
            npc.boss = true;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.buffImmune[31] = true;
            bossBag = mod.ItemType("TheVesselBag");
            music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/Bosses/TheVessel");
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale) {
            npc.lifeMax = (int)(npc.lifeMax * 0.625f * bossLifeScale);
            npc.damage = (int)(npc.damage * 0.6f);
            npc.defense = (int)(npc.defense * 0.6f);
        }

        public override void AI() {
            Player player = Main.player[npc.target];
            Vector2 moveTo = player.Center;
            Vector2 move = moveTo - npc.Center;
            double magnitude = Math.Sqrt(move.X * move.X + move.Y * move.Y);
            if (!player.active || player.dead || Main.dayTime) {
                npc.TargetClosest(false);
                npc.velocity = new Vector2(0f, -25f);
                if (npc.timeLeft > 10) {
                    npc.timeLeft = 10;
                }

                else {
                    npc.TargetClosest(true);
                }
            }

            if (Main.expertMode) {
                if (npc.life > (npc.lifeMax / 2)) {
                    rings = true;
                    double speed = 7;
                    attackCool -= 1f;
                    if (attackCool <= 0f) {
                        attackCool = 200f + 200f * (float)npc.life / (float)npc.lifeMax + (float)Main.rand.Next(200);
                        Vector2 delta = player.Center - npc.Center;
                        if (magnitude > 0) {
                            delta *= (10f + (float)RandomNumber(-5, 5) + ((float)speed / 2)) / (float)magnitude;
                        } else {
                            delta = new Vector2(0f, 5f);
                        }

                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y, delta.X, delta.Y, mod.ProjectileType("ChaosEnergy"), 80, 1f, Main.myPlayer, BuffID.OnFire, 600f);
                        npc.netUpdate = true;
                    }

                    if (magnitude > speed) {
                        move *= (float)speed / (float)magnitude;
                    }
                } else if (npc.life < (npc.lifeMax / 2)) {
                    double lifespeed = npc.life / 8;
                    double speed = (100 / (lifespeed * 5)) + 7;
                    npc.defense -= 5;
                    if (magnitude > speed) {
                        move *= (float)speed / (float)magnitude;
                    }

                    if (rings == true) {
                        ChaosRing(arenaWidth / 16, true);
                        ChaosRing(arenaWidth / 12, true);
                        ChaosRing(arenaWidth / 8, true);
                        ChaosRing(arenaWidth / 4, true);
                        rings = false;
                    }
                }
            } else {
                if (npc.life > (npc.lifeMax / 2)) {
                    rings = true;
                    double speed = 5;
                    attackCool -= 1f;
                    if (attackCool <= 0f) {
                        attackCool = 200f + 200f * (float)npc.life / (float)npc.lifeMax + (float)Main.rand.Next(200);
                        Vector2 delta = player.Center - npc.Center;
                        if (magnitude > 0) {
                            delta *= (10f + (float)RandomNumber(-5, 5) + ((float)speed / 2)) / (float)magnitude;
                        } else {
                            delta = new Vector2(0f, 5f);
                        }
                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y, delta.X, delta.Y, mod.ProjectileType("ChaosEnergy"), 60, 1f, Main.myPlayer, BuffID.OnFire, 600f);
                        npc.netUpdate = true;
                    }

                    if (magnitude > speed) {
                        move *= (float)speed / (float)magnitude;
                    }
                } else if (npc.life < (npc.lifeMax / 2)) {
                    rings = true;
                    double lifespeed = npc.life / 10;
                    double speed = (100 / (lifespeed * 5)) + 5;
                    npc.defense -= 5;
                    if (magnitude > speed) {
                        move *= (float)speed / (float)magnitude;
                    }

                    if (rings == true) {
                        ChaosRing(arenaWidth / 12, false);
                        ChaosRing(arenaWidth / 8, false);
                        ChaosRing(arenaWidth / 4, false);
                        rings = false;
                    }
                }
            }
            float turnResistance = 10f;
            move = (npc.velocity * turnResistance + move) / (turnResistance + 1f);
            npc.velocity = move;
        }

        void ChaosRing(int radius, bool clockwise) {
            Vector2 center = npc.Center;
            if (Main.netMode == 1) {
                return;
            }

            for (int k = 0; k < 10; k++) {
                float angle = 2f * (float)Math.PI / 10f * k;
                Vector2 pos = center + radius * new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle));
                int damage = 50;
                if (Main.expertMode) {
                    damage = 68;
                }
                int proj = Projectile.NewProjectile(pos.X, pos.Y, 0f, 0f, mod.ProjectileType("ChaosRing"), damage, 0f, Main.myPlayer, npc.whoAmI, angle);
                Main.projectile[proj].localAI[0] = radius;
                Main.projectile[proj].localAI[1] = clockwise ? 1 : -1;
                NetMessage.SendData(27, -1, -1, null, proj);
            }
        }

        public override void BossLoot(ref string name, ref int potionType) {
            if (Main.expertMode) {
                npc.DropBossBags();
            } else {
                Item.NewItem(npc.getRect(), mod.ItemType("TaintedOre"), 20 + Main.rand.Next(56));
                Item.NewItem(npc.getRect(), 73, 5);
            }
            potionType = ItemID.HealingPotion;
        }

        public override void HitEffect(int hitDirection, double damage) {
            for (int x = 0; x < (double)damage / (double)npc.lifeMax * 100.0; x++) {
                Dust.NewDust(npc.position, npc.width, npc.height, 5, (float)hitDirection, -5f, 0, default(Color), 1f);
            }
        }
    }
}
