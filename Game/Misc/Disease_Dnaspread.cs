// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Disease_Dnaspread : Disease {

		public ByTable original_dna = new ByTable();
		public bool transformed = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Space Retrovirus";
			this.max_stages = 4;
			this.spread = "On contact";
			this.spread_type = 4;
			this.cure = "Ryetalyn";
			this.cure_id = "ryetalyn";
			this.curable = true;
			this.agent = "S4E1 retrovirus";
			this.affected_species = new ByTable(new object [] { "Human" });
			this.desc = "This disease transplants the genetic code of the intial vector into new hosts.";
			this.severity = "Medium";
		}

		public Disease_Dnaspread ( bool? process = null, Disease_Advance D = null ) : base( process, D ) {
			
		}

		// Function from file: dna_spread.dm
		public override void Del(  ) {
			dynamic newUI = null;
			dynamic newSE = null;

			
			if ( Lang13.Bool( this.original_dna["name"] ) && Lang13.Bool( this.original_dna["UI"] ) && Lang13.Bool( this.original_dna["SE"] ) ) {
				newUI = this.original_dna["UI"];
				newSE = this.original_dna["SE"];
				((Mob)this.affected_mob).UpdateAppearance( newUI.Copy() );
				this.affected_mob.dna.SE = newSE.Copy();
				((Dna)this.affected_mob.dna).UpdateSE();
				this.affected_mob.real_name = this.original_dna["name"];
				GlobalFuncs.to_chat( this.affected_mob, "<span class='notice'>You feel more like yourself.</span>" );
			}
			base.Del();
			return;
		}

		// Function from file: dna_spread.dm
		public override bool stage_act(  ) {
			dynamic newUI = null;
			dynamic newSE = null;

			base.stage_act();

			switch ((int?)( this.stage )) {
				case 2:
					
					if ( Rand13.PercentChance( 8 ) ) {
						((Mob)this.affected_mob).emote( "sneeze" );
					}

					if ( Rand13.PercentChance( 8 ) ) {
						((Mob)this.affected_mob).emote( "cough" );
					}

					if ( Rand13.PercentChance( 1 ) ) {
						GlobalFuncs.to_chat( this.affected_mob, "<span class='warning'>Your muscles ache.</span>" );

						if ( Rand13.PercentChance( 20 ) ) {
							((Mob_Living)this.affected_mob).take_organ_damage( 1 );
						}
					}

					if ( Rand13.PercentChance( 1 ) ) {
						GlobalFuncs.to_chat( this.affected_mob, "<span class='warning'>Your stomach hurts.</span>" );

						if ( Rand13.PercentChance( 20 ) ) {
							((Mob_Living)this.affected_mob).adjustToxLoss( 2 );
							((Mob_Living)this.affected_mob).updatehealth();
						}
					}
					break;
				case 4:
					
					if ( !this.transformed ) {
						
						if ( !Lang13.Bool( this.strain_data["name"] ) || !Lang13.Bool( this.strain_data["UI"] ) || !Lang13.Bool( this.strain_data["SE"] ) ) {
							Lang13.Delete( this.affected_mob.virus );
							this.affected_mob.virus = null;
							return false;
						}
						this.original_dna["name"] = this.affected_mob.real_name;
						this.original_dna["UI"] = this.affected_mob.dna.UI.Copy();
						this.original_dna["SE"] = this.affected_mob.dna.SE.Copy();
						GlobalFuncs.to_chat( this.affected_mob, "<span class='warning'>You don't feel like yourself..</span>" );
						newUI = this.strain_data["UI"];
						newSE = this.strain_data["SE"];
						((Mob)this.affected_mob).UpdateAppearance( newUI.Copy() );
						this.affected_mob.dna.SE = newSE.Copy();
						((Dna)this.affected_mob.dna).UpdateSE();
						this.affected_mob.real_name = this.strain_data["name"];
						GlobalFuncs.domutcheck( this.affected_mob );
						this.transformed = true;
						this.carrier = true;
					}
					break;
			}
			return false;
		}

	}

}