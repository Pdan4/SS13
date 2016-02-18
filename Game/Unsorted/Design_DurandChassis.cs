// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_DurandChassis : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Exosuit Chassis (\"Durand\")";
			this.id = "durand_chassis";
			this.build_type = 16;
			this.build_path = typeof(Obj_Item_MechaParts_Chassis_Durand);
			this.materials = new ByTable().Set( "$metal", 25000 );
			this.construction_time = 100;
			this.category = new ByTable(new object [] { "Durand" });
		}

	}

}