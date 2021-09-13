using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace sum.Projectiles.Pets {

    public class blackSpiritLightPet : ModProjectile {

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Black Spirit");
            Main.projFrames[projectile.type] = 1;
            Main.projPet[projectile.type] = true;
            ProjectileID.Sets.TrailingMode[projectile.type] = 2;
            ProjectileID.Sets.LightPet[projectile.type] = true;
        }

        public override void SetDefaults() {
            projectile.height = 40;
            projectile.width = 40;
            projectile.penetrate = -1;
            projectile.netImportant = true;
            projectile.timeLeft *= 5;
            projectile.friendly = true;
            projectile.ignoreWater = true;
            projectile.scale = 0.9f;
            projectile.tileCollide = false;
        }

        private const int fBrightTicks = 200;
        private const int fnTicks = 100;
        private const int foTicks = 100;
        private const int range = 600;
        private readonly int rangeHypo = (int)Math.Sqrt(range * range + range * range);


        public override void AI() {
            Player player = Main.player[projectile.owner];
            newPlayer modPlayer = player.GetModPlayer<newPlayer>();

            
            if (!player.active) {
                projectile.active = false;
                return;
            }

            if (player.dead) {
                modPlayer.blackSpiritLightPet = false;
            }

            if (modPlayer.blackSpiritLightPet) {
                projectile.timeLeft = 2;
            }

            projectile.ai[1]++;

            if (projectile.ai[1] > 1000 && (int)projectile.ai[0] % 100 == 0) {
                for (int i = 0; i < Main.maxNPCs; i++) {

                    // Alert/play sound when enemy is nearby
                    if (Main.npc[i].active && !Main.npc[i].friendly && player.Distance(Main.npc[i].Center) < rangeHypo) {
                        Vector2 vectorToEn = Main.npc[i].Center - projectile.Center;
                        projectile.velocity += 9f * Vector2.Normalize(vectorToEn);
                        projectile.ai[1] = 0f;

                        // Need custom alart sound
                        //Main.PlaySound(SoundLoader.customSoundType, -1, -1, mod.GetSoundSlot(SoundType.Custom, " "));

                        break;
                    }

                    projectile.rotation += projectile.velocity.X / 15f;
                    Lighting.AddLight(projectile.Center, (255 - projectile.alpha) * 0.9f / 255f, (255 - projectile.alpha) * 0.1f / 255f, (255 - projectile.alpha) * 0.3f / 255f);

                    // Below are some maths to rotate and move the pet
                    if (projectile.velocity.Length() > 1f) {
                        projectile.velocity *= .98f;
                    }

                    if (projectile.velocity.Length() == 0) {
                        projectile.velocity = Vector2.UnitX.RotatedBy(Main.rand.NextFloat() * Math.PI * 2);
                        projectile.velocity *= 2f;
                    }

                    // Brightness
                    projectile.ai[0]++;
                    if (projectile.ai[0] < fnTicks) {
                        projectile.alpha = (int)(255 - 255 * projectile.ai[0] / fnTicks);
                    } else if (projectile.ai[0] < fnTicks + fBrightTicks) {
                        projectile.alpha = 0;
                        
                        // Particle effects
                        if (Main.rand.NextBool(6)) {
                            int n145 = Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Corruption, 0f, 0f, 200, default(Color), 0.8f);
                            projectile.velocity *= 0.3f;

                        } else if (projectile.ai[0] < fnTicks + fBrightTicks + foTicks) {
                            projectile.alpha = (int)(255 * (projectile.ai[0] - fnTicks - fBrightTicks) / foTicks);
                        }
                        
                        else {
                            projectile.Center = new Vector2(Main.rand.Next((int)player.Center.X - range, (int)player.Center.X + range), Main.rand.Next((int)player.Center.Y - range, (int)player.Center.Y + range));
                            projectile.ai[0] = 0;
                            Vector2 vecToPlayer = player.Center - projectile.Center;
                            projectile.velocity = 2f * Vector2.Normalize(vecToPlayer);
                        }

                        if (Vector2.Distance(player.Center, projectile.Center) > rangeHypo) {
                            projectile.Center = new Vector2(Main.rand.Next((int)player.Center.X - range, (int)player.Center.X + range), Main.rand.Next((int)player.Center.Y - range, (int)player.Center.Y + range));
                            projectile.ai[0] = 0;
                            Vector2 vecToPlayer = player.Center - projectile.Center;
                            projectile.velocity += 2f * Vector2.Normalize(vecToPlayer);
                        }

                        if ((int)projectile.ai[0] % 100 == 0) {
                            projectile.velocity = projectile.velocity.RotatedByRandom(MathHelper.ToRadians(90));
                        }
                    }
                    
                    

                }
            }


        }
    }
}