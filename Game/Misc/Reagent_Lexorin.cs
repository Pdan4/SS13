// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_Lexorin : Reagent {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Lexorin";
			this.id = "lexorin";
			this.description = "Lexorin temporarily stops respiration. Causes tissue damage.";
			this.reagent_state = 2;
			this.color = "#C8A5DC";
		}

		// Function from file: Chemistry-Reagents.dm
		public override bool on_mob_life( Mob_Living M = null, int? alien = null ) {
			
			if ( base.on_mob_life( M, alien ) ) {
				return true;
			}

			if ( Rand13.PercentChance( 33 ) ) {
				M.take_organ_damage( 0.5, 0 );
			}
			M.adjustOxyLoss( 3 );

			if ( Rand13.PercentChance( 20 ) ) {
				M.emote( "gasp" );
			}
			return false;
		}

	}

}