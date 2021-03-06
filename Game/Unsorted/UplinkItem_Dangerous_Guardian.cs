// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class UplinkItem_Dangerous_Guardian : UplinkItem_Dangerous {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Holoparasites";
			this.desc = "Though capable of near sorcerous feats via use of hardlight holograms and nanomachines, they require an organic host as a home base and source of fuel.";
			this.item = typeof(Obj_Item_Weapon_Storage_Box_SyndieKit_Guardian);
			this.cost = 12;
			this.exclude_modes = new ByTable(new object [] { typeof(GameMode_Nuclear), typeof(GameMode_Gang) });
		}

	}

}