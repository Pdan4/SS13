// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class UplinkItem_DeviceTools_Shield : UplinkItem_DeviceTools {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Energy Shield";
			this.desc = "An incredibly useful personal shield projector, capable of reflecting energy projectiles and defending against other attacks. Pair with an Energy Sword for a killer combination.";
			this.item = typeof(Obj_Item_Weapon_Shield_Energy);
			this.cost = 16;
			this.surplus = 20;
			this.include_modes = new ByTable(new object [] { typeof(GameMode_Nuclear), typeof(GameMode_Gang) });
		}

	}

}