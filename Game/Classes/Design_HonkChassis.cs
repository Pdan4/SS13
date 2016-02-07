// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_HonkChassis : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Exosuit Chassis (\"H.O.N.K\")";
			this.id = "honk_chassis";
			this.build_type = 16;
			this.build_path = typeof(Obj_Item_MechaParts_Chassis_Honker);
			this.materials = new ByTable().Set( "$metal", 20000 );
			this.construction_time = 100;
			this.category = new ByTable(new object [] { "H.O.N.K" });
		}

	}

}