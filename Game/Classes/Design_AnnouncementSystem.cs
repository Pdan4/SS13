// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_AnnouncementSystem : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Machine Design (Automated Announcement System Board)";
			this.desc = "The circuit board for an automated announcement system.";
			this.id = "automated_announcement";
			this.req_tech = new ByTable().Set( "programming", 3 ).Set( "bluespace", 2 );
			this.build_type = 1;
			this.materials = new ByTable().Set( "$glass", 1000 ).Set( "sacid", 20 );
			this.build_path = typeof(Obj_Item_Weapon_Circuitboard_AnnouncementSystem);
			this.category = new ByTable(new object [] { "Subspace Telecomms" });
		}

	}

}