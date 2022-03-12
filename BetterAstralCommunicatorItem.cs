//using CalamityMod;
//using CalamityMod.CalPlayer;
//using CalamityMod.Events;
//using CatalystMod;
//using CatalystMod.Common;
//using CatalystMod.Projectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace BetterAstralCommunicator
{
    public class BetterAstralCommunicatorItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Better Astral Communicator");
            Tooltip.SetDefault("Summons Astrageldon in any biome in any time\nNot consumable");
        }
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 26;
            item.value = 0;
            item.rare = 10;
            item.maxStack = 1;
            item.useAnimation = 30;
            item.useTime = 30;
            item.useStyle = 4;
            item.consumable = false;
            item.UseSound = SoundID.Item117;
        }

        public override bool CanUseItem(Player player)
        {
            Mod calamity = ModLoader.GetMod("CalamityMod");
            Mod catalyst = ModLoader.GetMod("CatalystMod");
            if ((bool)calamity.Call("GetDifficultyActive", "bossrush"))
                return false;
            //CatalystPlayer catalystPlayer = CatalystPlayer.ModPlayer(player);
            //CalamityPlayer calamityPlayer = player.Calamity();

            bool num1 = true;
            foreach (Projectile i in Main.projectile)
            {
                if (i.type == catalyst.ProjectileType("AstralOrb") && i.active)
                {
                    num1 = false;
                    break;
                }
            }
            bool IsAstral = calamity.Call("GetInZone", "astral") as bool? ?? false;
            Main.NewText("Is Overworld: " + player.ZoneOverworldHeight.ToString(), Color.White);
            Main.NewText("Is Astral: " + IsAstral.ToString(), Color.White);
            Main.NewText("Is Blight: " + player.GetModPlayer<CatalystPlayerClone>().ZoneBlight.ToString(), Color.White);
            Main.NewText("Haven`t Astrageldon: " + (!NPC.AnyNPCs(catalyst.NPCType("Astrageldon"))).ToString(), Color.White);
            Main.NewText("Haven`t Astral Orb: " + num1.ToString(), Color.White);


            return player.ZoneOverworldHeight /*&& (IsAstral || player.GetModPlayer<CatalystPlayerClone>().ZoneBlight)*/ && !NPC.AnyNPCs(catalyst.NPCType("Astrageldon")) && num1;
        }

        public override bool AltFunctionUse(Player player) => true;

        public override bool UseItem(Player player)
        {
            /*if (player.whoAmI == Main.myPlayer)
            {
                bool flag = false;
                if (player.altFunctionUse != 2 && WorldDefeats.DownedAstrageldonPhase1)
                    flag = true;
                Projectile.NewProjectile(player.Center + new Vector2((float)(18 * player.direction), -26f), new Vector2(0.0f, -2f), ModContent.ProjectileType<AstralOrb>(), 0, 0.0f, Main.myPlayer, 0.0f, flag ? -1f : 0.0f);
            }*/
            return ModLoader.GetMod("CatalystMod").GetItem("AstralCommunicator").UseItem(player);
        }
        public override void AddRecipes()
        {
            Mod catalyst = ModLoader.GetMod("CatalystMod");

            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(catalyst.ItemType("AstralCommunicator"));
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(this);
            recipe.SetResult(catalyst.ItemType("AstralCommunicator"));
            recipe.AddRecipe();
        }
    }
}