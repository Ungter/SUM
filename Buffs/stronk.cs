using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace sum.Buffs {

	public class stronk : ModBuff {

        public override void SetDefaults() { 

            DisplayName.SetDefault("Stronk");
            Description.SetDefault("Makes you strong burh");
            canBeCleared = false;
                            
        }

        public override void Update(Player player, ref int buffIndex) { 
        
            player.lifeRegen += 200;
            player.extraAccessorySlots += 2;
            player.moveSpeed += 9999;
            if (player.lifeRegen <= 200) { 
            
                player.lifeRegen++;
            }

        }

        
    }
}
