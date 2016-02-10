// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_Smartfridge : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Circuit Design (SmartFridge)";
			this.desc = "Allows for the construction of circuit boards used to build a smartfridge.";
			this.id = "smartfridge";
			this.req_tech = new ByTable().Set( "programming", 3 ).Set( "engineering", 2 );
			this.build_type = 1;
			this.materials = new ByTable().Set( "$glass", 2000 ).Set( "sacid", 20 );
			this.category = "Machine Boards";
			this.build_path = typeof(Obj_Item_Weapon_Circuitboard_Smartfridge);
		}

	}

}