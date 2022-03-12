using Terraria.ModLoader;

namespace BetterAstralCommunicator
{
    public class CatalystWorldClone : ModWorld
    {
        public static int BlightTiles;
        public override void ResetNearbyTileEffects()
        {
            CatalystWorldClone.BlightTiles = 0;
        }

        public override void TileCountsAvailable(int[] tileCounts)
        {
            Mod mod = Terraria.ModLoader.ModLoader.GetMod("CalValEX");
            if (mod == null)
                return;
            CatalystWorldClone.BlightTiles = tileCounts[mod.TileType("AstralDirtPlaced")] + tileCounts[mod.TileType("AstralGrassPlaced")] + tileCounts[mod.TileType("XenostonePlaced")] + tileCounts[mod.TileType("AstralSandPlaced")] + tileCounts[mod.TileType("AstralHardenedSandPlaced")] + tileCounts[mod.TileType("AstralSandstonePlaced")] + tileCounts[mod.TileType("AstralClayPlaced")] + tileCounts[mod.TileType("AstralIcePlaced")];
        }
    }
}