// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_Rpd : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Rapid pipe dispenser (RPD)";
			this.id = "rpd";
			this.build_type = 4;
			this.materials = new ByTable().Set( "$metal", 75000 ).Set( "$glass", 37500 );
			this.build_path = typeof(Obj_Item_Weapon_PipeDispenser);
			this.category = new ByTable(new object [] { "hacked", "Construction" });
		}

	}

}