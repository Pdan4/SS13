// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class SupplyPacks_Wheelchair : SupplyPacks {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Wheelchair Crate";
			this.contains = new ByTable(new object [] { typeof(Obj_Structure_Bed_Chair_Vehicle_Wheelchair) });
			this.cost = 40;
			this.containertype = typeof(Obj_Structure_Closet_Crate_Medical);
			this.containername = "Wheelchair Crate";
			this.group = "Medical";
		}

	}

}