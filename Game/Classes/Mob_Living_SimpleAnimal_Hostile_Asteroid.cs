// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mob_Living_SimpleAnimal_Hostile_Asteroid : Mob_Living_SimpleAnimal_Hostile {

		public string throw_message = "bounces off of";
		public string icon_aggro = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.vision_range = 2;
			this.atmos_requirements = new ByTable().Set( "min_oxy", 0 ).Set( "max_oxy", 0 ).Set( "min_tox", 0 ).Set( "max_tox", 0 ).Set( "min_co2", 0 ).Set( "max_co2", 0 ).Set( "min_n2", 0 ).Set( "max_n2", 0 );
			this.unsuitable_atmos_damage = 15;
			this.faction = new ByTable(new object [] { "mining" });
			this.environment_smash = 2;
			this.minbodytemp = 0;
			this.maxbodytemp = Double.PositiveInfinity;
			this.response_harm = "strikes";
			this.status_flags = 0;
			this.a_intent = "harm";
			this.see_in_dark = 8;
			this.see_invisible = 5;
		}

		public Mob_Living_SimpleAnimal_Hostile_Asteroid ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: mining_mobs.dm
		public override void handle_temperature_damage(  ) {
			
			if ( Convert.ToDouble( this.bodytemperature ) < this.minbodytemp ) {
				this.adjustBruteLoss( 2 );
			} else if ( Convert.ToDouble( this.bodytemperature ) > this.maxbodytemp ) {
				this.adjustBruteLoss( 20 );
			}
			return;
		}

		// Function from file: mining_mobs.dm
		public override bool death( bool? gibbed = null, bool? toast = null ) {
			GlobalFuncs.feedback_add_details( "mobs_killed_mining", "" + this.type );
			base.death( gibbed, toast );
			return false;
		}

		// Function from file: mining_mobs.dm
		public override bool hitby( Ent_Dynamic AM = null, bool? skipcatch = null, bool? hitpush = null, bool? blocked = null ) {
			Ent_Dynamic T = null;

			
			if ( AM is Obj_Item ) {
				T = AM;

				if ( !( this.stat != 0 ) ) {
					this.Aggro();
				}

				if ( Convert.ToDouble( ((dynamic)T).throwforce ) <= 20 ) {
					this.visible_message( "<span class='notice'>The " + T.name + " " + this.throw_message + " " + this.name + "!</span>" );
					return false;
				}
			}
			base.hitby( AM, skipcatch, hitpush, blocked );
			return false;
		}

		// Function from file: mining_mobs.dm
		public override dynamic bullet_act( dynamic P = null, dynamic def_zone = null ) {
			
			if ( !( this.stat != 0 ) ) {
				this.Aggro();
			}

			if ( Convert.ToDouble( P.damage ) < 30 && P.damage_type != "brute" ) {
				P.damage = P.damage / 3;
				this.visible_message( "<span class='danger'>" + P + " has a reduced effect on " + this + "!</span>" );
			}
			base.bullet_act( (object)(P), (object)(def_zone) );
			return null;
		}

		// Function from file: mining_mobs.dm
		public override void LoseAggro(  ) {
			base.LoseAggro();
			this.icon_state = this.icon_living;
			return;
		}

		// Function from file: mining_mobs.dm
		public override void Aggro(  ) {
			base.Aggro();

			if ( this.vision_range != this.aggro_vision_range ) {
				this.icon_state = this.icon_aggro;
			}
			return;
		}

	}

}