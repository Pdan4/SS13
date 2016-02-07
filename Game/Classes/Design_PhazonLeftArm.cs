// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_PhazonLeftArm : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Exosuit Left Arm (\"Phazon\")";
			this.id = "phazon_left_arm";
			this.build_type = 16;
			this.build_path = typeof(Obj_Item_MechaParts_Part_PhazonLeftArm);
			this.materials = new ByTable().Set( "$metal", 20000 ).Set( "$plasma", 10000 );
			this.construction_time = 200;
			this.category = new ByTable(new object [] { "Phazon" });
		}

	}

}