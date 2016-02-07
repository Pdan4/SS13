// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mob_Living_SimpleAnimal_Hostile_Alien_Drone : Mob_Living_SimpleAnimal_Hostile_Alien {

		public dynamic plant_cooldown = 30;
		public bool plants_off = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_living = "aliend_s";
			this.icon_dead = "aliend_dead";
			this.health = 60;
			this.melee_damage_lower = 15;
			this.melee_damage_upper = 15;
			this.icon_state = "aliend_s";
		}

		public Mob_Living_SimpleAnimal_Hostile_Alien_Drone ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: alien.dm
		public override bool handle_automated_action(  ) {
			
			if ( !base.handle_automated_action() ) {
				return false;
			}
			this.plant_cooldown--;

			if ( this.AIStatus == 2 ) {
				
				if ( !this.plants_off && Rand13.PercentChance( 10 ) && Convert.ToDouble( this.plant_cooldown ) <= 0 ) {
					this.plant_cooldown = Lang13.Initial( this, "plant_cooldown" );
					this.SpreadPlants();
				}
			}
			return false;
		}

	}

}