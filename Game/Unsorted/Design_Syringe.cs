// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_Syringe : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Syringe";
			this.id = "syringe";
			this.build_type = 4;
			this.materials = new ByTable().Set( "$metal", 10 ).Set( "$glass", 20 );
			this.build_path = typeof(Obj_Item_Weapon_ReagentContainers_Syringe);
			this.category = new ByTable(new object [] { "initial", "Medical" });
		}

	}

}