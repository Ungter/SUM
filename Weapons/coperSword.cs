using Terraria.ID;
using Terraria.ModLoader;

namespace sum.Weapons
{
	public class coperSword : ModItem
	{
		public override void SetStaticDefaults() 
		{
			
			Tooltip.SetDefault("\"I did your mom with this sword\"");
		}

		public override void SetDefaults() 
		{
			item.damage = 69;
			item.melee = true;
			item.width = 300;
			item.height = 300;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = ItemUseStyleID.EatingUsing;
			item.knockBack = 6;
			item.value = 10000;
			item.rare = ItemRarityID.Red;
			item.UseSound = SoundID.Item65;
			item.autoReuse = true;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.ClownHat, 10);
			recipe.AddIngredient(ItemID.ClownBanner, 69);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}