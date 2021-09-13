using Terraria;
using Terraria.ID;
using Microsoft.Xna;
using Terraria.ModLoader;

namespace sum.Items.Pets {

    public class blackSpiritLightPet : ModItem {

        public override void SetStaticDefaults() {

            DisplayName.SetDefault("Strange Black Blob");
            Tooltip.SetDefault("You feel as if this blob is your friend");
        }

        public override void SetDefaults() {
            item.damage = 0;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.shoot = ModContent.ProjectileType<Projectiles.Pets.blackSpiritLightPet>();
            item.width = 17;
            item.height = 27;
            item.UseSound = SoundID.DD2_DarkMageAttack;
            item.useAnimation = 20;
            item.useTime = 15;
            item.rare = ItemRarityID.Red;
            item.noMelee = true;
            item.value = Item.sellPrice(1, 0, 0, 0);
            item.buffType = ModContent.BuffType<Buffs.blackSpiritLightPet>();

            
        }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.VenusMagnum, 1);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void UseStyle(Player player) {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0) {
                player.AddBuff(item.buffType, 3600, true);
            }
        }
    }
}