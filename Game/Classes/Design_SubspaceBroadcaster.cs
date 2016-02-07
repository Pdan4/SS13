// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_SubspaceBroadcaster : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Machine Design (Subspace Broadcaster)";
			this.desc = "Allows for the construction of Subspace Broadcasting equipment.";
			this.id = "s-broadcaster";
			this.req_tech = new ByTable().Set( "programming", 2 ).Set( "engineering", 2 ).Set( "bluespace", 1 );
			this.build_type = 1;
			this.materials = new ByTable().Set( "$glass", 1000 ).Set( "sacid", 20 );
			this.build_path = typeof(Obj_Item_Weapon_Circuitboard_Telecomms_Broadcaster);
			this.category = new ByTable(new object [] { "Subspace Telecomms" });
		}

	}

}