// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_ShadowlingBlindnessSmoke : Reagent {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "odd black liquid";
			this.id = "blindness_smoke";
			this.description = "<::ERROR::> CANNOT ANALYZE REAGENT <::ERROR::>";
			this.metabolization_rate = 100;
		}

		// Function from file: shadowling_abilities.dm
		public override bool on_mob_life( dynamic M = null ) {
			
			if ( !Lang13.Bool( M ) ) {
				M = ((dynamic)this.holder).my_atom;
			}

			if ( !GlobalFuncs.is_shadow_or_thrall( M ) ) {
				M.WriteMsg( "<span class='warning'><b>You breathe in the black smoke, and your eyes burn horribly!</b></span>" );
				((Mob)M).blind_eyes( 5 );

				if ( Rand13.PercentChance( 25 ) ) {
					((Ent_Static)M).visible_message( "<b>" + M + "</b> claws at their eyes!" );
					((Mob)M).Stun( 3 );
				}
			} else {
				M.WriteMsg( "<span class='notice'><b>You breathe in the black smoke, and you feel revitalized!</b></span>" );
				((Mob_Living)M).heal_organ_damage( 2, 2 );
				((Mob_Living)M).adjustOxyLoss( -2 );
				((Mob_Living)M).adjustToxLoss( -2 );
			}
			base.on_mob_life( (object)(M) );
			return false;
		}

	}

}