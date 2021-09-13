using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace sum.Buffs {
    public class blackSpiritLightPet : ModBuff {

        public override void SetDefaults() {
            DisplayName.SetDefault("Black Spirit");
            Description.SetDefault("Your companion in this journy of obtaining power");
            Main.buffNoTimeDisplay[Type] = true;
            Main.lightPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex) {
            player.GetModPlayer<newPlayer>().blackSpiritLightPet = true;
            player.buffTime[buffIndex] = 17500;
            bool petProjNotSpawned = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.blackSpiritLightPet>()] <= 0;
            if (petProjNotSpawned && player.whoAmI == Main.myPlayer) {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.blackSpiritLightPet>(), 0, 0f, player.whoAmI, 0f, 0f);
            }

            if (player.controlDown && player.releaseDown) {
                if (player.doubleTapCardinalTimer[0] > 0 && player.doubleTapCardinalTimer[0] != 15) {
                    for (int j = 0; j < 1000; j++) {

                        if (Main.projectile[j].active && Main.projectile[j].type == ModContent.ProjectileType<Projectiles.Pets.blackSpiritLightPet>() && Main.projectile[j].owner == player.whoAmI) {
                            Projectile lPet = Main.projectile[j];
                            Vector2 vecToMouse = Main.MouseWorld - lPet.Center;
                            lPet.velocity += 5f * Vector2.Normalize(vecToMouse);
                        }
                    }
                }
            }
        }
    }
}