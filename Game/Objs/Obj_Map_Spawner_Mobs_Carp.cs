// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Map_Spawner_Mobs_Carp : Obj_Map_Spawner_Mobs {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.chance = 50;
			this.toSpawn = new ByTable(new object [] { typeof(Mob_Living_SimpleAnimal_Hostile_Carp) });
			this.icon_state = "mob_carp";
		}

		public Obj_Map_Spawner_Mobs_Carp ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}