// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_Retractor : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Retractor";
			this.id = "retractor";
			this.build_type = 4;
			this.materials = new ByTable().Set( "$metal", 6000 ).Set( "$glass", 3000 );
			this.build_path = typeof(Obj_Item_Weapon_Retractor);
			this.category = new ByTable(new object [] { "initial", "Medical" });
		}

	}

}