// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class RoundEvent_Rabbitrelease : RoundEvent {

		// Function from file: easter.dm
		public override bool start(  ) {
			Obj_Effect_Landmark R = null;

			
			foreach (dynamic _a in Lang13.Enumerate( GlobalVars.landmarks_list, typeof(Obj_Effect_Landmark) )) {
				R = _a;
				

				if ( R.name != "blobspawn" ) {
					
					if ( Rand13.PercentChance( 35 ) ) {
						
						if ( R.loc is Tile_Space ) {
							new Mob_Living_SimpleAnimal_Chicken_Rabbit_Space( R.loc );
						} else {
							new Mob_Living_SimpleAnimal_Chicken_Rabbit( R.loc );
						}
					}
				}
			}
			return false;
		}

		// Function from file: easter.dm
		public override void announce(  ) {
			GlobalFuncs.priority_announce( "Unidentified furry objects detected coming aboard " + GlobalFuncs.station_name() + ". Beware of Adorable-ness.", "Fluffy Alert", "sound/AI/aliens.ogg" );
			return;
		}

	}

}