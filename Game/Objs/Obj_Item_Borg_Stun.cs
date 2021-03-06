// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Borg_Stun : Obj_Item_Borg {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_state = "elecarm";
		}

		public Obj_Item_Borg_Stun ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: robot_items.dm
		public override bool attack( dynamic M = null, dynamic user = null, bool? def_zone = null ) {
			
			if ( !Lang13.Bool( user.cell.use( 30 ) ) ) {
				return false;
			}
			((Mob)M).Weaken( 5 );
			((Mob_Living)M).apply_effect( "stutter", 5 );
			((Mob)M).Stun( 5 );
			((Ent_Static)M).visible_message( "<span class='danger'>" + user + " has prodded " + M + " with " + this + "!</span>", "<span class='userdanger'>" + user + " has prodded you with " + this + "!</span>" );
			GlobalFuncs.add_logs( user, M, "stunned", this, "(INTENT: " + String13.ToUpper( user.a_intent ) + ")" );
			return false;
		}

	}

}