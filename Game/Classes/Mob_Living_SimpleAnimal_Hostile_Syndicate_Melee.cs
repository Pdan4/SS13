// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mob_Living_SimpleAnimal_Hostile_Syndicate_Melee : Mob_Living_SimpleAnimal_Hostile_Syndicate {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.melee_damage_lower = 25;
			this.melee_damage_upper = 30;
			this.icon_living = "syndicatemelee";
			this.loot = new ByTable(new object [] { typeof(Obj_Effect_Landmark_Mobcorpse_Syndicatesoldier), typeof(Obj_Item_Weapon_Melee_Energy_Sword_Saber_Red), typeof(Obj_Item_Weapon_Shield_Energy) });
			this.attacktext = "slashes";
			this.attack_sound = "sound/weapons/bladeslice.ogg";
			this.armour_penetration = 28;
			this.status_flags = 0;
			this.maxHealth = 170;
			this.health = 170;
			this.icon_state = "syndicatemelee";
		}

		public Mob_Living_SimpleAnimal_Hostile_Syndicate_Melee ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: syndicate.dm
		public override dynamic bullet_act( dynamic P = null, dynamic def_zone = null ) {
			
			if ( !Lang13.Bool( P ) ) {
				return null;
			}

			if ( Rand13.PercentChance( 50 ) ) {
				
				if ( P.damage_type == "brute" || P.damage_type == "fire" ) {
					this.health -= P.damage;
				}
			} else {
				this.visible_message( "<span class='danger'>" + this + " blocks " + P + " with its shield!</span>" );
			}
			return 0;
		}

	}

}