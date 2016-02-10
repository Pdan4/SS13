// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class UplinkItem_StealthyWeapons_Detomatix : UplinkItem_StealthyWeapons {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Detomatix PDA Cartridge";
			this.desc = "When inserted into a personal digital assistant, this cartridge gives you five opportunities to detonate PDAs of crewmembers who have their message feature enabled. The concussive effect from the explosion will knock the recipient out for a short period, and deafen them for longer. It has a chance to detonate your PDA.";
			this.item = typeof(Obj_Item_Weapon_Cartridge_Syndicate);
			this.cost = 3;
		}

	}

}