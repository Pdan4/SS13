// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class SupplyPack_Emergency_Atmostank : SupplyPack_Emergency {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Firefighting Watertank";
			this.cost = 10;
			this.access = 24;
			this.contains = new ByTable(new object [] { typeof(Obj_Item_Weapon_Watertank_Atmos) });
			this.crate_name = "firefighting watertank crate";
			this.crate_type = typeof(Obj_Structure_Closet_Crate_Secure);
		}

	}

}