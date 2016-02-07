// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_DurandHead : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Exosuit Head (\"Durand\")";
			this.id = "durand_head";
			this.build_type = 16;
			this.build_path = typeof(Obj_Item_MechaParts_Part_DurandHead);
			this.materials = new ByTable().Set( "$metal", 10000 ).Set( "$glass", 15000 ).Set( "$silver", 2000 );
			this.construction_time = 200;
			this.category = new ByTable(new object [] { "Durand" });
		}

	}

}