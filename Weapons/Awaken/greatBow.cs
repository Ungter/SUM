using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace sum.Weapons.Awaken { 

    public class greatBow : ModRecipe {

        public int NeededNPCType;

        private const int Range = 500;

        public greatBow(Mod mod, int NeededNPC) : base(mod) {
            NeededNPCType = NeededNPC; //NeededNPC is the npc that we have to put into the game (I think) (Watcher of Aduir)
        }


        // Goal is to make RecipeAvailble, below is to check the custom requirements
        public override bool RecipeAvailable() {

            bool foundNPC = false;

            // Check if the world is in hardmode
            if (!Main.hardMode) {
                return false;
            }

            // If the world is in hardmode then we'll try and find the required npc
            foreach (NPC npc in Main.npc) {

                if (!npc.active || npc.type != NeededNPCType) {

                    continue;

                }

                //else we'll check is required distance 
                if (Main.LocalPlayer.DistanceSQ(npc.Center) <= Range * Range) {

                    foundNPC = true;
                    break;

                }
            }
            // If all is in place then returns true
            return foundNPC;
        }

        // uhhh ig it fits the lore (?????)
        public override void OnCraft(Item item) {
            Main.LocalPlayer.AddBuff(BuffID.Clairvoyance, 30);
        }


    }


    public class greatBowStats : ModItem {
        public override void SetStaticDefaults() { 
            // Find more StDefaults !!
            DisplayName.SetDefault("Greatbow");
            Tooltip.SetDefault("You picked up the broken arrow and the black spirit felt a surge of energy coming from you.");
        }

        public override void SetDefaults() {
            // Note: these are the starting stats, the enhancement system will be implemeted on a later date
            item.damage = 20;
            item.ranged = true;
            item.width = 12;
            item.height = 23;
            item.maxStack = 1;
            item.useTime = 12;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useAnimation = 12;
            item.knockBack = 2;
            item.value = 11000;
            item.rare = ItemRarityID.LightRed;
            item.noMelee = true;
            item.shoot = ProjectileID.WoodenArrowFriendly;
            item.useAmmo = AmmoID.Arrow;
            item.shootSpeed = 10;
            // item.UseSound = idk yet
            item.autoReuse = true;
            
        }

        public override void AddRecipes() {
            ModRecipe gBowRec = new ModRecipe(mod);
            gBowRec.AddIngredient(ItemID.RangerEmblem, 1);
            gBowRec.AddIngredient(ItemID.MoltenFury, 1);
            gBowRec.AddIngredient(ItemID.RichMahoganyBow, 1);
            gBowRec.AddIngredient(ItemID.Feather, 6);
            gBowRec.AddTile(TileID.DemonAltar);
            gBowRec.SetResult(this);
            gBowRec.AddRecipe();
        }
    } 
}
