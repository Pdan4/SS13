// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Disease_Gbs : Disease {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "GBS";
			this.max_stages = 5;
			this.spread = "On contact";
			this.spread_type = 4;
			this.cure = "Synaptizine & Sulfur";
			this.cure_id = new ByTable(new object [] { "synaptizine", "sulfur" });
			this.cure_chance = 15;
			this.agent = "Gravitokinetic Bipotential SADS+";
			this.affected_species = new ByTable(new object [] { "Human" });
		}

		public Disease_Gbs ( bool? process = null, Disease_Advance D = null ) : base( process, D ) {
			
		}

		// Function from file: vgstation13.dme
		public override bool stage_act(  ) {
			base.stage_act();

			switch ((int?)( this.stage )) {
				case 2:
					
					if ( Rand13.PercentChance( 45 ) ) {
						((Mob_Living)this.affected_mob).adjustToxLoss( 5 );
						((Mob_Living)this.affected_mob).updatehealth();
					}

					if ( Rand13.PercentChance( 1 ) ) {
						((Mob)this.affected_mob).emote( "sneeze" );
					}
					break;
				case 3:
					
					if ( Rand13.PercentChance( 5 ) ) {
						((Mob)this.affected_mob).emote( "cough" );
					} else if ( Rand13.PercentChance( 5 ) ) {
						((Mob)this.affected_mob).emote( "gasp" );
					}

					if ( Rand13.PercentChance( 10 ) ) {
						GlobalFuncs.to_chat( this.affected_mob, "<span class='warning'>You're starting to feel very weak...</span>" );
					}
					break;
				case 4:
					
					if ( Rand13.PercentChance( 10 ) ) {
						((Mob)this.affected_mob).emote( "cough" );
					}
					((Mob_Living)this.affected_mob).adjustToxLoss( 5 );
					((Mob_Living)this.affected_mob).updatehealth();
					break;
				case 5:
					GlobalFuncs.to_chat( this.affected_mob, "<span class='warning'>Your body feels as if it's trying to rip itself open...</span>" );

					if ( Rand13.PercentChance( 50 ) ) {
						((Mob)this.affected_mob).gib();
					}
					break;
				default:
					return false;
					break;
			}
			return false;
		}

	}

}