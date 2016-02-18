// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class UplinkItem_StealthyWeapons_DoorCharge : UplinkItem_StealthyWeapons {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Explosive Airlock Charge";
			this.desc = "A small, easily concealable device. It can be applied to an open airlock panel, booby-trapping it. The next person to use that airlock will trigger an explosion, knocking them down and destroying the airlock maintenance panel.";
			this.item = typeof(Obj_Item_Device_DoorCharge);
			this.cost = 2;
			this.surplus = 10;
			this.exclude_modes = new ByTable(new object [] { typeof(GameMode_Nuclear) });
		}

	}

}