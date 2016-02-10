// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_Snackbarmachine : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Circuit Design (SnackBar Machine)";
			this.desc = "Allows for the cosntruction of circuit boards used to build SnackBar Machines";
			this.id = "snackbarmachine";
			this.req_tech = new ByTable().Set( "engineering", 3 ).Set( "biotech", 4 );
			this.build_type = 1;
			this.materials = new ByTable().Set( "$glass", 2000 ).Set( "sacid", 20 );
			this.category = "Machine Boards";
			this.build_path = typeof(Obj_Item_Weapon_Circuitboard_SnackbarMachine);
		}

	}

}