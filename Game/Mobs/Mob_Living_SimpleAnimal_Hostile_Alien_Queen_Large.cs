// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mob_Living_SimpleAnimal_Hostile_Alien_Queen_Large : Mob_Living_SimpleAnimal_Hostile_Alien_Queen {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.pixel_x = -16;
			this.icon_living = "queen_s";
			this.icon_dead = "queen_dead";
			this.move_to_delay = 4;
			this.maxHealth = 400;
			this.health = 400;
			this.icon = "icons/mob/alienqueen.dmi";
			this.icon_state = "queen_s";
		}

		public Mob_Living_SimpleAnimal_Hostile_Alien_Queen_Large ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}