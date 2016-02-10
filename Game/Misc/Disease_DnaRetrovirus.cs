// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Disease_DnaRetrovirus : Disease {

		public dynamic SE = null;
		public dynamic UI = null;
		public bool restcure = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Retrovirus";
			this.max_stages = 4;
			this.spread = "Contact";
			this.spread_type = 4;
			this.cure = "Rest or an injection of ryetalyn";
			this.cure_chance = 6;
			this.agent = "";
			this.affected_species = new ByTable(new object [] { "Human" });
			this.desc = "A DNA-altering retrovirus that scrambles the structural and unique enzymes of a host constantly.";
			this.severity = "Severe";
			this.permeability_mod = 0.4;
			this.stage_prob = 2;
		}

		// Function from file: retrovirus.dm
		public Disease_DnaRetrovirus ( bool? process = null, Disease_Advance D = null ) : base( process, D ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.agent = "Virus class " + Rand13.Pick(new object [] { "A", "B", "C", "D", "E", "F" }) + Rand13.Pick(new object [] { "A", "B", "C", "D", "E", "F" }) + "-" + Rand13.Int( 50, 300 );

			if ( Rand13.PercentChance( 40 ) ) {
				this.cure_id = new ByTable(new object [] { "ryetalyn" });
				this.cure_list = new ByTable(new object [] { "ryetalyn" });
			} else {
				this.restcure = true;
			}
			return;
		}

		// Function from file: retrovirus.dm
		public override bool stage_act(  ) {
			base.stage_act();

			switch ((int?)( this.stage )) {
				case 1:
					
					if ( this.restcure ) {
						
						if ( this.affected_mob.lying == true && Rand13.PercentChance( 30 ) ) {
							GlobalFuncs.to_chat( this.affected_mob, "<span class='notice'>You feel better.</span>" );
							this.f_cure();
							return false;
						}
					}

					if ( Rand13.PercentChance( 8 ) ) {
						GlobalFuncs.to_chat( this.affected_mob, "<span class='warning'>Your head hurts.</span>" );
					}

					if ( Rand13.PercentChance( 9 ) ) {
						GlobalFuncs.to_chat( this.affected_mob, "You feel a tingling sensation in your chest." );
					}

					if ( Rand13.PercentChance( 9 ) ) {
						GlobalFuncs.to_chat( this.affected_mob, "<span class='warning'>You feel angry.</span>" );
					}
					break;
				case 2:
					
					if ( this.restcure ) {
						
						if ( this.affected_mob.lying == true && Rand13.PercentChance( 20 ) ) {
							GlobalFuncs.to_chat( this.affected_mob, "<span class='notice'>You feel better.</span>" );
							this.f_cure();
							return false;
						}
					}

					if ( Rand13.PercentChance( 8 ) ) {
						GlobalFuncs.to_chat( this.affected_mob, "<span class='warning'>Your skin feels loose.</span>" );
					}

					if ( Rand13.PercentChance( 10 ) ) {
						GlobalFuncs.to_chat( this.affected_mob, "You feel very strange." );
					}

					if ( Rand13.PercentChance( 4 ) ) {
						GlobalFuncs.to_chat( this.affected_mob, "<span class='warning'>You feel a stabbing pain in your head!</span>" );
						((Mob)this.affected_mob).Paralyse( 2 );
					}

					if ( Rand13.PercentChance( 4 ) ) {
						GlobalFuncs.to_chat( this.affected_mob, "<span class='warning'>Your stomach churns.</span>" );
					}
					break;
				case 3:
					
					if ( this.restcure ) {
						
						if ( this.affected_mob.lying == true && Rand13.PercentChance( 20 ) ) {
							GlobalFuncs.to_chat( this.affected_mob, "<span class='notice'>You feel better.</span>" );
							this.f_cure();
							return false;
						}
					}

					if ( Rand13.PercentChance( 10 ) ) {
						GlobalFuncs.to_chat( this.affected_mob, "<span class='warning'>Your entire body vibrates.</span>" );
					}

					if ( Rand13.PercentChance( 35 ) ) {
						
						if ( Rand13.PercentChance( 50 ) ) {
							GlobalFuncs.scramble( true, this.affected_mob, Rand13.Int( 15, 45 ) );
						} else {
							GlobalFuncs.scramble( false, this.affected_mob, Rand13.Int( 15, 45 ) );
						}
					}
					break;
				case 4:
					
					if ( this.restcure ) {
						
						if ( this.affected_mob.lying == true && Rand13.PercentChance( 5 ) ) {
							GlobalFuncs.to_chat( this.affected_mob, "<span class='notice'>You feel better.</span>" );
							this.f_cure();
							return false;
						}
					}

					if ( Rand13.PercentChance( 60 ) ) {
						
						if ( Rand13.PercentChance( 50 ) ) {
							GlobalFuncs.scramble( true, this.affected_mob, Rand13.Int( 50, 75 ) );
						} else {
							GlobalFuncs.scramble( false, this.affected_mob, Rand13.Int( 50, 75 ) );
						}
					}
					break;
			}
			return false;
		}

	}

}