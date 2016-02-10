// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Disease2_Effect_Mind : Disease2_Effect {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Lazy Mind Syndrome";
			this.stage = 3;
		}

		// Function from file: effect.dm
		public override bool activate( Mob_Living mob = null, bool multiplier = false ) {
			Mob_Living H = null;
			dynamic B = null;

			
			if ( mob is Mob_Living_Carbon_Human ) {
				H = mob;
				B = ((dynamic)H).internal_organs_by_name["brain"];

				if ( Lang13.Bool( B ) && Convert.ToDouble( B.damage ) < Convert.ToDouble( B.min_broken_damage ) ) {
					B.take_damage( 5 );
				}
			} else {
				mob.setBrainLoss( 50 );
			}
			return false;
		}

	}

}