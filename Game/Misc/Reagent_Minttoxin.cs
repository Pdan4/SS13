// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_Minttoxin : Reagent {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Mint Toxin";
			this.id = "minttoxin";
			this.description = "Useful for dealing with undesirable customers.";
			this.reagent_state = 2;
			this.color = "#CF3600";
		}

		// Function from file: Chemistry-Reagents.dm
		public override bool on_mob_life( Mob_Living M = null, int? alien = null ) {
			
			if ( base.on_mob_life( M, alien ) ) {
				return true;
			}
			Interface13.Stat( null, M.mutations.Contains( 6 ) );

			if ( base.on_mob_life( M, alien ) ) {
				M.gib();
			}
			return false;
		}

	}

}