// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_PhazonHead : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Exosuit Head (\"Phazon\")";
			this.id = "phazon_head";
			this.build_type = 16;
			this.build_path = typeof(Obj_Item_MechaParts_Part_PhazonHead);
			this.materials = new ByTable().Set( "$metal", 15000 ).Set( "$glass", 5000 ).Set( "$plasma", 10000 );
			this.construction_time = 200;
			this.category = new ByTable(new object [] { "Phazon" });
		}

	}

}