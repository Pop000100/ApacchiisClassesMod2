using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ApacchiisClassesMod2.Items.Relics
{
	public class Croissant : ModItem
	{
        public string desc = "'Well Fed', 'Plenty Satisfied' and 'Exquisitely Satisfied' buffs now grant 50% bonus stats\n" +
                             "Increases defense by 3 defense";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("[Relic] Croissant");
            Tooltip.SetDefault(desc);
            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
		{
			Item.width = 30;
			Item.height = 30;
			Item.accessory = true;	
			Item.value = Item.sellPrice(0, 2, 0 ,0);
			Item.rare = ItemRarityID.Quest;

            Item.GetGlobalItem<ACMGlobalItem>().isRelic = true;
            Item.GetGlobalItem<ACMGlobalItem>().desc = desc;
        }

        public override void UpdateVanity(Player player)
        {
            var acmPlayer = player.GetModPlayer<ACMPlayer>();
            acmPlayer.hasRelic = true;
            player.statDefense += 3;

            if(player.HasBuff(BuffID.WellFed))
            {
                player.statDefense += 1;
                player.GetCritChance(DamageClass.Generic) += 2;
                player.GetAttackSpeed(DamageClass.Melee) += .025f;
                player.GetDamage(DamageClass.Generic) += .025f;
                player.GetKnockback(DamageClass.Summon) += .25f;
                player.moveSpeed += .1f;
            }

            if (player.HasBuff(BuffID.WellFed2))
            {
                player.statDefense += 2;
                player.GetCritChance(DamageClass.Generic) += 2;
                player.GetAttackSpeed(DamageClass.Melee) += .0375f;
                player.GetDamage(DamageClass.Generic) += .0375f;
                player.GetKnockback(DamageClass.Summon) += .375f;
                player.moveSpeed += .15f;
                player.pickSpeed += .05f;
            }

            if (player.HasBuff(BuffID.WellFed3))
            {
                player.statDefense += 3;
                player.GetCritChance(DamageClass.Generic) += 3;
                player.GetAttackSpeed(DamageClass.Melee) += .05f;
                player.GetDamage(DamageClass.Generic) += .05f;
                player.GetKnockback(DamageClass.Summon) += .5f;
                player.moveSpeed += .2f;
                player.pickSpeed += .075f;
            }

            base.UpdateVanity(player);
        }
        public override bool CanEquipAccessory(Player player, int slot, bool modded)
        {
            if (player.GetModPlayer<ACMPlayer>().hasRelic == true)
                return false;

            if (!modded)
                return false;

            return base.CanEquipAccessory(player, slot, modded);
        }
    }
}

