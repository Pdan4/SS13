// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_TelecommsProcessor : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Machine Design (Processor Unit)";
			this.desc = "Allows for the construction of Telecommunications Processor equipment.";
			this.id = "s-processor";
			this.req_tech = new ByTable().Set( "programming", 2 ).Set( "engineering", 2 );
			this.build_type = 1;
			this.materials = new ByTable().Set( "$glass", 1000 ).Set( "sacid", 20 );
			this.build_path = typeof(Obj_Item_Weapon_Circuitboard_Telecomms_Processor);
			this.category = new ByTable(new object [] { "Subspace Telecomms" });
		}

	}

}