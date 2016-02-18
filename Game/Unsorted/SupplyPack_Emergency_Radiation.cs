// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class SupplyPack_Emergency_Radiation : SupplyPack_Emergency {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Radiation Protection Crate";
			this.cost = 10;
			this.contains = new ByTable(new object [] { typeof(Obj_Item_Clothing_Head_Radiation), typeof(Obj_Item_Clothing_Head_Radiation), typeof(Obj_Item_Clothing_Suit_Radiation), typeof(Obj_Item_Clothing_Suit_Radiation) });
			this.crate_name = "radiation protection crate";
			this.crate_type = typeof(Obj_Structure_Closet_Crate_Radiation);
		}

	}

}