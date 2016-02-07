// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_HonkTorso : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Exosuit Torso (\"H.O.N.K\")";
			this.id = "honk_torso";
			this.build_type = 16;
			this.build_path = typeof(Obj_Item_MechaParts_Part_HonkerTorso);
			this.materials = new ByTable().Set( "$metal", 20000 ).Set( "$glass", 10000 ).Set( "$bananium", 10000 );
			this.construction_time = 300;
			this.category = new ByTable(new object [] { "H.O.N.K" });
		}

	}

}