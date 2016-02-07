// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_HonkHead : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Exosuit Head (\"H.O.N.K\")";
			this.id = "honk_head";
			this.build_type = 16;
			this.build_path = typeof(Obj_Item_MechaParts_Part_HonkerHead);
			this.materials = new ByTable().Set( "$metal", 10000 ).Set( "$glass", 5000 ).Set( "$bananium", 5000 );
			this.construction_time = 200;
			this.category = new ByTable(new object [] { "H.O.N.K" });
		}

	}

}