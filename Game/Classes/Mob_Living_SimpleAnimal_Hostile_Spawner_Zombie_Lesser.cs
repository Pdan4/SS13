// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mob_Living_SimpleAnimal_Hostile_Spawner_Zombie_Lesser : Mob_Living_SimpleAnimal_Hostile_Spawner_Zombie {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.max_mobs = 10;
			this.spawn_time = 150;
			this.health = 200;
			this.maxHealth = 200;
		}

		public Mob_Living_SimpleAnimal_Hostile_Spawner_Zombie_Lesser ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}