// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_Protolathe : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Machine Design (Protolathe Board)";
			this.desc = "The circuit board for a protolathe.";
			this.id = "protolathe";
			this.req_tech = new ByTable().Set( "programming", 2 ).Set( "engineering", 2 );
			this.build_type = 1;
			this.materials = new ByTable().Set( "$glass", 1000 ).Set( "sacid", 20 );
			this.build_path = typeof(Obj_Item_Weapon_Circuitboard_Protolathe);
			this.category = new ByTable(new object [] { "Research Machinery" });
		}

	}

}