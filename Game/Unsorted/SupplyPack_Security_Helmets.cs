// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class SupplyPack_Security_Helmets : SupplyPack_Security {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Helmets Crate";
			this.cost = 10;
			this.contains = new ByTable(new object [] { typeof(Obj_Item_Clothing_Head_Helmet_Sec), typeof(Obj_Item_Clothing_Head_Helmet_Sec), typeof(Obj_Item_Clothing_Head_Helmet_Sec) });
			this.crate_name = "helmet crate";
		}

	}

}