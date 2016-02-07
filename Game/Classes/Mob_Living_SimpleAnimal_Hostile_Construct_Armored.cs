// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mob_Living_SimpleAnimal_Hostile_Construct_Armored : Mob_Living_SimpleAnimal_Hostile_Construct {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.real_name = "Juggernaut";
			this.icon_living = "behemoth";
			this.maxHealth = 250;
			this.health = 250;
			this.response_harm = "harmlessly punches";
			this.harm_intent_damage = 0;
			this.melee_damage_lower = 30;
			this.melee_damage_upper = 30;
			this.attacktext = "smashes their armored gauntlet into";
			this.speed = 3;
			this.environment_smash = 2;
			this.attack_sound = "sound/weapons/punch3.ogg";
			this.status_flags = 0;
			this.mob_size = 3;
			this.force_threshold = 11;
			this.construct_spells = new ByTable(new object [] { typeof(Obj_Effect_ProcHolder_Spell_AoeTurf_Conjure_Lesserforcewall) });
			this.playstyle_string = "<b>You are a Juggernaut. Though slow, your shell can withstand extreme punishment, create shield walls, rip apart enemies and walls alike, and even deflect energy weapons.</b>";
			this.icon_state = "behemoth";
		}

		public Mob_Living_SimpleAnimal_Hostile_Construct_Armored ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: constructs.dm
		public override dynamic bullet_act( dynamic P = null, dynamic def_zone = null ) {
			int reflectchance = 0;
			double new_x = 0;
			double new_y = 0;
			dynamic curloc = null;

			
			if ( P is Obj_Item_Projectile_Energy || P is Obj_Item_Projectile_Beam ) {
				reflectchance = 80 - Num13.Floor( Convert.ToDouble( P.damage / 3 ) );

				if ( Rand13.PercentChance( reflectchance ) ) {
					this.apply_damage( P.damage * 0.5, P.damage_type );
					this.visible_message( "<span class='danger'>The " + P.name + " is reflected by " + this + "'s armored shell!</span>", "<span class='userdanger'>The " + P.name + " is reflected by your armored shell!</span>" );

					if ( Lang13.Bool( P.starting ) ) {
						new_x = Convert.ToDouble( P.starting.x + Rand13.Pick(new object [] { 0, 0, -1, 1, -2, 2, -2, 2, -2, 2, -3, 3, -3, 3 }) );
						new_y = Convert.ToDouble( P.starting.y + Rand13.Pick(new object [] { 0, 0, -1, 1, -2, 2, -2, 2, -2, 2, -3, 3, -3, 3 }) );
						curloc = GlobalFuncs.get_turf( this );
						P.original = Map13.GetTile( ((int)( new_x )), ((int)( new_y )), Convert.ToInt32( P.z ) );
						P.starting = curloc;
						P.current = curloc;
						P.firer = this;
						P.yo = new_y - Convert.ToDouble( curloc.y );
						P.xo = new_x - Convert.ToDouble( curloc.x );
					}
					return -1;
				}
			}
			return base.bullet_act( (object)(P), (object)(def_zone) );
		}

	}

}