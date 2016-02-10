// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_BorgRestartBoard : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "cyborg restart module";
			this.desc = "Used to restart cyborgs.";
			this.id = "borg_restart_board";
			this.req_tech = new ByTable().Set( "engineering", 1 );
			this.build_type = 16;
			this.build_path = typeof(Obj_Item_Borg_Upgrade_Restart);
			this.category = "Robotic_Upgrade_Modules";
			this.materials = new ByTable().Set( "$iron", 60000 ).Set( "$glass", 5000 );
		}

	}

}