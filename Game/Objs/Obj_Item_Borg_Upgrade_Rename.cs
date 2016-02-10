// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Borg_Upgrade_Rename : Obj_Item_Borg_Upgrade {

		public dynamic heldname = "default name";

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_state = "cyborg_upgrade1";
		}

		public Obj_Item_Borg_Upgrade_Rename ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: robot_upgrades.dm
		public override bool action( Mob_Living_Silicon_Robot R = null ) {
			
			if ( base.action( R ) ) {
				return false;
			}
			R.name = "";
			R.custom_name = null;
			R.real_name = "";
			R.updatename();
			R.updateicon();
			GlobalFuncs.to_chat( R, "<span class='warning'>You may now change your name.</span>" );
			return true;
		}

		// Function from file: robot_upgrades.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			this.heldname = GlobalFuncs.stripped_input( user, "Enter new robot name", "Robot Reclassification", this.heldname, 26 );
			return null;
		}

	}

}