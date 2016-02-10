// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Projectile_Beam_Mindflayer : Obj_Item_Projectile_Beam {

		public Obj_Item_Projectile_Beam_Mindflayer ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: special.dm
		public override bool on_hit( dynamic atarget = null, int? blocked = null ) {
			blocked = blocked ?? 0;

			dynamic M = null;

			
			if ( atarget is Mob_Living_Carbon_Human ) {
				M = atarget;
				((Mob_Living)M).adjustBrainLoss( 20 );
				M.hallucination += 20;
			}
			return false;
		}

	}

}