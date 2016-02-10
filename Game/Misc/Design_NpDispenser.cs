// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_NpDispenser : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Nano Paper Dispenser";
			this.desc = "A machine to create Nano Paper";
			this.id = "np_dispenser";
			this.req_tech = new ByTable().Set( "programming", 2 ).Set( "materials", 2 );
			this.build_type = 2;
			this.materials = new ByTable().Set( "$glass", 500 ).Set( "$iron", 1000 ).Set( "$gold", 500 );
			this.category = "Data";
			this.build_path = typeof(Obj_Item_Weapon_PaperBin_Nano);
		}

	}

}