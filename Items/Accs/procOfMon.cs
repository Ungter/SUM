using Terraria.ModLoader;
using Terraria.ID;
using Terraria;

namespace sum.Items.Accs {
    public class procOfMon : ModPlayer {


        public bool FrostBurnSummon;

        public override void ResetEffects() {
            FrostBurnSummon = false;
        }

        
        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit) {
            if ((proj.minion || ProjectileID.Sets.MinionShot[proj.type]) && FrostBurnSummon && !proj.noEnchantments) {

                target.AddBuff(BuffID.Frostburn, 60 * Main.rand.Next(5, 15), false);
            }
        }

    }
   
    // We nest the acc inside the mod namespace to attach the defined effect above to the accs
    namespace AccSprites {
        
        // Loads the png or animations
        [AutoloadEquip(EquipType.Neck)]

        internal class procOfMonarch : ModItem {

            // Sets the Name and Tooltip for the accs
            public override void SetStaticDefaults() {
                DisplayName.SetDefault("Shiny Blue Necklace");
                Tooltip.SetDefault("You found(made ?) this shiny necklace inside an igloo");
            }

            // Sets the stats for the accs
            public override void SetDefaults() {
                item.width = 35;
                item.height = 35;
                item.rare = ItemRarityID.Yellow;
                item.accessory = true;
                item.value = 150000;
            }

            // Since the player itself can't summon the frostburn effect because Player isn't attached to the effect, we need to use the GetModPlayer method to retrieve ModPlayer instance attached to the specified Player.
            public override void UpdateAccessory(Player player, bool hideVisual) {
                player.GetModPlayer<procOfMon>().FrostBurnSummon = true;
            }

            // Adds the recipe to make the actual accs
            public override void AddRecipes() {

                ModRecipe recipie = new ModRecipe(mod);
                // Remember to actually change this recipie pls
                recipie.AddIngredient(ItemID.DirtBlock, 1);
                recipie.AddTile(TileID.WorkBenches);
                recipie.SetResult(this);
                recipie.AddRecipe();

            }
        }
    }
}