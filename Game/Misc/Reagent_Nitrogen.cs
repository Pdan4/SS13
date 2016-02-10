// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_Nitrogen : Reagent {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Nitrogen";
			this.id = "nitrogen";
			this.description = "A colorless, odorless, tasteless gas.";
			this.reagent_state = 3;
			this.color = "#808080";
			this.custom_metabolism = 0.01;
		}

		// Function from file: Chemistry-Reagents.dm
		public override bool on_mob_life( Mob_Living M = null, int? alien = null ) {
			
			if ( base.on_mob_life( M, alien ) ) {
				return true;
			}

			if ( Lang13.Bool( alien ) && alien == 2 ) {
				M.adjustOxyLoss( -1 );
				M.adjustToxLoss( -1 );
			}
			return false;
		}

	}

}