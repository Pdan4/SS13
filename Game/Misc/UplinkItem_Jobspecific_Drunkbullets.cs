// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class UplinkItem_Jobspecific_Drunkbullets : UplinkItem_Jobspecific {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Boozey Shotgun Shells";
			this.desc = "A box containing 6 shotgun shells that simulate the effects of extreme drunkeness on the target, more effective for each type of alcohol in the target's system.";
			this.item = typeof(Obj_Item_Weapon_Storage_Box_SyndieKit_Boolets);
			this.cost = 3;
			this.job = new ByTable(new object [] { "Bartender" });
		}

	}

}