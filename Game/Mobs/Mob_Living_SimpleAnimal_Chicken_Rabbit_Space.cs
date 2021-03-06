// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mob_Living_SimpleAnimal_Chicken_Rabbit_Space : Mob_Living_SimpleAnimal_Chicken_Rabbit {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_prefix = "s_rabbit";
			this.icon_living = "s_rabbit";
			this.icon_dead = "s_rabbit_dead";
			this.atmos_requirements = new ByTable().Set( "min_oxy", 0 ).Set( "max_oxy", 0 ).Set( "min_tox", 0 ).Set( "max_tox", 0 ).Set( "min_co2", 0 ).Set( "max_co2", 0 ).Set( "min_n2", 0 ).Set( "max_n2", 0 );
			this.minbodytemp = 0;
			this.maxbodytemp = 1500;
			this.unsuitable_atmos_damage = 0;
			this.icon_state = "s_rabbit";
		}

		public Mob_Living_SimpleAnimal_Chicken_Rabbit_Space ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}