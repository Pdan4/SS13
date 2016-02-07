// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_AirManagement : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Computer Design (Atmospheric Monitor)";
			this.desc = "Allows for the construction of circuit boards used to build an Atmospheric Monitor.";
			this.id = "air_management";
			this.req_tech = new ByTable().Set( "programming", 2 );
			this.build_type = 1;
			this.materials = new ByTable().Set( "$glass", 1000 ).Set( "sacid", 20 );
			this.build_path = typeof(Obj_Item_Weapon_Circuitboard_AirManagement);
			this.category = new ByTable(new object [] { "Computer Boards" });
		}

	}

}