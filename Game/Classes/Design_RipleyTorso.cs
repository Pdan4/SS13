// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_RipleyTorso : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Exosuit Torso (APLU \"Ripley\")";
			this.id = "ripley_torso";
			this.build_type = 16;
			this.build_path = typeof(Obj_Item_MechaParts_Part_RipleyTorso);
			this.materials = new ByTable().Set( "$metal", 20000 ).Set( "$glass", 7500 );
			this.construction_time = 200;
			this.category = new ByTable(new object [] { "Ripley", "Firefighter" });
		}

	}

}