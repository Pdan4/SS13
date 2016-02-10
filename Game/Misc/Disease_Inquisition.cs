// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Disease_Inquisition : Disease {

		public Disease_Inquisition ( bool? process = null, Disease_Advance D = null ) : base( process, D ) {
			
		}

		// Function from file: fluspanish.dm
		public override bool stage_act(  ) {
			base.stage_act();

			switch ((int?)( this.stage )) {
				case 2:
					this.affected_mob.bodytemperature++;

					if ( Rand13.PercentChance( 5 ) ) {
						((Mob)this.affected_mob).emote( "sneeze" );
					}

					if ( Rand13.PercentChance( 5 ) ) {
						((Mob)this.affected_mob).emote( "cough" );
					}

					if ( Rand13.PercentChance( 1 ) ) {
						GlobalFuncs.to_chat( this.affected_mob, "<span class='warning'>You're burning in your own skin!</span>" );
						((Mob_Living)this.affected_mob).take_organ_damage( 0, 5 );
					}
					break;
				case 3:
					this.affected_mob.bodytemperature += 2;

					if ( Rand13.PercentChance( 5 ) ) {
						((Mob)this.affected_mob).emote( "sneeze" );
					}

					if ( Rand13.PercentChance( 5 ) ) {
						((Mob)this.affected_mob).emote( "cough" );
					}

					if ( Rand13.PercentChance( 5 ) ) {
						GlobalFuncs.to_chat( this.affected_mob, "<span class='warning'>You're burning in your own skin!</span>" );
						((Mob_Living)this.affected_mob).take_organ_damage( 0, 5 );
					}
					break;
			}
			return false;
		}

	}

}