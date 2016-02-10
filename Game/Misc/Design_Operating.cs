// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_Operating : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Circuit Design (Operating Computer)";
			this.desc = "Allows for the construction of circuit boards used to build an operating computer console.";
			this.id = "operating";
			this.req_tech = new ByTable().Set( "programming", 2 ).Set( "biotech", 2 );
			this.build_type = 1;
			this.materials = new ByTable().Set( "$glass", 2000 ).Set( "sacid", 20 );
			this.category = "Console Boards";
			this.build_path = typeof(Obj_Item_Weapon_Circuitboard_Operating);
		}

	}

}