using Terraria;
using Terraria.ID;
using Microsoft.Xna;
using Terraria.ModLoader;

namespace sum.Pets {

    public class bsPet : ModItem {

        public override void SetStaticDefaults() {

            DisplayName.SetDefault("Strange Black Blob");
            Tooltip.SetDefault("You feel as if this blob is your friend");
        }

        public override void SetDefaults() {
            item.damage = 0;
            item.useStyle = ItemUseStyleID.SwingThrow;
            
        }
    }
}