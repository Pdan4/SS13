// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_Drink_Carrotjuice : Reagent_Drink {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Carrot juice";
			this.id = "carrotjuice";
			this.description = "It is just like a carrot but without crunching.";
			this.color = "#973800";
			this.nutriment_factor = 1;
			this.data = 1;
		}

		// Function from file: Chemistry-Reagents.dm
		public override bool on_mob_life( Mob_Living M = null, int? alien = null ) {
			
			if ( base.on_mob_life( M, alien ) ) {
				return true;
			}
			M.eye_blurry = Num13.MaxInt( Convert.ToInt32( M.eye_blurry - 1 ), 0 );
			M.eye_blind = Num13.MaxInt( M.eye_blind - 1, 0 );

			dynamic _a = this.data; // Was a switch-case, sorry for the mess.
			if ( 21<=_a&&_a<=Double.PositiveInfinity ) {
				
				if ( Rand13.PercentChance( Convert.ToInt32( this.data - 10 ) ) ) {
					M.disabilities &= 65534;
				}
			}
			this.data++;
			return false;
		}

	}

}