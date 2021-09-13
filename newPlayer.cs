using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using sum.Projectiles.Pets;
using sum.Items;
using sum.Items.Pets;
using sum.Buffs;

namespace sum {

    public class newPlayer : ModPlayer {

        public bool blackSpiritLightPet;

        public override void ResetEffects() {
            blackSpiritLightPet = false;
        }


    }
}