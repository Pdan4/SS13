// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_Amatoxin : Reagent {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Amatoxin";
			this.id = "amatoxin";
			this.description = "A powerful poison derived from certain species of mushroom.";
			this.color = "#792300";
		}

		// Function from file: Chemistry-Reagents.dm
		public override bool on_mob_life( Mob_Living M = null, int? alien = null ) {
			
			if ( base.on_mob_life( M, alien ) ) {
				return true;
			}
			M.adjustToxLoss( 1.5 );
			return false;
		}

	}

}