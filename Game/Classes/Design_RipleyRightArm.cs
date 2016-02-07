// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_RipleyRightArm : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Exosuit Right Arm (APLU \"Ripley\")";
			this.id = "ripley_right_arm";
			this.build_type = 16;
			this.build_path = typeof(Obj_Item_MechaParts_Part_RipleyRightArm);
			this.materials = new ByTable().Set( "$metal", 15000 );
			this.construction_time = 150;
			this.category = new ByTable(new object [] { "Ripley", "Firefighter" });
		}

	}

}