// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_Rdservercontrol : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Computer Design (R&D Server Control Console Board)";
			this.desc = "The circuit board for an R&D Server Control Console.";
			this.id = "rdservercontrol";
			this.req_tech = new ByTable().Set( "programming", 3 );
			this.build_type = 1;
			this.materials = new ByTable().Set( "$glass", 1000 ).Set( "sacid", 20 );
			this.build_path = typeof(Obj_Item_Weapon_Circuitboard_Rdservercontrol);
			this.category = new ByTable(new object [] { "Research Machinery" });
		}

	}

}