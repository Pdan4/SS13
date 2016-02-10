// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Borg_Upgrade_Syndicate : Obj_Item_Borg_Upgrade {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.require_module = true;
			this.icon_state = "cyborg_upgrade3";
		}

		public Obj_Item_Borg_Upgrade_Syndicate ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: robot_upgrades.dm
		public override bool action( Mob_Living_Silicon_Robot R = null ) {
			
			if ( base.action( R ) ) {
				return false;
			}

			if ( R is Mob_Living_Silicon_Robot_Mommi ) {
				GlobalFuncs.to_chat( R, "<span class='warning'>Your self-protection systems prevent that.</span>" );
				GlobalFuncs.message_admins( new Txt().item( GlobalFuncs.key_name_admin( Task13.User ) ).str( " (" ).item( Task13.User.type ).str( ") tried to use " ).a( this.name ).item().str( " on " ).item( R ).str( " (a " ).item( R.type ).str( ")." ).ToString() );
				return false;
			}

			if ( R.emagged == 1 ) {
				return false;
			}
			GlobalFuncs.message_admins( new Txt().item( GlobalFuncs.key_name_admin( Task13.User ) ).str( " (" ).item( Task13.User.type ).str( ") used " ).a( this.name ).item().str( " on " ).item( R ).str( " (a " ).item( R.type ).str( ")." ).ToString() );
			R.SetEmagged( 2 );
			return true;
		}

	}

}