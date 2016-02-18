// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class SurgeryStep_Chainsaw : SurgeryStep {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.time = 64;
			this.name = "insert chainsaw";
			this.implements = new ByTable().Set( typeof(Obj_Item_Weapon_Twohanded_Required_Chainsaw), 100 );
		}

		// Function from file: limb augmentation.dm
		public override bool success( dynamic user = null, Mob target = null, string target_zone = null, dynamic tool = null, Surgery surgery = null ) {
			Obj_Item_Weapon_MountedChainsaw sawarms = null;

			
			if ( Lang13.Bool( target.l_hand ) && Lang13.Bool( target.r_hand ) ) {
				user.WriteMsg( "<span class='warning'>You can't fit the chainsaw in while " + target + "'s hands are full!</span>" );
				return false;
			} else {
				((Ent_Static)user).visible_message( "" + user + " finishes installing the chainsaw!", "<span class='notice'>You install the chainsaw.</span>" );
				((Mob)user).unEquip( tool );
				GlobalFuncs.qdel( tool );
				sawarms = new Obj_Item_Weapon_MountedChainsaw( target );
				target.put_in_hands( sawarms );
				return true;
			}
		}

		// Function from file: limb augmentation.dm
		public override int preop( dynamic user = null, Mob target = null, string target_zone = null, dynamic tool = null, Surgery surgery = null ) {
			((Ent_Static)user).visible_message( "" + user + " begins to install the chainsaw onto " + target + ".", "<span class='notice'>You begin to install the chainsaw onto " + target + "...</span>" );
			return 0;
		}

	}

}