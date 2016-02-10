// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_Ethanol_Beer : Reagent_Ethanol {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Beer";
			this.id = "beer";
			this.description = "An alcoholic beverage made from malted grains, hops, yeast, and water.";
			this.nutriment_factor = 0.8;
			this.color = "#664300";
		}

		// Function from file: Chemistry-Reagents.dm
		public override bool on_mob_life( Mob_Living M = null, int? alien = null ) {
			
			if ( base.on_mob_life( M, alien ) ) {
				return true;
			}
			M.jitteriness = Num13.MaxInt( M.jitteriness - 3, 0 );
			return false;
		}

	}

}