using System.IO;
using Terraria;
using Terraria.ModLoader;

namespace BetterAstralCommunicator
{
    public class CatalystPlayerClone : ModPlayer
    {
        public bool ZoneBlight;
        public override void UpdateBiomes()
        {
            ZoneBlight = CatalystWorldClone.BlightTiles > 400;
        }
        public override void CopyCustomBiomesTo(Player other)
        {
            other.GetModPlayer<CatalystPlayerClone>().ZoneBlight = ZoneBlight;
        }
        public override void SendCustomBiomes(BinaryWriter writer)
        {
            writer.Write(ZoneBlight);
        }
        public override void ReceiveCustomBiomes(BinaryReader reader)
        {
            ZoneBlight = reader.ReadBoolean();
        }
    }
}